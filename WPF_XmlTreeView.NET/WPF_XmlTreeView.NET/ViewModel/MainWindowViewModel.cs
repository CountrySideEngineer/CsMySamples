using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_XmlTreeView.NET.Command;
using WPF_XmlTreeView.NET.Model;

namespace WPF_XmlTreeView.NET.ViewModel
{
	internal class MainWindowViewModel : ViewModelBase
	{
		protected DelegateCommand? _sampleCommand = null;

		public DelegateCommand? SampleCommand
		{
			get
			{
				if (_sampleCommand == null)
				{
					_sampleCommand = new DelegateCommand(SampleCommandExecute);
				}
				return _sampleCommand;
			}
		}

		public void SampleCommandExecute()
		{
			Console.WriteLine($"{nameof(SampleCommandExecute)} property executed");
		}

		protected ProjectItem? _selectedItem;
		public ProjectItem? SelectedItem
		{
			get => _selectedItem;
			set
			{
				_selectedItem = value;
				RaisePropertyChanged();
			}
		}

		public ObservableCollection<SolutionData> Solutions
		{
			get;
			set;
		}

		protected ProjectItem _sampleItem_001 = new ProjectItem()
		{
			Name = "SampleItem_001",
			TypeName = "Control_001",
		};

		public ProjectItem SampleItem_001
		{
			get => _sampleItem_001;
			set
			{
				_sampleItem_001 = value;
				RaisePropertyChanged();
			}
		}

		protected ProjectItem _sampleItem_002 = new ProjectItem()
		{
			Name = "SampleItem_002",
			TypeName = "Control_002",
		};

		public ProjectItem SampleItem_002
		{
			get => _sampleItem_001;
			set
			{
				_sampleItem_001 = value;
				RaisePropertyChanged();
			}
		}

		/// <summary>
		/// Default constructor.
		/// </summary>
		public MainWindowViewModel() {
			Solutions = new ObservableCollection<SolutionData>()
			{
				new SolutionData
				{
					Name = "Sample solution",
					Items = new List<ProjectItem>()
					{
						new ProjectItem()
						{
							Name ="Name_001",
							Path ="Path_001",
							Items = new List<ProjectItem>()
							{
								new ProjectItem()
								{
									Name = "Name_001_001",
									TypeName = "Control_001"
								},
								new ProjectItem()
								{
									Name = "Name_001_002",
									TypeName = "Control_001"
								},
								_sampleItem_001,
							},
							TypeName = "Control_001"
						},
						new ProjectItem()
						{
							Name ="Name_002",
							Path ="Path_002",
							Items = new List<ProjectItem>()
							{
								new ProjectItem()
								{
									Name = "Name_002_001",
									TypeName = "Control_002"
								},
								new ProjectItem()
								{
									Name = "Name_002_002",
									TypeName = "Control_002"
								},
								new ProjectItem()
								{
									Name = "Name_002_003",
									TypeName = "Control_002"
								},
								_sampleItem_002,
							},
							TypeName = "Control_002"
						},
						new ProjectItem()
						{
							Name ="Name_003",
							Path ="Path_003",
							TypeName = "Control_001"
						},
					}
				}
			};
		}

	}
}
