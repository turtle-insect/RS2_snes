using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace RS2
{
	class DataContext
	{
		public ObservableCollection<Charactor> Party { get; set; } = new ObservableCollection<Charactor>();

		public DataContext()
		{
			for (uint i = 0; i < 5; i++)
			{
				Party.Add(new Charactor(75 * i));
			}
		}
	}
}
