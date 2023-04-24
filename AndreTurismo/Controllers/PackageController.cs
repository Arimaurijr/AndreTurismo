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
            pacote.Id = new PackageService().InserirPacote(pacote);

            return pacote;  
        }
        public List<PackageModel> RetornarPacotePorID(int id_pacote)
        {
            List<PackageModel> lista_pacote = new List<PackageModel>();

            lista_pacote = new PackageService().ListarTodasPacotes();

            return lista_pacote;
        }
    }
}
