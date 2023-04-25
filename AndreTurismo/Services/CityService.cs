using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndreTurismo.Models;
using Microsoft.Win32.SafeHandles;

namespace AndreTurismo.Services
{
    public class CityService
    {
        readonly string strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\USERS\ADM\DOCUMENTS\ANDRETURISMO.MDF";
        readonly SqlConnection conn;

        public CityService()
        {
            conn = new SqlConnection(strConn);
            //conn.Open();
        }
        
        public int InserirCidade(CityModel city)
        {
            conn.Open();

            try
            {
                string strInsert = "insert into city(descricao, data_cadastro_cidade) values (@descricao, @data_cadastro_cidade)" + "select cast(scope_identity() as int)";
                SqlCommand commandInsert = new SqlCommand(strInsert, conn);

                commandInsert.Parameters.Add(new SqlParameter("@descricao", city.Descricao));
                commandInsert.Parameters.Add(new SqlParameter("@data_cadastro_cidade", city.Data_Cadastro_Cidade));

                return (int)commandInsert.ExecuteScalar();


            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

            //return 0;
        }
        public List<CityModel> SelecionarTodasCidades()
        {
            List<CityModel> cidades = new();
            StringBuilder query_consulta = new StringBuilder();
            query_consulta.Append("select id_cadastro, descricao, data_cadastro_cidade from city");

            SqlCommand commandSelect = new(query_consulta.ToString(), conn);
            SqlDataReader dr = commandSelect.ExecuteReader();

            while (dr.Read())
            {
                CityModel city = new();

                city.Id = (int)dr["id_cidade"];
                city.Descricao = (string)dr["descricao"];
                city.Data_Cadastro_Cidade = (DateTime)dr["data_cadastro_cidade"];

                cidades.Add(city);
            }

            return cidades;
        }
        public bool DeletarCidade(CityModel city)
        {
            bool status = false;

            StringBuilder query = new StringBuilder();
            query.Append("delete from city where descricao = @descricao");

            try
            {
                SqlCommand commandDelete = new(query.ToString(), conn);
                commandDelete.Parameters.Add(new SqlParameter("@desricao", city.Descricao));

                commandDelete.ExecuteNonQuery();

                status = true;
            }
            catch(Exception e)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }


            return status;

        }
        public bool AtualizarCidade(CityModel cidade, string coluna, string valor)
        {
            conn.Open();

            bool status = false;
            StringBuilder query = new StringBuilder();
            query.Append("update city set " + coluna + " = " + valor);
            query.Append("            where id_cidade = " + cidade.Id);

            try
            {
                SqlCommand commandUpdate = new(query.ToString(), conn);

                commandUpdate.ExecuteNonQuery();
                status = true;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }


            return status;
        }
        public CityModel RetornarCidade(int id)
        {
            conn.Open();
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("select id_cidade, descricao, data_cadastro_cidade from city where id_cidade = " + id);

                CityModel cidade = new CityModel();

                SqlCommand commandSelect = new(sb.ToString(), conn);
                SqlDataReader dr = commandSelect.ExecuteReader();

                if (dr.Read())
                {
                    cidade.Id = (int)dr["id_cidade"];
                    cidade.Descricao = (string)dr["descricao"];
                    cidade.Data_Cadastro_Cidade = (DateTime)dr["data_cadastro_cidade"];
                }

                dr.Close();
                return cidade;
            }
            catch(Exception e)
            { throw; }
            finally { conn.Close(); }   
        }  
    }
}
