using FileExplorer.FileSystem;
using FileExplorer.FileSystem.Data;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace FileExplorer.ViewModels
{
    public class DataItemViewModel : BaseViewModel
    {
        public DataType Type { get; set; }

        public string FullPath { get; set; }

        public string Name { get { return Type == DataType.Drive ? FullPath : DirectoryStructure.GetFileOrFolderName(FullPath); } }

        public ObservableCollection<DataItemViewModel> Children { get; set; }

        public bool CanExpand { get { return Type != DataType.File; } }

        public bool IsExpanded {
            get
            {
                return Children?.Count(f => f != null) > 0;
            }
            set
            {
                if (value == true)
                {
                    Expand();
                }
                else
                {
                    ClearChildren();
                }
            }
        }

        public ICommand ExpandCommand { get; set; }

        public DataItemViewModel(string fullPath, DataType type)
        {
            Type = type;
            FullPath = fullPath;
            ExpandCommand = new RelayCommand(Expand);

            ClearChildren();
        }

        private void ClearChildren()
        {
            Children = new ObservableCollection<DataItemViewModel>();

            if (Type != DataType.File)
            {
                Children.Add(null);
            }
        }

        private void Expand()
        {
            if (Type == DataType.File)
            {
                return;
            }

            var children = DirectoryStructure.GetDirectoryContents(FullPath);

            Children = new ObservableCollection<DataItemViewModel>(children.Select(content => new DataItemViewModel(content.FullPath, content.Type)));
        }
    }
}
