using System;
using System.Collections.Generic;
using System.Text;

namespace MVVM_Prj.Model.Entities
{
  public class Note
  {
    public long NoteId { get; set; }
    public string Content { get; set; }
    public string Title { get; set; }
    public int TotalWord { get; set; }
    public int TotalCharacter { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }
    public bool Status { get; set; }
  }
}
