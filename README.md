POST http://localhost:5000/customers
content-type: application/json

{
    "firstName": "H�kon",
    "lastName": "R"
}


GET http://localhost:5000/customers
content-type: application/json


PUT http://localhost:5000/customers/1
content-type: application/json

{
    "firstName": "H�kon",
    "lastName": "Rosseb�"
}


DELETE http://localhost:5000/customers/1
content-type: application/json
