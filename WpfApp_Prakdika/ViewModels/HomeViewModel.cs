using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Navigation;
using WpfApp_Prakdika.Commands;
using WpfApp_Prakdika.Models;
using WpfApp_Prakdika.Views;

namespace WpfApp_Prakdika.ViewModels
{
    public class HomeViewModel : Notficetion
    {

        public ReyleCommand AddCommand { get; set; }
        public ReyleCommand RemoveCommand { get; set; }
        public ReyleCommand EditCommand { get; set; }
        public ReyleCommand ShowCommand { get; set; }

        public ObservableCollection<Person> Persons { get; set; } = new ObservableCollection<Person>();


        Page? Base;

        public HomeViewModel(Page page)
        {
          
            AddCommand = new ReyleCommand(_AddCommand, _CanAddCommand);

            RemoveCommand = new ReyleCommand(_RemoveRerson, _CanRemoveRerson);

            EditCommand = new ReyleCommand(_EditRerson, _CanEditRerson);

            ShowCommand = new ReyleCommand(_ShowCommand, _CanShowCommand);

            Persons = JsonSerializer.Deserialize<ObservableCollection<Person>>(File.ReadAllText("../../../DataBase\\persons.json"))!;

            Base = page;



        }



        public bool _CanAddCommand(object? pra)
        {
            return true;

        }

        public void _AddCommand(object? pra)
        {
            AddView addPage = new AddView();

            addPage.DataContext = new AddViewModel(Persons, addPage);

            Base?.NavigationService.Navigate(addPage);

        }


        public bool _CanRemoveRerson(object? pra) {

            int? index = pra as int?;

            if(index != null && index != -1) { return true; }


            return false;
        
        }

        public void _RemoveRerson(object? pra)
        {
            int? index = pra as int?;

            Persons.RemoveAt(Convert.ToInt32(index));

            File.WriteAllText("../../../DataBase/persons.json", JsonSerializer.Serialize(Persons, new JsonSerializerOptions() { WriteIndented = true }));

        }



        public bool _CanEditRerson(object? pra)
        {

            int? index = pra as int?;

            if (index != null && index != -1) { return true; }


            return false;

        }

        public void _EditRerson(object? pra)
        {
            int? index = pra as int?;

            EditView editView = new EditView();

            editView.DataContext = new EditViewModel(Persons, editView, Convert.ToInt32(index));

            Base?.NavigationService.Navigate(editView);
        }



        public bool _CanShowCommand(object? pra)
        {
            return true;
        }


        public void _ShowCommand(object? pra)
        {
            ShowPersonsView showView = new ShowPersonsView();

            showView.DataContext = new ShowPersonsViewModel(Persons , showView);

            Base?.NavigationService.Navigate(showView);
        }




    }
}
