using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndreTurismo.Models
{
    public class PackageModel
    {
        public readonly static string INSERIR_PACOTE =
        "insert into package" +
        "(      hotel_pacote,  passagem_pacote,  data_cadastro_pacote,  valor_pacote,  cliente_pacote)" +
        "values(@Hotel_Pacote, @Passagem_Pacote, @Data_Cadastro_Pacote, @Valor_Pacote, @Cliente_Pacote);" + "select cast(scope_identity() as int);";

        public int Id { get; set; }
        public HotelModel Hotel_Pacote { get; set; }
        public TicketModel Passagem_Pacote { get; set; }
        public DateTime Data_Cadastro_Pacote { get; set; }
        public decimal Valor_Pacote { get; set; }
        public ClientModel Cliente_Pacote { get; set; }

        public override string ToString()
        {
            string pacote = "ID: " + this.Id +
                            "Hotel: " + this.Hotel_Pacote +
                            "Passagem: " + this.Passagem_Pacote +
                            "Data de cadastro do pacote: " + this.Data_Cadastro_Pacote +
                            "Valor do pacote: " + this.Valor_Pacote +
                            "Cliente: " + this.Cliente_Pacote;
            return pacote;
        }
    }
}
