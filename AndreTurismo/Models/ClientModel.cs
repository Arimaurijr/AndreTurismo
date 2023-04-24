using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndreTurismo.Models
{
    public class ClientModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public AddressModel Endereco { get; set; }
        public DateTime Data_Cadastro_Cliente { get; set; }

        public override string ToString()
        {
            string cliente = "\n##### CLIENTE #####" +
                            "\nID: " + this.Id +
                            "\nNome: " + this.Nome +
                            "\nTelefone: " + this.Telefone +
                            "\nData de cadastro do cliente: " + this.Data_Cadastro_Cliente +
                             this.Endereco;
            return cliente;
        }
    }
}
