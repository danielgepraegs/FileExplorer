using FileExplorer.FileSystem;
using FileExplorer.FileSystem.Data;
using System.Collections.ObjectModel;
using System.Linq;

namespace FileExplorer.ViewModels
{
    class DirectoryStructureViewModel : BaseViewModel
    {
        public ObservableCollection<DataItemViewModel> Items { get; set; }

        public DirectoryStructureViewModel()
        {
            var children = DirectoryStructure.GetLogicalDrives();

            Items = new ObservableCollection<DataItemViewModel>(children.Select(drive => new DataItemViewModel(drive.FullPath, DataType.Drive)));
        }
    }
}
