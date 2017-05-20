using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using YTuber.IoC;

namespace YTuber.Helpers
{
    public class Dialogs : IResolvable
    {
        public async Task ShowError(string content)
        {
            MessageDialog dialog = new MessageDialog(content, "Error");
            await dialog.ShowAsync();
        }
    }
}
