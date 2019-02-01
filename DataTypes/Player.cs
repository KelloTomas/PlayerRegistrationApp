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
			Player player = new Player();
			player.OrderGeneral = values[0].GetInt();
			player.OrderCategory = values[1].GetInt();
			player.Number = values[2].GetInt();
			player.Firstname = values[3];
			player.Lastname = values[4];
			player.Year = values[5].GetInt();
			player.Club = values[6];
			player.Category = values[7];
			player.Time = values[8].GetTimeSpan();
			return player;
		}


	}
}
