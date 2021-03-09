using AutoMapper;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using Wpf_MVVM.Enities;
using Wpf_MVVM.EntityFramework;
using Wpf_MVVM.Model;

namespace Wpf_MVVM.Service
{
  class NoteService : INoteService
  {
    DatabaseContext _context;
    IMapper _mapper;

    public NoteService(DatabaseContext context, IMapper mapper)
    {
      _mapper = mapper;
      _context = context;
    }

    public NoteModel CreateNote(NoteModel noteModel)
    {
      Note note = _mapper.Map<Note>(noteModel);

      note.TotalCharacter = note.Content.Length;
      note.TotalWord = note.Content.Count(c => c == ' ') + 1;

      _context.Notes.Add(note);
      _context.SaveChanges();

      noteModel = _mapper.Map<NoteModel>(note);

      return noteModel;
    }

    public NoteModel DeleteNote(int notedId)
    {
      Note deleteNote = _context.Notes.Where(c => c.Id == notedId).FirstOrDefault();
      NoteModel noteModel = null;

      if (deleteNote != null)
      {
        _context.Notes.Remove(deleteNote);
        _context.SaveChanges();

        noteModel = _mapper.Map<NoteModel>(deleteNote);
      }
      
      return noteModel;
    }

    public NoteModel EditNote(NoteModel noteModel)
    {
      Note note = _mapper.Map<Note>(noteModel);

      note.TotalCharacter = note.Content.Length;
      note.TotalWord = note.Content.Count(c => c == ' ') + 1;

      _context.Entry(note).State = EntityState.Detached;
      _context.SaveChanges();

      noteModel = _mapper.Map<NoteModel>(note);

      return noteModel;
    }

    public ObservableCollection<NoteModel> GetNotes()
    {
      ObservableCollection<NoteModel> noteModels = new ObservableCollection<NoteModel>();

      foreach (var note in _context.Notes)
      {
        NoteModel model = _mapper.Map<NoteModel>(note);
        noteModels.Add(model);
      }

      return noteModels;
    }

    public ObservableCollection<NoteModel> GetNotesByName(string title)
    {
      ObservableCollection<NoteModel> noteModels = new ObservableCollection<NoteModel>();

      IEnumerable<Note> notes = _context.Notes
        .Where(note => string.IsNullOrEmpty(title) 
          || note.Title.ToLower().Contains(title.ToLower())
        ).ToList<Note>();

      foreach (var note in notes)
      {
        NoteModel model = _mapper.Map<NoteModel>(note);
        noteModels.Add(model);
      }

      return noteModels;
    }
  }
}
