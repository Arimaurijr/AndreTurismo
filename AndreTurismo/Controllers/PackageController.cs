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
    public class PackageController
    {
        
        public PackageModel InserirPacote()
        {
            PackageModel pacote = new PackageModel();

            Console.WriteLine("##### DADOS DO HOTEL #####");
            HotelModel hotel_model = new HotelModel();
            hotel_model = new HotelController().InsertHotel();
            pacote.Hotel_Pacote = hotel_model;

            Console.WriteLine();
            Console.WriteLine("##### DADOS PASSAGEM #####");
            TicketModel passagem_model = new TicketModel();
            passagem_model = new TicketController().InsertPassagem();
            pacote.Passagem_Pacote= passagem_model; 
            pacote.Cliente_Pacote = passagem_model.Cliente;

            
            Console.WriteLine();
            Console.WriteLine("#####DADOS DO CLIENTE#####");
            ClientModel cliente_model = new ClientModel();
            cliente_model = new ClientController().InsertClient();
            pacote.Cliente_Pacote = cliente_model;
            

            Console.WriteLine();
            Console.WriteLine("##### DIGITE O VALOR DO PACOTE #####");
            pacote.Valor_Pacote = decimal.Parse(Console.ReadLine());

            pacote.Data_Cadastro_Pacote = DateTime.Now;

            pacote.Id = new PackageService().InserirPacote(pacote); 

            return pacote;
        }
    */
}
