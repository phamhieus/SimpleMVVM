using System;
using System.Collections.Generic;
using System.Text;

namespace Wpf_MVVM.Enities
{
  public class Note
  {
    public int Id { set; get; }
    public int TotalCharacter { get; set; }
    public int TotalWord { get; set; }
    public string Title { set; get; }
    public string Content { set; get; }
    public DateTime CreatedDate { set; get; }
    public DateTime ModifiedDate { set; get; }
    public bool status { set; get; }
  }
}
