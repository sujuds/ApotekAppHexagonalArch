using System;
using System.Collections.Generic;
using System.Text;

namespace AppPersistence.MySql.Models
{
    public class Obat
    {
        public int? Id { get; set; }
        public string Kode { get; set; }
        public string Nama { get; set; }
        public int? Stok { get; set; }
        public int? Harga { get; set; }
        public string Foto { get; set; }
    }
}
