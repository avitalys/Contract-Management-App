# Contracts App

## Detailed Working Steps:
1. Added webapi project, added Models folder.
2. Made some changes to app's model.
3. Created Entitiy Framework's code-first SQLite dbContext from Customer model. Added CustomerController
4. Added Addresses to dbContext.
5. Added Data to Customers.db. Added ICustomerRepositry and applied to CustomerController. Added Data Trasfer Objects(DTO) to overcome EF not including Address right. Added AutoMapper to map Models to DTOs and vice versa.
6. Added fix for CustomerRepository's GetCustomerByIdAsync.
7. Moved mappers to repository, updated customers.db to include contracts and packages. Added data to db.
8. Added HTTP PUT method for address update by customer id. 
9. Added LoginController and LoginDTO, which on authentication creates JWT Token and returns it. In Program.cs added a middleware to validate the token. Added Authorize attribute to CustomerController's PUT method.
10. Added an Angualr app's client side, setup steps:
`npm install -g @angular/cli@14`
`ng new client`


## Commands For Running:
* For webapi:
build with - `dotnet build `
build and run HTTPS with - `dotnet run -lp https`

* For Angular client:
build and run: `ng serve`



## WebApi Example URI:
* POST: https://localhost:8080/api/login
* GET: https://localhost:8080/api/customers
* GET: https://localhost:8080/api/customers/17
* PUT: https://localhost:8080/api/customers/17

### JWT Bearer (with Authorization header)
* https://jwt.ms/ to decode JWT