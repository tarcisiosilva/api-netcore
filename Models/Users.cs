using System;
using MongoDB.Bson;

namespace api.Models
{
    public class Users
    {
        
            public ObjectId Id { get; set; }

            public int userId { get; set; }

            public string nome { get; set; }

            public string sexo { get; set; }

            public string email { get; set; }

            public string naturalidade { get; set; }

            public string cpf { get; set; }

            public DateTime date_create { get; set; }

            public DateTime lastModified { get; set; }


    }
}
