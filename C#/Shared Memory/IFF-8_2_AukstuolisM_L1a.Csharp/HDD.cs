using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace IFF_8_2_AukstuolisM_L1a.Csharp
{
    [DataContract]
    public class HDD
    {
        [DataMember]
        public string brand { get; set; }
        [DataMember]
        public int capacity { get; set; }
        [DataMember]
        public double price { get; set; }
    }
}
