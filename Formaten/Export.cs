/*
 * Created by SharpDevelop.
 * User: Daan
 * Date: 7-5-2014
 * Time: 21:32
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.IO;

namespace Boeiend
{
	/// <summary>
	/// Description of Export.
	/// </summary>
	public class Export
	{
		public void BewaarBestand(string pBestandsnaam, List<tMarkering> paFiltering)
		{
			TextWriter 	lFileHandle = null;
			try
			{
				lFileHandle = new StreamWriter(pBestandsnaam);
				
				lFileHandle.Write(MaakHdrRegel());
				
				foreach (var lMarkering in paFiltering)
				{
					if (!lMarkering.X_wgs84.ToLower().Contains("waarde"))
					{
						lFileHandle.Write(MaakBodyRegel(lMarkering));
					}
				}
				
				lFileHandle.Write(MaakFtrRegel());

				lFileHandle.Flush();
			}
			catch
			{
				Log.VoegToe(Severity.Fatal, "Bestand <{0}> niet opgeslagen", pBestandsnaam);
				return;
			}
			finally
			{
				if (lFileHandle!=null)
				{
					lFileHandle.Close();
				}
			}
//			gDirty = false;
			Log.VoegToe(Severity.Info, "<{0}> geexporteerd", pBestandsnaam);
		}

		virtual public string MaakHdrRegel()
		{
			return "";
		}

		virtual public string MaakBodyRegel(tMarkering pMarkering)
		{
			return "";
		}
		
		virtual public string MaakFtrRegel()
		{
			return "";
		}
	}
}
