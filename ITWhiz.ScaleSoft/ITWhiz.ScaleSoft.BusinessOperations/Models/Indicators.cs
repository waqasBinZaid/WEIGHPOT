using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITWhiz.ScaleSoft.BusinessOperations.Models
{
   public class Indicators : Base
    {
        public int ID { get; set; }
        public string Brand { get; set; }
        public string ModelNo { get; set; }
        public int BaudRate { get; set; }
        public int DataBit { get; set; }
        public int Parity { get; set; }
        public int StopBit { get; set; }
        public string Direction { get; set;}
        public int FromBytes { get; set;}
        public int BytesLength { get; set;}
        public int ControlCharacter { get; set;}

    }
}
