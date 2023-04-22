using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndreTurismo.Models
{
    public class TicketModel
    {
        public readonly static string INSERIR_PASSAGEM =
        "insert into passagem" +
        "(endereco_origem, endereco_destino, cliente_passagem, data_cadastro_passagem, valor_passagem)" +
        "values(@Origem,    @Destino,            @Cliente,        @Data,                  @Valor_Passagem)" + "select cast(scope_identity() as int);";


        public int Id { get; set; } 
        public AddressModel Origem { get; set; }
        public AddressModel Destino { get; set; }
        public ClientModel Cliente { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor_Passagem { get; set; }

        public override string ToString()
        {
            string passagem = "Origem: " + this.Origem +
                              "Destino: " + this.Destino +
                              "Cliente: " + this.Cliente +
                              "Data: " + this.Data +
                              "Valor: " + this.Valor_Passagem;
            return passagem;
        }
    }
}
