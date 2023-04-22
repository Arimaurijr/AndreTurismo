using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndreTurismo.Models;
using AndreTurismo.Services;

namespace AndreTurismo.Controllers
{
    /*
    public class TicketController
    {
        public TicketModel InsertPassagem()
        {
            TicketModel passagem = new TicketModel();

            Console.WriteLine("Digite o endereço de origem:(TicketController_InsertPassagem)");
            Console.WriteLine();
            passagem.Origem = new AddressController().Insert();

            Console.WriteLine("Digite o endereço de destino:(TicketController_InsertPassagem)");
            Console.WriteLine();
            passagem.Destino = new AddressController().Insert();

            Console.WriteLine("Digite os dados do cliente:(TicketController_InsertPassagem)");
            Console.WriteLine();
            passagem.Cliente = new ClientController().InsertClient();

            Console.WriteLine("Digite o valor da passagem:(TicketController_InsertPassagem)");
            passagem.Valor_Passagem = decimal.Parse(Console.ReadLine());    

            passagem.Data = DateTime.Now;

            passagem.Id = new TicketService().InserirPassagem(passagem);

            return passagem;
        }
    }
    */
}
