using FileExplorer.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace FileExplorer
{
    public class MainViewModel : BaseViewModel
    {
        private BaseViewModel selectedView;
        private string selectedPath;
        private string fileContent;
        private string filterText;

        public MainViewModel()
        {


            SelectedView = new DirectoryStructureViewModel(@"C:\Code\Sample Projects\");

            LoadFileCommand = new RelayCommand(LoadFile);
        }

        private void LoadFile()
        {
            if (this.SelectedPath != null)
            {

            }
            else
            {
                FileContent = "File must be selected";
            }
        }

        public ICommand LoadFileCommand { get; set; }

        public string FileContent
        {
            get => fileContent;
            set
            {
                fileContent = value;
                OnPropertyChanged(nameof(FileContent));
            }
        }
        public string SelectedPath
        {
            get => selectedPath;
            set
            {
                selectedPath = value;
                OnPropertyChanged(nameof(SelectedPath));
            }
        }

        public string FilterText
        {
            get => filterText;
            set
            {
                filterText = value;
                OnPropertyChanged(nameof(FilterText));
            }
        }

        public BaseViewModel SelectedView
        {
            get => selectedView;
            set
            {
                selectedView = value;
                OnPropertyChanged(nameof(SelectedView));
            }
        }

        public ObservableCollection<BaseViewModel> TreeViewDemos { get; set; } = new ObservableCollection<BaseViewModel>();
    }
}
