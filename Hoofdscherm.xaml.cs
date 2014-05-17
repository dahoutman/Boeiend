/*
 * Created by SharpDevelop.
 * User: Daan
 * Date: 1-5-2014
 * Time: 21:43
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
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
	/// <summary>
	/// Interaction logic for Window1.xaml
	/// </summary>
	public partial class Hoofdscherm : Window
	{
		string	gFullName = "";

		public Hoofdscherm()
		{
			InitializeComponent();
			Log.Toegevoegd += VoegLoggingToe;
			Log.VoegToe(Severity.Info, "Boeiend versie {0} opgestart", System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString());

			Instellingenscherm.ActGelezen += new ActGelezenEventHandler(InvokeActiviteit);
		}
		
 		private void InvokeActiviteit(object pObject, eFormaat pFormaat)
 		{
 			switch(pFormaat)
 			{
 				case eFormaat.OpenCPN: 	Markeringsscherm.Export = new GPX(); break;
 				case eFormaat.LocsMaps: Markeringsscherm.Export = new GPX(); break;
 				case eFormaat.WinGPS: 	Markeringsscherm.Export = new CSV(); break;
 			}
 		}

 		private void VoegLoggingToe(object pSender, tLogEventArgs pEA)
		{
			Loggingscherm.VoegLoggingToe(pEA);
		}
		
		private void miOpenClick(object sender, RoutedEventArgs e)
		{
			var lFD = new OpenFileDialog();
			lFD.CheckFileExists = true;
			lFD.Multiselect = false;
			lFD.Filter = "Supported (*.csv)|*.csv|All (*.*)|*.*" ;
			bool? lDialogResult = lFD.ShowDialog();
			if (lDialogResult == true)	
			{
				foreach (string lFileName in lFD.FileNames)
				{
					Markeringsscherm.ParseCsvBestand(lFileName);
				}
			}
		}
		
		private void miExportClick(object sender, RoutedEventArgs e)
		{
			var lFD = new SaveFileDialog();
			lFD.CheckFileExists = false;
			lFD.OverwritePrompt = true;
			switch (Instellingenscherm.Formaat)
			{
				case eFormaat.OpenCPN: 	lFD.Filter = "Supported (*.gpx)|*.gpx|All (*.*)|*.*" ; break;
				case eFormaat.LocsMaps:	lFD.Filter = "Supported (*.gpx)|*.gpx|All (*.*)|*.*" ; break;
				case eFormaat.WinGPS: 	lFD.Filter = "Supported (*.csv)|*.csv|All (*.*)|*.*" ; break;
			}
			bool? lResult = lFD.ShowDialog();
			if (lResult == true)	
			{
				gFullName = lFD.FileName;
				Markeringsscherm.BewaarBestand(lFD.FileName);
			}
		}
		
		private void miSaveAsClick(object sender, RoutedEventArgs e)
		{
		}
		
		private void miExitClick(object sender, RoutedEventArgs e)
		{
			Environment.Exit(0);
		}
		
		private void miVerwijderActsClick(object sender, RoutedEventArgs e)
		{
		}
		
		private void miHelpClick(object sender, RoutedEventArgs e)
		{
		}
		
		private void miAboutClick(object sender, RoutedEventArgs e)
		{
			About lDialoog = new About();
			lDialoog.ShowDialog();
		}
	}
}