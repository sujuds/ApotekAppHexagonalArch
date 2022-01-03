using System;
using System.Collections.Generic;
using System.Text;

namespace AppPersistence.MySql.Models
{
    public class Transaksi
    {
        public int? Id { get; set; }
        public string Kode { get; set; }
        public int? Total { get; set; }
        public virtual ICollection<TransaksiDetail> TransaksiDetails { get; set; }
    }

    public class TransaksiDetail
    {
        public int? Id { get; set; }
        public int? TransaksiId { get; set; }
        public Transaksi Transaksi { get; set; }
        public int? ObatId { get; set; }
        public Obat Obat { get; set; }
        public int? Jumlah { get; set; }
    }
}
