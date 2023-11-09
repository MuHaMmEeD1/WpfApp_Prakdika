using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Controls;
using WpfApp_Prakdika.Commands;
using WpfApp_Prakdika.Models;
using WpfApp_Prakdika.Views;

namespace WpfApp_Prakdika.ViewModels
{
    public class AddViewModel : Notficetion
    {
        public ObservableCollection<Person> Persons { get; set; }
        public Person Person { get; set; }

        public ReyleCommand AddCommand { get; set; }
        public ReyleCommand BackCommand { get; set; }


        Page Base;


        public AddViewModel(ObservableCollection<Person> Persons, Page page)
        {

            Base = page;

            BackCommand = new ReyleCommand(_BazeCommand);

            AddCommand = new ReyleCommand(_AddPerson, _CanAddPerson);


            Person = new Person() { address = new Adres(), company = new Companiy() };
            this.Persons = Persons;
        }

       



        public void _BazeCommand(object? parameter)
        {

            Base.NavigationService.GoBack();


            File.WriteAllText("../../../DataBase/persons.json", JsonSerializer.Serialize(Persons, new JsonSerializerOptions() { WriteIndented = true }));



        }



        public bool _CanAddPerson(object? parameter)
        {
            var pg = parameter as AddView;

            if(pg?._1.Text.Length != 0 && pg?._2.Text.Length != 0 && pg?._3.Text.Length != 0 && pg?._4.Text.Length != 0 && pg?._5.Text.Length != 0 && pg?._6.Text.Length != 0 && pg?._7.Text.Length != 0 && pg?._8.Text.Length != 0 && pg?._9.Text.Length != 0) { return true; }


            return false;
        }


        public void _AddPerson(object? parameter)
        {

            Persons.Add(Person);
            Person = new Person() { address = new Adres(), company = new Companiy() };
            OnPrCh(nameof(Person));
        }







    }
}
