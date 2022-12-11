﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BRY;
using PdfSharpCore.Drawing;

namespace AE_RemapTria
{
	public partial class TR_Grid : TR_Control
    {

		public TR_CellData CellData;
		public TR_Size Sizes;
		public TR_Colors Colors;
		public T_Funcs Funcs;

		public TR_Menu m_Menu;
		public TR_Input m_Input;

		public bool IsModif = false;

        private bool m_IsJapanOS = true;
        public bool IsJapanOS { get { return m_IsJapanOS; } }
		public bool IsMultExecute = false;

		public int FrameCount
        {
            get { return CellData.FrameCount; }
            set
            {
                if (CellData.FrameCount != value)
                {
                    CellData.FrameCount = value;
                    ChkMinMax();
                }
            }
        }

        public string FileName = "";
        public string KeyBaindFile = "";
        public const string KeyBaindName = "AE_Remap_key.json";
        public TR_Grid()
        {
            m_IsJapanOS = System.Globalization.CultureInfo.CurrentUICulture.Name == "ja-JP";

		}
        // *************************************************************************************************
        public override void SetTRForm(TR_Form fm)
        {
            m_form = fm;
            if (m_form != null)
            {
				CellData = m_form.CellData;
				Colors = m_form.Colors;
				Sizes = m_form.Sizes;
				Funcs = m_form.Funcs;
				m_Menu = m_form.Menu;
				MakeFuncs();
				ChkMinMax();

				CellData.ValueChanged += CellData_ValueChangedEvent;
				CellData.SelChanged += CellData_SelChangedEvent;
				CellData.CountChanged += CellData_CountChanged;

				Sizes.ChangeGridSize += Sizes_ChangeGridSize;
				Sizes.ChangeDisp += Sizes_ChangeDisp;
				Sizes.ChangeDispMax += Sizes_ChangeDisp; 
				Sizes.SetGrid(this);

				m_form.SizeChanged += M_form_SizeChanged;
                SetLocSize();
            }
            Invalidate();
        }

        private void M_form_SizeChanged(object? sender, EventArgs e)
        {
            SetLocSize();
        }
        public override void SetLocSize()
        {
            if (m_form != null)
            {
                m_Location = new Point(0, 0);
                m_Size = new Size(m_form.Width, MenuHeight);
            }
            Invalidate();
        }
        private void CellData_CountChanged(object? sender, EventArgs e)
        {
            ChkMinMax();
            //ChkHScrl();
            //ChkVScrl();
        }
        /*
		protected override void InitLayout()
		{
			//base.InitLayout();
			ChkMinMax();
			//ChkHScrl();
			//ChkVScrl();
			//ChkGrid();
			//MyFontSize = 9;
			//Alignment = StringAlignment.Center;
		}
		*/
        // ************************************************************************************
        private void Sizes_ChangeDisp(object? sender, EventArgs e)
        {
            Invalidate();
            //if (m_Frame != null) m_Frame.Invalidate();
        }

        private void Sizes_ChangeGridSize(object? sender, EventArgs e)
        {
            Invalidate();
        }

        // ************************************************************************************
        private void CellData_SelChangedEvent(object? sender, EventArgs e)
        {
            Invalidate();
        }
        // ************************************************************************************
        private void CellData_ValueChangedEvent(object? sender, EventArgs e)
        {
            Invalidate();
        }

        // ************************************************************************************
        private void ChkMinMax()
        {
            Size mn = new Size(
                Sizes.CellWidth * 6,
                Sizes.CellHeight * 6);
            Size mx = new Size(
                Sizes.CellWidth * CellData.CellCount,
                Sizes.CellHeight * CellData.FrameCountTrue);
            SetMinMaxSize(mn, mx);
            SizeSetting();

        }
        // ************************************************************************************
        public void SizeSetting()
        {
            Sizes.SizeSetting(Size, CellData);
        }
        //-------------------------------------------------
        /*
		[Category("_AE_Remap")]
		public T_HScrol HScrol
		{
			get { return m_HScrol; }
			set
			{
				m_HScrol = value;
				ChkHScrl();
			}
		}
		private void ChkHScrl()
		{
			if (m_HScrol != null)
			{
				Point p = new Point(
					this.Left,
					this.Top + this.Height + Sizes.InterHeight);
				if (m_HScrol.Location != p) m_HScrol.Location = p;
				if (m_HScrol.Width != this.Width) m_HScrol.Width = this.Width;

				m_HScrol.ValueChangedEvent += M_VScrol_ValueChangedEvent;
				m_HScrol.Maximum = Sizes.DispMax.X;
				m_HScrol.Value = Sizes.Disp.X;
			}

		}


		//-------------------------------------------------------------
		[Category("_AE_Remap")]
		public T_VScrol VScrol
		{
			get { return m_VScrol; }
			set
			{
				m_VScrol = value;
				ChkVScrl();
			}
		}
		private void ChkVScrl()
		{
			if (m_VScrol != null)
			{
				Point p = new Point(
					this.Left + this.Width + Sizes.InterWidth,
					this.Top);
				if (m_VScrol.Location != p) m_VScrol.Location = p;
				if (m_VScrol.Height != this.Height) m_VScrol.Height = this.Height;
				m_VScrol.ValueChangedEvent += M_VScrol_ValueChangedEvent;
				m_VScrol.Maximum = Sizes.DispMax.Y;
				m_VScrol.Value = Sizes.Disp.Y;
			}

		}

		// ************************************************************************************
		private void M_VScrol_ValueChangedEvent(object? sender, EventArgs e)
		{
			if (m_VScrol != null)
			{
				Sizes.DispY = m_VScrol.Value;
				this.Invalidate();
			}
			if (m_HScrol != null)
			{
				Sizes.DispX = m_HScrol.Value;
				this.Invalidate();
			}
		}
		*/
        // ************************************************************************************

