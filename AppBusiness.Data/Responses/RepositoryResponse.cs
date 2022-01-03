using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace AppBusiness.Data.Responses
{
    public class RepositoryResponse
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public IEnumerable<dynamic> Data { get; set; } = null;
        public dynamic Value { get; set; } = null;

    }
}
