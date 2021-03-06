﻿namespace Bookie.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.ComponentModel;
    using System.Linq;
    using System.Windows;
    using System.Windows.Data;
    using System.Windows.Input;
    using System.Windows.Media;
    using Common;
    using Common.Model;
    using Core.Domains;
    using Properties;
    using UserControls;
    using Views;

    public class MainViewModel : NotifyBase, IProgressSubscriber
    {
        public delegate void CancelDelegate();

        private readonly BookDomain _bookDomain;
        private readonly SourceDirectoryDomain _sourceDomain = new SourceDirectoryDomain();
        private List<Publisher> _allPublishers;
        private Author _authorFilter;
        private ObservableCollection<Author> _authorsTv;
        private ICollectionView _books;
        public UIElement _bookView;
        private bool _cancelled;
        private ICommand _cancelProgressCommand;
        private ICommand _editDetailsCommand;
        private string _filter;
        private Visibility _filterBoxVisibility;
        private bool _filterOnDescription;
        private bool _filterOnTitle;
        private Visibility _leftPane;
        private ICommand _leftPaneCommand;
        private ICommand _listViewCommand;
        private ICommand _openPdfCommand;
        private string _operationName;
        private string _progressBarText;
        private int _progressPercentage;
        private bool _progressReportingActive;
        private string _progressText;
        private ProgressView _progressView;
        private Publisher _publisherFilter;
        private ObservableCollection<Publisher> _publishersTv;
        private ICommand _refreshCommand;
        private ICommand _removeBookCommand;
        private Visibility _rightPane;
        private ICommand _rightPaneCommand;
        private Brush _scrapedColor;
        private Book _selectedBook;
        private string _selectedSort;
        private ICommand _settingsViewCommand;
        private bool _showProgress;
        private ObservableCollection<string> _sortList;
        private ObservableCollection<SourceDirectory> _sourceDirectories;
        private SourceDirectory _sourceDirectoryFilter;
        private ICommand _sourceViewCommand;
        private Brush _starColor;
        private int _tileHeight;
        private ICommand _tileViewCommand;
        private int _tileWidth;
        private bool _toggleFavourite;
        private Brush _toggleFavouriteColor;
        private bool _toggleScraped;
        private ICommand _viewLog;
        public ObservableCollection<Book> AllBooks;
        public BookDetails BookDetails;
        public BookTiles BookTiles;
        public PdfViewer PdfViewer;
        public Window Window;

        public MainViewModel()
        {
            SourceDirectories = new ObservableCollection<SourceDirectory>();
            StarColor = new SolidColorBrush(Colors.White);
            ScrapedColor = new SolidColorBrush(Colors.White);
            ToggleFavouriteColor = new SolidColorBrush(Colors.Black);

            _bookDomain = new BookDomain();
            BookTiles = new BookTiles();
            BookDetails = new BookDetails();
            PdfViewer = new PdfViewer();
            FilterOnTitle = true;
            //  var savedView = AppConfig.LoadSetting("SavedView");
            //switch (savedView)
            //{
            //    case "Tiles":
            //        BookView = BookTiles;
            //        break;

            //    case "Details":
            //        BookView = BookDetails;
            //        break;

            //    default:
            //        BookView = new BookTiles();
            //        break;
            //}
            BookView = BookTiles;
            ProgressService.RegisterSubscriber(this);

            var sortt = new List<string>
            {
                "Title [A-Z]",
                "Title [Z-A]",
                "Date Published [Newest]",
                "Date Published [Oldest]",
                "Date Added [Newest]",
                "Date Added [Oldest]"
            };

            SortList = new ObservableCollection<string>(sortt);
            RefreshAllBooks();
            RefreshPublishersAndAuthors();
            SelectedSort = "Title [A-Z]";
        }

        public string Title
        {
            get
            {
                if (Globals.DebugMode)
                {
                    return "Bookie - DEBUG";
                }
                return "Bookie";
            }
        }

        public Brush TitleBrush
        {
            get
            {
                if (Globals.InDebugMode())
                {
                    return new SolidColorBrush(Colors.Red);
                }
                var s = (SolidColorBrush) new BrushConverter().ConvertFromString("#09506E");
                return s;
            }
        }

        public bool FilterOnTitle
        {
            get { return _filterOnTitle; }
            set
            {
                _filterOnTitle = value;
                NotifyPropertyChanged("FilterOnTitle");
            }
        }

        public bool FilterOnDescription
        {
            get { return _filterOnDescription; }
            set
            {
                _filterOnDescription = value;
                NotifyPropertyChanged("FilterOnDescription");
            }
        }

        public bool ToggleScraped
        {
            get { return _toggleScraped; }
            set
            {
                _toggleScraped = value;
                NotifyPropertyChanged("ToggleScraped");
                if (value)
                {
                    ScrapedColor = new SolidColorBrush(Colors.Yellow);
                }
                else
                {
                    ScrapedColor = new SolidColorBrush(Colors.White);
                }
                ApplyToggleFilter();
                NotifyPropertyChanged("Books");
                NotifyPropertyChanged("BooksCount");
            }
        }

        public bool ToggleFavouriteBook
        {
            get
            {
                if (SelectedBook != null)
                {
                    ToggleFavouriteColor = SelectedBook.Favourite
                        ? new SolidColorBrush(Colors.Yellow)
                        : new SolidColorBrush(Colors.Black);
                    return SelectedBook.Favourite;
                }
                return false;
            }
            set
            {
                SelectedBook.Favourite = value;
                ToggleFavouriteColor = value ? new SolidColorBrush(Colors.Yellow) : new SolidColorBrush(Colors.Black);
                NotifyPropertyChanged("ToggleFavouriteBook");
                BookDomain.SetUnchanged(SelectedBook);
                SelectedBook.EntityState = EntityState.Modified;
                _bookDomain.UpdateBook(SelectedBook);

                if (ToggleFavourite)
                {
                    ApplyToggleFilter();
                    NotifyPropertyChanged("Books");
                }
            }
        }

        public Brush ToggleFavouriteColor
        {
            get { return _toggleFavouriteColor; }
            set
            {
                _toggleFavouriteColor = value;
                NotifyPropertyChanged("ToggleFavouriteColor");
            }
        }

        public Brush StarColor
        {
            get { return _starColor; }
            set
            {
                _starColor = value;
                NotifyPropertyChanged("StarColor");
            }
        }

        public Brush ScrapedColor
        {
            get { return _scrapedColor; }
            set
            {
                _scrapedColor = value;
                NotifyPropertyChanged("ScrapedColor");
            }
        }

        public bool ToggleFavourite
        {
            get { return _toggleFavourite; }
            set
            {
                _toggleFavourite = value;
                NotifyPropertyChanged("ToggleFavourite");
                if (value)
                {
                    StarColor = new SolidColorBrush(Colors.Yellow);
                }
                else
                {
                    StarColor = new SolidColorBrush(Colors.White);
                }
                ApplyToggleFilter();
                NotifyPropertyChanged("Books");
                NotifyPropertyChanged("BooksCount");
            }
        }

        public Visibility FilterBoxVisibility
        {
            get { return _filterBoxVisibility; }
            set
            {
                _filterBoxVisibility = value;
                NotifyPropertyChanged("FilterBoxVisibility");
            }
        }

        public ObservableCollection<string> SortList
        {
            get { return _sortList; }
            set
            {
                _sortList = value;
                NotifyPropertyChanged("SortList");
            }
        }

        public string SelectedSort
        {
            get { return _selectedSort; }
            set
            {
                _selectedSort = value;
                NotifyPropertyChanged("SelectedSort");

                if (_selectedSort != null)
                {
                    SortBooks();
                }
            }
        }

        public bool ShowProgress
        {
            get { return _showProgress; }
            set
            {
                _showProgress = value;
                NotifyPropertyChanged("ShowProgress");
            }
        }

        public bool ProgressReportingActive
        {
            get { return _progressReportingActive; }
            set
            {
                _progressReportingActive = value;
                NotifyPropertyChanged("ProgressReportingActive");
            }
        }

        public string ProgressBarText
        {
            get { return _progressBarText; }
            set
            {
                _progressBarText = value;
                NotifyPropertyChanged("ProgressBarText");
            }
        }

        public string ProgressText
        {
            get { return _progressText; }
            set
            {
                _progressText = value;
                NotifyPropertyChanged("ProgressText");
            }
        }

        public int ProgressPercentage
        {
            get { return _progressPercentage; }
            set
            {
                _progressPercentage = value;
                NotifyPropertyChanged("ProgressPercentage");
            }
        }

        public string OperationName
        {
            get { return _operationName; }
            set
            {
                _operationName = value;
                NotifyPropertyChanged("OperationName");
            }
        }

        public Visibility LeftPane
        {
            get { return _leftPane; }
            set
            {
                _leftPane = value;
                NotifyPropertyChanged("LeftPane");
            }
        }

        public Visibility RightPane
        {
            get { return _rightPane; }
            set
            {
                _rightPane = value;
                NotifyPropertyChanged("RightPane");
            }
        }

        public ICollectionView Books
        {
            get { return _books; }
            set
            {
                _books = value;
                NotifyPropertyChanged("Books");
            }
        }

        public ObservableCollection<Publisher> PublishersList
        {
            get { return _publishersTv; }
            set
            {
                _publishersTv = value;
                NotifyPropertyChanged("PublishersList");
            }
        }

        public ObservableCollection<Author> AuthorsList
        {
            get { return _authorsTv; }
            set
            {
                _authorsTv = value;
                NotifyPropertyChanged("AuthorsList");
            }
        }

        public string Filter
        {
            get { return string.IsNullOrEmpty(_filter) ? "" : _filter; }
            set
            {
                _filter = value;
                NotifyPropertyChanged("Filter");
                Books.Filter = ApplyTextFilter;
                Books.Refresh();
            }
        }

        public Publisher PublisherFilter
        {
            get { return _publisherFilter; }
            set
            {
                _publisherFilter = value;
                NotifyPropertyChanged("PublisherFilter");
                Books.Filter = ApplyPublisherFilter;
                Books.Refresh();
            }
        }

        public SourceDirectory SourceDirectoryFilter
        {
            get { return _sourceDirectoryFilter; }
            set
            {
                _sourceDirectoryFilter = value;
                NotifyPropertyChanged("SourceDirectoryFilter");
                Books.Filter = ApplySourceDirectoryFilter;
                Books.Refresh();
            }
        }

        public Author AuthorFilter
        {
            get { return _authorFilter; }
            set
            {
                _authorFilter = value;
                NotifyPropertyChanged("AuthorFilter");
                Books.Filter = ApplyAuthorFilter;
                Books.Refresh();
            }
        }

        public UIElement BookView
        {
            get { return _bookView; }
            set
            {
                _bookView = value;
                NotifyPropertyChanged("BookView");
                FilterBoxVisibility = Equals(_bookView, PdfViewer) ? Visibility.Hidden : Visibility.Visible;
            }
        }

        public Book SelectedBook
        {
            get { return _selectedBook; }
            set
            {
                _selectedBook = value;
                if (value != null)
                {
                    PdfViewer.ViewModel.Book = SelectedBook;
                }
                NotifyPropertyChanged("SelectedBook");
                NotifyPropertyChanged("SelectedBookEmpty");
                NotifyPropertyChanged("ToggleFavouriteBook");
            }
        }

        public int TileHeight
        {
            get { return _tileHeight; }
            set
            {
                _tileHeight = value;
                NotifyPropertyChanged("TileHeight");
            }
        }

        public bool SelectedBookEmpty
        {
            get { return SelectedBook != null; }
        }

        public string BooksCount
        {
            get { return "Found " + Books.Cast<Book>().Count() + " results"; }
        }

        public int TileWidth
        {
            get { return _tileWidth; }
            set
            {
                _tileWidth = value;
                _tileHeight = Convert.ToInt32(value*1.4);
                NotifyPropertyChanged("TileWidth");
                NotifyPropertyChanged("TileHeight");
                NotifyPropertyChanged("StarSize");
                Settings.Default.TileWidth = value;
            }
        }

        public bool Cancelled
        {
            get { return _cancelled; }
            set
            {
                _cancelled = value;
                NotifyPropertyChanged("Cancelled");
            }
        }

        public CancelDelegate Cancel { get; set; }

        public ICommand CancelProgressCommand
        {
            get
            {
                return _cancelProgressCommand
                       ?? (_cancelProgressCommand = new RelayCommand(p => CancelProgress(), p => true));
            }
        }

        public ICommand EditDetailsCommand
        {
            get
            {
                return _editDetailsCommand
                       ?? (_editDetailsCommand = new RelayCommand(p => EditBook(), p => SelectedBook != null));
            }
        }

        public ICommand RemoveBookCommand
        {
            get
            {
                return _removeBookCommand
                       ?? (_removeBookCommand = new RelayCommand(p => RemoveBook(), p => SelectedBook != null));
            }
        }

        public ICommand ViewLog
        {
            get
            {
                return _viewLog
                       ?? (_viewLog = new RelayCommand(p => ViewLogWindow(), p => true));
            }
        }

        public ICommand OpenPdfCommand
        {
            get
            {
                return _openPdfCommand
                       ?? (_openPdfCommand = new RelayCommand(p => ChangeToPdfView(), p => SelectedBook != null));
            }
        }

        public ICommand LeftPaneCommand
        {
            get
            {
                return _leftPaneCommand
                       ?? (_leftPaneCommand = new RelayCommand(p => LeftPaneToggle(), p => true));
            }
        }

        public ICommand RightPaneCommand
        {
            get
            {
                return _rightPaneCommand
                       ?? (_rightPaneCommand = new RelayCommand(p => RightPaneToggle(), p => true));
            }
        }

        public ICommand SettingsViewCommand
        {
            get
            {
                return _settingsViewCommand
                       ?? (_settingsViewCommand = new RelayCommand(p => ShowSettingsView(), p => true));
            }
        }

        public ICommand RefreshCommand
        {
            get
            {
                return _refreshCommand
                       ?? (_refreshCommand = new RelayCommand(p => RefreshAllBooks(), p => AllBooks != null));
            }
        }

        public ICommand ListViewCommand
        {
            get
            {
                return _listViewCommand
                       ?? (_listViewCommand = new RelayCommand(p => SwitchToDetailsView(), p => true));
            }
        }

        public ICommand TileViewCommand
        {
            get
            {
                return _tileViewCommand
                       ?? (_tileViewCommand = new RelayCommand(p => SwitchToTilesView(), p => true));
            }
        }

        public ICommand SourceViewCommand
        {
            get
            {
                return _sourceViewCommand
                       ?? (_sourceViewCommand = new RelayCommand(p => SourceDirectoryView(), p => true));
            }
        }

        public ObservableCollection<SourceDirectory> SourceDirectories
        {
            get { return _sourceDirectories; }
            set
            {
                _sourceDirectories = value;
                NotifyPropertyChanged("SourceDirectories");
            }
        }

        public List<Publisher> AllPublishers
        {
            get { return _allPublishers; }
            set
            {
                _allPublishers = value;
                NotifyPropertyChanged("AllPublishers");
            }
        }

        public List<Book> BooksFromSplash { get; set; }

        public void _progress_ProgressStarted(object sender, EventArgs e)
        {
            _progressView = new ProgressView();
            _progressView.ViewModel.OperationName = "Starting...";
            _progressView.ViewModel.ProgressText = "";
            _progressView.ViewModel.ProgressPercentage = 0;
            _progressView.ViewModel.ProgressBarText = "";
            ProgressReportingActive = true;
            ShowProgress = true;
            _progressView.Show();
        }

        public void _progress_ProgressCompleted(object sender, EventArgs e)
        {
            _progressView.ViewModel.OperationName = "Starting...";
            _progressView.ViewModel.ProgressPercentage = 0;
            _progressView.ViewModel.ProgressText = "";
            _progressView.ViewModel.ProgressBarText = "";
            ProgressReportingActive = false;
            ShowProgress = false;
            _progressView.Close();
        }

        public void _progress_ProgressChanged(object sender, ProgressWindowEventArgs e)
        {
            _progressView.ViewModel.OperationName = e.OperationName;
            _progressView.ViewModel.ProgressBarText = e.ProgressBarText;
            _progressView.ViewModel.ProgressText = e.ProgressText;
            _progressView.ViewModel.ProgressPercentage = e.ProgressPercentage;
        }

        private void Books_CollectionChanged(
            object sender,
            NotifyCollectionChangedEventArgs e)
        {
            NotifyPropertyChanged("BooksCount");
        }

        public void ChangeToPdfView()
        {
            if (SelectedBook == null)
            {
                return;
            }
            LeftPane = Visibility.Collapsed;
            RightPane = Visibility.Collapsed;
            PdfViewer.ViewModel.OpenPdf(SelectedBook.BookFile.FullPathAndFileNameWithExtension);

            BookView = PdfViewer;
        }

        private void CancelProgress()
        {
            ProgressService.Cancel();
        }

        private void ViewLogWindow()
        {
            var log = new LogWindow(new LogViewModel());
            log.ShowDialog();
        }

        public void i_BookChanged(object sender, BookEventArgs e)
        {
            if (e.Book == null)
            {
                return;
            }
            switch (e.State)
            {
                case (BookEventArgs.BookState.Added):
                    var bookExistsAdded =
                        AllBooks.Any(
                            b =>
                                b.Id
                                == e.Book.Id);
                    if (!bookExistsAdded)
                    {
                        AllBooks.Add(e.Book);
                    }
                    NotifyPropertyChanged("BooksCount");
                    break;

                case (BookEventArgs.BookState.Removed):
                    var bookExistsRemoved =
                        AllBooks.Any(
                            b =>
                                b.Id
                                == e.Book.Id);
                    if (bookExistsRemoved)
                    {
                        AllBooks.Remove(e.Book);
                    }
                    NotifyPropertyChanged("BooksCount");
                    break;

                case (BookEventArgs.BookState.Updated): //Remove book from list and re-add it
                    var bookExistsUpdated =
                        AllBooks.FirstOrDefault(
                            b =>
                                b.BookFile.FullPathAndFileNameWithExtension
                                == e.Book.BookFile.FullPathAndFileNameWithExtension);
                    if (bookExistsUpdated != null)
                    {
                        var index = AllBooks.IndexOf(bookExistsUpdated);
                        AllBooks.Remove(bookExistsUpdated);
                        AllBooks.Insert(index, e.Book);
                    }
                    else
                    {
                        AllBooks.Add(e.Book);
                    }
                    NotifyPropertyChanged("BooksCount");
                    break;
            }
        }

        private bool ApplyTextFilter(object item)
        {
            var book = item as Book;
            if (FilterOnTitle)
            {
                if (SourceDirectoryFilter.SourceDirectoryUrl == "All Sources")
                {
                    return book != null && book.Title.IndexOf(Filter, StringComparison.OrdinalIgnoreCase) >= 0;
                }
                return book != null && book.Title.IndexOf(Filter, StringComparison.OrdinalIgnoreCase) >= 0 &&
                       book.SourceDirectory.NickName == SourceDirectoryFilter.NickName;
            }
            if (FilterOnDescription)
            {
                if (SourceDirectoryFilter.SourceDirectoryUrl == "All Sources")
                {
                    return book != null && book.Abstract.IndexOf(Filter, StringComparison.OrdinalIgnoreCase) >= 0;
                }
                return book != null && book.Abstract.IndexOf(Filter, StringComparison.OrdinalIgnoreCase) >= 0 &&
                       book.SourceDirectory.NickName == SourceDirectoryFilter.NickName;
            }

            if (SourceDirectoryFilter.SourceDirectoryUrl == "All Sources")
            {
                return book != null && book.Title.IndexOf(Filter, StringComparison.OrdinalIgnoreCase) >= 0;
            }
            return book != null && book.Title.IndexOf(Filter, StringComparison.OrdinalIgnoreCase) >= 0 &&
                   book.SourceDirectory.NickName == SourceDirectoryFilter.NickName;
        }

        private bool ApplyPublisherFilter(object item)
        {
            var book = item as Book;
            if (PublisherFilter != null && PublisherFilter.Name == "All Publishers")
            {
                return true;
            }
            return book != null && book.Publishers.Any(x => x.Name == PublisherFilter.Name);
        }

        private bool ApplyAuthorFilter(object item)
        {
            var book = item as Book;
            if (AuthorFilter != null && AuthorFilter.FirstName == "All Authors")
            {
                return true;
            }

            return book != null && book.Authors.Any(x => x.FullName == AuthorFilter.FullName);
        }

        private bool ApplySourceDirectoryFilter(object item)
        {
            var book = item as Book;
            if (SourceDirectoryFilter == null)
            {
                SourceDirectoryFilter = new SourceDirectory
                {
                    SourceDirectoryUrl = "All Sources",
                    NickName = "All Source"
                };
            }
            if (SourceDirectoryFilter.NickName == "All Sources")
            {
                return true;
            }
            return book != null && book.SourceDirectory.NickName == SourceDirectoryFilter.NickName;
        }

        private void SwitchToTilesView()
        {
            if (Equals(BookView, PdfViewer))
            {
                LeftPane = Visibility.Visible;
                RightPane = Visibility.Visible;
            }
            BookView = BookTiles;
        }

        private void SwitchToDetailsView()
        {
            if (Equals(BookView, PdfViewer))
            {
                LeftPane = Visibility.Visible;
                RightPane = Visibility.Visible;
            }
            BookView = BookDetails;
        }

        private void ApplyToggleFilter()
        {
            IEnumerable<Book> filteredBooks = _bookDomain.GetAllBooks().ToList();
            if (ToggleScraped)
            {
                filteredBooks = filteredBooks.Where(x => x.Scraped).ToList();
            }
            if (ToggleFavourite)
            {
                filteredBooks = filteredBooks.Where(x => x.Favourite).ToList();
            }
            AllBooks = new ObservableCollection<Book>(filteredBooks);

            Books = CollectionViewSource.GetDefaultView(AllBooks);
            Books.Refresh();
        }

        private void SortBooks()
        {
            switch (SelectedSort)
            {
                case "Title [A-Z]":
                    Books.SortDescriptions.Clear();

                    Books.SortDescriptions.Add(new SortDescription("Title", ListSortDirection.Ascending));
                    break;

                case "Title [Z-A]":
                    Books.SortDescriptions.Clear();
                    Books.SortDescriptions.Add(new SortDescription("Title", ListSortDirection.Descending));
                    break;

                case "Date Published [Newest]":
                    Books.SortDescriptions.Clear();
                    Books.SortDescriptions.Add(new SortDescription("DatePublished", ListSortDirection.Descending));
                    break;

                case "Date Published [Oldest]":
                    Books.SortDescriptions.Clear();
                    Books.SortDescriptions.Add(new SortDescription("DatePublished", ListSortDirection.Ascending));
                    break;

                case "Date Added [Newest]":
                    Books.SortDescriptions.Clear();
                    Books.SortDescriptions.Add(new SortDescription("CreatedDateTime", ListSortDirection.Descending));
                    break;

                case "Date Added [Oldest]":
                    Books.SortDescriptions.Clear();
                    Books.SortDescriptions.Add(new SortDescription("CreatedDateTime", ListSortDirection.Ascending));
                    break;
            }
        }

        public async void RefreshAllBooks()
        {
            var b = await _bookDomain.GetAllAsync();
            AllBooks = b != null ? new ObservableCollection<Book>(b) : new ObservableCollection<Book>();
            Books = CollectionViewSource.GetDefaultView(AllBooks);
            Books.CollectionChanged += Books_CollectionChanged;

            SourceDirectories.Clear();
            SourceDirectories =
                new ObservableCollection<SourceDirectory>(_sourceDomain.GetAllSourceDirectories().ToList());
            SourceDirectories.Insert(0,
                new SourceDirectory {SourceDirectoryUrl = "All Sources", NickName = "All Sources"});
            SourceDirectoryFilter = SourceDirectories[0];
        }

        public void RefreshPublishersAndAuthors()
        {
            var p = new PublisherDomain();
            var all = p.GetAllPublishers();
            if (all != null)
            {
                all = all.GroupBy(r => r.Name).Select(y => y.First()).ToList();
                all.Insert(0, new Publisher {Name = "All Publishers"});
                if (Books != null)
                {
                    PublishersList = new ObservableCollection<Publisher>(all);
                }
            }

            var a = new AuthorDomain();
            var allAuthors = a.GetAllAuthors();
            if (allAuthors == null)
            {
                return;
            }

            allAuthors = allAuthors.GroupBy(o => o.FullName).Select(g => g.First()).ToList();
            allAuthors.Insert(0, new Author {FirstName = "All Authors"});

            if (Books != null)
            {
                AuthorsList = new ObservableCollection<Author>(allAuthors);
            }
        }

        private void EditBook()
        {
            var view = new EditBookView();
            view.ViewModel.SelectedBook = _bookDomain.GetBookById(SelectedBook.Id);
            view.ViewModel.BookChanged += i_BookChanged;
            view.ShowDialog();
        }

        private void RemoveBook()
        {
            var view = new RemoveBookView();
            view.ViewModel.SelectedBook = SelectedBook;
            view.ViewModel.BookChanged += i_BookChanged;
            view.ShowDialog();
        }

        private void SourceDirectoryView()
        {
            var sourceDirectoryView = new SourceDirectoryView(this);
            sourceDirectoryView.ShowDialog();
        }

        public void ShowSettingsView()
        {
            var settingsView = new SettingsView();
            settingsView.ShowDialog();
        }

        public void ProgressSubscriber(ProgressWindowEventArgs e)
        {
            ProgressPercentage = e.ProgressPercentage;
        }

        public void LeftPaneToggle()
        {
            LeftPane = LeftPane == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
        }

        public void RightPaneToggle()
        {
            RightPane = RightPane == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
        }
    }
}