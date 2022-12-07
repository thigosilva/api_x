﻿using Microsoft.AspNetCore.Http;
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
    public class cep : ControllerBase
    {
        [HttpGet]
        public string List_CEP(string p_nome)
        {



            string ChaveConexao = "Data Source=10.39.45.44; Initial Catalog=Senac2022; User ID=Turma2022;Password=Turma2022@2022";



            DataSet resultadoCep = new DataSet();

            SqlConnection Conexao = new SqlConnection(ChaveConexao);
            Conexao.Open();
            string wQuery = $"select * from cep where cep like  '{p_nome}'";
            SqlDataAdapter adapter = new SqlDataAdapter(wQuery, Conexao);
            adapter.Fill(resultadoCep);

            string json = JsonConvert.SerializeObject(resultadoCep, Formatting.Indented);



            return json;
        }
    }
}
