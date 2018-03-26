using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BitPrice.Models;
using BitPrice.Services;

using Xamarin.Forms;

namespace BitPrice.Views
{
	public class PricePage : ContentPage
	{
        List<CryptoPrices> prices;
        CryptoPriceService service;
        Label info;
        Grid InfoGrid;
        public PricePage ()
		{
            service = new CryptoPriceService();
            prices = new List<CryptoPrices>();
            GetPrice();
		}

        private async void GetPrice()
        {
            try {
                prices = await service.GetPrices();
                if (prices.Count > 0)
                {
                    LlenarGrid(prices);
                }
                else
                {
                    info = new Label
                    {
                        Text = "NO INFO",
                        BackgroundColor = Color.FromHex("#f0d01b")
                    };
                    Content = new StackLayout
                    {
                        Children = {
                        info
                    }
                    };
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("ERROR CATCH: " + ex.Message);
            }            
        }

        private void LlenarGrid(List<CryptoPrices> prices)
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
            foreach (CryptoPrices data in prices)
            {
                InfoGrid.Children.Add(new Label
                {
                    TextColor = Color.Black,
                    Text = data.symbol
                }, 0, 1, 0, 1);
                InfoGrid.Children.Add(new Label
                {
                    TextColor = Color.Black,
                    Text = data.rank
                }, 0, 1, 0, 2);
                InfoGrid.Children.Add(new Label
                {
                    TextColor = Color.Black,
                    Text = data.price_usd
                }, 0, 1, 0, 3);
                InfoGrid.Children.Add(new Label
                {
                    TextColor = Color.Black,
                    Text = data.percent_change_24h
                }, 0, 1, 0, 4);
            }
            Content = new ScrollView
            {
                Content = new StackLayout
                {
                    Children = {
                        InfoGrid
                    }
                }
            };
        }
	}
}