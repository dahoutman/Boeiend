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
using System.Linq;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

using Microsoft.Win32;

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
		public	string	S57_id			{get; set;}
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
		private const string						cRegister = "Vaarwaters";

		public Markeringsscherm()
		{
			InitializeComponent();
			
			lvMarkeringen.ItemsSource 	= gaFiltering;
			lbVaarwater.ItemsSource 	= gaVaarwater;
		}

		~Markeringsscherm()
		{
			if (gaVaarwater.Count > 0)
			{
				List<string> lWaarde = new List<string>();
				foreach (var lVaarwater in gaVaarwater)
				{
					if (lVaarwater.Value)
					{
						lWaarde.Add(lVaarwater.Key);
					}
				}
				Register.Sleutel.SetValue(cRegister, lWaarde.ToArray(), RegistryValueKind.MultiString);
			}
		}

		public Export Export
		{
			set { gExport = value; }
			get { return gExport; }
		}
		
		public void ParseCsvBestand(string pBestandsnaam)
		{
	    	int				lRegelnummer = 1;
	    	string 			lRegel;
			TextReader 		lFileHandle = null;
			var				laKolom = new Dictionary<string, int>();
			string [] 		gaRegister = (string [])Register.Sleutel.GetValue(cRegister);
			
			gaMarkering.Clear();
			gaFiltering.Clear();
			gaVaarwater.Clear();
			
			if (gaRegister == null || gaRegister.Length == 0)
			{
				gaVaarwater.Add("Allemaal", true);
			}
			else
			{
				gaVaarwater.Add("Allemaal", false);
			}

			try
			{
				lFileHandle = new StreamReader(pBestandsnaam);
				while ((lRegel = lFileHandle.ReadLine()) != null)
				{
					string [] laWoord = lRegel.Split(';');
					if (lRegelnummer == 1)
					{
						for (int i=0; i<laWoord.Length; i++)
						{
							if (laWoord[i].Trim() != "")
							{
								laKolom.Add(laWoord[i].Trim().ToUpper(), i);
							}
						}
					}
					if (lRegelnummer > 1 && laWoord.Length > 30)
					{
						var lMarkering = new tMarkering();
						lMarkering.Vaarwater 	= BepaalKolomindex(laKolom, laWoord, "VAARWATER");
						lMarkering.Benam_cod 	= BepaalKolomindex(laKolom, laWoord, "BENAM_COD");
						lMarkering.Benaming		= BepaalKolomindex(laKolom, laWoord, "BENAMING");
						lMarkering.S57_id		= BepaalKolomindex(laKolom, laWoord, "S57_ID");
						lMarkering.Inbedrijf 	= BepaalKolomindex(laKolom, laWoord, "INBEDRIJF");
						lMarkering.Y_rd	 		= BepaalKolomindex(laKolom, laWoord, "Y_RD");
						lMarkering.X_rd	 		= BepaalKolomindex(laKolom, laWoord, "X_RD");
						lMarkering.Obj_soort 	= BepaalKolomindex(laKolom, laWoord, "OBJ_SOORT");
						lMarkering.Iala_cat 	= BepaalKolomindex(laKolom, laWoord, "IALA_CAT");
						lMarkering.N_wgs_gms 	= BepaalKolomindex(laKolom, laWoord, "N_WGS_GMS");
						lMarkering.E_wgs_gms 	= BepaalKolomindex(laKolom, laWoord, "E_WGS_GMS");
						lMarkering.N_wgs_gm 	= BepaalKolomindex(laKolom, laWoord, "N_WGS_GM");
						lMarkering.E_wgs_gm 	= BepaalKolomindex(laKolom, laWoord, "E_WGS_GM");
						lMarkering.Obj_vorm_c 	= BepaalKolomindex(laKolom, laWoord, "OBJ_VORM_C");
						lMarkering.Obj_vorm 	= BepaalKolomindex(laKolom, laWoord, "OBJ_VORM");
						lMarkering.Obj_kleur_c 	= BepaalKolomindex(laKolom, laWoord, "OBJ_KLEUR_C");
						lMarkering.Obj_kleur 	= BepaalKolomindex(laKolom, laWoord, "OBJ_KLEUR");
						lMarkering.Kleurpatr_c 	= BepaalKolomindex(laKolom, laWoord, "KLEURPATR_C");
						lMarkering.Kleurpatr 	= BepaalKolomindex(laKolom, laWoord, "KLEURPATR");
						lMarkering.V_tt_c	 	= BepaalKolomindex(laKolom, laWoord, "V_TT_C");
						lMarkering.Tt_toptek 	= BepaalKolomindex(laKolom, laWoord, "TT_TOPTEK");
						lMarkering.Tt_kleur_c 	= BepaalKolomindex(laKolom, laWoord, "TT_KLEUR_C");
						lMarkering.Tt_kleur 	= BepaalKolomindex(laKolom, laWoord, "TT_KLEUR");
						lMarkering.Tt_pat_c 	= BepaalKolomindex(laKolom, laWoord, "TT_PAT_C");
						lMarkering.Tt_klr_pat 	= BepaalKolomindex(laKolom, laWoord, "TT_KLR_PAT");
						lMarkering.Sign_kar_c 	= BepaalKolomindex(laKolom, laWoord, "SIGN_KAR_C");
						lMarkering.Sign_kar 	= BepaalKolomindex(laKolom, laWoord, "SIGN_KAR");
						lMarkering.Sign_gr_c 	= BepaalKolomindex(laKolom, laWoord, "SIGN_GR_C");
						lMarkering.Sign_groep 	= BepaalKolomindex(laKolom, laWoord, "SIGN_GROEP");
						lMarkering.Sign_perio 	= BepaalKolomindex(laKolom, laWoord, "SIGN_PERIO");
						lMarkering.Racon_code 	= BepaalKolomindex(laKolom, laWoord, "RACON_CODE");
						lMarkering.Licht_kl_c 	= BepaalKolomindex(laKolom, laWoord, "LICHT_KL_C");
						lMarkering.Licht_klr 	= BepaalKolomindex(laKolom, laWoord, "LICHT_KLR");
						lMarkering.Opgeheven 	= BepaalKolomindex(laKolom, laWoord, "OPGEHEVEN");
						lMarkering.X_wgs84	 	= BepaalKolomindex(laKolom, laWoord, "X_WGS84");
						lMarkering.Y_wgs84	 	= BepaalKolomindex(laKolom, laWoord, "Y_WGS84");
						
						if (lMarkering.Vaarwater == "")
						{
							continue;
						}
						
						gaMarkering.Add(lMarkering);

						if (!gaVaarwater.ContainsKey(lMarkering.Vaarwater)) 
						{
							if (gaRegister == null || gaRegister.Length == 0 || gaRegister.Any(lMarkering.Vaarwater.Equals))
							{
								gaVaarwater.Add(lMarkering.Vaarwater, true);
							}
							else
							{
								gaVaarwater.Add(lMarkering.Vaarwater, false);
							}
						}
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
				BepaalFiltering();
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
		
		private string BepaalKolomindex	(Dictionary<string, int> paKolom, string [] paWoord, string pKey)
		{
			return paKolom.ContainsKey(pKey) ? paWoord[paKolom[pKey]] : "";
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
			BepaalFiltering();			
			lbVaarwater.Items.Refresh();
		}
		
		private void BepaalFiltering()
		{
			gaFiltering.Clear();
			foreach(var lMarkering in gaMarkering)
			{
				if (gaVaarwater[lMarkering.Vaarwater])
				{
					gaFiltering.Add(lMarkering);
				}
			}
			lvMarkeringen.Items.Refresh();
		}
	}
}