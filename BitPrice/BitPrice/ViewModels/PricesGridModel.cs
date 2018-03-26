using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace BitPrice.ViewModels
{
	public class PricesGridModel : ViewCell
    {
        Grid InfoGrid;
        Label Symbol;
        Label Rank;
        Label PriceUSD;
        Label Porcent;
        public PricesGridModel ()
		{
            InfoGrid = new Grid()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            InfoGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
            InfoGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            InfoGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            InfoGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            InfoGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            Symbol = new Label()
            {
                WidthRequest = 50,
                HeightRequest = 30
            };
            Symbol.SetBinding(Label.TextProperty, "symbol");

            Rank = new Label()
            {

                WidthRequest = 50,
                HeightRequest = 30
            };
            Rank.SetBinding(Label.TextProperty, "rank");

            PriceUSD = new Label()
            {
                WidthRequest = 50,
                HeightRequest = 30
            };
            PriceUSD.SetBinding(Label.TextProperty, "price_usd");

            Porcent = new Label()
            {
                WidthRequest = 50,
                HeightRequest = 30
            };
            Porcent.SetBinding(Label.TextProperty, "percent_change_24h");

            InfoGrid.Children.Add(Symbol, 0, 0);
            InfoGrid.Children.Add(Rank, 1, 0);
            InfoGrid.Children.Add(PriceUSD, 2, 0);
            InfoGrid.Children.Add(Porcent, 3, 0);
            View = new StackLayout {
				Children = {
					InfoGrid
				}
			};
		}
	}
}