using System;
using System.Collections.Generic;
using System.Text;
using YTuber.Helpers;
using YTuber.IoC;

namespace YTuber.Services.Help
{
    public class HelpService : IResolvable
    {

        private const string VERSION = "Version";
        private const string HELP_VERSION = "Help01";
        private const string HELP_CONTAINER = "Help";

        public LocalSettings LocalSettings { get; set; }
        public Navigation Navigation { get; set; }

        public bool ShowHelp()
        {

            try
            {
                if ((string)LocalSettings.GetValue(VERSION, HELP_CONTAINER) != HELP_VERSION)
                {
                    throw new Exception();
                }

                return false;
            }
            catch
            {
                LocalSettings.SetValue(VERSION, HELP_VERSION, HELP_CONTAINER);
                Navigation.Navigate(typeof(Views.Help.HelpView));

                return true;
            }
        }
    }
}
