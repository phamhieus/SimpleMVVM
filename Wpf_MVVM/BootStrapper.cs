using Autofac;
using Autofac.Core;

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

using Wpf_MVVM.Configuration;

namespace Wpf_MVVM
{
  class BootStrapper
  {
    private static ILifetimeScope _rootScope;

    public static void Start()
    {
      _rootScope = DenfendencyInjectionConfig.Configure();
    }

    public static void Stop()
    {
      _rootScope.Dispose();
    }

    public static T Resolve<T>()
    {
      if (_rootScope == null) throw new Exception("Bootstrapper hasn't been started!");

      return _rootScope.Resolve<T>();
    }

    public static T Resolve<T>(Parameter[] parameters)
    {
      if (_rootScope == null) throw new Exception("Bootstrapper hasn't been started!");

      return _rootScope.Resolve<T>(parameters);
    }
  }
}
