using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp_Prakdika.Models
{
    public class Adres : Notficetion
    {

        private string _street;
        private string city1;

        public string street
        {
            get { return _street; }
            set { _street = value; OnPrCh(); }
        }

        public string city { get => city1; set { city1 = value; OnPrCh(); } }




    }
}
