using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dev.Models;
using Microsoft.EntityFrameworkCore;

namespace dev.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}

        public DbSet<ProdutoModel> Produto{get;set;}
    }
}