using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly IConfiguration _configuration;

        public UsersController(IConfiguration configuration)
        {
            _configuration = configuration;
        }



        [HttpGet]

        public JsonResult Get()
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("UsersApp"));
            var dbList = dbClient.GetDatabase("dbMongo").GetCollection<Models.Users>("Users").AsQueryable();
            return new JsonResult(dbList);
        }

        [HttpPost]

        public JsonResult Post(Users user)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("UsersApp"));
            int lastUsersId = dbClient.GetDatabase("dbMongo").GetCollection<Models.Users>("Users").AsQueryable().Count();


            var filter =  Builders<Users>.Filter.Eq("email", user.email);

      

            if (IsCpf(user.cpf) == false)
            {
                return new JsonResult("CPF  Inválido ");
            }



       
            user.userId = lastUsersId + 1;
            dbClient.GetDatabase("dbMongo").GetCollection<Users>("Users").InsertOne(user);

            return new JsonResult("Adicionado com sucesso");

        }

      

        [HttpPut]

        public JsonResult Put(Users user)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("UsersApp"));

            var filter = Builders<Users>.Filter.Eq("userId", user.userId);

            var update = Builders<Users>.Update.Set("nome", user.nome)
                                                .Set("sexo", user.sexo)
                                                .Set("naturalidade", user.naturalidade)
                                                .Set("cpf", user.cpf)
                                                .Set("date_create", user.date_create)
                                                .Set("lastModified", true);



            dbClient.GetDatabase("dbMongo").GetCollection<Users>("Users").UpdateOne(filter, update);

            return new JsonResult("Dados Atualizados ");

        }


        [HttpDelete("{id}")]

        public JsonResult Delete(int id)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("UsersApp"));
            var filter = Builders<Users>.Filter.Eq("userId", id);

            dbClient.GetDatabase("dbMongo").GetCollection<Users>("Users").DeleteOne(filter);

            return new JsonResult("Dados Deletados ");

        }





        private static bool IsCpf(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            cpf = cpf.Trim().Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;

            for (int j = 0; j < 10; j++)
                if (j.ToString().PadLeft(11, char.Parse(j.ToString())) == cpf)
                    return false;

            string tempCpf = cpf.Substring(0, 9);
            int soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            int resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            string digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cpf.EndsWith(digito);
        }




    }
}