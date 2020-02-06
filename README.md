POST http://localhost:5000/customers
content-type: application/json

{
    "firstName": "Håkon",
    "lastName": "R"
}


GET http://localhost:5000/customers
content-type: application/json


PUT http://localhost:5000/customers/1
content-type: application/json

{
    "firstName": "Håkon",
    "lastName": "Rossebø"
}


DELETE http://localhost:5000/customers/1
content-type: application/json
