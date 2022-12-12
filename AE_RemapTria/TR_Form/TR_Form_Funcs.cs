﻿using BRY;
using PdfSharpCore.Drawing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement; 

namespace AE_RemapTria
{
	public partial class TR_Form
	{
		// ************************************************************************************
		#region Func
		private void MakeFuncs()
		{
			List<FuncItem> lst = new List<FuncItem>();

			lst.Add(new FuncItem(Input0, Keys.D0, Keys.NumPad0, "入力エリアに0"));
			lst.Add(new FuncItem(Input1, Keys.D1, Keys.NumPad1, "入力エリアに1"));
			lst.Add(new FuncItem(Input2, Keys.D2, Keys.NumPad2, "入力エリアに2"));
			lst.Add(new FuncItem(Input3, Keys.D3, Keys.NumPad3, "入力エリアに3"));
			lst.Add(new FuncItem(Input4, Keys.D4, Keys.NumPad4, "入力エリアに4"));
			lst.Add(new FuncItem(Input5, Keys.D5, Keys.NumPad5, "入力エリアに5"));
			lst.Add(new FuncItem(Input6, Keys.D6, Keys.NumPad6, "入力エリアに6"));
			lst.Add(new FuncItem(Input7, Keys.D7, Keys.NumPad7, "入力エリアに7"));
			lst.Add(new FuncItem(Input8, Keys.D8, Keys.NumPad8, "入力エリアに8"));
			lst.Add(new FuncItem(Input9, Keys.D9, Keys.NumPad9, "入力エリアに9"));
			lst.Add(new FuncItem(InputClear, Keys.Delete, "クリア"));
			lst.Add(new FuncItem(InputBS, Keys.Back, "BS"));
			lst.Add(new FuncItem(InputEnter, Keys.Enter, Keys.Return, "入力"));
			lst.Add(new FuncItem(InputEmpty, Keys.Decimal, Keys.OemPeriod, "空セル"));
			lst.Add(new FuncItem(InputInc, Keys.Add|Keys.Oemplus , "前の数値に1を足して入力"));
			lst.Add(new FuncItem(InputDec, Keys.Subtract | Keys.OemMinus, "前の数値に1を引いて入力"));
			lst.Add(new FuncItem(SelMoveUp, Keys.Up, "選択範囲を上に"));
			lst.Add(new FuncItem(SelMoveDown, Keys.Down, "選択範囲を下に"));
			lst.Add(new FuncItem(SelMoveLeft, Keys.Left, "選択範囲を左に"));
			lst.Add(new FuncItem(SelMoveRight, Keys.Right, "選択範囲を右に"));
			lst.Add(new FuncItem(SelAdd, Keys.Shift | Keys.Down, Keys.Multiply, "SelAdd"));
			lst.Add(new FuncItem(SelDec, Keys.Shift | Keys.Up, Keys.Divide, "SelDec"));
			lst.Add(new FuncItem(PageUp, Keys.PageUp));
			lst.Add(new FuncItem(PageDown, Keys.PageDown));
			lst.Add(new FuncItem(DispUp, Keys.Up | Keys.Control));
			lst.Add(new FuncItem(DispDown, Keys.Down | Keys.Control));
			lst.Add(new FuncItem(DispLeft, Keys.Left | Keys.Control));
			lst.Add(new FuncItem(DispRight, Keys.Right | Keys.Control));
			lst.Add(new FuncItem(Home, Keys.Home, "先頭へ"));
			lst.Add(new FuncItem(End, Keys.End, "最後へ"));

			lst.Add(new FuncItem(ToggleFrameEnabled, Keys.Control | Keys.Oemtilde));
			lst.Add(new FuncItem(FrameEnabledOFF, Keys.Control | Keys.Oem5));
			lst.Add(new FuncItem(FrameEnabledON, Keys.Control | Keys.Oem7));
			lst.Add(new FuncItem(HeightMax, Keys.Control | Keys.Oem5, "上下に広げる"));
			lst.Add(new FuncItem(SheetSettings, Keys.Control | Keys.K, "シート設定"));
			lst.Add(new FuncItem(SetSelection1, Keys.F1));
			lst.Add(new FuncItem(SetSelection2, Keys.F2));
			lst.Add(new FuncItem(SetSelection3, Keys.F3));
			lst.Add(new FuncItem(SetSelection4, Keys.F4));
			lst.Add(new FuncItem(SetSelection5, Keys.F5));
			lst.Add(new FuncItem(SetSelection6, Keys.F6));
			lst.Add(new FuncItem(SetSelection7, Keys.F7));
			lst.Add(new FuncItem(SetSelection8, Keys.F8));
			lst.Add(new FuncItem(SetSelection9, Keys.F9));
			lst.Add(new FuncItem(SetSelection10, Keys.F10));
			lst.Add(new FuncItem(SetSelection11, Keys.F11));
			lst.Add(new FuncItem(SetSelection12, Keys.F12));
			lst.Add(new FuncItem(SelectionAll, Keys.Control | Keys.A));
			lst.Add(new FuncItem(SelectionToEnd, Keys.Control | Keys.End));
			lst.Add(new FuncItem(Undo, Keys.Control|Keys.Z));
			lst.Add(new FuncItem(Quit, Keys.Control | Keys.Q ,"終了"));
			lst.Add(new FuncItem(Save, Keys.Control | Keys.S, "保存"));
			lst.Add(new FuncItem(SaveAs, Keys.Shift | Keys.Control | Keys.S, "別名保存"));
			lst.Add(new FuncItem(Open, Keys.Control | Keys.O, "読み込み"));
			lst.Add(new FuncItem(Copy, Keys.Control | Keys.C));
			lst.Add(new FuncItem(Cut, Keys.Control | Keys.X));
			lst.Add(new FuncItem(Paste, Keys.Control | Keys.V));
			lst.Add(new FuncItem(ClearAll, Keys.Control | Keys.Delete));
			lst.Add(new FuncItem(CellLeftShift, Keys.Alt | Keys.Left));
			lst.Add(new FuncItem(CellRightShift, Keys.Alt | Keys.Right));
			lst.Add(new FuncItem(CellInsert, Keys.Alt | Keys.I,"セル挿入"));
			lst.Add(new FuncItem(CellRemove, Keys.Alt | Keys.R,"セル削除"));
			lst.Add(new FuncItem(FrameInsert, Keys.Alt |Keys.Shift| Keys.I,"フレーム挿入"));
			lst.Add(new FuncItem(FrameRemove, Keys.Alt | Keys.Shift | Keys.R, "フレーム削除"));
			lst.Add(new FuncItem(SeetInfoDialog, Keys.Control | Keys.K, "シート情報"));
			lst.Add(new FuncItem(CaptionDialog, Keys.Control | Keys.E, "キャプション編集"));
			lst.Add(new FuncItem(OffsetFrameDialog, Keys.Alt | Keys.O, "オフセットフレーム"));
			lst.Add(new FuncItem(AutoInputDialog, Keys.Control | Keys.J, "自動入力"));
			lst.Add(new FuncItem(AboutDialog,  Keys.Control |Keys.F1, "このアプリについて"));
			//lst.Add(new FuncItem(KeyBindDialog, Keys.Control | Keys.L, "キーバインド"));
			lst.Add(new FuncItem(OpenSaveDialog, Keys.Control | Keys.T, "FileDialogのテスト"));
			//lst.Add(new FuncItem(WritePDF, Keys.Control | Keys.P, "PDF Export"));

			Funcs.SetFuncItems(lst.ToArray());
		}
		#endregion
		#region Menu
		// ************************************************************************************
		/*
		public void UpdateMenu()
		{
			if (m_Menu == null) return;
			m_Menu.UpdateMenu();
		}
		*/
		// ************************************************************************************
		public void MakeMenu()
		{
			if (Menu == null) return;


			Menu.ClearMenu();
			Menu.AddTopMenu("AE_Remapτρ?α", 93);
			Menu.AddTopMenu("Edit", 40);
			Menu.AddTopMenu("Windw", 50);

			Menu.AddSubMenu(0, "SheetSettings");
			Menu.AddSubMenu(0, "SeetInfoDialog");
			Menu.AddSubMenu(0, "OffsetFrameDialog");
			Menu.AddSubMenuSepa(0);
			Menu.AddSubMenu(0, "Open");
			Menu.AddSubMenu(0, "Save");
			Menu.AddSubMenu(0, "SaveAs");
			Menu.AddSubMenuSepa(0);
			Menu.AddSubMenu(0, "WritePDF");
			Menu.AddSubMenu(0, "Quit");

			Menu.AddSubMenu(1, "Undo");
			Menu.AddSubMenuSepa(1);
			Menu.AddSubMenu(1, "Copy");
			Menu.AddSubMenu(1, "Cut");
			Menu.AddSubMenu(1, "Paste");
			Menu.AddSubMenuSepa(1);
			Menu.AddSubMenu(1, "ClearAll");
			Menu.AddSubMenu(1, "SelectionAll");
			Menu.AddSubMenu(1, "SelectionToEnd");
			Menu.AddSubMenu(1, "AutoInputDialog");
			Menu.AddSubMenuSepa(1);
			Menu.AddSubMenu(1, "CellInsert");
			Menu.AddSubMenu(1, "CellRemove");
			Menu.AddSubMenu(1, "FrameInsert");
			Menu.AddSubMenu(1, "FrameRemove");
			Menu.AddSubMenu(1, "CaptionDialog");
			Menu.AddSubMenuSepa(1);
			Menu.AddSubMenu(1, "ToggleFrameEnabled");

			Menu.AddSubMenu(2, "AboutDialog");
			Menu.AddSubMenu(2, "KeyBindDialog");
			Menu.AddSubMenuSepa(2);
			Menu.AddSubMenu(2, "HeightMax");

			MenuPlates = new TR_MenuPlate[3];

			MenuPlates[0] = new TR_MenuPlate();
			MenuPlates[0].SetTRForm(this);
			MenuPlates[0].AddSubMenuItems(0);

			MenuPlates[1] = new TR_MenuPlate();
			MenuPlates[1].SetTRForm(this);
			MenuPlates[1].AddSubMenuItems(1);

			MenuPlates[2] = new TR_MenuPlate();
			MenuPlates[2].SetTRForm(this);
			MenuPlates[2].AddSubMenuItems(2);

		}
		#endregion

