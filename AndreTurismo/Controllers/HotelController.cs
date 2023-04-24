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
            hotel.Id = new HotelService().InserirHotel(hotel);
            return hotel;
        }
        public HotelModel RetornarHotelPorID(int id_hotel)
        {
            HotelModel hotel = new HotelModel();
            
            hotel = new HotelService().RetornarHotel(id_hotel);

            return hotel;
        }
    }
}
