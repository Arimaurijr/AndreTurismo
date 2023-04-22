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
    /*
    public class ClientController
    {
        public ClientModel InsertClient()
        {
            AddressController endereco_controller = new AddressController();
            AddressModel endereco_model =   endereco_controller.Insert();

            ClientModel cliente = new ClientModel();

            Console.WriteLine("Digite o nome do cliente:");
            cliente.Nome = Console.ReadLine();
            Console.WriteLine("Digite o telefone");
            cliente.Telefone = Console.ReadLine();
            cliente.Data_Cadastro_Cliente = DateTime.Now;
            cliente.Endereco = endereco_model;

            cliente.Id = new ClientService().InserirCliente(cliente);

            return cliente;

            
        }
        
    }
    */
}