		// ************************************************************************************
		/// <summary>
		/// シート設定ダイアログの表示
		/// </summary>
		/// <returns></returns>
		public bool SheetSettings()
		{
			TR_SheetSettingDialog dlg = new TR_SheetSettingDialog();
			dlg.SetTRForm(this);
			int ExFrame = CellData.UnEnabledFrameCount;
			dlg.Frame = CellData.FrameCount;
			dlg.Fps = CellData.FrameRate;
			dlg.SheetName = CellData.SheetName;
			string caution = "";
			if(ExFrame > 0)
			{
				caution=String.Format("Warning! 抜きコマ{0}個あり。", ExFrame);
			}
			else
			{
				caution = string.Format("Orig: {0}+{1}({2}F) fps:{3}",
				CellData.FrameCount / (int)CellData.FrameRate,
				CellData.FrameCount % (int)CellData.FrameRate,
				CellData.FrameCount,
				(int)CellData.FrameRate
				);
			}
			dlg.Caption = caution;
			dlg.Location = new Point(
				this.Left + 20,
				this.Top + T_Size.MenuHeightDef + Sizes.CaptionHeight + Sizes.CaptionHeight2
				);
			if (dlg.ShowDialog(this) == DialogResult.OK)
			{
				CellData.PushUndo(BackupSratus.All);
				CellData.FrameRate = dlg.Fps;
				CellData.FrameCount = dlg.Frame;
				CellData.SheetName = dlg.SheetName;
				FileName = T_Def.ChangeName(FileName, dlg.SheetName);
				Sizes.CallOnChangeGridSize();
			}
			dlg.Dispose();
			return true;
		}

