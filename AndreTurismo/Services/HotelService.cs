using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndreTurismo.Models;

namespace AndreTurismo.Services
{ 
    public class HotelService
    {
        readonly string strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\USERS\ADM\DOCUMENTS\ANDRETURISMO.MDF";
        readonly SqlConnection conn;

        public HotelService()
        {
            conn = new SqlConnection(strConn);
            //conn.Open();
        }

        public int InserirHotel(HotelModel hotel)
        {
            conn.Open();

            try
            {
                string strInsert = "insert into hotel(nome_hotel, data_cadastro_hotel, valor_hotel, endereco_hotel)" +
                  "values (@nome_hotel, @data_cadastro_hotel, @valor_hotel, @endereco_hotel)" + "select cast(scope_identity() as int)";

                SqlCommand commandInsert = new SqlCommand(strInsert, conn);

                commandInsert.Parameters.Add(new SqlParameter("@nome_hotel", hotel.Nome));
                commandInsert.Parameters.Add(new SqlParameter("@data_cadastro_hotel", hotel.Data_Cadastro_Hotel));
                commandInsert.Parameters.Add(new SqlParameter("@valor_hotel", hotel.Valor_Hotel));
                commandInsert.Parameters.Add(new SqlParameter("@endereco_hotel", hotel.Endereco.Id));

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
        private int InserirEndereco(AddressModel address)
        {
            string strInsert = "insert into address(logradouro,numero,bairro,cep,complemento,data_cadastro_endereco,id_cidade_endereco)" +
                  "values (@logradouro,@numero,@bairro,@cep,@complemento,@data_cadastro_endereco,@id_cidade_endereco); select cast(scope_identity() as int)";

            SqlCommand commandInsert = new SqlCommand(strInsert, conn);

            commandInsert.Parameters.Add(new SqlParameter("@logradouro", address.Logradouro));
            commandInsert.Parameters.Add(new SqlParameter("@numero", address.Numero));
            commandInsert.Parameters.Add(new SqlParameter("@bairro", address.Bairro));
            commandInsert.Parameters.Add(new SqlParameter("@cep", address.CEP));
            commandInsert.Parameters.Add(new SqlParameter("@complemento", address.Complemento));
            commandInsert.Parameters.Add(new SqlParameter("@data_cadastro_endereco", address.Data_Cadastro_Endereco));
            commandInsert.Parameters.Add(new SqlParameter("@id_cidade_endereco", address.Cidade.Id));

            commandInsert.ExecuteNonQuery();


            return (int)commandInsert.ExecuteScalar();
        }
        */

        public HotelModel RetornarHotel(int id_hotel)
        {
            conn.Open();

            try
            {
                HotelModel hotel = new HotelModel();
                StringBuilder sb = new StringBuilder();

                sb.Append("select  id_hotel,");
                sb.Append("        nome_hotel,");
                sb.Append("        endereco_hotel,");
                sb.Append("        data_cadastro_hotel,");
                sb.Append("        valor_hotel");
                sb.Append("        from hotel");
                sb.Append("        where id_hotel = " + id_hotel);

                SqlCommand commandSelect = new(sb.ToString(), conn);
                SqlDataReader dr = commandSelect.ExecuteReader();

                if (dr.Read())
                {
                    hotel.Id = (int)dr["id_hotel"];
                    hotel.Nome = (string)dr["nome_hotel"];
                    hotel.Data_Cadastro_Hotel = (DateTime)dr["data_cadastro_hotel"];
                    hotel.Valor_Hotel = (decimal)dr["valor_hotel"];
                    int id_endereco = (int)dr["endereco_hotel"];
                    dr.Close();

                    hotel.Endereco = new AddressService().RetornarEndereco(id_endereco);

                }

                return hotel;
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
        public bool DeletarHotel(HotelModel hotel)
        {
            bool status = false;

            StringBuilder query = new StringBuilder();
            query.Append("delete from hotel where id_hotel = @id_hotel");

            try
            {
                SqlCommand commandDelete = new(query.ToString(), conn);
                commandDelete.Parameters.Add(new SqlParameter("@id_hotel", hotel.Id));

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

            return status;
        }

        public bool AtualizarHotel(HotelModel hotel)
        {
            bool status = false;
            StringBuilder query = new StringBuilder();
            query.Append("update hotel set nome_hotel = @nome_hotel,");
            query.Append("                  data_cadastro_hotel = @data_cadastro_hotel,");
            query.Append("                  valor_hotel = @valor_hotel");
            query.Append("                  endereco_hotel = @endereco_hotel");

            try
            {
                SqlCommand commandUpdate = new(query.ToString(), conn);
                commandUpdate.Parameters.Add(new SqlParameter("@nome_hotel", hotel.Nome));
                commandUpdate.Parameters.Add(new SqlParameter("@data_cadastro_hotel", hotel.Data_Cadastro_Hotel));
                commandUpdate.Parameters.Add(new SqlParameter("@valor_total", hotel.Valor_Hotel));
                commandUpdate.Parameters.Add(new SqlParameter("@endereco_hotel", hotel.Endereco));

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
