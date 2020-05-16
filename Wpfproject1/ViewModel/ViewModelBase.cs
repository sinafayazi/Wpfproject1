using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Serialization;
using Wpfproject1.Command;
using Wpfproject1.Model;
namespace Wpfproject1.ViewModel
{
	public class ViewModelBase : ModelBase
	{

		public ICommand SaveCommand
		{
			get;
			set;
		}
		public ICommand LoadCommand
		{
			get;
			set;
		}
		public ViewModelBase()
		{

		}

	}
}
