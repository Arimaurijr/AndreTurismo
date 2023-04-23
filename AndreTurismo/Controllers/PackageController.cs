using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndreTurismo.Models;
using AndreTurismo.Services;

namespace AndreTurismo.Controllers
{

    public class PackageController
    {
        public PackageModel InsertPacote(PackageModel pacote)
        {
            try
            {
                pacote = new PackageService().InserirPacote(pacote);
            }
            catch 
            {
                Console.WriteLine("Não foi possível inserir o pacote");
            }

            return pacote;
        }
    }
         
}
