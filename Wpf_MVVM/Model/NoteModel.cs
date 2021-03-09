using System;
using System.Collections.Generic;
using System.Text;

namespace Wpf_MVVM.Model
{
  public class NoteModel
  {
    public int Id { set; get; }
    public string Title { set; get; }
    public string Content { set; get; }
    public int TotalCharacter { get; set; }
    public int TotalWord { get; set; }
    public DateTime CreatedDate { set; get; }
    public DateTime ModifiedDate { set; get; }
    public bool status { set; get; }
  }
}
