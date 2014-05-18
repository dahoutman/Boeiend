/*
 * Created by SharpDevelop.
 * User: Daan
 * Date: 17-5-2014
 * Time: 20:58
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Boeiend
{
	/// <summary>
	/// Description of WPT.
	/// </summary>
	public class WPT : Export
	{
		public override string MaakHdrRegel()
		{
			return string.Format("{0}{1}{2}{3}{4}{5}{6}{7}", 
			                     "OziExplorer Waypoint File Version 1.0", 
			                     Environment.NewLine,
			                     "WGS 84",
			                     Environment.NewLine,
			                     "Reserved 2",
			                     Environment.NewLine,
			                     "Reserved 3",
			                     Environment.NewLine);
		}
		public override string MaakBodyRegel(tMarkering pMarkering)
		{
//  21,PTRS          , -26.636541, 152.449640,35640.91155, 0, 1, 3,  16777215,  16711935,Peach Trees Camping area, 0, 0,    0,   -777, 6, 0,17,0,10.0,2,,,,0
			return string.Format("{0},{1},{2},{3},35640.91537,0,1,0,8388608,65535,,0,0,0,-777,6,0,17,0,10.0,2,,,,0{4}",
                     			 1,
                     			 pMarkering.Benaming,
                     			 pMarkering.X_wgs84,
                     			 pMarkering.Y_wgs84, 
                     			 Environment.NewLine);
                     			 
		}
	}
}
