using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
		private uint NumOfRegistered = 0;
		public Form1()
		{
			InitializeComponent();
			this.KeyPress += Form1_KeyPress;
			dataGridView1.CellClick += DataGridView1_CellClick;
			//priezvisko.TextChanged += Priezvisko_TextChanged;

			List<string[]> rows = File.ReadAllLines("reg.csv").Select(x => x.Split(',')).ToList();
			rows.ForEach(x =>
			{
				/*
				byte[] tempBytes = System.Text.Encoding.GetEncoding("UTF-8").GetBytes(x[0]);
				tempBytes = Encoding.Convert(Encoding.UTF8, Encoding.ASCII, tempBytes);
				x[0] = System.Text.Encoding.ASCII.GetString(tempBytes);
				*/
				dataGridView1.Rows.Add(x);
			});

			openApp();
		}


		private void Form1_KeyPress(object sender, KeyPressEventArgs e)
		{
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
					if (((String)v.Cells[0].Value).IndexOf(priezvisko.Text, StringComparison.OrdinalIgnoreCase) == 0)
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
				oWB = (Microsoft.Office.Interop.Excel._Workbook)(oXL.Workbooks.Add(""));
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

		private void SaveCompetitor()
		{
			if (cislo.Text == "")
			{
				MessageBox.Show("Zadaj startove cislo");
				return;
			}
			//object misvalue = System.Reflection.Missing.Value;
			try
			{

				//Format A1:D1 as bold, vertical alignment = center.
				/*
                oSheet.get_Range("A1", "D1").Font.Bold = true;
                oSheet.get_Range("A1", "D1").VerticalAlignment =
                    Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                    
                // Create an array to multiple values at once.
                string[,] saNames = new string[5, 2];

                saNames[0, 0] = "John";
                saNames[0, 1] = "Smith";
                saNames[1, 0] = "Tom";

                saNames[4, 1] = "Johnson";

                //Fill A2:B6 with an array of values (First and Last Names).
                oSheet.get_Range("A2", "B6").Value2 = saNames;

                //Fill C2:C6 with a relative formula (=A2 & " " & B2).
                oRng = oSheet.get_Range("C2", "C6");
                oRng.Formula = "=A2 & \" \" & B2";

                //Fill D2:D6 with a formula(=RAND()*100000) and apply format.
                oRng = oSheet.get_Range("D2", "D6");
                oRng.Formula = "=RAND()*100000";
                oRng.NumberFormat = "$0.00";

                //AutoFit columns A:D.
                oRng = oSheet.get_Range("A1", "D1");
                oRng.EntireColumn.AutoFit();
                */
				NumOfRegistered++;
				oSheet.Cells[NumOfRegistered + 1, 3] = cislo.Text;
				oSheet.Cells[NumOfRegistered + 1, 4] = priezvisko.Text;
				oSheet.Cells[NumOfRegistered + 1, 5] = meno.Text;
				oSheet.Cells[NumOfRegistered + 1, 6] = rocnik.Text;
				oSheet.Cells[NumOfRegistered + 1, 7] = klub.Text;
				oSheet.Cells[NumOfRegistered + 1, 8] = kategoria.Text;

				numOfRegistered.Text = NumOfRegistered.ToString();

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
				NumOfRegistered--;
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

		private void button2_Click(object sender, EventArgs e)
		{
			try
			{

				//oXL.Visible = true;
				oXL.UserControl = false;
				oWB.SaveAs($"out{NumOfRegistered}.xlsx", Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing,
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

		private void priezvisko_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)13)
			{
				dataGridView1.Focus();
				e.Handled = true;
			}
		}

		private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
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

		private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
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

		private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
		{
			ignoreChange = true;
			FillHeader(dataGridView1.SelectedRows[0]); // when click arrow, but update old row data
		}
	}
}
