# Contracts App

## Detailed Working Steps:
1. Added webapi project, added Models folder.
2. Made some changes to app's model.
3. Created Entitiy Framework's code-first SQLite dbContext from Customer model. Added CustomerController
4. Added Addresses to dbContext.
5. Added Data to Customers.db. Added ICustomerRepositry and applied to CustomerController. Added Data Trasferable Objects(DTO) to overcome EF not including Address right. Added AutoMapper to map Models to DTOs and vice versa.
6. Added fix for CustomerRepository's GetCustomerByIdAsync.
7. Moved mappers to repository, updated customers.db to include contracts and packages. Added data to db.


## WebApi Example URI:
* https://localhost:8080/api/customers
* https://localhost:8080/api/customers/17