		// ************************************************************************************
		/// <summary>
		/// 終了
		/// </summary>
		/// <returns></returns>
		public bool Quit()
		{
			if ((IsModif) && (IsMultExecute == false))
			{
				SaveAs();
			}
			try
			{
				Application.Exit();
			}
			catch
			{

			}
			return true;
		}
		// ************************************************************************************
		/// <summary>
		/// Undo
		/// </summary>
		/// <returns></returns>
		public bool Undo()
		{
			BackupSratus bs = CellData.PopUndo();
			if (bs== BackupSratus.All)
			{
				//ChkHScrl();
				//ChkVScrl();
				ChkSize();
			}
			else
			{
				Sizes.SizeSetting(Grid, CellData);
			}
			DrawAll();
			return true;
		}
		// ************************************************************************************
		public bool SetCellTarget(int c)
		{
			if((CellData.TargetIndex!=c)&&(c>=0)&&(c<CellData.CellCount))
			{
				CellData.SetTargetCell(c);
				DrawAll();
				return true;
			}
			else
			{
				return false;
			}
		}
		public bool SetCellStart(int f)
		{
			if ((f >= 0) && (f < CellData.FrameCount))
			{
				int bs = CellData.Selection.Start;
				CellData.SetSelStart(f);
				DrawAll();
				return true;
			}
			else
			{
				return false;
			}
		}
		// ************************************************************************************
		/// <summary>
		/// すべて消す
		/// </summary>
		/// <returns></returns>
		public bool ClearAll()
		{
			IsModif = false;
			CellData.ClearAll();
			if(Grid!=null)Grid.ChkOffScr();
			Invalidate();
			return true;
		}
		// ************************************************************************************
		public bool ToggleFrameEnabled()
		{
			IsModif = true;
			bool ret = CellData.ToggleFrameEnabled();
			if(ret)
			{
				DrawAll();
			}
			return ret; 
		}
		// ************************************************************************************
		public bool FrameEnabledON()
		{
			IsModif = true;
			CellData.SetFrameEnabled(true);
			DrawAll();
			return true;
		}
		// ************************************************************************************
		public bool FrameEnabledOFF()
		{
			IsModif = true;
			CellData.SetFrameEnabled(false);
			DrawAll();
			return true;
		}
		// ************************************************************************************
		public bool InputAddKey(int v)
		{
			bool ret = false;
			if ((v >= 0) || (v <= 9))
			{
				if (m_Value < 0) m_Value = 0;
				m_Value = m_Value * 10 + v;
				ret = true;
				DrawAll();
			}
			else if (v < 0)
			{
				ret = InputClear();
				DrawAll();
			}
			return ret;
		}
		public bool Inputnum(int v)
		{
			bool ret = false;
			IsModif = true;
			ret = InputAddKey(v);
			return ret;
		}
		public bool Input0() { return Inputnum(0); }
		public bool Input1() { return Inputnum(1); }
		public bool Input2() { return Inputnum(2); }
		public bool Input3() { return Inputnum(3); }
		public bool Input4() { return Inputnum(4); }
		public bool Input5() { return Inputnum(5); }
		public bool Input6() { return Inputnum(6); }
		public bool Input7() { return Inputnum(7); }
		public bool Input8() { return Inputnum(8); }
		public bool Input9() { return Inputnum(9); }


