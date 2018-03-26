using System;
using BitPrice.Views;
using Xamarin.Forms;

namespace BitPrice
{
	public partial class App : Application
	{

        public static void SetMainPage(Page pegein = null)
        {
            if (pegein != null)
            {
                App.Current.MainPage = pegein;
            }
        }

        public App ()
		{
			InitializeComponent();


            MainPage = new SplashPage();
        }

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
