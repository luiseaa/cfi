using System;
using System.Collections.Generic;
using cfiDrive.ViewModels;
using Xamarin.Forms;

namespace cfiDrive.Views
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            BindingContext = new HomePageViewModel();
        }
    }
}
