using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpfproject1.Model
{
	public class Content : ModelBase
	{
		private ObservableCollection<Library> libs;
		public ObservableCollection<Library> Libs
		{
			get
			{
				return libs;
			}
			set
			{
				libs = value;
				OnPropertyChanged();
			}
		}

	}

}


