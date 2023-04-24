using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndreTurismo.Models
{
    public class CityModel
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime Data_Cadastro_Cidade { get; set; } 
        public override string ToString()
        {
            string cidade = "\n##### CIDADE #####" +
                            "\nId: " + this.Id +
                            "\nDescrição:" + this.Descricao +
                            "\nData cadastro da cidade:" + this.Data_Cadastro_Cidade + "\n";
            return cidade;
        }
    }
}
