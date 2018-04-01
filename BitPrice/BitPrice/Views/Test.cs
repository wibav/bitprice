using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace BitPrice.Views
{
	public class Test : ContentPage
	{
        Frame Verde;
        Frame Rojo;
        Label Moneda;
        Label price;
        Grid Caja;
		public Test ()
		{
            Moneda = new Label
            {
                Text = "BTC / USD",
                TextColor = Color.Red,
                BackgroundColor = Color.White,
            };
            price = new Label
            {
                Text = "9800",
                TextColor = Color.Black,
                BackgroundColor = Color.White                
            }
            Verde = new Frame
            {
                Content = Moneda,
                HasShadow = true
            };

            Caja = new Grid
            {
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            Caja.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
            Caja.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
            Caja.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            Caja.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            Caja.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            Caja.Children.Add(Verde, 0, 0);
            Caja.Children.Add(Verde, 1, 0);
            Caja.Children.Add(Verde, 2, 1);
            Content = new StackLayout {
				Children = {
				    Caja                    
				}
			};
		}
	}
}