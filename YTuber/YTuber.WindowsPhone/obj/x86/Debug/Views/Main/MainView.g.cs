﻿

#pragma checksum "C:\Users\marti\documents\visual studio 2015\Projects\YTuber\YTuber\YTuber.Shared\Views\Main\MainView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "06E8AA1E2516AB75654A2F070D41D73E"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace YTuber.Views.Main
{
    partial class MainView : global::YTuber.Base.NavigationPage, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 164 "..\..\..\..\Views\Main\MainView.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).Tapped += this.LightDismiss_Tapped;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 178 "..\..\..\..\Views\Main\MainView.xaml"
                ((global::Windows.UI.Xaml.Controls.ListViewBase)(target)).ItemClick += this.Menu_ItemClick;
                 #line default
                 #line hidden
                break;
            case 3:
                #line 100 "..\..\..\..\Views\Main\MainView.xaml"
                ((global::Windows.UI.Xaml.Controls.WebView)(target)).NavigationStarting += this.YoutubeWebView_NavigationStarting;
                 #line default
                 #line hidden
                #line 101 "..\..\..\..\Views\Main\MainView.xaml"
                ((global::Windows.UI.Xaml.Controls.WebView)(target)).FrameNavigationCompleted += this.YoutubeWebView_NavigationCompleted;
                 #line default
                 #line hidden
                #line 102 "..\..\..\..\Views\Main\MainView.xaml"
                ((global::Windows.UI.Xaml.Controls.WebView)(target)).NavigationCompleted += this.YoutubeWebView_NavigationCompleted;
                 #line default
                 #line hidden
                #line 103 "..\..\..\..\Views\Main\MainView.xaml"
                ((global::Windows.UI.Xaml.Controls.WebView)(target)).NavigationFailed += this.YoutubeWebView_NavigationFailed;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}


