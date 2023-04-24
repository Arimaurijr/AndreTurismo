using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndreTurismo.Models;
using AndreTurismo.Services;

namespace AndreTurismo.Controllers
{
    public  class CityController
    {
        
        public CityModel Insert(CityModel city)
        {
            city.Id = new CityService().InserirCidade(city); 
            
            return city;

        }
        public CityModel RetornarCidadePorID(int id_cidade) 
        { 
            return new CityService().RetornarCidade(id_cidade);
        }
       
    }
}
