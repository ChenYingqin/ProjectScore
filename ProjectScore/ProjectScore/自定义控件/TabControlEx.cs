using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using WinTabControl.Win32;

namespace WinTabControl
{
    public partial class TabControlEx : TabControl
    {
        private Rectangle addRec;
        private Color colorMouseOn = Color.Silver;

        private Image close_Image;
        private Image close_normalImage;
        private Image TabIcon;

        private Rectangle rectClose;
        private Rectangle rectIcon;
        private Rectangle rectFont;
        private Color onSelectedColor1 = Color.White;
        private Color onSelectedColor2 = Color.White;
        private Color offSelectedColor1 = Color.FromArgb(60, 116, 201);
        private Color offSelectedColor2 = Color.FromArgb(60, 116, 201);
        private Color MoveSelectedColor1 = Color.FromArgb(60, 116, 201);
        private Color MoveSelectedColor2 = Color.FromArgb(60, 116, 201);
        private Color BottomLineColor = Color.FromArgb(188, 188, 188);
        private SolidBrush brushFont = new SolidBrush(Color.Black);
        private Color backcolor = System.Drawing.SystemColors.Control;
        private Image _backgroundImage = null;
        private Rectangle rctTabHeaderColor;
        private Rectangle rctTabHeaderImage;
        private int tabIndex = 0;
        private int OverIndex = -1;
        private int tabid = 0;
        private bool AllSelected = false;
        private Point tabPoint;
        private TabPage _SourceTabPage = null;
        private int _tabHOffset = 0;

        /// <summary>
        /// 设置选项卡处于选中状态时第一背景色.
        /// </summary>
        [Description("设置选项卡处于选中状态时第一背景色。")]
        [DefaultValue(typeof(Color), "White")]
        [Browsable(true)]
        public Color TabOnColorState
        {
            get { return onSelectedColor1; }
            set
            {
                if (!value.Equals(onSelectedColor1))
                {
                    onSelectedColor1 = value;
                    Invalidate();
                    Update();
                }
            }
        }

        /// <summary>
        /// 设置选项卡处于选中状态时第二背景色.
        /// </summary>
        [Description("设置选项卡处于选中状态时第二背景色。")]
        [DefaultValue(typeof(Color), "Pink")]
        [Browsable(true)]
        public Color TabOnColorEnd
        {
            get { return onSelectedColor2; }
            set
            {
                if (!value.Equals(onSelectedColor2))
                {
                    onSelectedColor2 = value;
                    Invalidate();
                    Update();
                }
            }
        }

        /// <summary>
        /// 设置选项卡处于非选中状态时第一背景色.
        /// </summary>
        [Description("设置选项卡处于非选中状态时第一背景色。")]
        [DefaultValue(typeof(Color), "192, 255, 255")]
        [Browsable(true)]
        public Color TabOffColorState
        {
            get { return offSelectedColor1; }
            set
            {
                if (!value.Equals(offSelectedColor1))
                {
                    offSelectedColor1 = value;
                    Invalidate();
                    Update();
                }
            }
        }

        /// <summary>
        /// 设置选项卡处于非选中状态时第二背景色.
        /// </summary>
        [Description("设置选项卡处于非选中状态时第二背景色。")]
        [DefaultValue(typeof(Color), "200, 66, 204, 255")]
        [Browsable(true)]
        public Color TabOffColorEnd
        {
            get { return offSelectedColor2; }
            set
            {
                if (!value.Equals(offSelectedColor2))
                {
                    offSelectedColor2 = value;
                    Invalidate();
                    Update();
                }
            }
        }

        /// <summary>
        /// 设置鼠标移动到非选中状态选项卡时第一背景色.
        /// </summary>
        [Description("设置鼠标移动到非选中状态选项卡时第一背景色。")]
        [DefaultValue(typeof(Color), "200, 66, 204, 255")]
        [Browsable(true)]
        public Color TabMoveColorState
        {
            get { return MoveSelectedColor1; }
            set
            {
                if (!value.Equals(MoveSelectedColor1))
                {
                    MoveSelectedColor1 = value;
                    Invalidate();
                    Update();
                }
            }
        }

