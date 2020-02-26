# Payment

Responsible for validating requests, storing card information and forwarding payment requests and accepting payment responses to and from the acquiring bank.

The payment gateway will need to provide merchants with a way to process a payment. To do this, the merchant should be able to submit a request to the payment gateway. A payment request should include appropriate fields such as the card number, expiry month/date, amount, currency, and cvv.