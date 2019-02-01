﻿using DataTypes;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
	public partial class Form1 : Form
	{
		private bool ignoreChange = false;
		private Microsoft.Office.Interop.Excel.Application oXL;
		private Microsoft.Office.Interop.Excel._Workbook oWB;
		private Microsoft.Office.Interop.Excel._Worksheet oSheet;
		private Microsoft.Office.Interop.Excel.Range oRng;
		private ObservableCollection<Player> RegisteredPlayers = new ObservableCollection<Player>();
		public Form1()
		{
			InitializeComponent();
			dataGridView1.CellClick += DataGridView1_CellClick;
			//priezvisko.TextChanged += Priezvisko_TextChanged;

			OpenFileDialog openFileDialog = new OpenFileDialog
			{
				Filter = "csv files (*.csv)|*.csv"
			};

			if (openFileDialog.ShowDialog() != DialogResult.OK)
			{
				Close();
			}
			else
			{
				List<string[]> rows = File.ReadAllLines(openFileDialog.FileName).Select(x => x.Split(';')).ToList();
				rows.ForEach(x =>
				{
					/*
					byte[] tempBytes = System.Text.Encoding.GetEncoding("UTF-8").GetBytes(x[0]);
					tempBytes = Encoding.Convert(Encoding.UTF8, Encoding.ASCII, tempBytes);
					x[0] = System.Text.Encoding.ASCII.GetString(tempBytes);
					*/
					dataGridView1.Rows.Add(x);
				});

				kategoria.DataSource = Enum.GetValues(typeof(Category));

				openApp();
			}
		}

		private void Priezvisko_TextChanged(object sender, EventArgs e)
		{
			if (ignoreChange)
			{
				ignoreChange = false;
				return;
			}
			//CultureInfo c = new CultureInfo("sk-SK");
			foreach (DataGridViewRow v in dataGridView1.Rows)
			{
				try
				{
					if (((string)v.Cells[0].Value).IndexOf(priezvisko.Text, StringComparison.OrdinalIgnoreCase) == 0)
					//if (String.Compare(((String)v.Cells[0].Value).Substring(0, priezvisko.Text.Length), priezvisko.Text, c, CompareOptions.IgnoreNonSpace | CompareOptions.IgnoreCase) == 0)
					{
						v.Visible = true;
					}
					else
					{
						v.Visible = false;
					}
				}
				catch (ArgumentOutOfRangeException)

				{
					v.Visible = false;
				}
				catch (Exception)
				{

				}
			}
		}

		private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			//cislo.Focus();
			ignoreChange = true;
			//priezvisko.TextChanged -= Priezvisko_TextChanged;
			FillHeader(dataGridView1.Rows[e.RowIndex]);


			//priezvisko.TextChanged += Priezvisko_TextChanged;
		}

		private void FillHeader(DataGridViewRow data)
		{
			try
			{
				priezvisko.Text = data.Cells[0].Value.ToString();
				meno.Text = data.Cells[1].Value.ToString();
				rocnik.Text = data.Cells[2].Value.ToString();
				klub.Text = data.Cells[3].Value.ToString();
				kategoria.Text = data.Cells[4].Value.ToString();
			}
			catch (Exception)
			{
			}
		}

		private void openApp()
		{
			try
			{
				//Start Excel and get Application object.
				oXL = new Microsoft.Office.Interop.Excel.Application();
				oXL.Visible = true;
				oXL.UserControl = false;

				//Get a new workbook.
				oWB = oXL.Workbooks.Add("");
				oSheet = (Microsoft.Office.Interop.Excel._Worksheet)oWB.ActiveSheet;

				// create table
				oRng = oSheet.get_Range("A1:I1");
				oSheet.ListObjects.AddEx(XlListObjectSourceType.xlSrcRange, oRng, Microsoft.Office.Interop.Excel.XlYesNoGuess.xlNo).Name = "MyTableStyle";
				oSheet.ListObjects.get_Item("MyTableStyle").TableStyle = "TableStyleMedium1";

				//Add table headers going cell by cell.
				oSheet.Cells[1, 1] = "Poradie";
				oSheet.Cells[1, 2] = "Poradie kat.";
				oSheet.Cells[1, 3] = "Cislo";
				oSheet.Cells[1, 4] = "Priezvisko";
				oSheet.Cells[1, 5] = "Meno";
				oSheet.Cells[1, 6] = "Rocnik";
				oSheet.Cells[1, 7] = "Klub";
				oSheet.Cells[1, 8] = "Kat.";
				oSheet.Cells[1, 9] = "Cas";
			}
			catch
			{

			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			SaveCompetitor();
		}

		private int ParseOrDefault(string number)
		{
			int.TryParse(number, out int n);
			return n;
		}
		private void SaveCompetitor()
		{
			if (!int.TryParse(cislo.Text, out int number))
			{
				MessageBox.Show("Zadaj startove cislo");
				cislo.Focus();
				return;
			}

			try
			{
				Player player = new Player
				{
					OrderGeneral = 0,
					OrderCategory = 0,
					Number = number,
					Lastname = priezvisko.Text,
					Firstname = meno.Text,
					Year = ParseOrDefault(rocnik.Text),
					Club = klub.Text,
					Category = kategoria.Text
				};
				RegisteredPlayers.Add(player);
				oSheet.Cells[RegisteredPlayers.Count + 1, 3] = cislo.Text;
				oSheet.Cells[RegisteredPlayers.Count + 1, 4] = priezvisko.Text;
				oSheet.Cells[RegisteredPlayers.Count + 1, 5] = meno.Text;
				oSheet.Cells[RegisteredPlayers.Count + 1, 6] = rocnik.Text;
				oSheet.Cells[RegisteredPlayers.Count + 1, 7] = klub.Text;
				oSheet.Cells[RegisteredPlayers.Count + 1, 8] = kategoria.Text;
				numOfRegistered.Text = RegisteredPlayers.Count.ToString();

				priezvisko.Text = "";
				meno.Text = "";
				rocnik.Text = "";
				klub.Text = "";
				kategoria.ResetText();
				cislo.Text = "";

				priezvisko.Focus();
				ShowAllRecordsInTable();
			}
			catch
			{
				MessageBox.Show("Did not added");
			}
		}

		private void ShowAllRecordsInTable()
		{

			foreach (DataGridViewRow v in dataGridView1.Rows)
			{
				try
				{
					v.Visible = true;
				}
				catch (Exception)
				{
				}
			}
		}

		private void btn_SaveXLSX(object sender, EventArgs e)
		{
			try
			{

				//oXL.Visible = true;
				oXL.UserControl = false;
				oWB.SaveAs($"out{RegisteredPlayers}.xlsx", Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing,
					false, false, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange,
					Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

				//oWB.Close();
			}
			catch
			{

			}
		}

		private void Cislo_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				SaveCompetitor();
				e.Handled = true;
				return;
			}
			if (e.KeyChar == (char)Keys.Escape)
			{
				dataGridView1.Focus();
				e.Handled = true;
				return;
			}
		}

		private void Priezvisko_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				dataGridView1.Focus();
				e.Handled = true;
			}
		}

		private void DataGridView1_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				ignoreChange = true;
				FillHeader(dataGridView1.SelectedRows[0]);
				cislo.Focus();
				e.Handled = true;
				return;
			}
			if (e.KeyChar == (char)Keys.Escape)
			{
				ignoreChange = true;
				priezvisko.Focus();
				e.Handled = true;
				return;
			}
		}

		private void DataGridView1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				e.Handled = true;
				return;
			}
			/*
			ignoreChange = true;
			FillHeader(dataGridView1.SelectedRows[0]); // when click arrow, but update old row data
			*/
		}

		private void DataGridView1_KeyUp(object sender, KeyEventArgs e)
		{
			ignoreChange = true;
			FillHeader(dataGridView1.SelectedRows[0]); // when click arrow, but update old row data
		}

		private void Btn_SaveCSV(object sender, EventArgs e)
		{
			File.WriteAllText($"reg-{RegisteredPlayers.Count}.csv", RegisteredPlayers.GetInCSV());
		}
	}
}
