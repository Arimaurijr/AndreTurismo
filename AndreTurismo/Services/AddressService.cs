﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndreTurismo.Models;

namespace AndreTurismo.Services
{
    public class AddressService
    {
        readonly string strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\USERS\ADM\DOCUMENTS\ANDRETURISMO.MDF";
        readonly SqlConnection conn;

        public AddressService()
        {
            conn = new SqlConnection(strConn);
            //conn.Open();
        }

       

        public int InserirEndereco(AddressModel endereco)
        {

            conn.Open();

            try
            {
                string strInsert = "insert into address(logradouro,numero,bairro,cep,complemento,data_cadastro_endereco,id_cidade_endereco)" +
                  "values (@logradouro,@numero,@bairro,@cep,@complemento,@data_cadastro_endereco,@id_cidade_endereco)" + "select cast(scope_identity() as int)";

                SqlCommand commandInsert = new SqlCommand(strInsert, conn);

                commandInsert.Parameters.Add(new SqlParameter("@logradouro", endereco.Logradouro));
                commandInsert.Parameters.Add(new SqlParameter("@numero", endereco.Numero));
                commandInsert.Parameters.Add(new SqlParameter("@bairro", endereco.Bairro));
                commandInsert.Parameters.Add(new SqlParameter("@cep", endereco.CEP));
                commandInsert.Parameters.Add(new SqlParameter("@complemento", endereco.Complemento));
                commandInsert.Parameters.Add(new SqlParameter("@data_cadastro_endereco", endereco.Data_Cadastro_Endereco));
                commandInsert.Parameters.Add(new SqlParameter("@id_cidade_endereco", endereco.Cidade.Id));

                return (int)commandInsert.ExecuteScalar();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
            finally
            {
                conn.Close();
            }


            //conn.Close();
        }


        public List<AddressModel> ListarTodosEnderecos()
        {
            //conn.Open();

            List<AddressModel> enderecos = new();
            StringBuilder sb = new StringBuilder();
            sb.Append("select address.id_endereco,");
            sb.Append("       address.logradouro,");
            sb.Append("       address.numero,");
            sb.Append("       address.cep,");
            sb.Append("       address.complemento,");
            sb.Append("       address.data_cadastro_endereco,");
            sb.Append("       address.id_cidade_endereco,");

            sb.Append("       city.id_cidade,");
            sb.Append("       city.descricao,");
            sb.Append("       city.data_cadastro_cidade");
            sb.Append("       from address, city");
            sb.Append("       where address.id_cidade_endereco = city.id_cidade;");

            SqlCommand commandSelect = new(sb.ToString(), conn);
            SqlDataReader dr = commandSelect.ExecuteReader();

            while (dr.Read())
            {
                AddressModel endereco = new();

                endereco.Id = (int)dr["id_endereco"];
                endereco.Logradouro = (string)dr["logradouro"];
                endereco.Numero = (int)dr["numero"];
                endereco.Bairro = (string)dr["bairro"];
                endereco.CEP = (string)dr["cep"];
                endereco.Complemento = (string)dr["complemento"];
                endereco.Data_Cadastro_Endereco = (DateTime)dr["data_cadastro_endereco"];

                endereco.Cidade = new CityService().RetornarCidade((int)dr["id_cidade_endereco"]);

                endereco.Cidade = new CityModel()
                {
                    Id = (int)dr["id_cidade"],
                    Descricao = (string)dr["descricao"],
                    Data_Cadastro_Cidade = (DateTime)dr["data_cadastro_cidade"]
                };

                enderecos.Add(endereco);
            }

            return enderecos;

            //conn.Close();
        }

        public bool DeletarEndereco(AddressModel endereco)
        {
            //conn.Open();

            bool status = false;

            StringBuilder query = new StringBuilder();
            query.Append("delete from address where id_endereco = @id_endereco");

            try
            {
                SqlCommand commandDelete = new(query.ToString(), conn);
                commandDelete.Parameters.Add(new SqlParameter("@id_endereco", endereco.Id));

                commandDelete.ExecuteNonQuery();

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

            //conn.Close();

            return status;


        }

        public bool AtualizarEndereco(AddressModel endereco,string coluna, string valor)
        {
            conn.Open();

            bool status = false;
            StringBuilder query = new StringBuilder();
            query.Append("update address set " + coluna + " = " + valor);
            query.Append("            where id_endereco = " + endereco.Id);

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

        public AddressModel RetornarEndereco(int id_endereco)
        {
            conn.Open();

            try
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

                SqlCommand commandSelect = new(sb.ToString(), conn);
                SqlDataReader dr = commandSelect.ExecuteReader();

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

                    endereco.Cidade = new CityService().RetornarCidade(id_cidade);

                }


                return endereco;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

        }

    }
}

