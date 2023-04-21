using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AndreTurismo.Models;
using AndreTurismo.Services;

namespace AndreTurismo.Controllers
{
    public class AddressController
    {
        /*
        readonly string strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\USERS\ADM\DOCUMENTS\ANDRETURISMO.MDF";
        readonly SqlConnection conn;

        public AddressController()
        {
            conn = new SqlConnection(strConn);
            conn.Open();
        }
        */

        public AddressModel Insert()
        {

            CityModel city = new CityModel();
            Console.WriteLine("##### DIGITE A DESCRIÇÃO DA CIDADE #####");
            city.Descricao = Console.ReadLine();
            city.Data_Cadastro_Cidade = DateTime.Now;

            city.Id =  new CityService().InserirCidade(city);

            AddressModel endereco = new AddressModel();  
            endereco.Cidade = city;


            //AddressModel endereco = new AddressModel();

            Console.WriteLine("##### DIGITE OS DADOS ENDEREÇO #####");
            Console.WriteLine("Digite o logradouro");
            endereco.Logradouro = Console.ReadLine();

            Console.WriteLine("Digite o numero");
            endereco.Numero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o bairro");
            endereco.Bairro = Console.ReadLine();

            Console.WriteLine("Digite o CEP");
            endereco.CEP = Console.ReadLine();

            Console.WriteLine("Digite o complemento");
            endereco.Complemento = Console.ReadLine();

            endereco.Data_Cadastro_Endereco = DateTime.Now;

            /*
            int InserirCidade(CityModel city) 
            {
                string strInsert = "insert into City (descricao) values (@descricao);" + "select cast(scope_identity() as int)";

                SqlCommand commandInsert = new SqlCommand(strInsert, conn);
                commandInsert.Parameters.Add(new SqlParameter("@descricao", city.Descricao));

                return (int)commandInsert.ExecuteScalar();

            }
            */

            endereco.Id  = new AddressService().InserirEndereco(endereco);
            
            return endereco;

            //return new AddressService().InserirEndereco(endereco);
           
        }
        /*
        private int InserirCidade(CityModel city)
        {
            string strInsert = "insert into City (descricao) values (@descricao);" + "select cast(scope_identity() as int)";

            SqlCommand commandInsert = new SqlCommand(strInsert, conn);
            commandInsert.Parameters.Add(new SqlParameter("@descricao", city.Descricao));

            return (int)commandInsert.ExecuteScalar();

        }
        */
        /*
        private int InserirCidade(CityModel city)
        {
            string strInsert = "insert into City (descricao,data_cadastro_cidade) values (@descricao,@data_cadastro_cidade);" + "select cast(scope_identity() as int)";

            SqlCommand commandInsert = new SqlCommand(strInsert, conn);
            commandInsert.Parameters.Add(new SqlParameter("@descricao", city.Descricao));
            commandInsert.Parameters.Add(new SqlParameter("@data_cadastro_cidade", city.Data_Cadastro_Cidade));

            return (int)commandInsert.ExecuteScalar();

        }
        */



    }
}
