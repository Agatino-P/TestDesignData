using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace TestDesignData
{
    public class PersonViewModel : ViewModelBase
    {

        public PersonModel _personModel { get; private set; }
        private string _name; public string Name { get => _name; set => Set(() => Name, ref _name, value); }
        private int _age; public int Age { get => _age; set => Set(() => Age, ref _age, value); }

        private List<string> _strings = new List<string>();
            public List<string> Strings { get => _strings; set { Set(() => Strings, ref _strings, value); }
}

        private RelayCommand<PersonViewModel> _showModek;
        public RelayCommand<PersonViewModel> ShowModel => _showModek ?? (_showModek = new RelayCommand<PersonViewModel>(
            (p) => MessageBox.Show(p._personModel.Agex10.ToString(), p._personModel.Name),
            (p) => p != null,
            keepTargetAlive: true
            ));


        public static PersonViewModel FromPersonModel(PersonModel personModel, bool enableToModel = true)
        {
            PersonViewModel newPersonViewModel = new PersonViewModel();
            if (newPersonViewModel.fromModel(personModel, enableToModel))
            {
                return newPersonViewModel;
            }
            else
            {
                return null;
            }
        }


        public PersonViewModel()
        {
            if (IsInDesignMode)
            {
                fromModel(new PersonModel() { Name = "name", Agex10 = 10 });
                Age = 3;
            }
        }

        //Add #1
        private bool fromModel(PersonModel personModel, bool enableToModel = true)
        {
            _personModel = personModel;
            Name = _personModel.Name;
            Age = _personModel.Agex10 / 10;

            if (IsInDesignMode)
            {
                Strings.Add("stringa1");
                Strings.Add("stringa2");
            }

            if (enableToModel)
                this.PropertyChanged += PersonViewModel_PropertyChanged;
            return true;
        }

        //Add #2
        private void PersonViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            propertyToModel(e.PropertyName);
        }

        //Add #3
        private void propertyToModel(string propertyName)
        {
            switch (propertyName)
            {
                case nameof(Name):
                    _personModel.Name = Name;
                    break;
                case nameof(Age):
                    _personModel.Agex10 = Age * 10;
                    break;
                default:
                    break;
            }
        }

    }
}
