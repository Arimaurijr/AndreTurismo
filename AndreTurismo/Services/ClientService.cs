﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using AndreTurismo.Models;

namespace AndreTurismo.Services
{

    public class ClientService
    {
        readonly string strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\USERS\ADM\DOCUMENTS\ANDRETURISMO.MDF";
        readonly SqlConnection conn;

        public ClientService()
        {
            conn = new SqlConnection(strConn);
            
        }

        public int InserirCliente(ClientModel cliente)
        {
            conn.Open();

            try
            {
                string strInsert = "insert into client(nome_cliente, telefone, data_cadastro_cliente, endereco_cliente)" +
                  "values (@nome_cliente, @telefone, @data_cadastro_cliente, @endereco_cliente)" + "select cast(scope_identity() as int)";

                SqlCommand commandInsert = new SqlCommand(strInsert, conn);

                commandInsert.Parameters.Add(new SqlParameter("@nome_cliente", cliente.Nome));
                commandInsert.Parameters.Add(new SqlParameter("@telefone", cliente.Telefone));
                commandInsert.Parameters.Add(new SqlParameter("@data_cadastro_cliente", cliente.Data_Cadastro_Cliente));
                commandInsert.Parameters.Add(new SqlParameter("@endereco_cliente",cliente.Endereco.Id));

                return (int)commandInsert.ExecuteScalar();


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

        

        
        public ClientModel RetornarCliente(int id_cliente)
        {
            conn.Open();

            ClientModel cliente = new ClientModel();

            StringBuilder sb = new StringBuilder();
            sb.Append("select id_cliente,");
            sb.Append("       nome_cliente,");
            sb.Append("       endereco_cliente,");
            sb.Append("       data_cadastro_cliente,");
            sb.Append("       telefone");
            sb.Append("       from client");
            sb.Append("       where id_cliente = " + id_cliente);
            

            SqlCommand commandSelect = new(sb.ToString(), conn);
            SqlDataReader dr = commandSelect.ExecuteReader();

            if (dr.Read())
            {
                cliente.Id = (int)dr["id_cliente"];
                cliente.Nome = (string)dr["nome_cliente"];
                cliente.Telefone = (string)dr["Telefone"];
                cliente.Data_Cadastro_Cliente = (DateTime)dr["data_cadastro_cliente"];
   
                int id_endereco = (int)dr["endereco_cliente"];
                dr.Close();

                cliente.Endereco = new AddressService().RetornarEndereco(id_endereco);
            }

            return cliente;
        }

        public bool DeletarCliente(ClientModel cliente)
        {
            bool status = false;

            StringBuilder query = new StringBuilder();
            query.Append("delete from client where id_cliente = @id_cliente");

            try
            {
                SqlCommand commandDelete = new(query.ToString(), conn);
                commandDelete.Parameters.Add(new SqlParameter("@id_cliente", cliente.Id));

                commandDelete.ExecuteNonQuery();

                status = true;
            }
            catch(Exception ex) 
            {
                throw;
            }
            finally 
            {
                conn.Close();
            }

            return status;
        }
        public bool AtualizarCliente(ClientModel cliente, string coluna, string valor)
        {
            conn.Open();

            bool status = false;
            StringBuilder query = new StringBuilder();
            query.Append("update client set " + coluna + " = " + valor);
            query.Append("            where id_cliente = " + cliente.Id);

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
    }
}
