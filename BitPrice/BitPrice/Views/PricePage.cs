using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Acr.UserDialogs;
using BitPrice.Models;
using BitPrice.Services;
using BitPrice.ViewModels;

using Xamarin.Forms;

namespace BitPrice.Views
{
	public class PricePage : ContentPage
	{
        List<CryptoPrices> prices;
        CryptoPriceService service;
        Label info;
        ListView listado;
        public PricePage ()
		{
            service = new CryptoPriceService();
            prices = new List<CryptoPrices>();
            GetPrice();
		}

        private async void GetPrice()
        {
            try {
                UserDialogs.Instance.ShowLoading("Por favor espere...", MaskType.Black);
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
                UserDialogs.Instance.HideLoading();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("ERROR CATCH: " + ex.Message);
            }            
        }

        private void LlenarGrid(List<CryptoPrices> prices)
        {
            listado = new ListView
            {
                ItemTemplate = new DataTemplate(typeof(PricesGridModel)),
                ItemsSource = prices
        };

            Content = new ScrollView
            {
                Content = new StackLayout
                {
                    Children = {
                        listado
                    }
                }
            };
        }
	}
}