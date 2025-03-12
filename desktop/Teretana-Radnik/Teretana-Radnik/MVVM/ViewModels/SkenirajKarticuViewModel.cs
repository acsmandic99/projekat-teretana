using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teretana_Radnik.MVVM.ViewModels
{
     public class SkenirajKarticuViewModel : ViewModelBase
    {
		private string id;
		public string ID
		{
			get { return id; }
			set { id = value; OnPropertyChanged(nameof(ID)); }
		}

	}
}
