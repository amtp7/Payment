using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using Microsoft.OpenApi.Models;

using Payments.Domain.IRepository;
using Payments.Infrastructure.EFModel;
using Payments.Infrastructure.Repository;
using Payments.Domain.Logic.Interfaces;
using Payments.Domain.Logic.Classes;

using AutoMapper;
using Payments.Infrastructure.MapperProfiles;
using System.Net.Http;
using System.Net;
using Payments.Domain.MapperProfiles;
using Payments.Domain.Utils;
using Payments.Domain.DTOs;

namespace Payments.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // SWAGGER
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Payments API", Version = "v1" });
            });

            // AUTOMAPPER
            services.AddAutoMapper(typeof(Startup));
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new InfrastructurePaymentProfile());
                cfg.AddProfile(new DomainPaymentProfile());                
            });
            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);
           
            // DBCONTEXT
            services.AddDbContext<PaymentsContext>(opts => opts.UseSqlServer(Configuration["ConnectionString:PaymentsDB"]));

            // LOGIC
            services.AddTransient<IStatus, Status>();
            services.AddTransient<IPaymentLogic, PaymentLogic>();
            services.AddTransient<IPaymentRepository, PaymentRepository>();
            services.AddTransient<IPaymentHistoryDTO, PaymentHistoryDTO>();

            // HTTP CLIENT
            Uri endPoint = new Uri("https://localhost:44340/api/BankSimulator/CheckPayment");
            HttpClient httpClient = new HttpClient()
            {
                BaseAddress = endPoint,
            };
            ServicePointManager.FindServicePoint(endPoint).ConnectionLeaseTimeout = 60000;
            services.AddSingleton(httpClient);            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Payments API");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
