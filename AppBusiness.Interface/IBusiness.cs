using AppBusiness.Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppBusiness.Interface
{
    public interface IBusiness
    {
        IObatService IObatService { get; }
        ITransaksiService ITransaksiService { get; }
    }
}
