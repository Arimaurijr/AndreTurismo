using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using AndreTurismo.Models;
using Dapper;

namespace AndreTurismo.Services
{

    public class ClientService
    {
        public string Conn { get; set; }

        public ClientService()
        {
            Conn = ConfigurationManager.ConnectionStrings["servicoturismo"].ConnectionString;


        }

        public ClientModel InserirCliente(ClientModel cliente)
        {

            using (var db = new SqlConnection(Conn))
            {
                db.Open();
                var query = ClientModel.INSERIR_CLIENTE.Replace("@Endereco", new AddressService().InserirEndereco(cliente.Endereco).Id.ToString());
                cliente.Id = (int)db.ExecuteScalar(query, cliente);
            }

            return cliente;
        }
        /*
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
        public bool AtualizarCliente(ClientModel cliente)
        {
            bool status = false;
            StringBuilder query = new StringBuilder();
            query.Append("update client set nome_cliente = @nome_cliente,");
            query.Append("                  telefone = @telefone,");
            query.Append("                  data_cadastro_cliente = @data_cadastro_cliente");
            query.Append("                  endereco_cliente = @endereco_cliente");

            try
            {
                SqlCommand commandUpdate = new(query.ToString(), conn);
                commandUpdate.Parameters.Add(new SqlParameter("@nome_cliente", cliente.Nome));
                commandUpdate.Parameters.Add(new SqlParameter("@telefone", cliente.Telefone));
                commandUpdate.Parameters.Add(new SqlParameter("@data_cadastro_cliente", cliente.Data_Cadastro_Cliente));
                commandUpdate.Parameters.Add(new SqlParameter("@endereco_cliente", cliente.Endereco));

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
    */

    }

}
