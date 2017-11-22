using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace styler
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            //var location = locationPicker.Navigation;
            //var style = stylePicker.Navigation;
            var location = locationPicker.Items[locationPicker.SelectedIndex];

            if (location == "Lekki")
            {
                await Navigation.PushAsync(new MapPage2());
            }

            else if (location == "Ikoyi")
            {
                await Navigation.PushAsync(new MapPage());
            }
            
            
        }
    }
}
