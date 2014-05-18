/*
 * Created by SharpDevelop.
 * User: Daan
 * Date: 7-5-2014
 * Time: 21:50
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Text.RegularExpressions;

namespace Boeiend
{
	/// <summary>
	/// Description of CSV.
	/// </summary>
	public class CSV : Export
	{
//AD-WRAK,,53,3.304800,5,15.770800,Spar;Geel/zwart/geel;Horizontaal;2 Kegels punten naar elkaar;Zwart;,Spar;Geel/zwart/geel;Horizontaal;2 Kegels punten naar elkaar;Zwart;,Spar;Geel/zwart/geel;Horizontaal;2 Kegels punten naar elkaar;Zwart;,Spar;Geel/zwart/geel;Horizontaal;2 Kegels punten naar elkaar;Zwart;,Spar;Geel/zwart/geel;Horizontaal;2 Kegels punten naar elkaar;Zwart;,Spar;Geel/zwart/geel;Horizontaal;2 Kegels punten naar elkaar;Zwart;
//VAARWATER LANGS DE AFSLUITDIJK;VW-AD   -0119;AD-WRAK;01.01.2005; 563140,6905; 146661,4833;SK32 630;4;53.03.18.29;005.15.46.25;53.03.3048;005.15.7708;5;spar;6,2,6;Geel/zwart/geel;1;Horizontaal;10;2 Kegels, punten naar elkaar;2;Zwart;#;Niet toegewezen;#;Niet toegewezen;#;Niet toegewezen;#;#;#;Niet toegewezen;#;5,262847;53,055081;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
		override public string MaakBodyRegel(tMarkering pMarkering)
		{
			string lWaypointtype = string.Format("{0};{1};{2};{3};{4};",
			                                     pMarkering.Obj_vorm,
			                                     pMarkering.Obj_kleur,
			                                     pMarkering.Kleurpatr,
			                                     pMarkering.Tt_toptek.Replace(",", ""),
			                                     pMarkering.Tt_kleur);
			
			string[] 	lNwoord = pMarkering.N_wgs_gm.Split('.');
			string[] 	lEwoord = pMarkering.E_wgs_gm.Split('.');
			string		lSubnaam = string.Format("{0}{1}s", pMarkering.Sign_kar, pMarkering.Sign_perio);
			lSubnaam = Regex.Replace(lSubnaam, @"\(([^\)]+)\)", "");
			lSubnaam = lSubnaam.Replace("#s", "").
								Replace("Niet toegewezen", "").
								Replace("quick-flash plus long- flash", "Qfl+Lfl").
								Replace("very quick flash plus long- fl", "VQfl+Lfl").
								Replace(" ", "");
			
			string lRegel = string.Format("{0},{1},{2},{3}.{4},{5},{6}.{7},{8}{9}", 
			                              pMarkering.Benaming,
			                              lSubnaam,
			                              lNwoord[0],lNwoord[1],lNwoord[2],
			                              lEwoord[0],lEwoord[1],lEwoord[2],
			                              lWaypointtype.Replace("Niet toegewezen", ""),
			                              Environment.NewLine);
			return lRegel;
 		}
	}
}
