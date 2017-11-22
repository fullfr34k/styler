using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace styler
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {
        public MapPage()
        {
            InitializeComponent();

            var map = new Map(
                MapSpan.FromCenterAndRadius(
                    new Position(6.45, 3.433333), Distance.FromMiles(0.3)))
            {
                IsShowingUser = true,
                HeightRequest = 100,
                WidthRequest = 960,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            var stack = new StackLayout { Spacing = 0 };
            stack.Children.Add(map);
            Content = stack;

            var slider = new Slider(1, 18, 1);
            slider.ValueChanged += (sender, e) =>
            {
                var zoomLevel = e.NewValue; // between 1 and 18
                var latlongdegrees = 360 / (Math.Pow(2, zoomLevel));
                map.MoveToRegion(new MapSpan(map.VisibleRegion.Center, latlongdegrees, latlongdegrees));
            };

            var position = new Position(6.45, 3.433333);
            var pin = new Pin
            {
                Type = PinType.Place,
                Position = position,
                Label = "OutMall Plaza, Okorie Victor",
                Address = "No. 54 Wole Olateju street, Lekki phase one, Lagos"
            };
            map.Pins.Add(pin);

            var position2 = new Position(6.46, 3.601521);
            var pin2 = new Pin
            {
                Type = PinType.Place,
                Position = position2,
                Label = "De-Shoppe, Chidinma Isiadinso",
                Address = "No. 17 Bourdillon road, Ikoyi, Lagos"
            };
            map.Pins.Add(pin2);

            pin.Clicked += Pin_Clicked;
            pin2.Clicked += Pin_Clicked;
        }

        private void Pin_Clicked(object sender, EventArgs e)
        {
            var selectedPin = sender as Pin;

            DisplayAlert(selectedPin?.Label, selectedPin?.Address, "Ok");
        }
    }
}
