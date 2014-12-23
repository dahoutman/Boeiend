/*
 * Created by SharpDevelop.
 * User: Daan
 * Date: 7-5-2014
 * Time: 21:31
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Boeiend;

namespace Boeiend
{
	/// <summary>
	/// Description of GPX.
	/// </summary>
	public class GPX : Export
	{
		public GPX()
		{			
		}

		override public string MaakHdrRegel()
		{
			return string.Format("{0}{1}{2}{3}", 
			                     "<?xml version=\"1.0\"?>", 
			                     Environment.NewLine,
			                     "<gpx version=\"1.0\" creator=\"Boeiend\"> ",
			                     Environment.NewLine);
		}

		override public string MaakBodyRegel(tMarkering pMarkering)
		{
			string lIcon = "Top_Can_Buoy_";
			switch (pMarkering.Obj_vorm_c.Trim())
			{
				case "3":  lIcon = "Sphere_"; break;
				case "4":  lIcon = "Pilar_"; break;
				case "5":  lIcon = "Spar_"; break;
				case "1":  lIcon = "Tower_"; break;
				case "2":  lIcon = "Can_"; break;
				case "6":  lIcon = "Can_"; break;
				case "10": lIcon = "Float_"; break;
			}			
			
			foreach (var lKleurcode in pMarkering.Obj_kleur_c.Split(','))
			{
				switch (lKleurcode)
				{
					case "1": lIcon += "White_"; break;
					case "2": lIcon += "Black_"; break;
					case "3": lIcon += "Red_"; break;
					case "4": lIcon += "Green_"; break;
					case "5": lIcon += ""; break;
					case "6": lIcon += "Yellow_"; break;
				}
			}
			lIcon = lIcon.Substring(0, lIcon.Length-1);
			
			string lBegin		= string.Format("\t<wpt lat=\"{0}\" lon=\"{1}\">{2}", pMarkering.Y_wgs84.Replace(',','.'), pMarkering.X_wgs84.Replace(',','.'), Environment.NewLine);
			string lType 		= string.Format("\t\t<type>WPT</type>{0}", Environment.NewLine);
			string lName		= string.Format("\t\t<name>{0}</name>{1}", pMarkering.Benaming, Environment.NewLine);
			string lSym			= string.Format("\t\t<sym>{0}</sym>{1}", lIcon, Environment.NewLine);
			string lExtensions  = string.Format("{0}{1}{2}{3}", 
			                                    string.Format("\t\t<extensions>{0}", Environment.NewLine),
			                                    string.Format("\t\t\t<locus:icon>file:Betonning.zip:{0}.png</locus:icon>{1}", lIcon, Environment.NewLine),
			                                    string.Format("\t\t\t<opencpn:viz_name>1</opencpn:viz_name>{0}", Environment.NewLine),
			                                    string.Format("\t\t</extensions>{0}", Environment.NewLine));
			string lEnd			= string.Format("\t</wpt>{0}", Environment.NewLine);
			return string.Format("{0}{1}{2}{3}{4}{5}", lBegin, lType, lName, lSym, lExtensions, lEnd);
 		}

		override public string MaakFtrRegel()
		{
			return "</gpx>" + Environment.NewLine;
		}
	}
}
