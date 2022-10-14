﻿using System;
using System.Diagnostics;
using System.IO.Pipes;
using System.Runtime.InteropServices;
using BRY;

namespace AE_RemapTria
{


		internal static class Program
	{
		public static string CallExeName = "AE_RemapTria";
		public static string MyExeName = "AE_RemapTriaCall";
		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			CallExe ce = new CallExe(CallExeName, MyExeName);
			ce.Run(args);
			Console.WriteLine(ce.ResultString);
		}
	}
}