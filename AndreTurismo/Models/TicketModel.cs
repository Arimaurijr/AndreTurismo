﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndreTurismo.Models
{
    public class TicketModel
    {
        public int Id { get; set; } 
        public AddressModel Origem { get; set; }
        public AddressModel Destino { get; set; }
        public ClientModel Cliente { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor_Passagem { get; set; }

        public override string ToString()
        {
            string passagem = "ENDERECO ORIGEM: " + this.Origem +
                             "ENDERECO DESTINO: " + this.Destino +
                              this.Cliente +
                             "\nData registro da passagem: " + this.Data +
                             "\nValor da passagem: " + this.Valor_Passagem;
            return passagem;
        }
    }
}
