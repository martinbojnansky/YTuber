using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using YTuber.Base;
using YTuber.IoC;

namespace YTuber.Helpers
{
    public class Navigation : IResolvable
    {
        private Frame _frame => (Frame)Window.Current.Content;
        public object NavigationParameter { get; private set; }

        private ICommand _goBackCommand;
        public ICommand GoBackCommand => _goBackCommand ?? (_goBackCommand = new Command(GoBack));

        public void Navigate(Type type, object parameter = null)
        {
            if (_frame != null)
            {
                NavigationParameter = parameter;
                _frame.Navigate(type, parameter);
            }
        }

        public void GoBack()
        {
            if (_frame != null && _frame.CanGoBack)
            {
                NavigationParameter = null;
                _frame.GoBack();
            }
        }
    }
}
