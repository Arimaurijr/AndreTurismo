﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndreTurismo.Models;
using Microsoft.Win32.SafeHandles;
using Dapper;
using System.Data;

namespace AndreTurismo.Services
{
    public class CityService
    {
        
        public string Conn { get; set; }

        public CityService()
        {
            Conn = ConfigurationManager.ConnectionStrings["servicoturismo"].ConnectionString;

      
        }

        public CityModel InserirCidade(CityModel city)
        {

            using(var db = new SqlConnection(Conn))
            {
                db.Open();
                city.Id = (int)db.ExecuteScalar(CityModel.INSERT, city);
            }

            return city;  
        }
        public CityModel RetornarCidade(int id)
        {
               
           
                StringBuilder sb = new StringBuilder();
                sb.Append("select id_cidade, descricao, data_cadastro_cidade from city where id_cidade = " + id);

                CityModel cidade = new CityModel();
                var db = new SqlConnection(Conn);
                db.Open();

                SqlCommand commandSelect = new(sb.ToString(), db);
                IDataReader dr = commandSelect.ExecuteReader();

                if (dr.Read())
                {
                    cidade.Id = (int)dr["id_cidade"];
                    cidade.Descricao = (string)dr["descricao"];
                    cidade.Data_Cadastro_Cidade = (DateTime)dr["data_cadastro_cidade"];
                }

                
                dr.Close();
                db.Close();
                return cidade;
        }
       
    }
}
