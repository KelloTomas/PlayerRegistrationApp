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
		public MainWindow()
		{
			InitializeComponent();
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
				PlayersWithTime.Add(currPlayer);
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
					PlayersWithTime.SetOrder();
					string html = File.ReadAllText("head.html");
					foreach (var category in Enum.GetNames(typeof(Category)).Cast<string>().ToArray())
					{
						html += $"<H1>{category}</H1><table>" +
							$"<tr>" +
							$"<th>Por</th>" +
							$"<th>PorKat</th>" +
							$"<th>Číslo</th>" +
							$"<th>Priezvisko</th>" +
							$"<th>Meno</th>" +
							$"<th>Ročník</th>" +
							$"<th>Klub</th>" +
							$"<th>Kat.</th>" +
							$"<th>Čas</th>" +
							$"</tr>";
						foreach (var player in PlayersWithTime.Where(p => p.Category == category).OrderBy(p => p.Time))
						{
							html += $"<tr>" +
								$"<td>{player.OrderGeneral}</td>" +
								$"<td>{player.OrderCategory}</td>" +
								$"<td>{player.Number}</td>" +
								$"<td>{player.Lastname}</td>" +
								$"<td>{player.Firstname}</td>" +
								$"<td>{player.Year}</td>" +
								$"<td>{player.Club}</td>" +
								$"<td>{player.Category}</td>" +
								$"<td>{player.Time}</td>" +
								$"</tr>";
						}
						html += $"</table>";
					}
					html += "</body></html>";
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
