using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using YTuber.Helpers;
using YTuber.IoC;

namespace YTuber.Base
{
    [DataContract]
    public abstract class ViewModelBase : IResolvable, INotifyPropertyChanged
    {
        public Navigation Navigation { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void RaisePropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
