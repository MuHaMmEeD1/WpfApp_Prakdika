using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Controls;
using WpfApp_Prakdika.Commands;
using WpfApp_Prakdika.Models;
using WpfApp_Prakdika.Views;

namespace WpfApp_Prakdika.ViewModels
{
    public class EditViewModel : Notficetion
    {
        public ObservableCollection<Person> Persons { get; set; }
        public Person Person { get; set; }

        public ReyleCommand EditCommand { get; set; }
        public ReyleCommand BackCommand { get; set; }


        Page Base;

        int index = 0;

        public EditViewModel(ObservableCollection<Person> Persons, Page page, int index)
        {

            Base = page;

            BackCommand = new ReyleCommand(_BazeCommand);

            EditCommand = new ReyleCommand(_EditPerson, _CanAddPerson);


            Person = new Person() { address = new Adres(), company = new Companiy() };
            this.Persons = Persons;
            this.index = index;

            Person.id = Persons[index].id;
            Person.name = Persons[index].name;
            Person.username = Persons[index].username;
            Person.email = Persons[index].email;
            Person.address = new Adres() { street = Persons[index].address.street , city = Persons[index].address.city };
           
            Person.website = Persons[index].website;
            Person.company= new Companiy() { name = Persons[index].company.name, bs = Persons[index].company.bs };
           
            
        }





        public void _BazeCommand(object? parameter)
        {

            Base.NavigationService.GoBack();


            File.WriteAllText("../../../DataBase/persons.json", JsonSerializer.Serialize(Persons, new JsonSerializerOptions() { WriteIndented = true }));



        }



        public bool _CanAddPerson(object? parameter)
        {
            var pg = parameter as AddView;

            if (pg?._1.Text.Length != 0 && pg?._2.Text.Length != 0 && pg?._3.Text.Length != 0 && pg?._4.Text.Length != 0 && pg?._5.Text.Length != 0 && pg?._6.Text.Length != 0 && pg?._7.Text.Length != 0 && pg?._8.Text.Length != 0 && pg?._9.Text.Length != 0) { return true; }


            return false;
        }


        public void _EditPerson(object? parameter)
        {

            Persons[index] = Person;
          
        }







    }
}