        /*
	protected override void OnResize(EventArgs e)
	{
		SizeSetting();
		if (m_HScrol != null)
		{
			Point p = new Point(
				this.Left,
				this.Top + this.Height + Sizes.InterHeight);
			if (m_HScrol.Location != p) m_HScrol.Location = p;
			if (m_HScrol.Width != this.Width) m_HScrol.Width = this.Width;

			m_HScrol.Maximum = Sizes.DispMax.X;
			m_HScrol.Value = Sizes.Disp.X;
		}
		if (m_VScrol != null)
		{
			Point p = new Point(
				this.Left + this.Width + Sizes.InterWidth,
				this.Top);
			if (m_VScrol.Location != p) m_VScrol.Location = p;
			if (m_VScrol.Height != this.Height) m_VScrol.Height = this.Height;

			m_VScrol.Maximum = Sizes.DispMax.Y;
			m_VScrol.Value = Sizes.Disp.Y;
		}
		if (m_Caption != null) m_Caption.SetLoc();
		if (m_Frame != null) m_Frame.SetLocSize();
		this.Invalidate();
	}
		*/
        //-------------------------------------------------
        public Point PosCell(int x, int y)
        {
            return Sizes.PosCell(x, y);
        }
        //-------------------------------------------------
        /*
		private int m_mdFrame = -1;
		private int m_CopyFrame = -1;
		private Point m_md = new Point(-1, -1);
		private Point m_disp = new Point(-1, -1);
		protected override void OnMouseDown(MouseEventArgs e)
		{
			if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
			{
				Point cp = Sizes.PosCell(e.X, e.Y);
				if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
				{
					int y0 = CellData.Selection.Start;
					int y1 = CellData.Selection.LastFrame;
					if (cp.Y <= y0)
					{
						y0 = cp.Y;
					}
					else
					{
						y1 = cp.Y;
					}
					CellData.PushUndo(BackupSratus.SelectionChange);
					CellData.Selection.Set2Frame(y0, y1);
				}
				else if ((Control.ModifierKeys & Keys.Alt) == Keys.Alt)
				{
					CellData.PushUndo(BackupSratus.SelectionChange);
					CellData.Selection.SelToEnd();
				}
				else
				{
					m_mdFrame = cp.Y;
					CellData.PushUndo(BackupSratus.SelectionChange);
					CellData.Selection.SetTargetStartLength(cp.X, cp.Y, 1);
					if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
					{
						m_CopyFrame = CellData.GetCellData(cp.X, cp.Y);
						CellData.PushUndo(BackupSratus.NumberInput);
					}
					else
					{
						m_CopyFrame = -1;
					}

				}
				this.Invalidate();
				Sizes.CallOnChangeDisp();
			}
			else if ((e.Button & MouseButtons.Middle) == MouseButtons.Middle)
			{
				m_md = new Point(e.X, e.Y);
				m_disp = Sizes.Disp;
			}
			base.OnMouseDown(e);
		}
		protected override void OnMouseMove(MouseEventArgs e)
		{
			if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
			{
				if (m_mdFrame >= 0)
				{
					bool b = CellData._undoPushFlag;
					if (m_CopyFrame >= 0)
					{
						CellData._undoPushFlag = false;
					}
					if (e.Y >= this.Height)
					{
						Sizes.DispY += Sizes.CellHeight;
					}
					else if (e.Y < 0)
					{
						Sizes.DispY -= Sizes.CellHeight;
					}
					Point cp = Sizes.PosCell(e.X, e.Y);
					CellData.Selection.Set2Frame(m_mdFrame, cp.Y);
					if (m_CopyFrame >= 0)
					{
						CellData.SetCellNum(m_CopyFrame, false);
					}
					CellData._undoPushFlag = b;
					this.Invalidate();
					Sizes.CallOnChangeDisp();
				}
				else if ((e.Button & MouseButtons.Middle) == MouseButtons.Middle)
				{
					int ax = e.X - m_md.X;
					int ay = e.Y - m_md.Y;

					Sizes.SetDisp(m_disp.X + ax, m_disp.Y + ay);
					this.Invalidate();
				}
				base.OnMouseMove(e);
			}
		}
		protected override void OnMouseUp(MouseEventArgs e)
		{
			if (m_mdFrame >= 0)
			{
				m_mdFrame = -1;
				this.Invalidate();
			}
			m_md = new Point(-1, -1);
			m_disp = new Point(-1, -1);
			m_CopyFrame = -1;
			base.OnMouseUp(e);
		}

		protected override void OnDragEnter(DragEventArgs drgevent)
		{
			if (drgevent != null)
			{
#pragma warning disable CS8602 // null 参照の可能性があるものの逆参照です。
				if (drgevent.Data.GetDataPresent(DataFormats.FileDrop))
				{
					drgevent.Effect = DragDropEffects.All;
				}
				else
				{
					drgevent.Effect = DragDropEffects.None;
				}
#pragma warning restore CS8602 // null 参照の可能性があるものの逆参照です。
			}
			//base.OnDragEnter(drgevent);
		}
		protected override void OnDragDrop(DragEventArgs drgevent)
		{
			if (drgevent != null)
			{
				string[] files = (string[])drgevent.Data.GetData(DataFormats.FileDrop, false);
				foreach (string file in files)
				{
					if (Open(file) == true)
					{
						break;
					}
				}
			}
			//base.OnDragDrop(drgevent);
		}
		*/
    }
}