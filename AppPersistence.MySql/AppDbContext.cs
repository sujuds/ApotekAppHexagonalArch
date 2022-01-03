using AppPersistence.MySql.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppPersistence.MySql
{
    public class AppDbContext : DbContext
    {
        #region model
        public DbSet<Obat> Obats { get; set; }
        public DbSet<Transaksi> Transaksis { get; set; }
        public DbSet<TransaksiDetail> TransaksiDetails { get; set; }
        #endregion

        //public AppDbContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connString = "server=localhost; port=3306; database=db_apotek; user=root; password=5u7ud100%";
            optionsBuilder.UseMySql(connString, ServerVersion.AutoDetect(connString));

            base.OnConfiguring(optionsBuilder);
        }
    }
}
