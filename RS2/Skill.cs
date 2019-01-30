using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace RS2
{
	class Skill : INotifyPropertyChanged
	{
		private readonly uint mAddress;
		private readonly uint mID;

		public Skill(uint address, uint id)
		{
			mAddress = address;
			mID = id;
		}

		public bool Vacate
		{
			get { return SaveData.Instance().ReadBit(mAddress + 24, mID); }
			set { SaveData.Instance().WriteBit(mAddress + 24, mID, value); }
		}

		public uint ID
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 25 + mID, 1); }
			set
			{
				SaveData.Instance().WriteNumber(mAddress + 25 + mID, 1, value);
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ID)));
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;
	}
}
