using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Data;

using Wpf_MVVM.Model;
using Wpf_MVVM.Service;

namespace Wpf_MVVM.ViewModel.Proccessors
{
  public class NoteProcessor
  {
    INoteService _noteService;
    private ObservableCollection<NoteModel> _notes;

    public NoteProcessor(INoteService noteService, ObservableCollection<NoteModel> notes)
    {
      _noteService = noteService;
      _notes = notes;
    }

    public void Add(NoteModel noteModel)
    {
      noteModel.ModifiedDate = DateTime.Now;
      noteModel.CreatedDate = DateTime.Now;

      noteModel = _noteService.CreateNote(noteModel);
      _notes.Add(noteModel);
    }

    public void Delete(NoteModel noteModel)
    {
      _noteService.DeleteNote(noteModel.Id);
      _notes.Remove(noteModel);
    }

    public void Update(NoteModel note)
    {
      NoteModel currNote = _notes.Where(n => n.Id == note.Id).FirstOrDefault();

      currNote = note;

      currNote.ModifiedDate = DateTime.Now;
      note = _noteService.EditNote(currNote);
    }
  }
}
