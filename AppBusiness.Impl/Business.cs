using AppBusiness.Interface;
using AppBusiness.Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppBusiness.Impl
{
    public class Business : IBusiness
    {
        
        public IObatService IObatService { get; protected set; }
        public ITransaksiService ITransaksiService { get; protected set; }

        public Business(IObatService iObatService, ITransaksiService itransaksiService)
        {
            IObatService = iObatService;
            ITransaksiService = itransaksiService;
        }
    }
}
