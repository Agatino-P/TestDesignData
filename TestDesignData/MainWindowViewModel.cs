using GalaSoft.MvvmLight;
using System.ComponentModel;
using System.Windows;

namespace TestDesignData
{
    public class MainWindowViewModel : ViewModelBase
    {
        private BindingList<PersonViewModel> _persons = new BindingList<PersonViewModel>();
        public BindingList<PersonViewModel> Persons { get => _persons; set => Set(() => Persons, ref _persons, value); }

        private BindingList<PersonModel> _personMs = new BindingList<PersonModel>();
        public BindingList<PersonModel> PersonMs { get => _personMs; set => Set(() => PersonMs, ref _personMs, value); }

        public MainWindowViewModel()
        {
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
                {
                Persons.Add(PersonViewModel.FromPersonModel(new PersonModel() { Agex10 = 11, Name = "Duno" }));
                Persons.Add(PersonViewModel.FromPersonModel(new PersonModel() { Agex10 = 21, Name = "Ddue" }));

            }
            else
            {
                PersonModel newPersonModel = new PersonModel() { Agex10 = 10, Name = "uno" };
                PersonMs.Add(newPersonModel);
                Persons.Add(PersonViewModel.FromPersonModel(newPersonModel));

                newPersonModel = new PersonModel() { Agex10 = 20, Name = "due" };
                PersonMs.Add(newPersonModel);
                Persons.Add(PersonViewModel.FromPersonModel(newPersonModel));
            }


        }
    }
}
