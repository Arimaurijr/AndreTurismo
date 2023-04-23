using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EF_Turismo.Models;

namespace EF_Turismo.Data
{
    public class EF_TurismoContext : DbContext
    {
        public EF_TurismoContext (DbContextOptions<EF_TurismoContext> options)
            : base(options)
        {
        }

        public DbSet<EF_Turismo.Models.CityModel> CityModel { get; set; } = default!;

        public DbSet<EF_Turismo.Models.AddressModel>? AddressModel { get; set; }

        public DbSet<EF_Turismo.Models.ClientModel>? ClientModel { get; set; }

        public DbSet<EF_Turismo.Models.HotelModel>? HotelModel { get; set; }

        public DbSet<EF_Turismo.Models.TicketModel>? TicketModel { get; set; }

        public DbSet<EF_Turismo.Models.PackageModel>? PackageModel { get; set; }
    }
}
