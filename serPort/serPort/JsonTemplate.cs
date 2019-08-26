using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace serPort
{
    class JsonTemplate
    {
        public string title { get; set; }
        public string startTemperature { get; set; }
        public string stopTemperature { get; set; }
        public string checkType { get; set; }
        public string sto { get; set; }
        public string str1 { get; set; }
        public string strMax { get; set; }
        public string hysteresis { get; set; }
        public string rate { get; set; }
        public string indicators { get; set; }
        public string atEndGoTo { get; set; }
        public string stamp { get; set; }
    }
}