        /// <summary>
        /// 设置鼠标移动到非选中状态选项卡时第二背景色.
        /// </summary>
        [Description("设置鼠标移动到非选中状态选项卡时第二背景色。")]
        [DefaultValue(typeof(Color), "192, 255, 255")]
        [Browsable(true)]
        public Color TabMoveColorEnd
        {
            get { return MoveSelectedColor2; }
            set
            {
                if (!value.Equals(MoveSelectedColor2))
                {
                    MoveSelectedColor2 = value;
                    Invalidate();
                    Update();
                }
            }
        }

        /// <summary>
        /// 设置选项卡工作区背景色.
        /// </summary>
        [Description("设置选项卡工作区背景色。")]
        [DefaultValue(typeof(Color), "Control")]
        [Browsable(true)]
        public Color BackTabPageColor
        {
            get { return backcolor; }
            set
            {
                if (!value.Equals(backcolor))
                {
                    backcolor = value;
                    Invalidate();
                    Update();
                }
            }
        }

        /// <summary>
        /// 设置选项卡工作区背景图.
        /// </summary>
        [Description("设置选项卡工作区背景图。")]
        [Browsable(true)]
        public Image BackTabPageImage
        {
            get
            {
                return _backgroundImage;
            }
            set
            {
                if (value != null)
                {
                    if (!value.Equals(_backgroundImage))
                    {
                        _backgroundImage = value;
                        Invalidate();
                        Update();
                    }
                }
                else
                {
                    _backgroundImage = null;
                    Invalidate();
                    Update();
                }
            }
        }

        public TabControlEx()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint |
                 ControlStyles.SupportsTransparentBackColor | ControlStyles.ResizeRedraw |
                 ControlStyles.UserMouse, true);

            this.ItemSize = new Size(150, 25);
            this.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            //this.AllowDrop = true; 


