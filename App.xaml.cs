using System;
using System.Windows;
using System.Windows.Markup;

namespace Boeiend
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		protected override void OnStartup(StartupEventArgs e)
		{
		    base.OnStartup(e);

			// zet de hele boel gewoon altijd op Nederlands
			try
			{
			    FrameworkPropertyMetadata lMetaData = new FrameworkPropertyMetadata(XmlLanguage.GetLanguage("nl-NL"));
				FrameworkElement.LanguageProperty.OverrideMetadata(typeof(FrameworkElement), lMetaData);
			}
			catch
			{
				MessageBox.Show("De PlanEditor is niet helemaal correct opgestart. " +
				           		"Dit komt waarschijnlijk omdat niet alle componenten van .Net geinstalleerd zijn." +
				           		"Een stack trace kan hier gevonden worden:\n" + Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData));
			}
		}
	}
}