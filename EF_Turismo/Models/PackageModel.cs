using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Turismo.Models
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
                            "Hotel: " + this.Hotel_Pacote +
                            "Passagem: " + this.Passagem_Pacote +
                            "Data de cadastro do pacote: " + this.Data_Cadastro_Pacote +
                            "Valor do pacote: " + this.Valor_Pacote +
                            "Cliente: " + this.Cliente_Pacote;
            return pacote;
        }
    }
}
