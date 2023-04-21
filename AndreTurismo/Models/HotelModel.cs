using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndreTurismo.Models
{
    public class HotelModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public AddressModel Endereco { get; set; }
        public DateTime Data_Cadastro_Hotel { get; set; }
        public decimal Valor_Hotel { get; set; }

        public override string ToString()
        {
            string hotel = "ID: " + this.Id +
                            "\nNome: " + this.Nome +
                            "\nEndereço: " + this.Endereco +
                            "\nData de cadastro: " + this.Data_Cadastro_Hotel +
                            "\nValor: " + this.Valor_Hotel;
            return hotel;
        }
    }
}
