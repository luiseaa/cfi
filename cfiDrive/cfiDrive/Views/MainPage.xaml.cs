using cfiDrive.ViewModels;
using Xamarin.Forms;

namespace cfiDrive.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel();

        }
    }
}
