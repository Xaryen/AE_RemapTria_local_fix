﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AE_RemapTria
{
    public class TR_Size
    {
        private TR_Form? m_form = null; 
        private TR_Grid? m_grid = null;
		private TR_CellData? m_celldata = null;
		public void SetTRForm(TR_Form? fm)
        {
            m_form = fm;
            if(m_form != null)
            {
                m_grid = m_form.Grid;
                m_celldata = m_form.CellData;
			}
        }
 
        private int m_CellWidth;
        private int m_CellHeight;
        private int m_CaptionHeight;
        private int m_CaptionHeight2;
        private int m_FrameWidth;
        private int m_FrameWidth2;
        private int m_InterWidth;
        private int m_InterHeight;
        private int m_MenuHeight;

        private Point m_Disp;
        private Point m_DispMax;
        private Rectangle m_DispCell;

        private Size m_DispSize;
        private int m_CellCount;
        private int m_FrameCountTrue;

        public const int CellWidthDef = 30;
        public const int CellHeightDef = 16;
        public const int FrameWidthDef = 90;
        public const int FrameWidth2Def = 20;
        public const int CaptionHeightDef = 20;
        public const int CaptionHeight2Def = 12;
        public const int InterWidthDef = 4;
        public const int InterHeightDef = 4;
        public const int MenuHeightDef = 20;
        public const int CellCountMin = 6;
        public const int FrameCountMin = 12;
        public const int HScrolHeight = 20;
        public const int VScrolWidth = 20;
        // ***********************************************************
        public static Point InputLocDef = new Point(0, MenuHeightDef + InterHeightDef);
        public static Size InputSizeDef = new Size(FrameWidthDef, CaptionHeightDef + CaptionHeight2Def);
        public static Point MenuLocDef = new Point(0, 0);
        public static Size MenuSizeDef = new Size(200, MenuHeightDef);
        public static Point GridLocDef = new Point(
            FrameWidthDef + InterWidthDef,
            CaptionHeightDef + CaptionHeight2Def + InterHeightDef);
        // ***********************************************************
        public Size InputSize()
        {
            return new Size(m_FrameWidth - m_FrameWidth2, m_CaptionHeight);
        }
        public Point InputLoc()
        {
            return new Point(m_FrameWidth2, m_MenuHeight + m_InterHeight + m_CaptionHeight2);
        }
        // ***********************************************************
        public TR_Size()
        {

            m_CellWidth = CellWidthDef;
            m_CellHeight = CellHeightDef;
            m_FrameWidth = FrameWidthDef;
            m_FrameWidth2 = FrameWidth2Def;
            m_CaptionHeight = CaptionHeightDef;
            m_CaptionHeight2 = CaptionHeight2Def;
            m_InterWidth = InterWidthDef;
            m_InterHeight = InterHeightDef;
            m_MenuHeight = MenuHeightDef;

            m_Disp = new Point(0, 0);
            m_DispMax = new Point(0, 0);
            m_DispCell = new Rectangle(0, 0, 0, 0);

            m_DispSize = new Size(0, 0);
            m_FrameCountTrue = 0;
            m_CellCount = 0;

        }
        //---------------------------------------
 
        //---------------------------------------
        public int CellWidth
        {
            get { return m_CellWidth; }
            set { m_CellWidth = value; ; }
        }
        //---------------------------------------
        public int CellHeight
        {
            get { return m_CellHeight; }
            set { m_CellHeight = value; ; }
        }
        //---------------------------------------
        public int CaptionHeight
        {
            get { return m_CaptionHeight; }
            set { m_CaptionHeight = value;  }
        }
        //---------------------------------------
        public int CaptionHeight2
        {
            get { return m_CaptionHeight2; }
            set { m_CaptionHeight2 = value;  }
        }
        //---------------------------------------
        public int FrameWidth
        {
            get { return m_FrameWidth; }
            set { m_FrameWidth = value;  }
        }
        //---------------------------------------
        public int FrameWidth2
        {
            get { return m_FrameWidth2; }
            set { m_FrameWidth2 = value;  }
        }
        //---------------------------------------
        public int InterWidth
        {
            get { return m_InterWidth; }
            set { m_InterWidth = value; }
        }
        //---------------------------------------
        public int InterHeight
        {
            get { return m_InterHeight; }
            set { m_InterHeight = value; }
        }
        //---------------------------------------
        public int MenuHeight
        {
            get { return m_MenuHeight; }
            set { m_MenuHeight = value;  }
        }
        //---------------------------------------
        public void SizeSetting()
        {
            if ((m_grid == null) || (m_celldata == null)) return;
            m_DispSize = m_grid.Size;
            m_FrameCountTrue = m_celldata.FrameCountTrue;
            m_CellCount = m_celldata.CellCount;

            int ax = m_CellWidth * m_CellCount - m_DispSize.Width;
            int ay = m_CellHeight * m_FrameCountTrue - m_DispSize.Height;
            if (ax < 0) ax = 0;
            if (ay < 0) ay = 0;

            m_DispMax.X = ax;
            m_DispMax.Y = ay;

            if (m_Disp.X > m_DispMax.X)
            {
                m_Disp.X = m_DispMax.X;
            }
            if (m_Disp.Y > m_DispMax.Y)
            {
                m_Disp.Y = m_DispMax.Y;
            }

            ChkDisp();


        }
        //---------------------------------------
        public void ChkDisp()
        {
            m_DispCell.X = m_Disp.X / m_CellWidth - 1;
            if (m_DispCell.X < 0) m_DispCell.X = 0;
            m_DispCell.Y = m_Disp.Y / m_CellHeight - 1;
            if (m_DispCell.Y < 0) m_DispCell.Y = 0;

            m_DispCell.Width = m_DispSize.Width / m_CellWidth + 1;
            if (m_DispCell.Width > m_CellCount) m_DispCell.Width = m_CellCount;

            m_DispCell.Height = m_DispSize.Height / m_CellHeight + 2;
            if (m_DispCell.Height > m_FrameCountTrue) m_DispCell.Height = m_FrameCountTrue;
        }
        //---------------------------------------
        public int DispX
        {
            get { return m_Disp.X; }
            set
            {
                int v = value;
                if (v < 0) v = 0;
                else if (v > m_DispMax.X) v = m_DispMax.X;
                if (m_Disp.X != v)
                {
                    m_Disp.X = v;
                    ChkDisp();
                }
            }
        }
        //---------------------------------------
        public int DispY
        {
            get { return m_Disp.Y; }
            set
            {
                int v = value;
                if (v < 0) v = 0;
                else if (v > m_DispMax.Y) v = m_DispMax.Y;
                if (m_Disp.Y != v)
                {
                    m_Disp.Y = v;
                    ChkDisp();
                }
            }
        }
        //---------------------------------------
        public Point Disp
        {
            get { return m_Disp; }
        }
        public void SetDisp(int x, int y)
        {
            int vx = x;
            if (vx < 0) vx = 0;
            else if (vx > m_DispMax.X) vx = m_DispMax.X;
            int vy = y;
            if (vy < 0) vy = 0;
            else if (vy > m_DispMax.Y) vy = m_DispMax.Y;
            bool b = false;

            if (m_Disp.X != vx)
            {
                m_Disp.X = vx;
                b = true;
            }
            if (m_Disp.Y != vy)
            {
                m_Disp.Y = vy;
                b = true;
            }
            if (b)
            {
                ChkDisp();
            }
        }
        //---------------------------------------
        /// <summary>
        ///表示されていない範囲のサイズ
        /// </summary>
        public Point DispMax
        {
            get { return m_DispMax; }
        }
        /// <summary>
        /// 表示されているセルフレーム
        /// </summary>
        public Rectangle DispCell
        {
            get { return m_DispCell; }
        }
        //---------------------------------------
        /// <summary>
        /// 座標からセルフレームの位置を求める
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public Point PosCell(int x, int y)
        {
            int y2 = (m_Disp.Y + y) / m_CellHeight;
            int x2 = (m_Disp.X + x) / m_CellWidth;
            return new Point(x2, y2);
        }
    }
}
