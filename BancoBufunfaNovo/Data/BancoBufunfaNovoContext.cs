using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BancoBufunfaNovo.Models;

namespace BancoBufunfaNovo.Data
{
    public class BancoBufunfaNovoContext : DbContext
    {
        public BancoBufunfaNovoContext (DbContextOptions<BancoBufunfaNovoContext> options)
            : base(options)
        {
        }

        public DbSet<BancoBufunfaNovo.Models.Cliente> Cliente { get; set; }

        public DbSet<BancoBufunfaNovo.Models.Conta> Conta { get; set; }
    }
}
