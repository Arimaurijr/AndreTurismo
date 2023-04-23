using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Turismo.Models
{
    public class CityModel
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime Data_Cadastro_Cidade { get; set; } 
        public override string ToString()
        {
            string cidade = "Id: " + this.Id + 
                            "\nDescrição:" + this.Descricao +
                            "\nData cadastro:" + this.Data_Cadastro_Cidade;
            return cidade;
;        }
    }
}
