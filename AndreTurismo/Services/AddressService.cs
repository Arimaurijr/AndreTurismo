﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndreTurismo.Models;
using Dapper;

namespace AndreTurismo.Services
{
    public class AddressService
    {
        public string Conn { get; set; }
        public AddressService()
        {
            Conn = ConfigurationManager.ConnectionStrings["servicoturismo"].ConnectionString;
        }

        public AddressModel InserirEndereco(AddressModel endereco)
        {
            
            using (var db = new SqlConnection(Conn))
            {
                db.Open();
                var query = AddressModel.INSERIR_ENDERECO.Replace("@Cidade", new CityService().InserirCidade(endereco.Cidade).Id.ToString());
                endereco.Id = (int)db.ExecuteScalar(query, endereco);
            }

            return endereco;
           
        }

        public AddressModel RetornarEndereco(int id_endereco)
        {

            StringBuilder sb = new StringBuilder();
            sb.Append("select id_endereco,");
            sb.Append("       logradouro,");
            sb.Append("       numero,");
            sb.Append("       bairro,");
            sb.Append("       cep,");
            sb.Append("       complemento,");
            sb.Append("       data_cadastro_endereco,");
            sb.Append("       id_cidade_endereco");
            sb.Append("       from address where id_endereco = " + id_endereco);

            AddressModel endereco = new AddressModel();
            var db = new SqlConnection(Conn);
            db.Open();

            SqlCommand commandSelect = new(sb.ToString(), db);
            IDataReader dr = commandSelect.ExecuteReader();

            if (dr.Read())
            {

                endereco.Id = (int)dr["id_endereco"];
                endereco.Logradouro = (string)dr["logradouro"];
                endereco.Numero = (int)dr["numero"];
                endereco.Bairro = (string)dr["bairro"];
                endereco.CEP = (string)dr["cep"];
                endereco.Complemento = (string)dr["complemento"];
                endereco.Data_Cadastro_Endereco = (DateTime)dr["data_cadastro_endereco"];
                int id_cidade = (int)dr["id_cidade_endereco"];
                dr.Close();
                db.Close();

                endereco.Cidade = new CityService().RetornarCidade(id_cidade);

            }


            return endereco;
         }

    } 
       
}

