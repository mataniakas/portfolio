using System;
using System.Collections.Generic;
using System.Text;

namespace IFF_8_2_AukstuolisM_L1a.Csharp
{
    class HDDWithComputedValue
    {
        public HDD item { get; set; }
        public double computedData { get; set; }
        public HDDWithComputedValue(HDD _item)
        {
            item = _item;
            computedData = (item.capacity * item.price);
        }
    }
}