		// ************************************************************************

		// ************************************************************************
		public bool InputClear()
		{
			bool ret = false;
			if (m_Value >= 0)
			{
				m_Value = -1;
				DrawAll();
				ret = true;
			}
			else
			{
				CellData.SetCellNumEmpty(false);
				DrawAll();
				ret = true;
			}
			IsModif = true;
			return ret;
		}
		// ************************************************************************
		public bool InputBS()
		{
			bool ret = false;
			if (m_Value >= 10)
			{
				m_Value = m_Value / 10;
				ret = true;
			}
			else if ((m_Value >= 0) && (m_Value < 10))
			{
				m_Value = -1;
				ret = true;
			}
			else
			{
				CellData.SetCellNumBS();
				ret = true;
			}
			IsModif = true;
			DrawAll();
			return ret;
		}
		public bool InputEmpty()
		{
			bool ret = false;
			CellData.SetCellNumEmpty(true);
			DrawAll();
			IsModif = true;
			return ret;
		}
		public void ChkSelectionV()
		{
			int y0 = CellData.Selection.Start * Sizes.CellHeight;
			int y1 = (CellData.Selection.Start + CellData.Selection.Length) * Sizes.CellHeight;

			int t0 = y0 - Sizes.DispY;
			int t1 = y1 - Sizes.DispY;
			if (t0 >= this.Height)
			{
				int v = (CellData.Selection.Start + CellData.Selection.Length + 1) * Sizes.CellHeight - this.Height;
				if (v > Sizes.DispMax.Y - Sizes.CellHeight * 3) v = Sizes.DispMax.Y;
				Sizes.DispY = v;
			}
			else if (t1 <= 0)
			{
				int v = (CellData.Selection.Start) * Sizes.CellHeight;
				if (v < Sizes.CellHeight * 3) v = 0;
				Sizes.DispY = v;
			}

		}
		public void ChkSelectionH()
		{
			int x0 = CellData.Selection.Target * Sizes.CellWidth;
			int x1 = x0 + Sizes.CellWidth;

			int t0 = x0 - Sizes.DispX;
			int t1 = x1 - Sizes.DispX;
			if (t1 >= this.Width)
			{
				int v = Sizes.CellWidth * (CellData.Selection.Target + 1) - this.Width;
				if (v >= Sizes.DispMax.X - Sizes.CellWidth / 2) v = Sizes.DispMax.X;
				Sizes.DispX = v;
			}
			else if (t0 <= 0)
			{
				int v = CellData.Selection.Target * Sizes.CellWidth;
				if (v < Sizes.CellHeight / 2) v = 0;
				Sizes.DispX = v;
			}

		}
		public bool InputEnter()
		{
			bool ret = false;
			if (m_Value >= 0)
			{
				CellData.SetCellNum(m_Value);
				InputClear();
				ret = true;
				ChkSelectionV();
			}
			else
			{
				ret = InputSame();
			}
			IsModif = true;
			this.Invalidate();

			return ret;

		}
		public bool InputSame()
		{
			CellData.SetCellNumSame();
			ChkSelectionV();
			IsModif = true;
			DrawAll();

			return true;
		}
		public bool InputInc()
		{
			CellData.SetCellNumInc();
			ChkSelectionV();
			IsModif = true;
			DrawAll();

			return true;
		}
		public bool InputDec()
		{
			CellData.SetCellNumDec();
			ChkSelectionV();
			IsModif = true;
			DrawAll();

			return true;
		}

