using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WPF_DialogServiceSample
{
    internal class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public virtual void RaisePropertyChanged([CallerMemberName] string propertName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertName));
        }

        public IDialogService<IEnumerable<string>>? FileService { get; set; } = null;

        protected string _content = string.Empty;
        public string Content
        {
            get => _content;
            set
            {
                _content = value;
                RaisePropertyChanged();
            }
        }

        public DelegateCommand SelectFileCommand
        {
            get
            {
                return new DelegateCommand(SelectFileCommandExecute);
            }
        }

        public void SelectFileCommandExecute()
        {
            var files = new List<string>();
            bool? dialogRes = FileService?.ShowDialog(files);
            if (true == dialogRes)
            {
                string content = string.Empty;
                foreach (var file in files)
                {
                    content += file;
                    content += Environment.NewLine;
                }
                Content = content;
            }
        }

    }
}
