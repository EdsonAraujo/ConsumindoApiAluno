using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ConsumindoApiAluno.Entities.Services
{
    internal class AlunoServices
    {
        public async Task<Aluno> Integracao(int id)
        {
            // recebe o endereço   da API
            // A classe HttpClient faz  a operação da API que permite fazer solicitações HTTP, como GET, POST, PUT, DELETE entre outras 
            // fazer requisição
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"https://localhost:7120/aluno/{id}");
            var jsonString = await response.Content.ReadAsStringAsync();    

            Aluno jsonObject = JsonConvert.DeserializeObject<Aluno>(jsonString);

            if (jsonObject != null)
            {
                return jsonObject;
            }
            else
            {
                return new Aluno
                {
                    Verificacao = true
                };
            }
        }



    }
}
