using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

using Xamarin.Forms;
using System.Globalization;
using Acr.UserDialogs;

namespace cfiDrive.Shared
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        private static bool _isBusy;
        private string _busyMessage = "Loading...";

        public INavigation Navigation { get; set; }

        public string BusyMessage
        {
            get
            {
                return _busyMessage;
            }
            set
            {
                _busyMessage = value;
                if (IsBusy)
                {
                    UserDialogs.Instance.ShowLoading(BusyMessage, MaskType.Black);
                }
            }
        }

        public BaseViewModel(bool listenCultureChanges = false)
        {
           
        }

        public bool IsBusy
        {
            get
            {
                return _isBusy;
            }
            set
            {
                _isBusy = value;
                try
                {
                    if (_isBusy)
                    {
                        UserDialogs.Instance.ShowLoading(BusyMessage, MaskType.Black);
                    }
                    else
                    {
                        UserDialogs.Instance.HideLoading();


                    }
                }
                catch (Exception ex)
                {   
                    Console.Write(ex.Message);
                }
                OnPropertyChanged();
            }
        }

        protected void NotifyAllPropertiesChanged()
        {
            NotifyPropertyChanged(null);
        }

        protected bool SetProperty<T>(ref T backingStore, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
            {
                return false;
            }

            backingStore = value;
            NotifyPropertyChanged(propertyName);

            return true;
        }

        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        protected virtual void OnCultureChanged(CultureInfo culture)
        {
        }

        


        internal virtual Task Initialize(params object[] args)
        {
            return Task.FromResult(0);
        }


        protected void SetObservableProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
            {
                return;
            }
            field = value;
            OnPropertyChanged(propertyName);
        }

        protected void OnPropertyChanged([CallerMemberName] string property = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));


        #region INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }
}
