using CountrySideEngineer.ProgressWindow.Model;
using CountrySideEngineer.ProgressWindow.Model.CommandArgument;
using CountrySideEngineer.ProgressWindow.Model.Interface;
using CountrySideEngineer.ProgressWindow.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountrySideEngineer.ProgressWindow
{
    public class ProgressWindow
	{
        public void Start(IAsyncTask<ProgressInfo> task)
		{
            var viewModel = new ProgressWindowsViewModel()
            {
                AsyncTask = task
            };
            var progress = new Progress<ProgressInfo>((_) =>
            {
                var cmdArg = new ProgressChangedCommandArgument()
                {
                    ProgressInfo = _
                };
                viewModel.OnProgressChanged(this, cmdArg);
            });
            viewModel.Progress = progress;
            var view = new CountrySideEngineer.ProgressWindow.View.ProgressWindow
            {
                DataContext = viewModel
            };
            view.ShowDialog();
		}
    }
}
