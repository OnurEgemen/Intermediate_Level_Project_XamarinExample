using OctoberDemo.Model;
using OctoberDemo.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace OctoberDemo.ViewModel
{
    public class ListPageViewModel : BaseViewModel
    {
        public ListPageViewModel()
        {
            jewelries = GetJewelries();
        }


        ObservableCollection<Jewelry> jewelries;

        public ObservableCollection<Jewelry> Jewelries
        {
            get { return jewelries; }
            set
            {
                jewelries = value;
                OnPropertyChanged();
            }

        }

        private Jewelry selectedJewelry;

        public Jewelry SelectedJewelry
        {
            get { return selectedJewelry; }
            set 
            { 
                selectedJewelry = value; 
                OnPropertyChanged(); 
            }
        }

        public ICommand SelectionCommand => new Command(DisplayJewelry);

        private void DisplayJewelry()
        {
            if(selectedJewelry != null)
            {
                var viewModel = new DetailsViewModel { SelectedJewelry = selectedJewelry, Jewelries = jewelries, Position = jewelries.IndexOf(selectedJewelry) };
                var detailsPage = new DetailsPage { BindingContext = viewModel };

                var navigation = Application.Current.MainPage as NavigationPage;
                navigation.PushAsync(detailsPage,true);

            }
        }

        
        private ObservableCollection<Jewelry> GetJewelries()
        {
            return new ObservableCollection<Jewelry>
            {
                new Jewelry{Name = "Silver Ring", Price=1200f, Image="silverRing.jpg", Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit" },
                new Jewelry{Name = "Basic Neckle", Price=700f, Image="basicNeckle.jpg", Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit" },
                new Jewelry{Name = "Gold Ring", Price=9500f, Image="goldRing.jpg", Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit" },
                new Jewelry{Name = "Elegant Neckle", Price=3000f, Image="elegantNeckle.jpg", Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit" },
                new Jewelry{Name = "Pearl Neckle", Price=7600f, Image="pearlNeckle.jpg", Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit" },
                new Jewelry{Name = "Diamond", Price=17000f, Image="diamondRing.jpg", Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit" }
            };
        }


    }
}
