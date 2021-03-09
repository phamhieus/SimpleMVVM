using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Wpf_MVVM.ViewModel.Commons
{
  public class ViewModelBase : INotifyPropertyChanged
  {
    public event PropertyChangedEventHandler PropertyChanged;

    protected void NotifyPropertyChanged(string propertyName)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
  }
}
