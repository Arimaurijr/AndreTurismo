using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndreTurismo.Models;

namespace AndreTurismo.Services
{
    
    public class PackageService
    {
        readonly string strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\USERS\ADM\DOCUMENTS\ANDRETURISMO.MDF";
        readonly SqlConnection conn;

        public PackageService()
        {
            conn = new SqlConnection(strConn);
            //conn.Open();
        }

        public int InserirPacote(PackageModel pacote)
        {
            conn.Open();

            try
            {
                string strInsert = "insert into package(hotel_pacote, passagem_pacote, data_cadastro_pacote, valor_pacote, cliente_pacote)" +
                  "values (@hotel_pacote, @passagem_pacote, @data_cadastro_pacote, @valor_pacote, @cliente_pacote)" + "select cast(scope_identity() as int)";

                SqlCommand commandInsert = new SqlCommand(strInsert, conn);

                commandInsert.Parameters.Add(new SqlParameter("@hotel_pacote",pacote.Hotel_Pacote.Id));
                commandInsert.Parameters.Add(new SqlParameter("@passagem_pacote",pacote.Passagem_Pacote.Id));
                commandInsert.Parameters.Add(new SqlParameter("@data_cadastro_pacote",pacote.Data_Cadastro_Pacote));
                commandInsert.Parameters.Add(new SqlParameter("@valor_pacote",pacote.Valor_Pacote));
                commandInsert.Parameters.Add(new SqlParameter("@cliente_pacote",pacote.Cliente_Pacote.Id));

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

        /*
        private int InserirPassagem(PackageModel package)
        {
            string strInsert = "insert into passagem(endereco_origem, endereco_destino, cliente_passagem, data_cadastro_passagem, valor_passagem)" +
                  "values (@endereco_origem, @endereco_destino, @cliente_passagem, @data_cadastro_passagem,@valor_passagem); select cast(scope_identity() as int)";

            SqlCommand commandInsert = new SqlCommand(strInsert, conn);

            commandInsert.Parameters.Add(new SqlParameter("@endereco_origem", package.Passagem_Pacote.Origem));
            commandInsert.Parameters.Add(new SqlParameter("@endereco_destino", package.Passagem_Pacote.Destino));
            commandInsert.Parameters.Add(new SqlParameter("@cliente_passagem", package.Cliente_Pacote.Id));
            commandInsert.Parameters.Add(new SqlParameter("@data_cadastro_passagem", package.Passagem_Pacote.Data));
            commandInsert.Parameters.Add(new SqlParameter("@valor_passagem", package.Passagem_Pacote.Valor_Passagem));

            commandInsert.ExecuteNonQuery();

            return (int)commandInsert.ExecuteScalar();

        }
        private int InserirHotel(PackageModel package)
        {
            string strInsert = "insert into hotel(nome_hotel, data_cadastro_hotel, valor_hotel, endereco_hotel)" +
                  "values (@nome_hotel, @data_cadastro_hotel, @valor_hotel, @endereco_hotel); select cast(scope_identity() as int)";

            SqlCommand commandInsert = new SqlCommand(strInsert, conn);

            commandInsert.Parameters.Add(new SqlParameter("@nome_hotel", package.Hotel_Pacote.Nome));
            commandInsert.Parameters.Add(new SqlParameter("@data_cadastro_hotel", package.Hotel_Pacote.Data_Cadastro_Hotel));
            commandInsert.Parameters.Add(new SqlParameter("@valor_hotel", package.Hotel_Pacote.Valor_Hotel));
            commandInsert.Parameters.Add(new SqlParameter("@endereco_hotel", package.Hotel_Pacote.Endereco));

            commandInsert.ExecuteNonQuery();

            return (int)commandInsert.ExecuteScalar();

        }
        private int InserirCliente(PackageModel package)
        {
            string strInsert = "insert into client(nome_cliente,telefone,data_cadastro_cliente,endereco)" +
                  "values (@nome_cliente,@telefone,@data_cadastro_cliente,@endereco); select cast(scope_identity() as int)";

            SqlCommand commandInsert = new SqlCommand(strInsert, conn);

            commandInsert.Parameters.Add(new SqlParameter("@nome_cliente", package.Cliente_Pacote.Nome));
            commandInsert.Parameters.Add(new SqlParameter("@telefone", package.Cliente_Pacote.Telefone));
            commandInsert.Parameters.Add(new SqlParameter("@data_cadastro_cliente", package.Cliente_Pacote.Data_Cadastro_Cliente));
            commandInsert.Parameters.Add(new SqlParameter("@endereco", package.Cliente_Pacote.Endereco));


            commandInsert.ExecuteNonQuery();


            return (int)commandInsert.ExecuteScalar();
        }
        */

        public List<PackageModel> ListarTodasPacotes()
        {
            conn.Open();

            try
            {

                List<PackageModel> pacotes = new();
                StringBuilder sb = new StringBuilder();

                sb.Append("select id_pacote,");
                sb.Append("       hotel_pacote,");
                sb.Append("       passagem_pacote,");
                sb.Append("       data_cadastro_pacote,");
                sb.Append("       valor_pacote,");
                sb.Append("       cliente_pacote");
                sb.Append("       from package");


                SqlCommand commandSelect = new(sb.ToString(), conn);
                SqlDataReader dr = commandSelect.ExecuteReader();

                while (dr.Read())
                {
                    PackageModel pacote = new();

                    pacote.Id = (int)dr["id_pacote"];
                    int id_hotel = (int)dr["hotel_pacote"];
                    int id_passagem = (int)dr["passagem_pacote"];
                    int id_cliente = (int)dr["cliente_pacote"];
                    pacote.Hotel_Pacote = new HotelService().RetornarHotel(id_hotel);
                    pacote.Passagem_Pacote = new TicketService().RetornarPassagem(id_passagem);
                    pacote.Cliente_Pacote = new ClientService().RetornarCliente(id_cliente);


                    pacote.Valor_Pacote = (decimal)dr["valor_pacote"];
                    pacote.Data_Cadastro_Pacote = (DateTime)dr["data_cadastro_pacote"];

                    pacotes.Add(pacote);

                }

                return pacotes;
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
