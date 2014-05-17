/*
 * Created by SharpDevelop.
 * User: Daan
 * Date: 4-5-2014
 * Time: 07:19
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
	/// <summary>
	/// Interaction logic for About.xaml
	/// </summary>
	public partial class About : Window
	{
		public About()
		{
			InitializeComponent();
			this.Owner = Application.Current.MainWindow;			
			this.tbAbout.Text = "d.a.houtman versie " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
		}
	}
}