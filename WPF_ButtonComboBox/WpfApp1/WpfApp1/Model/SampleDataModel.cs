﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents.Serialization;
using System.Windows.Input;
using System.Windows.Media;
using WpfApp1.Command;
using WpfApp1.ViewModel;

namespace WpfApp1.Model 
{
	internal class SampleDataModel : ViewModelBase
	{
		public string DataTitle { get; set; }

		public string Content { get; set; }

		protected string _selectedCommand;
		public string SelectedCommand
		{
			get => _selectedCommand;
			set
			{
				_selectedCommand = value;
				RaisePropertyChanged();

				try
				{
					DisplayName = value.Substring(0, 3);
				}
				catch (Exception)
				{
					DisplayName = string.Empty;
				}
			}
		}

		protected string _displayName;
		public string DisplayName
		{
			get => _displayName;
			set
			{
				_displayName = value;
				RaisePropertyChanged();
			}
		}

		protected IEnumerable<string> _commands;
		public IEnumerable<string> Commands
		{
			get => _commands;
			set
			{
				_commands = value;
				RaisePropertyChanged();
			}
		}

		protected IEnumerable<SampleCommandModel> _commandModels;
		public IEnumerable<SampleCommandModel> CommandModels
		{
			get => _commandModels;
			set
			{
				_commandModels = value;
				RaisePropertyChanged();
			}
		}

		protected SampleCommandModel _selectedCommandModel;
		public SampleCommandModel SampleCommandModel
		{
			get => _selectedCommandModel;
			set
			{
				_selectedCommandModel = value;
				RaisePropertyChanged();

				DisplayName = _selectedCommandModel?.Execute();
			}
		}

		public SampleDataModel()
		{
			DataTitle = string.Empty;
			Content = string.Empty;
			Commands = new List<string>();

			SelectedCommand = string.Empty;
		}
	}
}
