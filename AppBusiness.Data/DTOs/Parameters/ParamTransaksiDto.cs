using System;
using System.Collections.Generic;
using System.Text;

namespace AppBusiness.Data.DTOs.Parameters
{
    public class ParamTransaksiDto
    {
        public int? Id { get; set; }
        public string Kode { get; set; }
        public IEnumerable<ParamTransaksiDetailDto> TransaksiDetails { get; set; }
    }

    public class ParamTransaksiDetailDto
    {
        public int? Id { get; set; }
        public int? Jumlah { get; set; }
        public ParamObatDto Obat { get; set; }
    }
}
