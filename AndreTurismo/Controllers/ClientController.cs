using System;
using System.Collections.Generic;
using System.Linq;
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
            try
            {
                cliente = new ClientService().InserirCliente(cliente);
            }
            catch 
            {
                Console.WriteLine("Não foi possível inserir o cliente !");   
            }

            return cliente;
        }

        public ClientModel RetornarClientePorID(int id_cliente)
        {
            ClientModel cliente = new ClientModel();

            try
            {
                cliente = new ClientService().RetornarCliente(id_cliente);
            }
            catch
            {
                Console.WriteLine("Não possível achar o cliente");
            }

            return cliente;
        }
        
    }
   
}
