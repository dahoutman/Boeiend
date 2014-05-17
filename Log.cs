/*
 * Created by SharpDevelop.
 * User: Daan
 * Date: 1-10-2011
 * Time: 7:39
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Diagnostics;

namespace Boeiend
{
	public delegate void LogEventHandler(object sender, tLogEventArgs pEA);
	public enum Severity {Debug, Info, Warning, Fatal};
	public class tLogEventArgs: EventArgs
	{
		public	Severity	Type	{get; set;}
		public	DateTime	Tijd	{get; set;}
		public	string		Module	{get; set;}
		public	string		Regel	{get; set;}
		public	string		Tekst	{get; set;}
	}

	static public class Log
	{
		public 	static 	event LogEventHandler	Toegevoegd;
		private static	tLogEventArgs 			gLogEventArgs = new tLogEventArgs();
		private static 	bool 					gNieuweFout = false;
		
		public static void VoegToe (Severity pType, string pTekst, params object[] pParams)
		{
			if (Toegevoegd != null)
			{
				StackFrame CallStack = new StackFrame(1, true);

				gLogEventArgs.Type = pType;
				gLogEventArgs.Tijd = DateTime.Now;
				gLogEventArgs.Tekst = String.Format(pTekst, pParams);
				gLogEventArgs.Module = System.IO.Path.GetFileNameWithoutExtension(CallStack.GetFileName());
				gLogEventArgs.Regel = CallStack.GetFileLineNumber().ToString();
				Toegevoegd(null, gLogEventArgs);
			}
			if (pType != Severity.Info)
			{
				gNieuweFout = true;
			}
		}

		public static void VoegToe (Severity Type, string Tekst)
		{
			if (Toegevoegd != null)
			{
				StackFrame CallStack = new StackFrame(1, true);

				gLogEventArgs.Type = Type;
				gLogEventArgs.Tijd = DateTime.Now;
				gLogEventArgs.Tekst = Tekst;
				gLogEventArgs.Module = System.IO.Path.GetFileNameWithoutExtension(CallStack.GetFileName());
				gLogEventArgs.Regel = CallStack.GetFileLineNumber().ToString();
				Toegevoegd(null, gLogEventArgs);
			}
			if (Type != Severity.Info)
			{
				gNieuweFout = true;
			}
		}

		public static bool NieuweFout
		{
			get 
			{ 
				return (gNieuweFout); 
			}
			set 
			{ 
				if (value == false)
				{
					gNieuweFout = value;
				}
			}
		}
	}
}
