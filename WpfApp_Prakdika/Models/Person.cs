using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp_Prakdika.Models
{
    public class Person : Notficetion
    {
        private int id1;
        private string name1;
        private string username1;
        private string email1;
        private Adres address1;
        private string website1;
        private Companiy company1;

        public int id { get => id1; set { id1 = value; OnPrCh(); } }
        public string name { get => name1; set { name1 = value; OnPrCh(); } }
        public string username { get => username1; set { username1 = value; OnPrCh(); } }
        public string email { get => email1; set { email1 = value; OnPrCh(); } }
        public Adres address { get => address1; set { address1 = value; OnPrCh(); } }
        public string website { get => website1; set { website1 = value; OnPrCh(); } }
        public Companiy company { get => company1; set { company1 = value; OnPrCh(); } }



        public override string ToString()
        {
            return name;
        }



    }
}
