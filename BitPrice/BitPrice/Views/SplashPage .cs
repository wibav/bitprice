using BitPrice;
using BitPrice.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Chappsy.Views
{
	public class SplashPage  : ContentPage
	{
        Image splashImage;

        public SplashPage  ()
		{
            NavigationPage.SetHasNavigationBar(this, false);
            var sub = new AbsoluteLayout();
            splashImage = new Image
            {
                Source = FileImageSource.FromResource("BitPrice.Img.Splash.jpg"),
                //WidthRequest = 100,
                //HeightRequest = 100
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            AbsoluteLayout.SetLayoutFlags(splashImage, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(splashImage, new Rectangle(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

            sub.Children.Add(splashImage);

            this.BackgroundColor = Color.FromHex("#afafaf");
            //this.BackgroundColor = Color.Red;
            this.Content = sub;
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await splashImage.ScaleTo(3, 2000); //Time-consuming processes such as initialization
            await splashImage.ScaleTo(2.5, 1500, Easing.Linear);
            //await splashImage.ScaleTo(3, 2000); //Time-consuming processes such as initialization
            //await splashImage.ScaleTo(2.5, 1500, Easing.Linear);


            //await splashImage.ScaleTo(150, 1200, Easing.Linear);
            App.SetMainPage(new MainPage());
            //Application.Current.MainPage = new NavigationPage(new StartPage());    //After loading  MainPage it gets Navigated to our new Page
        }
    }
}