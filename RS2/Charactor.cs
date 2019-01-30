using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace RS2
{
	class Charactor
	{
		public ObservableCollection<Skill> Skills { get; set; } = new ObservableCollection<Skill>();
		public ObservableCollection<Value> Equipments { get; set; } = new ObservableCollection<Value>();
		public ObservableCollection<Value> Arts { get; set; } = new ObservableCollection<Value>();

		private readonly uint mAddress;

		public Charactor(uint address)
		{
			mAddress = address;

			for (uint i = 0; i < 8; i++)
			{
				Skills.Add(new Skill(address, i));
			}
			for (uint i = 0; i < 7; i++)
			{
				Equipments.Add(new Value(41 + i, 1));
			}
			for (uint i = 0; i < 8; i++)
			{
				Arts.Add(new Value(33 + i, 1));
			}
		}

		public uint ID
		{
			get { return SaveData.Instance().ReadNumber(mAddress, 2); }
			set { SaveData.Instance().WriteNumber(mAddress, 2, value); }
		}

		public uint Graphic
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 2, 1); }
			set { SaveData.Instance().WriteNumber(mAddress + 2, 1, value); }
		}

		public uint Sex
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 3, 1); }
			set { SaveData.Instance().WriteNumber(mAddress + 3, 1, value); }
		}

		public uint Auto
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 4, 1); }
			set { SaveData.Instance().WriteNumber(mAddress + 4, 1, value); }
		}

		public uint HP
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 5, 2); }
			set { Util.WriteNumber(mAddress + 5, 2, value, 1, 999); }
		}

		public uint LP
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 7, 1); }
			set { Util.WriteNumber(mAddress + 7, 1, value, 0, 255); }
		}

		public uint MaxLP
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 8, 1); }
			set { Util.WriteNumber(mAddress + 8, 1, value, 1, 255); }
		}

		public uint JP
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 9, 1); }
			set { Util.WriteNumber(mAddress + 9, 1, value, 0, 255); }
		}

		public uint MaxJP
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 10, 1); }
			set { Util.WriteNumber(mAddress + 10, 1, value, 1, 255); }
		}

		public uint WP
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 11, 1); }
			set { Util.WriteNumber(mAddress + 11, 1, value, 0, 255); }
		}

		public uint MaxWP
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 12, 1); }
			set { Util.WriteNumber(mAddress + 12, 1, value, 1, 255); }
		}

		public uint Sword
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 13, 1); }
			set { Util.WriteNumber(mAddress + 13, 1, value, 0, 99); }
		}

		public uint Ax
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 14, 1); }
			set { Util.WriteNumber(mAddress + 14, 1, value, 0, 99); }
		}

		public uint Spear
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 15, 1); }
			set { Util.WriteNumber(mAddress + 15, 1, value, 0, 99); }
		}

		public uint Bow
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 16, 1); }
			set { Util.WriteNumber(mAddress + 16, 1, value, 0, 99); }
		}

		public uint Magic
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 22, 1); }
			set { Util.WriteNumber(mAddress + 22, 1, value, 0, 99); }
		}
	}
}