		// ************************************************************************************
		public bool SelMoveDown()
		{
			CellData.PushUndo(BackupSratus.SelectionChange);
			bool ret = CellData.Selection.MoveDown();
			ChkSelectionV();
			DrawAll();
			return ret;
		}
		// ************************************************************************************
		public bool SelMoveUp()
		{
			CellData.PushUndo(BackupSratus.SelectionChange);
			bool ret = CellData.Selection.MoveUp();
			ChkSelectionV();
			DrawAll();

			return ret;
		}
		// ************************************************************************************
		public bool SelMoveRight()
		{
			CellData.PushUndo(BackupSratus.SelectionChange);
			bool b = CellData.Selection.MoveRight();
			ChkSelectionH();
			DrawAll();

			return b;
		}
		public bool SelMoveLeft()
		{
			CellData.PushUndo(BackupSratus.SelectionChange);
			bool b = CellData.Selection.MoveLeft();
			ChkSelectionH();
			DrawAll();
			return b;
		}
		public bool Home()
		{
			Sizes.DispY = 0;
			DrawAll();
			return true;

		}
		public bool End()
		{
			Sizes.DispY = Sizes.DispMax.Y;
			DrawAll();
			return true;

		}
		public bool PageDown()
		{
			Sizes.DispY += this.Height / 2;
			DrawAll();
			return true;
		}
		public bool PageUp()
		{
			Sizes.DispY -= this.Height / 2;
			DrawAll();
			return true;
		}
		public bool DispUp()
		{
			Sizes.DispY -= Sizes.CellHeight;
			DrawAll();
			return true;
		}
		public bool DispDown()
		{
			Sizes.DispY += Sizes.CellHeight;
			DrawAll();
			return true;
		}
		public bool DispLeft()
		{
			Sizes.DispX -= Sizes.CellWidth;
			DrawAll();
			return true;
		}
		public bool DispRight()
		{
			Sizes.DispX += Sizes.CellWidth;
			DrawAll();
			return true;
		}
		public bool SelAdd()
		{
			bool ret = CellData.SelectionAdd(1);
			if (ret) DrawAll();
			return ret;
		}
		public bool SelDec()
		{
			bool ret = false;
			if (CellData.Selection.Length > 1)
			{
				ret = CellData.SelectionAdd(-1);
				if (ret) DrawAll();
			}
			return ret;
		}
		public bool SelectionAll()
		{
			bool ret = false;
			if (CellData.Selection.Length < CellData.FrameCount)
			{
				CellData.PushUndo(BackupSratus.SelectionChange);
				ret = CellData.SelectionAll();
				if (ret) DrawAll();

			}
			return ret;
		}
		// ************************************************************************************
		public bool HeightMax()
		{
			bool ret = false;
			Rectangle r = PrefFile.NowScreen(this.Bounds);
			if (r.Width > 100)
			{
				int h = r.Height - 25;
				this.Location = new Point(this.Left, r.Top + 25);
				this.Size = new Size(this.Width, h);
				ChkSize();
				DrawAll();
				ret = true;
			}
			return ret;
		}
		public bool SetSelectionLength(int v)
		{
			bool b = false;
			if (CellData.Selection.Length != v)
			{
				CellData.PushUndo(BackupSratus.SelectionChange);
				CellData.Selection.Length = v;
				b = true;

				DrawAll();
			}
			return b;
		}
		public bool SelectionToEnd()
		{
			bool ret = false;

			int l2 = CellData.FrameCount - CellData.Selection.Start;
			if(CellData.Selection.Length<l2)
			{
				CellData.Selection.SetLength(l2);
				ret = true;
				DrawAll();
			}
			return ret;
		}
		#region Selection
		public bool SetSelection1()
		{
			return SetSelectionLength(1);
		}
		public bool SetSelection2()
		{
			return SetSelectionLength(2);
		}
		public bool SetSelection3()
		{
			return SetSelectionLength(3);
		}
		public bool SetSelection4()
		{
			return SetSelectionLength(4);
		}
		public bool SetSelection5()
		{
			return SetSelectionLength(5);
		}
		public bool SetSelection6()
		{
			return SetSelectionLength(6);
		}
		public bool SetSelection7()
		{
			return SetSelectionLength(7);
		}
		public bool SetSelection8()
		{
			return SetSelectionLength(8);
		}
		public bool SetSelection9()
		{
			return SetSelectionLength(9);
		}
		public bool SetSelection10()
		{
			return SetSelectionLength(10);
		}
		public bool SetSelection11()
		{
			return SetSelectionLength(11);
		}
		public bool SetSelection12()
		{
			return SetSelectionLength(12);
		}
		#endregion
		
		
		public bool SaveAs()
		{
			if (IsMultExecute) return false;
			return SaveDialog(FileName);
		}
		public bool SaveDialog(string p)
		{
			bool ret = false;
			if (IsMultExecute) return ret;
			T_OpenSaveDialog dlg = new T_OpenSaveDialog();
			if (p != "")
			{
				dlg.FullName = p;
			}
			dlg.Caption = "Save to File";
			bool b = false;
			b = this.TopMost;
			this.TopMost = false;
			this.ForegroundWindow();
			dlg.ToCenter();
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				if (Save(dlg.FileName))
				{
					FileName = dlg.FullName;
					ret = true;
				}
				else
				{
					MessageBox.Show("err");
				}
			}
			this.TopMost = b;
			dlg.Dispose();
			return ret;
		}
		public bool Save(string p)
		{
			if (IsMultExecute) return false;
			string d = T_Def.GetDir(p);
			string n = T_Def.GetNameNoExt(p);
			p = Path.Combine(d, n+".ardj.josn");
			CellData.SheetName = T_Def.GetNameNoExt(p);
			bool ret = CellData.Save(p);
			if (ret)
			{
				FileName=p;
				CellData.SheetName = T_Def.GetNameNoExt(FileName);
				DrawAll();
				IsModif = false;

			}
			return ret;
		}
		public bool SaveBackup(string p)
		{
			if (IsMultExecute) return false;
			string s = CellData.SheetName;
			DateTime c = CellData.CREATE_TIME;
			DateTime u = CellData.UPDATE_TIME;
			CellData.SheetName = "";
			CellData.CREATE_TIME = new DateTime(1963, 9, 9);
			CellData.UPDATE_TIME = new DateTime(1963, 9, 9);
			bool ret = CellData.Save(p);
			CellData.SheetName = s;
			CellData.CREATE_TIME = c;
			CellData.UPDATE_TIME = u;
			return ret;

		}
		public bool OpenBackup(string p)
		{
			bool ret = false;
			if (File.Exists(p) == false) return ret;
			ret = CellData.Load(p);
			CellData.SheetName = "";
			CellData.CREATE_TIME = new DateTime(1963, 9, 9);
			CellData.UPDATE_TIME = new DateTime(1963, 9, 9);
			CellData.CREATE_USER = "";
			CellData.UPDATE_USER = "";

			if (ret)
			{
				ChkSize();
				DrawAll();
			}
			return ret;
		}
		public bool Save()
		{
			if (IsMultExecute) return false;

			string d = T_Def.GetDir(FileName);

			if(d!="")
			{
				return Save(FileName);
			}
			else
			{
				return SaveAs();
			}
		}
		public bool Open()
		{
			bool ret = false;
			T_OpenSaveDialog dlg = new T_OpenSaveDialog();
			if (FileName != "")
			{
				dlg.FullName = FileName;
			}
			dlg.Caption = "Open from file";
			bool b = false;
			b = this.TopMost;
			this.TopMost =false;
			this.ForegroundWindow();
			dlg.ToCenter();
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				ret = (Open(dlg.FullName));
			}
			this.TopMost = b;
			dlg.Dispose();
			return ret;
		}
		public bool Open(string p)
		{
			bool ret = false;
			if (File.Exists(p) == false) return ret;
			CellData.PushUndo(BackupSratus.All);
			ret = CellData.Load(p);
			if(ret)
			{
				FileName = p;
				CellData.SheetName = T_Def.GetNameNoExt(p);
				//ChkHScrl();
				//ChkVScrl();
				ChkSize();
				IsModif = false;
				DrawAll();
			}
			return ret;

		}
		public bool CellRemove()
		{
			IsModif = true;
			bool ret = CellData.RemoveCell();
			if (ret) DrawAll();
			return ret;
		}
		public bool CellInsert()
		{
			bool ret = false;
			/*
			if (m_form == null) return false;
			m_form.ForegroundWindow();
			T_NameDialog dlg = new T_NameDialog();
			dlg.SetForm(m_form);
			dlg.Caption = "Insert Cell";
			dlg.ValueText = "";
			dlg.Location = new Point(
				m_Form.Left + 20,
				m_Form.Top + T_Size.MenuHeightDef + Sizes.CaptionHeight + Sizes.CaptionHeight2
				);
			bool b = false;
			if (m_Form != null)
			{
				b = m_Form.TopMost;
				m_Form.TopMost = false;
			}
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				ret =CellData.InsertCell(dlg.ValueText);
				IsModif = true;
				this.Invalidate();
			}
			if (m_Form != null) m_Form.TopMost = b;
			dlg.Dispose();
			*/
			return ret;
		}
		public bool FrameInsert()
		{
			IsModif = true;
			bool ret = CellData.InsertFrame();
			if (ret) DrawAll();
			return ret;
		}
		public bool FrameRemove()
		{
			IsModif = true;
			bool ret = CellData.RemoveFrame();
			if (ret) DrawAll();
			return ret;
		}
		public string ToArdj()
		{
			return CellData.ToArdj();
		}
		public bool Copy()
		{
			return CellData.Copy();
		}
		public bool Cut()
		{
			bool ret = CellData.Cut();
			if (ret)
			{
				IsModif = true;
				this.Invalidate();
			}
			return ret;
		}
		public bool Paste()
		{
			bool ret = CellData.Paste();
			if (ret)
			{
				IsModif = true;
				DrawAll();
			}
			return ret;
		}
		public bool CellLeftShift()
		{
			bool ret = CellData.CellLeftShift();
			if (ret)
			{
				ChkSelectionH();
				DrawAll();
			}
			return ret;
		}
		public bool CellRightShift()
		{
			bool ret = CellData.CellRightShift();
			if (ret)
			{
				ChkSelectionH();
				DrawAll();
			}
			return ret;
		}
		public bool Import_layer(string s)
		{
			bool ret = false;
			if ((s == null) || (s.Length == 0)) return ret;
			string[] sa = s.Split(',');
			try
			{
				if (sa[0] != "$") return ret;
				int frameCount = Convert.ToInt32(sa[1]);
				int frameRate = Convert.ToInt32(sa[2]);
				int cc = Convert.ToInt32(sa[3]);
				if (sa.Length != cc + 4) return ret;

				int[][] cell = new int[cc][];
				for (int i = 0; i < cc; i++)
				{
					cell[i] = new int[2];
					string[] sss = sa[i + 4].Split('-');
					if(sss.Length >= 2)
					{
						cell[i][0] = Convert.ToInt32(sss[0]);
						cell[i][1] = Convert.ToInt32(sss[1]);
					}
				}
				CellData.PushUndo(BackupSratus.All);
				bool u = CellData._undoPushFlag;
				CellData._undoPushFlag = false;

				if (CellData.FrameCount!= frameCount) CellData.SetFrameCount(frameCount);
				CellData.FromArray(cell);
				CellData._undoPushFlag = u;
				IsModif = true;
				DrawAll();

			}
			catch
			{
				ret = false;
			}

			return ret;
		}
		public bool SeetInfoDialog()
		{
			bool ret = false;
			/*
			if (m_form == null) return false;
			m_form.ForegroundWindow();
			T_SheetInfoDialog dlg = new T_SheetInfoDialog();
			dlg.SetForm(m_form);
			dlg.Location = new Point(
				m_form.Left + 20,
				m_form.Top + T_Size.MenuHeightDef + Sizes.CaptionHeight + Sizes.CaptionHeight2
				);
			bool b = false;
			if (m_form != null)
			{
				b = m_form.TopMost;
				m_form.TopMost = false;
			}
			dlg.SetCelLData(CellData);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				IsModif = true;
				dlg.GetCellData(ref CellData);
				ret = true;
			}
			if (m_Form != null) m_Form.TopMost = b;
			*/
			return ret;
		}
		public bool CaptionDialog()
		{
			bool ret = false;
			/*
			if (m_form == null) return false;
			m_form.ForegroundWindow();
			T_NameDialog dlg = new T_NameDialog();
			dlg.SetForm(m_form);
			dlg.Caption = "Cell Caption: "+ CellData.CaptionTarget();
			dlg.ValueText = CellData.CaptionTarget();
			dlg.Location = new Point(
				m_form.Left + 20,
				m_form.Top + T_Size.MenuHeightDef + Sizes.CaptionHeight + Sizes.CaptionHeight2
				);
			bool b = false;
			if (m_form != null)
			{
				b = m_form.TopMost;
				m_form.TopMost = false;
			}
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				CellData.SetCaptionTarget(dlg.ValueText);
				if (m_form != null) m_form.Invalidate();
				IsModif = true;
				ret = true;
			}
			if (m_form != null) m_form.TopMost = b;
			dlg.Dispose();
			*/
			return ret;
		}
		public bool OffsetFrameDialog()
		{
			bool ret = false;
			/*
			if (m_Form == null) return false;
			m_Form.ForegroundWindow();
			T_OffsetFrameDialog dlg = new T_OffsetFrameDialog();
			dlg.SetForm(m_Form);
			dlg.Value = CellData.OffSetFrame;
			dlg.Location = new Point(
				m_Form.Left + 20,
				m_Form.Top + T_Size.MenuHeightDef + Sizes.CaptionHeight + Sizes.CaptionHeight2
				);
			bool b = false;
			if (m_Form != null)
			{
				b = m_Form.TopMost;
				m_Form.TopMost = false;
			}
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				CellData.OffSetFrame = dlg.Value;
				if (m_Form != null) m_Form.Invalidate();
				IsModif = true;
				ret = true;
			}
			if (m_Form != null) m_Form.TopMost = b;
			dlg.Dispose();
			*/
			return ret;
		}
		private int m_AutoinputStert = 1;
		private int m_AutoinputLast = 10;
		private int m_AutoinputKoam = 3;

		public bool AutoInputDialog()
		{
			bool ret = false;
			/*
			if (m_Form == null) return false;
			m_Form.ForegroundWindow();
			T_AutoInputDialog dlg = new T_AutoInputDialog();
			dlg.SetForm(m_Form);
			dlg.Start = m_AutoinputStert;
			dlg.Last = m_AutoinputLast;
			dlg.Koma = m_AutoinputKoam;

			dlg.Location = new Point(
				m_Form.Left + 20,
				m_Form.Top + T_Size.MenuHeightDef + Sizes.CaptionHeight + Sizes.CaptionHeight2
				);
			bool b = false;
			if (m_Form != null)
			{
				b = m_Form.TopMost;
				m_Form.TopMost = false;
			}
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				m_AutoinputStert = dlg.Start;
				m_AutoinputLast = dlg.Last;
				m_AutoinputKoam = dlg.Koma;
				CellData.AutoInput(m_AutoinputStert, m_AutoinputLast, m_AutoinputKoam);
				IsModif = true;
				this.Invalidate();
				ret = true;
			}
			if (m_Form != null) m_Form.TopMost = b;
			dlg.Dispose();
			*/
			return ret;
		}
		public bool AboutDialog()
		{
			bool ret = false;
			/*
			if (m_Form == null) return false;
			m_Form.ForegroundWindow();
			T_AboutDialog dlg = new T_AboutDialog();
			string s =  Application.ExecutablePath;
			DateTime dt = File.GetLastWriteTimeUtc(s);
			//DateTime dt = F_W.GetBuildDateTime(s);

			dt = dt + new TimeSpan(9, 0, 0);
			dlg.Info = "build:" +dt.ToString() ;
			dlg.SetForm(m_Form);
			dlg.Location = new Point(
				m_Form.Left + 20,
				m_Form.Top + T_Size.MenuHeightDef + Sizes.CaptionHeight + Sizes.CaptionHeight2
				);
			bool b = false;
			if (m_Form != null)
			{
				b = m_Form.TopMost;
				m_Form.TopMost = false;
			}
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				ret = true;
			}
			if (m_Form != null) m_Form.TopMost = b;
			dlg.Dispose();
			*/
			return ret;
		}
		public bool KeyBindDialog()
		{
			bool ret = false;
			/*
			if (m_Form == null) return false;
			m_Form.ForegroundWindow();
			T_KeyBindDialog dlg = new T_KeyBindDialog();
			dlg.SetFuncs(Funcs);
			dlg.SetForm(m_Form);
			dlg.Location = new Point(
				m_Form.Left + 20,
				m_Form.Top + T_Size.MenuHeightDef + Sizes.CaptionHeight + Sizes.CaptionHeight2
				);
			bool b = false;
			if (m_Form != null)
			{
				b = m_Form.TopMost;
				m_Form.TopMost = false;
			}
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				Funcs.CopyFrom(dlg.Funcs);
				MakeMenu();
				ret = true;
			}
			if (m_Form != null) m_Form.TopMost = b;
			dlg.Dispose();
			*/
			return ret;
		}
		public bool OpenSaveDialog()
		{
			bool ret = false;
			/*
			if (m_Form == null) return false;
			m_Form.ForegroundWindow();
			T_OpenSaveDialog dlg = new T_OpenSaveDialog();
			//dlg.SetFuncs(Funcs);
			dlg.SetForm(m_Form);
			bool b = false;
			if (m_Form != null)
			{
				b = m_Form.TopMost;
				m_Form.TopMost = false;
			}
			dlg.ToCenter();
			//dlg.ImportDrive();
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				ret = true;
			}
			if (m_Form != null) m_Form.TopMost = b;
			//dlg.ExportDrive();
			dlg.Dispose();
			*/
			return ret;
		}
		//-------------------------------------------------
		public bool WritePDF(string p)
		{
			return TR_PDF.ExportPDF(p,Grid);
		}
		//-------------------------------------------------
		public bool WritePDF()
		{
			bool ret = false;
			SaveFileDialog dlg = new SaveFileDialog();
			dlg.Filter = "*.pdf|*.pdf|*.*|*.*";
			if (FileName != "")
			{
				dlg.InitialDirectory = T_Def.GetDir(FileName);
				dlg.FileName = T_Def.GetNameNoExt(FileName) + ".pdf";
			}
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				ret = WritePDF(T_Def.ChangeExt(dlg.FileName, ".pdf"));
				FileName = T_Def.ChangeExt(dlg.FileName, ".ardj.json");
			}
			dlg.Dispose();
			return ret;
		}

	}
}