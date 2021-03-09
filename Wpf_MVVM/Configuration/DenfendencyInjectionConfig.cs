using Autofac;

using AutoMapper;

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

using Wpf_MVVM.EntityFramework;
using Wpf_MVVM.Service;
using Wpf_MVVM.ViewModel;

namespace Wpf_MVVM.Configuration
{
  class DenfendencyInjectionConfig
  {
    public static IContainer Configure()
    {
      var builder = new ContainerBuilder();

      builder.RegisterType<DatabaseContext>().AsSelf().SingleInstance();
      builder.RegisterType<NoteService>().As<INoteService>();
      builder.RegisterType<NoteViewModel>().AsSelf();
      builder.RegisterType<MainWindow>().AsSelf();

      builder.Register(c => AutoMapperConfig.RegisterMappings()).As<IMapper>().SingleInstance();

      return builder.Build();
    }
  }
}
