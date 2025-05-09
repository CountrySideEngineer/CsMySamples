using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using WPF_MultiWindow.Model;

namespace WPF_MultiWindow.ViewModel
{
    internal class SubWindowViewModel : WindowViewModel
    {
        protected ulong _sampleContent = 0;
        public ulong SampleContent
        {
            get => _sampleContent;
            set
            {
                _sampleContent = value;
                RaisePropertyChanged();
            }
        }

        protected DispatcherTimer _timer;

        public SampleModel SampleModel = new SampleModel();

        public SubWindowViewModel() : base()
        {
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromMilliseconds(250);
            _timer.Tick += (s, e) => UpdateContent();
            _timer.Start();
        }

        public void UpdateContent()
        {
            ulong content = SampleModel.UpdateValue();

            SampleContent = content;
        }
    }
}
