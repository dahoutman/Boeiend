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
	public partial class Loggingscherm : UserControl
	{
		private Hoofdscherm 	gHoofdscherm = null; // Reference to the MainWindow
		private Brush			gStandaardKleur;

		public Loggingscherm()
		{
			InitializeComponent();
		}

		// get a reference to main windows when it is available.
	    // The Loaded Event is set in the XAML code above.
	    private void OnControlLoaded(object sender, RoutedEventArgs e)
	    {
	        gHoofdscherm = Window.GetWindow(this) as Hoofdscherm;
	    	gStandaardKleur = gHoofdscherm.tiLoggingscherm.Background;
	        gHoofdscherm.tcTabs.SelectionChanged += tcTabs_SelectionChanged;
	    }

		public void VoegLoggingToe(tLogEventArgs pEA)
		{
//			if (cbSeverity.SelectedIndex <= (int)pEA.Type)
			{
	    		tLogEventArgs	lEA = new tLogEventArgs();
	    		lEA.Type	= pEA.Type;
	    		lEA.Tijd	= pEA.Tijd;
	    		lEA.Module	= pEA.Module;
	    		lEA.Regel	= pEA.Regel;
	    		lEA.Tekst	= pEA.Tekst;
	    		lvLogging.Items.Add(lEA);
				lvLogging.Items.Refresh();
	    		
	    		if (gHoofdscherm != null && pEA.Type == Severity.Warning) 
	    		{
	    			gHoofdscherm.tiLoggingscherm.Background = Brushes.Red;
	    		}
			}
		}

		private void btClipboard_Click(object sender, RoutedEventArgs e)
		{
	    	StringBuilder buffer = new StringBuilder();  

	    	foreach (tLogEventArgs lEa in lvLogging.Items)
	      	{  
	      		if (lEa.Type != Severity.Info)
	      		{
	   	         	buffer.Append(lEa.Tekst);  
		         	buffer.Append("\n");  
		         }
	     	}  
	     	Clipboard.SetText(buffer.ToString());
		}
		
		private void tcTabs_SelectionChanged(object pSender, SelectionChangedEventArgs pArgs)
		{
			if (gHoofdscherm.tiLoggingscherm.IsSelected)
			{
				gHoofdscherm.tiLoggingscherm.Background = gStandaardKleur;
			}
		}
	}
}