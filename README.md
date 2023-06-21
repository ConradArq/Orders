## What it does

1. On running the app the database is generated if it hasn't been already. It's then filled/updated with orders and order details from an API endpoint.
2. A table is shown displaying all orders in the database along with a link to view their details.
3. When the user clicks on 'Actualizar', another call is made to the API endpoint in order to update the database and the displayed table.
4. A log is generated to register all calls to the API, database insertions, retrieval of orders and order details from the database and exceptions. The log file is saved in the following path: C:/Orders/log.txt.