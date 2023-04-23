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

        public AddressModel InsertEndereco(AddressModel endereco)
        {

            try
            {
                endereco = new AddressService().InserirEndereco(endereco);
            }
            catch (Exception ex) 
            {
                Console.WriteLine("Excessão lançada");
                
            }

            return endereco;
        }
        public AddressModel RetornarEnderecoPorID(int id_cidade)
        {
            AddressModel endereco = new AddressModel();
            
            try
            {
                endereco = new AddressService().RetornarEndereco(id_cidade);
            }
            catch (Exception ex) 
            {
                Console.WriteLine("Não possível inserir o endereço");
            }

            return endereco;
        }

    }
}
