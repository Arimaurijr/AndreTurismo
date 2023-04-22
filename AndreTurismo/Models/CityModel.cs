using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndreTurismo.Models
{

    public class CityModel
    {
        public readonly static string INSERT = "insert into city(descricao,data_cadastro_cidade) VALUES(@descricao, @data_cadastro_cidade);" + "select cast(scope_identity() as int);";

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
