using OctoberDemo.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace OctoberDemo.ViewModel
{
    public class DetailsViewModel : BaseViewModel
    {
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

        private int position;
        
        public int Position
        {
            get 
            {
                if(position != jewelries.IndexOf(selectedJewelry))
                    return jewelries.IndexOf(selectedJewelry);
                return position;
            }
            set
            {
                position = value;
                selectedJewelry = jewelries[position];

                OnPropertyChanged();
                OnPropertyChanged(nameof(SelectedJewelry));
            }
        }


        public ICommand ChangePositionCommand => new Command(ChangePosition);

        private void ChangePosition(object obj)
        {
            string direction=(string)obj;

            if(direction=="L")
            {
                if (Position == 0)
                {
                    Position = jewelries.Count - 1;
                    return;
                }

                Position -= 1;
            }
            else if (direction=="R")
            {
                if(Position == jewelries.Count - 1)
                {
                    Position = 0;
                    return;
                }
                Position +=1;
            }
        }



    }
}
