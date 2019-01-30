using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace RS2
{
	/// <summary>
	/// MainWindow.xaml の相互作用ロジック
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void Window_PreviewDragOver(object sender, DragEventArgs e)
		{
			e.Handled = e.Data.GetDataPresent(DataFormats.FileDrop);
		}

		private void Window_Drop(object sender, DragEventArgs e)
		{
			String[] files = e.Data.GetData(DataFormats.FileDrop) as String[];
			if (files == null) return;
			if (!System.IO.File.Exists(files[0])) return;

			Load(files[0]);
		}

		private void MenuItemFileOpen_Click(object sender, RoutedEventArgs e)
		{
			OpenFileDialog dlg = new OpenFileDialog();
			if (dlg.ShowDialog() == false) return;

			Load(dlg.FileName);
		}

		private void MenuItemFileSave_Click(object sender, RoutedEventArgs e)
		{
			Save();
		}

		private void MenuItemFileSaveAs_Click(object sender, RoutedEventArgs e)
		{
			SaveFileDialog dlg = new SaveFileDialog();
			if (dlg.ShowDialog() == false) return;

			if (SaveData.Instance().SaveAs(dlg.FileName) == true) MessageBox.Show("Success");
			else MessageBox.Show("Fail");
		}

		private void MenuItemExit_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void MenuItemAbout_Click(object sender, RoutedEventArgs e)
		{
			new AboutWindow().ShowDialog();
		}

		private void Load(String filename)
		{
			if (SaveData.Instance().Open(filename) == false)
			{
				MessageBox.Show("Fail");
				return;
			}

			DataContext = new DataContext();
			MessageBox.Show("Success");
		}

		private void Save()
		{
			if (SaveData.Instance().Save() == true) MessageBox.Show("Success");
			else MessageBox.Show("Fail");
		}

		private void ButtonArt_Click(object sender, RoutedEventArgs e)
		{
			Value v = (sender as Button)?.DataContext as Value;
			if (v == null) return;
			v.ID = Choice(v.ID, ChoiceWindow.eType.eArt);
		}

		private void ButtonSkill_Click(object sender, RoutedEventArgs e)
		{
			Skill v = (sender as Button)?.DataContext as Skill;
			if (v == null) return;
			v.ID = Choice(v.ID, ChoiceWindow.eType.eSkill);
		}

		private void ButtonEquipment_Click(object sender, RoutedEventArgs e)
		{
			Value v = (sender as Button)?.DataContext as Value;
			if (v == null) return;
			v.ID = Choice(v.ID, ChoiceWindow.eType.eItem);
		}

		private uint Choice(uint id, ChoiceWindow.eType type)
		{
			var dlg = new ChoiceWindow();
			dlg.ID = id;
			dlg.Type = type;
			dlg.ShowDialog();
			return dlg.ID;
		}
	}
}
