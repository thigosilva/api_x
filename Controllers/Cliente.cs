using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;


namespace api_x.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Cliente : ControllerBase
    {
        [HttpGet]
        public string List_CEP(string p_nome)
        {



            string ChaveConexao = "Data Source=10.39.45.44; Initial Catalog=TI_Noite; User ID=Turma2022;Password=Turma2022@2022";



            DataSet resultadocliente = new DataSet();

            SqlConnection Conexao = new SqlConnection(ChaveConexao);
            Conexao.Open();
            string wQuery = $"select * from Clientes where GivenName like  '{p_nome}'";
            SqlDataAdapter adapter = new SqlDataAdapter(wQuery, Conexao);
            adapter.Fill(resultadocliente);

            string json = JsonConvert.SerializeObject(resultadocliente, Formatting.Indented);



            return json;
        }
    }
}
