using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using AndreTurismo.Models;
using AndreTurismo.Services;

namespace AndreTurismo.Controllers
{
    public  class CityController
    {
        public bool InsertCidade(CityModel city)
        {
            bool status = true;

            try
            {
                new CityService().InserirCidade(city);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
           
           return status;
            
        }
        public CityModel RetornarCidadePorID(int id_cidade)
        {
            CityModel cidade = new CityModel();  
            
            try
            {
                cidade = new CityService().RetornarCidade(id_cidade);
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }

            return cidade;
        }
    }
}
