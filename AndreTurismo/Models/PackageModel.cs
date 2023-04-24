using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndreTurismo.Models
{
    public class PackageModel
    {
        public int Id { get; set; }
        public HotelModel Hotel_Pacote { get; set; }
        public TicketModel Passagem_Pacote { get; set; }
        public DateTime Data_Cadastro_Pacote { get; set; }
        public decimal Valor_Pacote { get; set; }
        public ClientModel Cliente_Pacote { get; set; }

        public override string ToString()
        {
            string pacote = "ID: " + this.Id +
                             this.Hotel_Pacote +
                             this.Passagem_Pacote +
                             this.Cliente_Pacote +
                            "Data de cadastro do pacote: " + this.Data_Cadastro_Pacote +
                            "\nValor do pacote: " + this.Valor_Pacote;
            return pacote;
        }
    }
}
