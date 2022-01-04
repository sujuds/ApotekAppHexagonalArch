using AppBusiness.Impl;
using AppBusiness.Impl.Services;
using AppPersistence.Mock;

namespace RestApi.Test
{
    public class BaseTest
    {
        public Business Business { get; set; }
        public BaseTest()
        {
            var tesPersistence = new TestPersistence();

            Business = new Business(
                new ObatService(tesPersistence),
                new TransaksiService(tesPersistence));
        }
    }
}
