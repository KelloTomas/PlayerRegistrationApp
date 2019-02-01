using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace DataTypes
{
	public static class Extensions
	{
		public static T? GetValueOrNull<T>(this string valueAsString) where T : struct
		{
			if (string.IsNullOrEmpty(valueAsString))
				return null;
			return (T)Convert.ChangeType(valueAsString, typeof(T));
		}
		public static int GetInt(this string valueAsString)
		{
			int variable = 0;
			int.TryParse(valueAsString, out variable);
			return variable;
		}
		public static TimeSpan GetTimeSpan(this string valueAsString)
		{
			TimeSpan variable = new TimeSpan(0);
			TimeSpan.TryParse(valueAsString, out variable);
			return variable;
		}
		public static void SetOrder(this ObservableCollection<Player> players)
		{
			players.SetGeneralOrder();
			players.SetCategoryOrder();
		}
		public static void SetGeneralOrder(this ObservableCollection<Player> players)
		{
			int order = 0;
			foreach (var player in players.OrderBy(p => p.Time))
			{
				player.OrderGeneral = ++order;
			}
		}
		public static void SetCategoryOrder(this ObservableCollection<Player> players)
		{
			foreach (var category in Enum.GetNames(typeof(Category)).Cast<string>().ToArray())
			{
				int poradieCat = 0;
				foreach (var player in players.Where(p => p.Category == category).OrderBy(p => p.Time))
				{
					player.OrderCategory = ++poradieCat;
				}
			}
		}


		public static string GetInHTML(this ObservableCollection<Player> players)
		{
			players.SetOrder();
			string html = string.Empty;
			html += $"<H1>Vysledky</H1><table>" +
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
			foreach (var player in players.OrderBy(p => p.Time))
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
			return html;
		}
		public static string GetInHTMLByCat(this ObservableCollection<Player> players)
		{
			players.SetOrder();
			string html = string.Empty;
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
				foreach (var player in players.Where(p => p.Category == category).OrderBy(p => p.Time))
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
			return html;
		}
		public static string GetInCSV(this ObservableCollection<Player> players)
		{
			players.SetOrder();
			string csvContent = string.Empty;
			csvContent += $"Por;PorKat;Číslo;Priezvisko;Meno;Ročník;Klub;Kat.;Čas\n";
			foreach (var player in players.OrderBy(p => p.Time))
			{
				csvContent += $"{player.OrderGeneral}" +
					$";{player.OrderCategory}" +
					$";{player.Number}" +
					$";{player.Lastname}" +
					$";{player.Firstname}" +
					$";{player.Year}" +
					$";{player.Club}" +
					$";{player.Category}" +
					$";{player.Time}\n";
			}
			return csvContent;
		}
		public static string GetInCSVByCat(this ObservableCollection<Player> players)
		{
			players.SetOrder();
			string csvContent = string.Empty;
			foreach (var category in Enum.GetNames(typeof(Category)).Cast<string>().ToArray())
			{
				csvContent += $"\n\nPor;PorKat;Číslo;Priezvisko;Meno;Ročník;Klub;Kat.;Čas\n";
				foreach (var player in players.Where(p => p.Category == category).OrderBy(p => p.Time))
				{
					csvContent += $"{player.OrderGeneral}" +
						$";{player.OrderCategory}" +
						$";{player.Number}" +
						$";{player.Lastname}" +
						$";{player.Firstname}" +
						$";{player.Year}" +
						$";{player.Club}" +
						$";{player.Category}" +
						$";{player.Time}\n";
				}
			}
			return csvContent;
		}
	}
	public class Player
	{
		public int OrderGeneral { get; set; }
		public int OrderCategory { get; set; }
		public int Number { get; set; }
		public string Firstname { get; set; }
		public string Lastname { get; set; }
		public int Year { get; set; }
		public string Club { get; set; }
		public string Category { get; set; }
		public TimeSpan Time { get; set; }

		public static Player FromCsv(string csvLine)
		{
			string[] values = csvLine.Split(';');
			Player player = new Player
			{
				OrderGeneral = values[0].GetInt(),
				OrderCategory = values[1].GetInt(),
				Number = values[2].GetInt(),
				Firstname = values[3],
				Lastname = values[4],
				Year = values[5].GetInt(),
				Club = values[6],
				Category = values[7],
				Time = values[8].GetTimeSpan()
			};
			return player;
		}

		public Player Copy()
		{
			Player player = new Player
			{
				OrderGeneral = 0,
				OrderCategory = 0,
				Number = Number,
				Firstname = Firstname,
				Lastname = Lastname,
				Year = Year,
				Club = Club,
				Category = Category,
				Time = Time
			};
			return player;
		}
	}
}
