﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Text.Unicode;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace AE_RemapTria
{
	//**************************************************************
	/// <summary>
	/// セルのコマ打ちデータ
	/// </summary>
	public partial class TR_CellData 
	{
		/// <summary>
		/// イベント発生フラグ。falseでイベント発生しない。
		/// </summary>
		public bool _eventFlag = true;

		public event EventHandler? ValueChanged = null;
		public event EventHandler? SelChanged = null;
		public event EventHandler? CountChanged = null;
		// ******************************************************************************
		private TR_Selection m_sel = new();
		public TR_Selection Selection { get { return m_sel; } }
		public bool IsTargetCell(int idx) { return  m_sel.IsTargerCell(idx); }
		public bool IsSelectedFrame(int f) { return m_sel.IsSelectedFrame(f); }
		public bool IsSelected(int c,int f) { return m_sel.IsSelected(c,f); }
		// ******************************************************************************
		/// <summary>
		/// 抜きセル用のフラグ配列
		/// </summary>
		private TR_CellLayer m_FrameEnabled = new TR_CellLayer(1,true);
		public bool EnableFrame(int f) { return m_FrameEnabled.Enable(f); }
		/// <summary>
		/// セルデータ
		/// </summary>
		private TR_CellLayer[] m_cells = new TR_CellLayer[1];
		// ******************************************************************************
		private string m_Info = "";
		public string Info
		{
			get { return m_Info; }
		}
		/// <summary>
		/// セルのレイヤ―数
		/// </summary>
		public int CellCount { get { return m_cells.Length; } set { SetCellCount(value); } }
		/// <summary>
		/// フレーム数（物理的な）
		/// </summary>
		public int FrameCount { get { return m_FrameEnabled.FrameCount; } set { SetFrameCount(value); } }
		/// <summary>
		/// EnabledFrameを考慮したフレーム数
		/// </summary>
		public int FrameCountTrue { get { return m_FrameEnabled.FrameCountTrue; } }
		public int UnEnabledFrameCount { get { return m_FrameEnabled.UnEnabledFrameCount; } }
		public TR_CellLayer CellLayer(int c) { return m_cells[c]; }
		/// <summary>
		/// セル名をインデックスで獲得
		/// </summary>
		/// <param name="c">セルのインデックス</param>
		/// <returns>セルの名前</returns>
		public string CaptionFromIndex(int c) 
		{
			string ret = "";
			if((c>=0)&&(c<CellCount))
			{
				ret = m_cells[c].Caption;
			}
			return ret;
		}
		public string CaptionTarget()
		{
			return CaptionFromIndex(Selection.Target);
		}
		public void SetCaptionTarget(string s)
		{
			s = s.Trim();
			if (s == "") return;
			int c = Selection.Target;
			if ((c >= 0) && (c < CellCount))
			{
				m_cells[c].Caption = s;
			}

		}
		public int TargetIndex
		{
			get { return m_sel.Target; }
			set 
			{
				int v = value;
				if (v < 0) v = 0;
				else if (v >= CellCount) v = CellCount - 1;

				if (m_sel.Target != v)
				{
					PushUndo(BackupSratus.SelectionChange);
					m_sel.Target = v;
					OnSelChanged(new EventArgs());
				}
			}
		}
		// ******************************************************
		private T_Fps m_FrameRate = T_Fps.FPS24;
		public T_Fps FrameRate
		{
			get { return m_FrameRate; }
			set 
			{ 
				if(m_FrameRate != value)
				{
					m_FrameRate = value;
					OnValueChanged(new EventArgs());
				};  
			}
		}
		// ******************************************************
		private T_PageSec m_PageSec = T_PageSec.sec6;
		public T_PageSec PageSec { 
			get { return m_PageSec; }
			set { m_PageSec = value;}
		}
		private T_FrameDisp m_FrameDisp = T_FrameDisp.pageFrame;
		public T_FrameDisp FrameDisp { get { return m_FrameDisp; } }
		public void ToggleFrameDisp()
		{
			int v = (int)m_FrameDisp + 1;
			if (v >= (int)T_FrameDisp.Count) v = (int)T_FrameDisp.frame;
			m_FrameDisp = (T_FrameDisp)v;
		}

		// ******************************************************
		private int m_StartKoma = 1;
		/// <summary>
		/// 表示フレーム数のスタート番号
		/// </summary>
		public int StartKoma 
		{ 
			get { return m_StartKoma; } 
			set {
				if (value >= 1)
				{
					m_StartKoma = 1;
				}
				else
				{
					m_StartKoma = 0;
				}
				OnValueChanged(new EventArgs());
			}
		}
		private int m_OffSetFrame = 0;
		public int OffSetFrame
		{
			get { return m_OffSetFrame; }
			set
			{
				m_OffSetFrame=value;
				OnValueChanged(new EventArgs());
			}
		}


		// ******************************************************
		public string SheetName = "";
		public string TITLE = "";
		public string SUB_TITLE = "";
		public string OPUS = "";
		public string SCECNE = "";
		public string CUT = "";
		public string CAMPANY_NAME = "";

		public string CREATE_USER = "";
		public string UPDATE_USER = "";

		public DateTime CREATE_TIME = new DateTime(1963, 9, 9);
		public DateTime UPDATE_TIME = new DateTime(1963, 9, 9);

		// ******************************************************
		public TR_CellData()
		{
			_undoPushFlag = false;
			m_sel.SetCellData(this);
			InitSize(12, 72);
			_undoPushFlag = true;
		}

		// ******************************************************
		protected virtual void OnValueChanged(EventArgs e)
		{
			if (_eventFlag == false) return;
			if (ValueChanged != null)
			{
				ValueChanged(this, e);
			}
		}
		// ******************************************************
		protected virtual void OnSelChanged(EventArgs e)
		{
			if (_eventFlag == false) return;
			if (SelChanged != null)
			{
				SelChanged(this, e);
			}
		}
		// ******************************************************
		protected virtual void OnCountChanged(EventArgs e)
		{
			if (_eventFlag == false) return;
			if (CountChanged != null)
			{
				CountChanged(this, e);
			}
		}
		// ******************************************************
		public void CallCountCahnged()
		{
			OnCountChanged(EventArgs.Empty);
		}
		// ******************************************************
		public void InitSize(int cc,int fc)
		{
			if (cc < 10) cc = 10;
			if (fc < 6) fc = 6;
			m_FrameEnabled = new TR_CellLayer(fc,true);
			m_cells = new TR_CellLayer[cc];
			for (int i = 0; i < cc; i++)
			{
				m_cells[i] = new TR_CellLayer(fc, Char.ConvertFromUtf32('A' + i));
			}
			CalcInfo();
		}
		// ******************************************************
		public void SetFrameCount(int fc)
		{
			if (fc <= 6) fc = 6;
			if (m_FrameEnabled.FrameCount != fc)
			{
				int tfc = fc + m_FrameEnabled.UnEnabledFrameCount;
				PushUndo(BackupSratus.All);
				int cc = CellCount;

				for (int i = 0; i < cc; i++)
				{
					m_cells[i].SetFrameCountTrue(tfc);
				}
				m_FrameEnabled.SetFrameCountTrue(tfc);
				CalcInfo();
				OnCountChanged(new EventArgs());
			}
		}
		// ******************************************************
		public void SetCellCount(int cc)
		{
			if (cc <= 10) cc = 10;
			if (m_cells.Length != cc)
			{
				PushUndo(BackupSratus.All);
				int fc = FrameCount;
				int oldcc = CellCount;
				Array.Resize(ref m_cells, cc);

				if (cc > oldcc)
				{
					for (int i = oldcc; i < cc; i++)
					{
						m_cells[i] = new TR_CellLayer(fc, Char.ConvertFromUtf32('A'+i)); ;
					}
				}
				OnCountChanged(new EventArgs());
			}
		}
		// ******************************************************
		public void SetCellFrame(int c,int f)
		{
			bool b = _eventFlag;
			_eventFlag = false;
			bool b2 = _undoPushFlag;
			_undoPushFlag = false;
			SetCellCount(c);
			SetFrameCount(f);
			_eventFlag = b;
			_undoPushFlag = b2;
			OnValueChanged(new EventArgs());

		}
		// ******************************************************
		public int[] EnableFrames()
		{

			return m_FrameEnabled.Values(Selection); 
		}
		public void SetFrameEnabled(int[]bb)
		{
			m_FrameEnabled.SetValues(Selection, bb);
		}
		// ******************************************************
		private void CalcInfo()
		{
			m_Info = string.Format("{0}+{1}:{2}",
				FrameCount / (int)m_FrameRate,
				FrameCount % (int)m_FrameRate,
				(int)m_FrameRate
				);
		}
		// ******************************************************
		public bool InitFrameEnabled()
		{
			PushUndo(BackupSratus.FrameEnabled);
			m_FrameEnabled.Init();
			CalcInfo();
			return true;
		}

		// ******************************************************
		public bool ToggleFrameEnabled()
		{
			PushUndo(BackupSratus.FrameEnabled);
			for (int i = 0; i < Selection.Length; i++)
			{
				int f = Selection.Start + i;
				if ((f >= 0) && (f < m_FrameEnabled.FrameCountTrue))
				{
					m_FrameEnabled.SetEnable(f, !m_FrameEnabled.Enable(f));
				}
			}
			m_FrameEnabled.CalcEnableFrame();
			CalcInfo ();
			OnCountChanged(new EventArgs());
			return true;
		}
		// ******************************************************
		public void SetFrameEnabled(bool b)
		{
			PushUndo(BackupSratus.FrameEnabled);
			for (int i = 0; i < Selection.Length; i++)
			{
				int f = Selection.Start + i;
				if ((f >= 0) && (f < m_FrameEnabled.FrameCountTrue))
				{
					m_FrameEnabled.SetEnable(f,b);
				}
			}
			m_FrameEnabled.CalcEnableFrame();
			CalcInfo();
			OnCountChanged(new EventArgs());
		}
		// ******************************************************
		public CellSatus GetCellStatus(int c, int f)
		{
			CellSatus cs = new CellSatus();
			cs.Init();
			if ((c >= 0) && (c < CellCount))
			{
				int v = m_cells[c].Value(f);
				cs.Cell = c;
				cs.Frame = f;
				cs.Value = v;
				if(f== 0)
				{
					if (v == 0)
					{
						cs.Status = CellType.EmptyStart;
					}
					else
					{
						cs.Status = CellType.Normal;
					}
				}
				else
				{
					if(v == m_cells[c].Value(f-1))
					{
						if (v == 0)
						{
							cs.Status = CellType.None;
						}
						else
						{
							cs.Status = CellType.SameAsBefore;
						}
					}
					else
					{
						if (v == 0)
						{
							cs.Status = CellType.EmptyStart;
						}
						else
						{
							cs.Status = CellType.Normal;
						}

					}
				}
			}
			return cs;
		}
		// ******************************************************
		public void SetTargetCell(int c)
		{
			int cc = c;
			if (cc < 0) cc = 0;
			else if (cc >= m_cells.Length) cc = m_cells.Length-1;
			if( cc != m_sel.Target)
			{
				PushUndo(BackupSratus.SelectionChange);
				m_sel.SetTarget(cc);
				OnSelChanged(new EventArgs());
			}
		}
		// ******************************************************
		public void SetSelStart(int f)
		{
			int ff = f;
			if (ff < 0) ff = 0;
			else if (ff >= m_cells[0].FrameCountTrue) ff = m_cells[0].FrameCountTrue;
			if (ff != m_sel.Start)
			{
				PushUndo(BackupSratus.SelectionChange);
				m_sel.SetStart(ff);
				//OnSelChanged(new EventArgs());
			}
		}
		// ******************************************************
		public void ClearAll()
		{
			PushUndo(BackupSratus.All);
			m_FrameEnabled.Init();
			for (int c = 0; c < m_cells.Length; c++) m_cells[c].Init();
			CalcInfo();
			OnValueChanged(new EventArgs());

		}
		// ******************************************************
		public void Clear(int c)
		{
			if((c>=0) && (c < CellCount))
			{
				m_cells[c].Init();
				CalcInfo();
				OnValueChanged(new EventArgs());
			}

		}

		// ******************************************************
		public int[] GetCellNum()
		{
			return m_cells[Selection.Target].Values(Selection);
		}
		// ******************************************************
		/// <summary>
		/// 選択範囲に選択範囲の前のフレームと同じ数値を入れる
		/// </summary>
		public void SetCellNumSame()
		{
			if (_undoPushFlag == true) PushUndo(BackupSratus.NumberInput);

			int sv = m_sel.Start-1;
			if (sv < 0) sv = 0;
			int v = m_cells[m_sel.Target].Value(sv);
			if ((sv == 0) && (v <= 0)) v = 1;

			m_cells[Selection.Target].SetValues(Selection, v);
			m_sel.MoveDown();
			OnValueChanged(new EventArgs());

		}
		public void SetCellNumInc()
		{
			if (_undoPushFlag == true) PushUndo(BackupSratus.NumberInput);
			//int fc = m_data[0].Length;

			int sv = m_sel.Start - 1;
			if (sv < 0) sv = 0;
			int v = m_cells[m_sel.Target].Value(sv);
			v += 1;
			m_cells[Selection.Target].SetValues(Selection, v);
			m_sel.MoveDown();
			OnValueChanged(new EventArgs());

		}

		public void SetCellNumDec()
		{
			if (_undoPushFlag == true) PushUndo(BackupSratus.NumberInput);
			int sv = m_sel.Start - 1;
			if (sv < 0) sv = 0;
			int v = m_cells[m_sel.Target].Value(sv);
			v -= 1;
			if (v < 0) v = 0;
			m_cells[Selection.Target].SetValues(Selection, v);
			m_sel.MoveDown();
			OnValueChanged(new EventArgs());

		}
		// ******************************************************
		/// <summary>
		/// 選択範囲にセル番号を入力
		/// </summary>
		/// <param name="v"></param>
		public void SetCellNum(int v,bool IsMove =true)
		{
			if (v < 0) v = 0;
			if (_undoPushFlag == true) PushUndo(BackupSratus.NumberInput);
			m_cells[Selection.Target].SetValues(Selection, v);
			if (IsMove)
			{
				m_sel.MoveDown();
			}
			OnValueChanged(new EventArgs());

		}
		// ******************************************************
		public void SetCellNumEmpty(bool IsMove=true)
		{
			bool b = true;
			if(IsMove==false)
			{
				b = false;
				int[] v = GetCellNum();
				for (int i = 0; i < v.Length; i++)
				{
					if(v[i] != 0)
					{
						b = true;
						break;
					}
				}
			}
			if (b) SetCellNum(0,IsMove);
		}
		// ******************************************************
		public void SetCellNumBS()
		{
			if (Selection.MoveUp())
			{
				SetCellNumEmpty(false);
			}
		}
		/// <summary>
		/// 選択範囲にセル番号配列を入力
		/// 要素数が元の選択範囲より多ければ選択範囲を拡張
		/// </summary>
		/// <param name="ints"></param>
		public void SetCellNum(int [] ints)
		{
			if(_undoPushFlag==true) PushUndo(BackupSratus.NumberInput);
			int len = m_sel.Length;
			if (len > ints.Length)
			{
				m_sel.Length = len;
				len = ints.Length;
			}
			m_cells[Selection.Target].SetValues(Selection, ints);
			OnValueChanged(new EventArgs());

		}

		// ******************************************************
		public bool SelectionAdd(int v)
		{
			bool ret = false;
			int len = m_sel.Length + v;
			if(len>0)
			{
				if (m_sel.Start + len <= FrameCount)
				{
					PushUndo(BackupSratus.SelectionChange);
					m_sel.Length = len;
					ret = true;
					OnSelChanged(new EventArgs());
				}

			}
			return ret;
		}
		public bool SelectionAll(int c)
		{
			bool ret = false;
			if (c < 0) c = 0;
			else if (c >= CellCount) c = CellCount - 1;
			PushUndo(BackupSratus.SelectionChange);
			m_sel.Target = c;
			m_sel.Start = 0;
			m_sel.Length = FrameCount;
			OnSelChanged(new EventArgs());
			return ret;
		}
		public bool SelectionAll()
		{
			return SelectionAll(m_sel.Target);
		}
		static private string NV(int v)
		{
			string s = v.ToString();
			if (s == "") s = "0";
			return s;
		}
		static private string SP2(int v)
		{
			string s = NV(v);
			if (v < 10)
			{
				return " " + s;
			}
			else
			{
				return s;
			}
		}
		static private string SP4(int v)
		{
			string s = NV(v);
			if (v < 10)
			{
				return "   " + s;
			}
			else if (v < 100)
			{
				return "  " + s;
			}
			else if (v < 1000)
			{
				return " " + s;
			}
			else
			{
				return s;
			}
		}
		public string FrameStr(int idx)
		{
			string ret = "";
			int frmV = 0;
			int pageV = 0;
			int secV = 0;
			int pageFrm = (int)m_PageSec*(int)m_FrameRate;
			idx -= m_OffSetFrame;
			switch (m_FrameDisp)
			{
				case T_FrameDisp.frame:
					if (idx >= 0)
					{
						frmV = idx + m_StartKoma;
					}
					else
					{
						frmV = idx;
					}
					ret = NV(frmV);
					break;
				case T_FrameDisp.pageFrame:
					//s0 = String.Format("{0,3}", frmV);
					if ((idx % (int)FrameRate) == 0)
					{
						pageV = (idx / (int)pageFrm) + 1;
						ret += NV(pageV)+"p";
					}
					frmV = (idx % pageFrm);
					if (frmV < 0) frmV = pageFrm + frmV;
					frmV += m_StartKoma;
					ret += SP4(frmV);
					break;
				case T_FrameDisp.pageSecFrame:
					if (idx % (int)FrameRate == 0)
					{
						pageV = (idx / (int)pageFrm) + 1;
						ret += NV(pageV) + "p";
						secV = (idx / (int)m_FrameRate);
						ret += SP2(secV) + "+";
					}
					frmV = (idx % (int)FrameRate);
					if (frmV < 0) frmV = (int)FrameRate + frmV;
					frmV += m_StartKoma;
					ret += SP2(frmV);
					break;
				case T_FrameDisp.SecFrame:
					if (idx % (int)FrameRate == 0)
					{
						secV = (idx / (int)FrameRate);
						ret = NV(secV)+"+";
					}
					frmV = (idx % (int)FrameRate);
					if(frmV < 0) frmV = (int)FrameRate + frmV;
					frmV += m_StartKoma;
					ret += SP2(frmV);
					break;
			}
			return ret;

		}
		// **********************************************************************
		public bool SwapCell(int c0,int c1)
		{
			bool ret = false;

			if((c0 != c1)&&(c0>=0) && (c0<CellCount)&&(c1 >= 0) && (c1 < CellCount))
			{
				ret =m_cells[c0].Swap(ref m_cells[c1]);
			}
			return ret;
		}
		public bool CellLeftShift()
		{
			bool ret = false;
			if((Selection.Target>0)&&(Selection.Target < CellCount))
			{
				ret = SwapCell(Selection.Target-1, Selection.Target);
				Selection.Target -= 1;
			}
			return ret;
		}
		public bool CellRightShift()
		{
			bool ret = false;
			if ((Selection.Target >=0) && (Selection.Target < CellCount - 1))
			{
				ret = SwapCell(Selection.Target, Selection.Target+1);
				Selection.Target += 1;
			}
			return ret;
		}
		public bool AutoInput(int st,int lt,int koma)
		{
			if ((st==lt)||(koma<=0)) return false;
			PushUndo(BackupSratus.NumberInput);
			m_cells[Selection.Target].AutoInput(Selection, st,lt, koma);
			return true;
		}
	}
}