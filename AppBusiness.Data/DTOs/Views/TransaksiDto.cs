﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AppBusiness.Data.DTOs.Views
{
    public class TransaksiDto
    {
        public int? Id { get; set; }
        public string Kode { get; set; }
        public int? Total { get; set; }
        public IEnumerable<TransaksiDetailDto> TransaksiDetails { get; set; }
    }

    public class TransaksiDetailDto
    {
        public int? Id { get; set; }
        public int? Jumlah { get; set; }
        public ObatDto Obat { get; set; }
    }
}
