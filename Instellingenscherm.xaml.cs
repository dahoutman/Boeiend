/*
 * Created by SharpDevelop.
 * User: Daan
 * Date: 1-5-2014
 * Time: 21:48
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace Boeiend
{
	public enum				eFormaat {OpenCPN, LocsMaps, WinGPS, OziExp};
	public delegate void 	ActGelezenEventHandler(object pSender, eFormaat pFormaat);

	/// <summary>
	/// Interaction logic for Instellingenscherm.xaml
	/// </summary>
	public partial class Instellingenscherm : UserControl
	{
		public eFormaat							gFormaat;
		public event ActGelezenEventHandler 	ActGelezen;

		public eFormaat Formaat
		{
			get { return gFormaat; }
		}

		public Instellingenscherm()
		{
			InitializeComponent();
		}
		
		private void rbOpencpnClicked(object sender, RoutedEventArgs e)
		{
			gFormaat = eFormaat.OpenCPN;
			if (ActGelezen != null) ActGelezen(sender, eFormaat.OpenCPN);
		}
		
		private void rbLocusChecked(object sender, RoutedEventArgs e)
		{
			gFormaat = eFormaat.LocsMaps;
			if (ActGelezen != null) ActGelezen(sender, eFormaat.LocsMaps);
		}
		
		private void rbWingpsChecked(object sender, RoutedEventArgs e)
		{
			gFormaat = eFormaat.WinGPS;
			if (ActGelezen != null) ActGelezen(sender, eFormaat.WinGPS);
		}

		private void rbOziExpChecked(object sender, RoutedEventArgs e)
		{
			gFormaat = eFormaat.OziExp;
			if (ActGelezen != null) ActGelezen(sender, eFormaat.OziExp);
		}
	}
}