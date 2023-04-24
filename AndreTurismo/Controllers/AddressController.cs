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
           endereco.Id = new AddressService().InserirEndereco(endereco);
           return endereco;
        }
        public AddressModel RetornarEnderecoPorID(int id_endereco)
        {
            AddressModel endereco = new AddressModel();
            endereco = new AddressService().RetornarEndereco(id_endereco);

            return endereco;
        }

    }
}
