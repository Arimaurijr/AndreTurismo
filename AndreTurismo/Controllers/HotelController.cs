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
        public HotelModel InsertHotel(HotelModel hotel)
        {
            try
            {
                hotel = new HotelService().InserirHotel(hotel);
            }
            catch 
            {
                Console.WriteLine("Não foi possível inserir o hotel");
            }
            return hotel;
        }
        public HotelModel RetornarHotelPorId(int id_hotel) 
        {
            HotelModel hotel = new HotelModel();    
            try
            {
                hotel = new HotelService().RetornarHotel(id_hotel); 
            }
            catch 
            {
                Console.WriteLine("Não foi possível retornar nenhum hotel");
            }

            return hotel;
        }
    }
    
}
