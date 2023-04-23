using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndreTurismo.Models;
using AndreTurismo.Services;

namespace AndreTurismo.Controllers
{
    public class TicketController
    {
          public TicketModel InsertPassagem(TicketModel passagem)
          {
                try
                {
                    passagem = new TicketService().InserirPassagem(passagem);
                }
                catch 
                {
                    Console.WriteLine("Não foi possível inserir a passagem");
                }

                return passagem;
          }
          public TicketModel RetornarPassagemPorID(int id_passagem)
          {
             TicketModel passagem = new TicketModel();
             
              passagem = new TicketService().RetornarPassagem(id_passagem);

            return passagem;
          }
    }   
}
