/*
 * Created by SharpDevelop.
 * User: Daan
 * Date: 1-5-2014
 * Time: 21:48
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace Boeiend
{
	public class tVaarwater
	{
		public tVaarwater(string pNaam)
		{			
			Naam = pNaam;
		}
		public	string	Naam		{get; set;}
		public 	bool	isAan		{get; set;}		
	}

	public class tMarkering
	{
		public tMarkering()
		{			
		}
		
		public	string	Vaarwater		{get; set;}
		public	string	Benam_cod		{get; set;}
		public	string	Benaming		{get; set;}
		public	string	Inbedrijf		{get; set;}
		public	string	Y_rd			{get; set;}
		public	string	X_rd			{get; set;}
		public	string	Obj_soort		{get; set;}
		public	string	Iala_cat		{get; set;}
		public	string	N_wgs_gms		{get; set;}
		public	string	E_wgs_gms		{get; set;}
		public	string	N_wgs_gm		{get; set;}
		public	string	E_wgs_gm		{get; set;}
		public	string	Obj_vorm_c		{get; set;}
		public	string	Obj_vorm		{get; set;}
		public	string	Obj_kleur_c		{get; set;}
		public	string	Obj_kleur		{get; set;}
		public	string	Kleurpatr_c		{get; set;}
		public	string	Kleurpatr		{get; set;}
		public	string	V_tt_c			{get; set;}
		public	string	Tt_toptek		{get; set;}
		public	string	Tt_kleur_c		{get; set;}
		public	string	Tt_kleur		{get; set;}
		public	string	Tt_pat_c		{get; set;}
		public	string	Tt_klr_pat		{get; set;}
		public	string	Sign_kar_c		{get; set;}
		public	string	Sign_kar		{get; set;}
		public	string	Sign_gr_c		{get; set;}
		public	string	Sign_groep		{get; set;}
		public	string	Sign_perio		{get; set;}
		public	string	Racon_code		{get; set;}
		public	string	Licht_kl_c		{get; set;}
		public	string	Licht_klr		{get; set;}
		public	string	Opgeheven		{get; set;}
		public	string	X_wgs84			{get; set;}
		public	string	Y_wgs84			{get; set;}
	}

	/// <summary>
	/// Interaction logic for Markeringsscherm.xaml
	/// </summary>
	public partial class Markeringsscherm : UserControl
	{
		private Export 								gExport = null;
		private List<tMarkering>					gaMarkering		= new List<tMarkering>();
		private List<tMarkering>					gaFiltering		= new List<tMarkering>();
		private Dictionary<string, bool>			gaVaarwater 	= new Dictionary<string, bool>();

		public Markeringsscherm()
		{
			InitializeComponent();
			
			lvMarkeringen.ItemsSource 	= gaFiltering;
			lbVaarwater.ItemsSource 	= gaVaarwater;
		}

		public Export Export
		{
			set { gExport = value; }
			get { return gExport; }
		}
		
		public void ParseCsvBestand(string pBestandsnaam)
		{
	    	int			lRegelnummer = 1;
	    	string 		lRegel;
			TextReader 	lFileHandle = null;
			
			gaMarkering.Clear();
			gaVaarwater.Clear();
			
			gaVaarwater.Add("Allemaal", true);

			try
			{
				lFileHandle = new StreamReader(pBestandsnaam);
				while ((lRegel = lFileHandle.ReadLine()) != null)
				{
					string [] laWoord = lRegel.Split(';');
					if (lRegelnummer > 1 && laWoord.Length > 30)
					{
						var lMarkering = new tMarkering();
						lMarkering.Vaarwater 	= laWoord[0];
						lMarkering.Benam_cod 	= laWoord[1];
						lMarkering.Benaming		= laWoord[2];
						lMarkering.Inbedrijf 	= laWoord[3];
						lMarkering.Y_rd	 		= laWoord[4];
						lMarkering.X_rd	 		= laWoord[5];
						lMarkering.Obj_soort 	= laWoord[6];
						lMarkering.Iala_cat 	= laWoord[7];
						lMarkering.N_wgs_gms 	= laWoord[8];
						lMarkering.E_wgs_gms 	= laWoord[9];
						lMarkering.N_wgs_gm 	= laWoord[10];
						lMarkering.E_wgs_gm 	= laWoord[11];
						lMarkering.Obj_vorm_c 	= laWoord[12];
						lMarkering.Obj_vorm 	= laWoord[13];
						lMarkering.Obj_kleur_c 	= laWoord[14];
						lMarkering.Obj_kleur 	= laWoord[15];
						lMarkering.Kleurpatr_c 	= laWoord[16];
						lMarkering.Kleurpatr 	= laWoord[17];
						lMarkering.V_tt_c	 	= laWoord[18];
						lMarkering.Tt_toptek 	= laWoord[19];
						lMarkering.Tt_kleur_c 	= laWoord[20];
						lMarkering.Tt_kleur 	= laWoord[21];
						lMarkering.Tt_pat_c 	= laWoord[22];
						lMarkering.Tt_klr_pat 	= laWoord[23];
						lMarkering.Sign_kar_c 	= laWoord[24];
						lMarkering.Sign_kar 	= laWoord[25];
						lMarkering.Sign_gr_c 	= laWoord[26];
						lMarkering.Sign_groep 	= laWoord[27];
						lMarkering.Sign_perio 	= laWoord[28];
						lMarkering.Racon_code 	= laWoord[29];
						lMarkering.Licht_kl_c 	= laWoord[30];
						lMarkering.Licht_klr 	= laWoord[31];
						lMarkering.Opgeheven 	= laWoord[32];
						lMarkering.X_wgs84	 	= laWoord[33];
						lMarkering.Y_wgs84	 	= laWoord[34];
						
						if (lMarkering.Vaarwater == "")
						{
							continue;
						}
						
						gaMarkering.Add(lMarkering);
						gaFiltering.Add(lMarkering);

						if (!gaVaarwater.ContainsKey(lMarkering.Vaarwater)) gaVaarwater.Add(lMarkering.Vaarwater, true);
					}
					lRegelnummer++;
				}
			}
			catch
			{
				Log.VoegToe(Severity.Fatal, "Bestand <{0}> niet ingelezen. Fout op regel {1}", pBestandsnaam, lRegelnummer);
				return;
			}
			finally
			{
				if (lFileHandle!=null)
				{
					lFileHandle.Close();
				}
				lvMarkeringen.Items.Refresh();
				lbVaarwater.Items.Refresh();
				Log.VoegToe(Severity.Info, "CSV-bestand ingelezen");
			}
		}

		public void BewaarBestand(string pBestandsnaam)
		{
			if (gExport != null)
			{
				gExport.BewaarBestand(pBestandsnaam, gaFiltering);
			}
		}
		
		private void cbItemChanged(object pSender, RoutedEventArgs e)
		{
			var lCheckBox = pSender as CheckBox;
			
			if (lCheckBox.Content.ToString() == "Allemaal")
			{
				foreach (var lKey in new List<string>(gaVaarwater.Keys))
				{
					gaVaarwater[lKey] = (bool)lCheckBox.IsChecked;
				}
			}
			else
			{
				gaVaarwater[lCheckBox.Content.ToString()] = (bool)lCheckBox.IsChecked;
			}
			gaFiltering.Clear();
			foreach(var lMarkering in gaMarkering)
			{
				if (gaVaarwater[lMarkering.Vaarwater])
				{
					gaFiltering.Add(lMarkering);
				}
			}
			lvMarkeringen.Items.Refresh();
			lbVaarwater.Items.Refresh();
		}
	}
}