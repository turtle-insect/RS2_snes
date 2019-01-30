using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace RS2
{
	class Value : INotifyPropertyChanged
	{
		public Value(uint address, uint size)
		{
			mAddress = address;
			mSize = size;
		}

		public uint ID
		{
			get { return SaveData.Instance().ReadNumber(mAddress, mSize); }
			set
			{
				SaveData.Instance().WriteNumber(mAddress, mSize, value);
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ID)));
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		private readonly uint mAddress;
		private readonly uint mSize;
	}
}
