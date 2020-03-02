# Payments API

Responsible for validating requests, storing card information and forwarding payment requests and accepting payment responses to and from the acquiring bank.

The payment gateway will need to provide merchants with a way to process a payment. To do this, the merchant should be able to submit a request to the payment gateway. A payment request should include appropriate fields such as the card number, expiry month/date, amount, currency, and cvv.

# Work Done
I have done a Payments Web API and a Bank Simulator Web API.

Payments Web API sends an Http Request to Bank Simulator API when CheckPayment is called. It verifies as an example if the funds are enough t cover the payment to be done, and returns the corresponding status.

Payments Web API can be called to check payment history by payment Id, and it returns payment info, with masked card number.
I used Swagger for API testing.
