using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Controls;
using WpfApp_Prakdika.Commands;
using WpfApp_Prakdika.Models;

namespace WpfApp_Prakdika.ViewModels
{



    public class ShowPersonsViewModel
    {
        public ObservableCollection<Person> Persons { get; set; } = new ObservableCollection<Person>();

        public Page Base = new();

        public ReyleCommand BackCommand { get; set; }    


        public ShowPersonsViewModel(ObservableCollection<Person> persons, Page base_)
        {

            BackCommand = new ReyleCommand(_BakeCommand);

            Persons = persons;
            Base = base_;
        }

        public void _BakeCommand(object? parameter)
        {

            Base.NavigationService.GoBack();


            



        }

    }
}
