using AppPersistence.Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppPersistence.Interface
{
    public interface IPersistence
    {
        IObat Obat { get; } 
        ITransaksi Transaksi { get; } 
    }
}
