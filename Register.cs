/*
 * Created by SharpDevelop.
 * User: Daan
 * Date: 5-6-2014
 * Time: 20:55
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Microsoft.Win32;

namespace Boeiend
{
	/// <summary>
	/// Description of Registry.
	/// </summary>
	public static class Register
	{
		static private RegistryKey	gSleutel = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Boeiend");

		static public RegistryKey Sleutel
		{
			get { return gSleutel; }
		}
		
	}
}
