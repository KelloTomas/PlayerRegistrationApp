using DataTypes;
using DevExpress.XtraRichEdit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace TimeAssign
{
	public partial class MainWindow : Window
	{
		public ObservableCollection<Player> PlayersWithTime { get; set; } = new ObservableCollection<Player>();
		public List<Player> PlayersDb;
		private string htmlFileName;
		public MainWindow()
		{
			InitializeComponent();
			htmlFileName = $"{DateTime.Now.ToString("HH-mm-ss")}.html";
			DataContext = this;
		}
		protected override void OnContentRendered(EventArgs e)
		{
			base.OnContentRendered(e);
			System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog
			{
				Filter = "csv files (*.csv)|*.csv"
			};

			if (openFileDialog.ShowDialog() != System.Windows.Forms.DialogResult.OK)
			{
				Close();
			}
			else
			{
				PlayersDb = File.ReadAllLines(openFileDialog.FileName)
											   .Select(line => Player.FromCsv(line))
											   .ToList();
			}
		}

		private void Sec_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Tab)
			{
				var currPlayer = PlayersDb.FirstOrDefault(p => p.Number == number.Text.GetInt());
				if (currPlayer == null)
				{
					MessageBox.Show($"Zaznam s cislom {number.Text} sa nenaisel");
					return;
				}
				currPlayer.Time = new TimeSpan(hour.Text.GetInt(), min.Text.GetInt(), sec.Text.GetInt());
				PlayersWithTime.Add(currPlayer.Copy());
				PlayersWithTime.SetOrder();
				number.Clear();
				hour.Clear();
				min.Text = "";
				sec.Text = "";
				number.Focus();
				e.Handled = true;
			}
		}

		private void Button_Click_PDF(object sender, RoutedEventArgs e)
		{
			try
			{
				var saveFileDialog = new System.Windows.Forms.SaveFileDialog
				{
					DefaultExt = ".pdf",
					Filter = "pdf files (*.pdf)|*.pdf|All files (*.*)|*.*",
					FileName = $"Results.pdf"
				};
				if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				{
					string html = File.ReadAllText("headPdf.html");
					html += PlayersWithTime.GetInHTMLByCat();
					RichEditDocumentServer r = new RichEditDocumentServer
					{
						HtmlText = html
					};
					r.ExportToPdf(saveFileDialog.FileName);
				}
			}
			catch (Exception)
			{

			}
		}

		
		private bool _isHtmlOpen = false;
		private void Button_Click_HTML(object sender, RoutedEventArgs e)
		{
			try
			{
				File.WriteAllLines("results" + htmlFileName, new string [] { File.ReadAllText("headHtml.html"), PlayersWithTime.GetInHTML(), "</body></head>"});
				if (!_isHtmlOpen)
				{
					System.Diagnostics.Process.Start("results" + htmlFileName);
					_isHtmlOpen = true;
				}
			}
			catch (Exception)
			{

			}
		}
		private bool _isHtmlByCatOpen = false;
		private void Button_Click_HTMLByCat(object sender, RoutedEventArgs e)
		{
			try
			{
				File.WriteAllLines("resultsCat" + htmlFileName, new string [] { File.ReadAllText("headHtml.html"), PlayersWithTime.GetInHTMLByCat(), "</body></head>"});
				if (!_isHtmlByCatOpen)
				{
					System.Diagnostics.Process.Start("resultsCat" + htmlFileName);
					_isHtmlByCatOpen = true;
				}
			}
			catch (Exception)
			{

			}
		}
		private void Button_Click_CSV(object sender, RoutedEventArgs e)
		{
			try
			{
				var saveFileDialog = new System.Windows.Forms.SaveFileDialog
				{
					DefaultExt = ".csv",
					Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*",
					FileName = $"results-{PlayersWithTime.Count}.csv"
				};
				if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				{
					File.WriteAllText(saveFileDialog.FileName, PlayersWithTime.GetInCSV());
				}
			}
			catch (Exception)
			{

			}
		}
	}
}
