using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using AndreTurismo.Models;

namespace AndreTurismo.Services
{
    
    public class TicketService
    {
        readonly string strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\USERS\ADM\DOCUMENTS\ANDRETURISMO.MDF";
        readonly SqlConnection conn;

        public TicketService()
        {
            conn = new SqlConnection(strConn);
            //conn.Open();
        }

        public int InserirPassagem(TicketModel passagem)
        {
            conn.Open();

            try
            {
                string strInsert = "insert into passagem(endereco_origem, endereco_destino, cliente_passagem, data_cadastro_passagem, valor_passagem)" +
                  "values (@endereco_origem, @endereco_destino, @cliente_passagem, @data_cadastro_passagem, @valor_passagem)" + "select cast(scope_identity() as int)";

                SqlCommand commandInsert = new SqlCommand(strInsert, conn);

                commandInsert.Parameters.Add(new SqlParameter("@endereco_origem", passagem.Origem.Id));
                commandInsert.Parameters.Add(new SqlParameter("@endereco_destino", passagem.Destino.Id));
                commandInsert.Parameters.Add(new SqlParameter("@cliente_passagem", passagem.Cliente.Id));
                commandInsert.Parameters.Add(new SqlParameter("@data_cadastro_passagem", passagem.Data));
                commandInsert.Parameters.Add(new SqlParameter("@valor_passagem", passagem.Valor_Passagem));

                
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

        public bool AtualizarPassagem(TicketModel passagem, string coluna, string valor)
        {
            conn.Open();

            bool status = false;
            StringBuilder query = new StringBuilder();
            query.Append("update passagem set " + coluna + " = " + valor);
            query.Append("            where id_passagem = " + passagem.Id);

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

        public TicketModel RetornarPassagem(int id_passagem)
        {
            try
            {
                conn.Open();
                StringBuilder sb = new StringBuilder();
                TicketModel passagem = new TicketModel();

                sb.Append("select id_passagem,");
                sb.Append("       endereco_origem,");
                sb.Append("       endereco_destino,");
                sb.Append("       cliente_passagem,");
                sb.Append("       data_cadastro_passagem,");
                sb.Append("       valor_passagem");
                sb.Append("       from  passagem");
                sb.Append("       where id_passagem = " + id_passagem);


                SqlCommand commandSelect = new(sb.ToString(), conn);
                SqlDataReader dr = commandSelect.ExecuteReader();

                if (dr.Read())
                {

                    passagem.Id = (int)dr["id_passagem"];
                    int id_origem = (int)dr["endereco_origem"];
                    int id_destino = (int)dr["endereco_destino"];
                    int id_cliente = (int)dr["cliente_passagem"];
                    dr.Close();
                    passagem.Origem = new AddressService().RetornarEndereco(id_origem);
                    passagem.Destino = new AddressService().RetornarEndereco(id_destino);
                    passagem.Cliente = new ClientService().RetornarCliente(id_cliente);


                }

                return passagem;

            }
            catch 
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