            //从资源文件（嵌入到程序集）里读取图片
            //close_Image = new Bitmap(close);
            //close_normalImage = new Bitmap(JWBControl.ImgResources);
        }

        ~TabControlEx()
        {
            GC.SuppressFinalize(this);
        }

        protected virtual void Draw(Graphics g)
        {
            //DrawBorder(g);

            Rectangle rct = this.ClientRectangle;
            rct.Inflate(-1, -1);
            Rectangle rctTabArea = this.DisplayRectangle;

            if (this.TabCount > 0)
            {
                rctTabHeaderColor = new Rectangle(rct.Left, rct.Top, rct.Width, rctTabArea.Top);
                rctTabHeaderImage = new Rectangle(rct.Left - 1, rct.Top - 1, rct.Width + 3, rctTabArea.Top);
            }
            else
            {
                rctTabHeaderColor = new Rectangle(rct.Left, rct.Top, rct.Width, rctTabArea.Top + 24);
                rctTabHeaderImage = new Rectangle(rct.Left - 1, rct.Top - 1, rct.Width + 3, rctTabArea.Top + 25);
            }

            using (Bitmap overlay = new Bitmap(rctTabHeaderImage.Width, rctTabHeaderImage.Height))
            {
                using (Graphics gr = Graphics.FromImage(overlay))
                {
                    gr.SmoothingMode = SmoothingMode.HighQuality;

                    if (_backgroundImage != null)
                    {
                        using (Brush brush = new TextureBrush(_backgroundImage, WrapMode.TileFlipXY))
                            gr.FillRectangle(brush, 0, 0, overlay.Width, overlay.Height);
                    }
                    else
                    {
                        g.FillRectangle(new SolidBrush(backcolor), 0, 0, rctTabHeaderColor.Width + 2, rctTabHeaderColor.Height);
                    }
                }

                g.DrawImage(overlay, rctTabHeaderImage, 1, 1, overlay.Width, overlay.Height, GraphicsUnit.Pixel);
                //g.DrawLine(new Pen(new SolidBrush(BottomLineColor), 1), 0, 28, this.ClientSize.Width, 28);
            }
        }

        protected virtual void DrawBorder(Graphics g)
        {
            Rectangle rct = this.ClientRectangle;
            Rectangle rctTabArea = this.DisplayRectangle;

            using (Pen pen = new Pen(Color.White))
            {
                pen.DashStyle = DashStyle.Solid;

                g.DrawLine(pen, rct.X, rctTabArea.Y, rct.X, rct.Bottom - 1);
                g.DrawLine(pen, rct.X, rct.Bottom - 1, rct.Width - 1, rct.Bottom - 1);
                g.DrawLine(pen, rct.Width - 1, rct.Bottom - 1, rct.Width - 1, rctTabArea.Y);
            }
        }

        protected virtual void DrawAll(Graphics g, Rectangle rect, string title, bool selected, bool mouseOver)
        {
            try
            {
                rectFont = new Rectangle(rect.X+(rect.Width - (int)g.MeasureString(title, Font).Width) / 2, rect.Y+(rect.Height - Font.Height) / 2, rect.Width, Font.Height);
                //rectClose = new Rectangle(rect.X + rect.Width - 25, 11, 12, 12);

                drawRect(g, rect, selected, mouseOver);
                if(!selected)
                {
                    g.DrawString(title, Font, Brushes.White, rectFont);
                }
                else
                {
                    g.DrawString(title, Font, Brushes.Black, rectFont);
                }
                //drawString(g, rectFont, title, Font);
                //drawClose(g, rectClose, CloseHitTest(this.PointToClient(Cursor.Position)));

                for (int i = 0; i < this.TabCount; i++)
                {
                    rect = this.GetTabRect(i);

                    if (this.ImageList != null && !this.TabPages[i].ImageIndex.Equals(-1))
                    {
                        if (this.TabPages[i].ImageIndex <= this.ImageList.Images.Count - 1)
                        {
                            TabIcon = this.ImageList.Images[this.TabPages[i].ImageIndex];
                            rectIcon = new Rectangle(rect.X + 16, 8, 16, 16);
                            drawTabIcon(g, rectIcon);
                            TabIcon.Dispose();
                        }
                    }
                }
            }
            catch { }
        }

        protected virtual void drawRect(Graphics g, Rectangle rect, bool selected, bool mouseOver)
        {
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddBezier(
                    new Point(rect.X, rect.Bottom + 2),
                    new Point(rect.X + 3, rect.Bottom - 2),
                    new Point(rect.X + 3, rect.Bottom - 2),
                    new Point(rect.X, rect.Bottom + 2));
                //path.AddLine(rect.X + 4, rect.Bottom - 4, rect.Left + 15 - 4, rect.Y + 4);
                path.AddBezier(
                    new Point(rect.Left + 15 - 4, rect.Y + 4),
                    new Point(rect.Left + 15 - 3, rect.Y + 2),
                    new Point(rect.Left + 15 - 3, rect.Y + 2),
                    new Point(rect.Left + 15, rect.Y));
                //path.AddLine(rect.Left + 15, rect.Y, rect.Right - 15, rect.Y);
                path.AddBezier(
                    new Point(rect.Right - 15, rect.Y),
                    new Point(rect.Right - 15 + 3, rect.Y + 2),
                    new Point(rect.Right - 15 + 3, rect.Y + 2),
                    new Point(rect.Right - 15 + 4, rect.Y + 4));
                //path.AddLine(rect.Right - 15 + 4, rect.Y + 4, rect.Right - 4, rect.Bottom - 4);
                path.AddBezier(
                    new Point(rect.Right, rect.Bottom),
                    new Point(rect.Right - 3, rect.Bottom - 3),
                    new Point(rect.Right - 3, rect.Bottom - 3),
                    new Point(rect.Right + 1, rect.Bottom + 1));

                Region region = new System.Drawing.Region(path);

                //g.DrawPath(new Pen(Color.Black), path);

                if (mouseOver)
                {
                    using (LinearGradientBrush brush = new LinearGradientBrush(rect, MoveSelectedColor1, MoveSelectedColor2, LinearGradientMode.Vertical))
                    {
                        g.FillPath(brush, path);
                    }
                    //g.FillPath(new SolidBrush(MoveSelectedColor), path);
                }
                else
                {
                    using (LinearGradientBrush brush = selected ? new LinearGradientBrush(rect, onSelectedColor1, onSelectedColor2, LinearGradientMode.Vertical) : new LinearGradientBrush(rect, offSelectedColor1, offSelectedColor2, LinearGradientMode.Vertical))
                    {
                        g.FillPath(brush, path);
                    }
                    //g.FillPath(new SolidBrush(selected ? onSelectedColor : offSelectedColor), path);
                }
                //g.DrawLine(new Pen(selected ? onSelectedColor2 : BottomLineColor, 1), rect.X + 1, rect.Bottom + 1, rect.Right, rect.Bottom + 1);
            }
        }

        protected virtual void drawString(Graphics g, Rectangle rect, string title, Font font)
        {
            g.DrawString(title, font, brushFont, rect);
        }

        protected virtual void drawTabIcon(Graphics g, Rectangle rect)
        {
            g.DrawImageUnscaled(TabIcon, rect);
        }

        protected virtual void drawClose(Graphics g, Rectangle rect, bool mouseOn)
        {
            if (mouseOn)
                g.DrawImage(close_Image, rect);
            else
                g.DrawImage(close_normalImage, rect);
        }

        private bool CloseHitTest(Point cltPosition)
        {
            return rectClose.Contains(cltPosition);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Draw(e.Graphics);
            Graphics g = e.Graphics;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
            //Size tempSize = this.ItemSize;

            if (this.TabCount > 0)
            {
                if ((this.ItemSize.Width * this.TabCount) + 30 > this.ClientSize.Width || (this.ClientSize.Width - 30) / (this.TabCount) > this.ItemSize.Width)
                {
                    if (this.ClientSize.Width < (this.TabCount * this.ItemSize.Width) + 30 || this.ItemSize.Width < 150)
                    {
                        if (this.TabCount > 0)
                        {
                            this.ItemSize = new Size((this.ClientSize.Width - 30) / (this.TabCount), 25);
                        }
                    }

                    if (this.ItemSize.Width > 150)
                    {
                        this.ItemSize =  new Size(150, 25);
                    }
                }

                //addRec = new Rectangle((this.ItemSize.Width * this.TabCount) + 5, 8, 16, 16); //指定显示区域的位置的大小
                //e.Graphics.FillEllipse(new SolidBrush(colorMouseOn), addRec);

                //e.Graphics.DrawLine(new Pen(Color.White, 1.55f), (this.ItemSize.Width * this.TabCount) + 8, 16, (this.ItemSize.Width * this.TabCount) + 18, 16);
               // e.Graphics.DrawLine(new Pen(Color.White, 1.55f), (this.ItemSize.Width * this.TabCount) + 13, 11, (this.ItemSize.Width * this.TabCount) + 13, 21);

                for (int i = 0; i < this.TabCount; i++)
                {
                    if (tabIndex != 0)
                    {
                        if (tabIndex < this.TabCount)
                        {
                            if (tabIndex == i)
                            {
                                this.SelectedIndex = i;
                                DrawAll(g, this.GetTabRect(i), this.TabPages[i].Text, true, false);
                            }
                            else
                            {
                                if (OverIndex == i)
                                {
                                    DrawAll(g, this.GetTabRect(i), this.TabPages[i].Text, false, true);
                                }
                                else
                                {
                                    DrawAll(g, this.GetTabRect(i), this.TabPages[i].Text, false, false);
                                }
                            }
                        }
                        else
                        {
                            if ((tabIndex - 1) == i)
                            {
                                this.SelectedIndex = i;
                                DrawAll(g, this.GetTabRect(i), this.TabPages[i].Text, true, false);
                            }
                            else
                            {
                                if (OverIndex == i)
                                {
                                    DrawAll(g, this.GetTabRect(i), this.TabPages[i].Text, false, true);
                                }
                                else
                                {
                                    DrawAll(g, this.GetTabRect(i), this.TabPages[i].Text, false, false);
                                }
                            }
                        }
                    }
                    else
                    {
                        if (this.SelectedIndex == i)
                        {
                            DrawAll(g, this.GetTabRect(i), this.TabPages[i].Text, true, false);
                        }
                        else
                        {
                            if (OverIndex == i)
                            {
                                DrawAll(g, this.GetTabRect(i), this.TabPages[i].Text, false, true);
                            }
                            else
                            {
                                DrawAll(g, this.GetTabRect(i), this.TabPages[i].Text, false, false);
                            }
                        }
                    }
                }
                tabIndex = 0;
            }
            else
            {
                tabIndex = 0;
                addRec = new Rectangle(10, 8, 16, 16); //指定显示区域的位置的大小
                //e.Graphics.FillEllipse(new SolidBrush(colorMouseOn), addRec);

                e.Graphics.DrawLine(new Pen(Color.White, 1.55f), 10 + 3, 16, 10 + 13, 16);
                e.Graphics.DrawLine(new Pen(Color.White, 1.55f), 10 + 8, 11, 10 + 8, 21);
            }
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == (int)User32.Msgs.WM_NCHITTEST)
            {
                if (m.Result.ToInt32() == User32._HT_TRANSPARENT)
                    m.Result = (IntPtr)User32._HT_CLIENT;
            }

            if (m.Msg == (int)User32.Msgs.WM_LBUTTONDOWN)
            {
                if (this.TabCount > 1)
                {
                    TabPage selectingTabPage = OverTab();
                    if (selectingTabPage != null)
                    {
                        int index = TabPages.IndexOf(selectingTabPage);
                        if (index != this.SelectedIndex)
                        {
                            if (!selectingTabPage.Enabled)
                            {
                                m.Result = new IntPtr(1);
                            }
                            else
                            {
                                this.SelectedTab = selectingTabPage;
                            }
                        }
                    }
                }
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (e.Button == MouseButtons.Left)
            {
                this._SourceTabPage = OverTab();

                tabPoint = new Point(e.X, e.Y);

                //if (addRec.Contains(e.Location))
                //{
                //    colorMouseOn = Color.Orange;
                //}
            }

            this.Invalidate();
        }

        //protected override void OnMouseUp(MouseEventArgs e)
        //{
        //    base.OnMouseUp(e);
            
        //    if (e.Button == MouseButtons.Left)
        //    {
        //        bool AscendingMove = false;

        //        if (addRec.Contains(e.Location))
        //        {
        //            colorMouseOn = Color.FromArgb(229, 233, 227);
        //            AddTabPage("tabPage" + (this.TabCount + 1).ToString());
        //        }

        //        if (this.TabCount > 0)
        //        {
        //            if (!AllSelected)
        //            {
        //                Rectangle tabRect = new Rectangle(this.GetTabRect(this.SelectedIndex).X + this.GetTabRect(this.SelectedIndex).Width - 25, 11, 12, 12);

        //                if (tabRect.Contains(e.Location))
        //                {
        //                    AscendingMove = true;
        //                    tabIndex = this.SelectedIndex;
        //                    this.TabPages.Remove(this.SelectedTab);
        //                }
        //                else
        //                {
        //                    AscendingMove = false;
        //                }
        //            }
        //            else
        //            {
        //                Rectangle tabRect = new Rectangle(this.GetTabRect(tabid).X + this.GetTabRect(tabid).Width - 25, 11, 12, 12);

        //                if (tabRect.Contains(e.Location))
        //                {
        //                    AscendingMove = true;
        //                    this.TabPages.RemoveAt(tabid);
        //                    AllSelected = false;
        //                }
        //                else
        //                {
        //                    AscendingMove = false;
        //                }
        //            }

        //            if (this._SourceTabPage != null)
        //            {
        //                TabPage currTabPage = GetTabPageFromXY(e.X, e.Y);

        //                if ((currTabPage != null) && (!currTabPage.Equals(this._SourceTabPage)))
        //                {
        //                    Rectangle currRect = base.GetTabRect(base.TabPages.IndexOf(currTabPage));
        //                    if ((base.TabPages.IndexOf(currTabPage) < base.TabPages.IndexOf(this._SourceTabPage)))
        //                    {
        //                        base.TabPages.Remove(this._SourceTabPage);
        //                        base.TabPages.Insert(base.TabPages.IndexOf(currTabPage), this._SourceTabPage);
        //                        base.SelectedTab = this._SourceTabPage;
        //                    }
        //                    else if ((base.TabPages.IndexOf(currTabPage) > base.TabPages.IndexOf(this._SourceTabPage)))
        //                    {
        //                        if (!AscendingMove)
        //                        {
        //                            base.TabPages.Remove(this._SourceTabPage);
        //                            base.TabPages.Insert(base.TabPages.IndexOf(currTabPage) + 1, this._SourceTabPage);
        //                            base.SelectedTab = this._SourceTabPage;
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    this._SourceTabPage = null;
        //    base.Cursor = Cursors.Default;
        //    this.Invalidate();
        //}

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            OverIndex = -1;
            Invalidate();
        }

        //protected override void OnMouseMove(MouseEventArgs e)
        //{
        //    base.OnMouseMove(e);

        //    for (int i = 0; i < this.TabCount; i++)
        //    {
        //        if (this.SelectedIndex != i && this.GetTabRect(i).Contains(e.Location))
        //        {
        //            OverIndex = i;
        //            break;
        //        }
        //        else
        //        {
        //            OverIndex = -1;
        //        }
        //    }

        //    if (addRec.Contains(e.Location))
        //    {
        //        colorMouseOn = Color.OrangeRed;
        //    }
        //    else
        //    {
        //        colorMouseOn = Color.Silver;
        //    }

        //    if ((e.Button == MouseButtons.Left) && (this._SourceTabPage != null))
        //    {
        //        TabPage currTabPage = GetTabPageFromXY(e.X, e.Y);
        //        if ((currTabPage != null))
        //        {
        //            Rectangle currRect = base.GetTabRect(base.TabPages.IndexOf(currTabPage));
        //            if ((base.TabPages.IndexOf(currTabPage) < base.TabPages.IndexOf(this._SourceTabPage)))
        //            {
        //                base.Cursor = Cursors.PanWest;
        //            }
        //            else if ((base.TabPages.IndexOf(currTabPage) > base.TabPages.IndexOf(this._SourceTabPage)))
        //            {
        //                base.Cursor = Cursors.PanEast;
        //            }
        //            else
        //            {
        //                base.Cursor = Cursors.Default;
        //            }
        //        }
        //        else
        //        {
        //            this.Cursor = Cursors.No;
        //        }
        //    }
        //    else
        //    {
        //        this.Cursor = Cursors.Default;
        //    }

        //    this.Invalidate();
        //}

        private TabPage GetTabPageFromXY(int x, int y)
        {
            for (int i = 0; i <= base.TabPages.Count - 1; i++)
            {
                if (base.GetTabRect(i).Contains(x, y))
                {
                    return base.TabPages[i];
                }
            }
            return null;
        }

        protected override void OnSelecting(TabControlCancelEventArgs e)
        {
            base.OnSelecting(e);

            if (OverIndex > -1)
            {
                Rectangle tabRect = new Rectangle(this.GetTabRect(e.TabPageIndex).X + this.GetTabRect(e.TabPageIndex).Width - 25, 11, 12, 12);

                if (tabRect.Contains(tabPoint))
                {
                    e.Cancel = true;
                    AllSelected = true;
                    tabid = e.TabPageIndex;
                }
                else
                {
                    AllSelected = false;
                }
            }
            else
            {
                AllSelected = false;
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
        }

        public override Rectangle DisplayRectangle
        {
            get
            {
                Rectangle rect = base.DisplayRectangle;
                return new Rectangle(rect.Left - 3, rect.Top, rect.Width + 6, rect.Height + 3);
            }
        }

        public void AddTabPage(string tabName)
        {
            TabPages.Add(tabName);
            SelectTab(TabPages.Count - 1);
            this.SelectedTab.AutoScroll = true;
        }

        protected virtual TabPage OverTab()
        {
            TabPage over = null;

            Point pt = this.PointToClient(Cursor.Position);
            User32.TCHITTESTINFO mouseInfo = new User32.TCHITTESTINFO(pt, User32.TabControlHitTest.TCHT_ONITEM);
            int currentTabIndex = User32.SendMessage(this.Handle, User32._TCM_HITTEST, IntPtr.Zero, ref mouseInfo);

            if (currentTabIndex > -1)
            {
                Rectangle currentTabRct = this.GetTabRect(currentTabIndex);

                if (currentTabIndex == 0)
                    currentTabRct.X += _tabHOffset;

                if (currentTabRct.Contains(pt))
                    over = this.TabPages[currentTabIndex] as TabPage;
            }

            return over;
        }
    }
}
