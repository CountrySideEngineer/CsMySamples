using CountrySideEngineer.ProgressWindow.Model;
using CountrySideEngineer.ProgressWindow.Model.CommandArgument;
using CountrySideEngineer.ProgressWindow.Task.Interface;
using CountrySideEngineer.ProgressWindow.ViewModel;
using System;

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
                try
                {
                    var cmdArg = new ProgressChangedCommandArgument()
                    {
                        ProgressInfo = _
                    };
                    viewModel.OnProgressChanged(this, cmdArg);

                    if (!_.ShouldContinue)
                    {
                        viewModel.OnCloseWindowsCloseRequest(this, cmdArg);
                    }
                }
                catch (Exception)
                {
                    var cmdArg = new ProgressChangedCommandArgument()
                    {
                        ProgressInfo = new ProgressInfo
                        {
                            ShouldContinue = false,
                        }
                    };
                    viewModel.OnCloseWindowsCloseRequest(this, cmdArg);
                }
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
