using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;

namespace YTuber.Base
{
    public class NavigationLink
    {
        public Symbol Symbol { get; set; }
        public string Title { get; set; }
        public Type PageType { get; set; }

        public NavigationLink() { }
        public NavigationLink(Symbol symbol, string title, Type pageType)
        {
            Symbol = symbol;
            Title = title;
            PageType = pageType;
        }
    }
}
