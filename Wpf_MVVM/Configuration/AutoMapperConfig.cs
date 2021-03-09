using AutoMapper;

using System;
using System.Collections.Generic;
using System.Text;

using Wpf_MVVM.Enities;
using Wpf_MVVM.Model;

namespace Wpf_MVVM.Configuration
{
  public static class AutoMapperConfig
  {
    public static IMapper RegisterMappings()
    {
      var config = new MapperConfiguration(cfg =>
      {
        cfg.CreateMap<NoteModel, Note>();
        cfg.CreateMap<Note, NoteModel>();
      });

      return config.CreateMapper();
    }
  }
}
