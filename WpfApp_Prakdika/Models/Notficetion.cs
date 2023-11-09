using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp_Prakdika.Models
{
    public class Notficetion :INotifyPropertyChanged

    {






        public void OnPrCh([CallerMemberName] string? name = null)
        {


            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        }


        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
