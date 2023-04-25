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

        public bool AtualizarHotel(HotelModel hotel, string coluna, string valor)
        {
            conn.Open();

            bool status = false;
            StringBuilder query = new StringBuilder();
            query.Append("update hotel set " + coluna + " = " + valor);
            query.Append("            where id_hotel = " + hotel.Id);

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
