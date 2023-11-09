using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp_Prakdika.Models
{
    public class Companiy : Notficetion
    {
        private string name1;
        private string bs1;

        public string name { get => name1; set { name1 = value; OnPrCh(); } }
        public string bs { get => bs1; set { bs1 = value; OnPrCh(); } }



    }
}
