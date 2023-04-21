using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndreTurismo.Models;
using AndreTurismo.Services;

namespace AndreTurismo.Controllers
{
    public class HotelController
    {
        public HotelModel InsertHotel()
        {
            HotelModel hotel = new HotelModel();
            
            Console.WriteLine("Digite o nome do hotel");
            hotel.Nome = Console.ReadLine();

            Console.WriteLine("Digite o valor da diária");
            hotel.Valor_Hotel = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Digite o endereço do hotel");
            hotel.Endereco = new AddressController().Insert();

            hotel.Data_Cadastro_Hotel = DateTime.Now;

            hotel.Id = new HotelService().InserirHotel(hotel);

            return hotel;
        }
    }
}
