using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

using Wpf_MVVM.Enities;
using Wpf_MVVM.Model;

namespace Wpf_MVVM.Service
{
  public interface INoteService
  {
    public NoteModel CreateNote(NoteModel NoteModel);
    public NoteModel EditNote(NoteModel NoteModel);
    public NoteModel DeleteNote(int NotedId);
    public ObservableCollection<NoteModel> GetNotes();
    public ObservableCollection<NoteModel> GetNotesByName(string title);
  }
}
