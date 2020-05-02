using GalaSoft.MvvmLight;
using System.ComponentModel;
using System.Windows;

namespace TestDesignData
{
    public class MainWindowViewModel : ViewModelBase
    {
        private BindingList<PersonViewModel> _persons = new BindingList<PersonViewModel>();
        public BindingList<PersonViewModel> Persons { get => _persons; set => Set(() => Persons, ref _persons, value); }

        public MainWindowViewModel()
        {
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
                {
                Persons.Add(PersonViewModel.FromPersonModel(new PersonModel() { Agex10 = 11, Name = "Duno" }));
                Persons.Add(PersonViewModel.FromPersonModel(new PersonModel() { Agex10 = 21, Name = "Ddue" }));

            }
            else
            {

                Persons.Add(PersonViewModel.FromPersonModel(new PersonModel() { Agex10 = 10, Name = "uno" }));
                Persons.Add(PersonViewModel.FromPersonModel(new PersonModel() { Agex10 = 20, Name = "due" }));
                Persons.Add(PersonViewModel.FromPersonModel(new PersonModel() { Agex10 = 30, Name = "tre" }));
                Persons.Add(PersonViewModel.FromPersonModel(new PersonModel() { Agex10 = 40, Name = "quattro" }));
                Persons.Add(PersonViewModel.FromPersonModel(new PersonModel() { Agex10 = 50, Name = "cinque" }));
            }


        }
    }
}
