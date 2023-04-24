using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using AndreTurismo.Models;
using AndreTurismo.Services;
//using AndreTurismo.Controllers.AddressController;

namespace AndreTurismo.Controllers
{
    public class ClientController
    {
        public ClientModel InsertClient(ClientModel cliente)
        {
            cliente.Id = new ClientService().InserirCliente(cliente);
            return cliente;
        }
        public ClientModel RetornarClientePorID(int id_cliente)
        {
            ClientModel cliente = new ClientModel();
            cliente = new ClientService().RetornarCliente(id_cliente);
            return cliente;
        }
    }
}
