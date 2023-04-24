using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndreTurismo.Models
{
    public class AddressModel
    {
        public int Id { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string CEP { get; set; }
        public string Complemento { get; set; }
        public CityModel Cidade { get; set; }
        public DateTime Data_Cadastro_Endereco { get; set; }

        public override string ToString()
        {
            string enredeco = "\n##### ENDEREÇO #####" +
                              "\nId: " + this.Id +
                              "\nLogradouro: " + this.Logradouro +
                              "\nNumero: " + this.Numero +
                              "\nBairro: " + this.Bairro +
                              "\nCEP: " + this.CEP +
                              "\nComplemento: " + this.Complemento +
                              "\nData de Cadastro do endereço: " + this.Data_Cadastro_Endereco +
                               this.Cidade +
                              "\n";

            return enredeco;
        }

    }
}
