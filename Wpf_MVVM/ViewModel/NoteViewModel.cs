using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

using Wpf_MVVM.Model;
using Wpf_MVVM.Service;
using Wpf_MVVM.ViewModel.Commons;
using Wpf_MVVM.ViewModel.Proccessors;

namespace Wpf_MVVM.ViewModel
{
  public class NoteViewModel : ViewModelBase
  {
    private NoteModel note;
    private ICollectionView noteViews;
    private ObservableCollection<NoteModel> notes;
    private bool openPopupAdd = false;
    private string searchKey = "";

    public string SearchKey 
    {
      get { return searchKey; }
      set
      {
        searchKey = value;

        noteViews.Refresh();
        NotifyPropertyChanged("SearchKey");
      }
    }

    public bool OpenPopupAdd
    {
      get { return openPopupAdd; }
      set 
      {
        openPopupAdd = value;
        NotifyPropertyChanged("OpenPopupAdd");
      }
    }

    public ObservableCollection<NoteModel> Notes
    {
      get { return notes; }
      set
      {
        notes = value; 
        NotifyPropertyChanged("NoteData");
      }
    }

    public NoteModel NoteData
    {
      get { return note; }
      set 
      { 
        note = value;
        NotifyPropertyChanged("NoteData");
      }
    }

    public ICommand CreateCommand { get; set; }
    public ICommand DeleteCommand { get; set; }
    public ICommand UpdateCommand { get; set; }
    public ICommand SearchCommand { get; set; }
    public ICommand ButtonPopupCommand { get; set; }


    private readonly NoteProcessor _processor;
    private readonly INoteService _noteService;

    public NoteViewModel() { }

    public NoteViewModel(INoteService noteService)
    {
      notes = noteService.GetNotes();

      _noteService = noteService;
      _processor = new NoteProcessor(_noteService, notes);

      NoteData = new NoteModel();

      noteViews = CollectionViewSource.GetDefaultView(notes);

      CreateCommand = new RelayCommand<NoteModel>(obj => obj != null, AddNote);
      DeleteCommand = new RelayCommand<NoteModel>(obj => obj != null, _processor.Delete);
      UpdateCommand = new RelayCommand<NoteModel>(obj => obj != null, _processor.Update);

      ButtonPopupCommand =  new RelayCommand<object>(obj => true, OnClickButtonOpenPopup);

      noteViews.Filter = obj => String.IsNullOrEmpty(SearchKey) ? true : ((NoteModel)obj).Title.Contains(SearchKey);
    }

    private void AddNote(NoteModel noteModel)
    {
      _processor.Add(noteModel);
      OnClickButtonOpenPopup("ButtonOpenPopup");
    }

    public void OnClickButtonOpenPopup(object sender)
    {
      OpenPopupAdd = !OpenPopupAdd;
    }
  }
}
