# api-netcore
Development new api  with .NET and MongoDB

##

This api is the samle Crud the users. 

##



Method:

<The request type>

GET | POST | DELETE | PUT


##

URL Params

< /api/users >

    
    GET
example : localhost:19416/api/users 
 ##   
    DELETE
example : localhost:19416/api/users/{ID}
##    
    POST
example : localhost:19416/api/users 
    
      {   
        
        "nome": "Tarcisio Silva",
        "sexo": "M",
        "email": "taarcisiosilva@gmail.com",
        "naturalidade": "Curitiba",
        "cpf": "0000000000 ",
        "date_create": "2022-01-25T03:00:00Z",
        "lastModified": "2022-01-25T03:00:00Z"
    }
    
##    
    PUT
example : localhost:19416/api/users 
    
      {   
        "userId": 1,
        "nome": "Tarcisio Silva",
        "sexo": "M",
        "email": "taarcisiosilva@gmail.com",
        "naturalidade": "Curitiba",
        "cpf": "0000000000 ",
        "date_create": "2022-01-25T03:00:00Z",
        "lastModified": "2022-01-25T03:00:00Z"
    }



##

use postman for access this api after executed in your project 

##

For this project is necessary used json body for send data to database  in api.

    {   
        
        "nome": "Tarcisio Silva",
        "sexo": "M",
        "email": "taarcisiosilva@gmail.com",
        "naturalidade": "Curitiba",
        "cpf": "0000000000 ",
        "date_create": "2022-01-25T03:00:00Z",
        "lastModified": "2022-01-25T03:00:00Z"
    }
    
 ##
 
 In appsettings.json how settings database  at moment exists my configuration test database but for your  is necessary  setting your datas.
    
 ##
    
 Is necessary install  :  mvc.newtonsoft ,  mongodb.driver  packages 
    
    
