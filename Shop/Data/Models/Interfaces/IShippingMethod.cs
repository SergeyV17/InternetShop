using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Models.Interfaces
{
    public interface IShippingMethod
    {
        public string Name { get;  }
        public decimal Value { get;  }
    }
}
