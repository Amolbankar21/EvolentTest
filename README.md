# EvolentTest

Prerequisite Software to run application 
•	Visual Studio with .net core 2.2 
•	Sqlite 
•	Postman	

Setp 1 : Get User Token using WebAPI
http://localhost:51519/api/login
Add below JSON request payload in body 
{Username = "GuestUser", EmailAddress = "guestuser@gmail.com"}
 
Set 2 – Get Contact web API response 
Pass above bearer token in request to perform GET, POST, PUT and DELETE operation in Contact Web API
Contact WEB API as below

GET - http://localhost:51519/api/Contact

POST- http://localhost:51519/api/Contact
Payload for adding new contact as below 
{"firstname": "ContactFirstName", "lastname": " ContactLastName ", Email: "test1@gmail.com", PhoneNumber: "9822335755", Status: true}

PUT- http://localhost:51519/api/Contact/3
Payload for Updating contact as below 
{"firstname": "UpdateUser", "lastname": " ContactLastName ", Email: "test1@gmail.com", PhoneNumber: "9822335755", Status: true}

DELETE - http://localhost:51519/api/Contact/3
  


