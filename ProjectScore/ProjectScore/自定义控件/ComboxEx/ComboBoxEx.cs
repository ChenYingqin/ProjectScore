using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace JWBControl
{
    public partial class ComboBoxEx : ComboBox
    {
        private bool IsMouseHover = false;
        private bool IsPressed = false;
        private Rectangle btnRect;
        public Image NormalImage { get; set; }
        public Image MouseMoveImage { get; set; }
        public Image MouseDownImage { get; set; }
        public ComboBoxEx()
        {
            InitializeComponent();
            NormalImage = new Bitmap(ProjectScore.Properties.Resources.小三角);
            MouseMoveImage = new Bitmap(ProjectScore.Properties.Resources.小三角_浮动);
            MouseDownImage = new Bitmap(ProjectScore.Properties.Resources.小三角_点击);
        }
        private const int WM_MOUSEHOVER = 0x02a1;
        private const int WM_PAINT = 0xf;
        private const int WM_CTLCOLOREDIT = 0x133;
        private const int WM_LBUTTONUP = 0x0202;
        private const int WM_LBUTTONDOWN = 0x0201;
        private const int WM_MOUSEMOVE = 0x0200;
        private const int WM_MOUSELEAVE = 0x02A3;
        protected override void WndProc(ref   Message m)
        {
            base.WndProc(ref m);
            //WM_PAINT = 0xf; 要求一个窗口重画自己,即Paint事件时    
            //WM_CTLCOLOREDIT = 0x133;当一个编辑型控件将要被绘制时发送此消息给它的父窗口；    
            //通过响应这条消息，所有者窗口可以通过使用给定的相关显示设备的句柄来设置编辑框的文本和背景颜色    
            //windows消息值表,可参考:http://hi.baidu.com/dooy/blog/item/0e770a24f70e3b2cd407421b.html    
            if (m.Msg == WM_PAINT || m.Msg == WM_CTLCOLOREDIT)
            {

                IntPtr hDC = Win32.GetWindowDC(m.HWnd);
                if (hDC.ToInt32() == 0) //如果取设备上下文失败则返回    
                {
                    return;
                }

                //建立Graphics对像    
                Graphics g = Graphics.FromHdc(hDC);
                g.FillRectangle(new SolidBrush(Color.White), new Rectangle(Width - 19, 1, 18, Height - 2));
                //g.FillRectangle(new SolidBrush(this.BackColor), new Rectangle(Width - 19, 3, 19, Height-6));
                if (IsMouseHover == true)
                {
                    if (IsPressed == true)
                    {
                        //g.FillRectangle(new SolidBrush(Color.LightBlue), new Rectangle(Width - 19, 1, 19, Height - 2));
                        g.DrawImage(MouseDownImage, Width - 15, (Height - 8) / 2);
                    }
                    else
                    {
                        g.DrawImage(MouseMoveImage, Width - 15, (Height - 8) / 2);
                    }

                }
                else
                {
                    g.DrawImage(NormalImage, Width - 15, (Height - 8) / 2);
                }
                //画边框的     
                ControlPaint.DrawBorder(g, new Rectangle(0, 0, Width, Height), Color.FromArgb(193, 193, 193), ButtonBorderStyle.Solid);

                //g.DrawLine(new Pen(Brushes.Blue, 2), new PointF(this.Width - this.Height, 0), new PointF(this.Width - this.Height, this.Height));    
                //释放DC      
                Win32.ReleaseDC(m.HWnd, hDC);
            }
            if (m.Msg == WM_MOUSEMOVE)
            {
                if (btnRect.Contains(this.PointToClient(MousePosition)))
                {

                    IsMouseHover = true;
                }
                else IsMouseHover = false;
            }
            if (m.Msg == WM_MOUSELEAVE)
            {
                IsMouseHover = false;
            }
            if (m.Msg == WM_LBUTTONDOWN)
            {
                if (btnRect.Contains(this.PointToClient(MousePosition)))
                {
                    IsPressed = true;
                }
            }
            if (m.Msg == WM_LBUTTONUP)
            {
                IsPressed = false;
            }

        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            this.FlatStyle = FlatStyle.Flat;
        }
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            btnRect = new Rectangle(Width - 19, 0, 19, Height);
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            //绘制区域
            Rectangle r = e.Bounds;

            Font fn = null;

            if (e.Index >= 0)
            {
                //设置字体、字符串格式、对齐方式
                fn = this.Font;
                string s = this.Items[e.Index].ToString();
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Near;
                //根据不同的状态用不同的颜色表示
                if (e.State == (DrawItemState.NoAccelerator | DrawItemState.NoFocusRect))
                {
                    //Brush br = new LinearGradientBrush(new Point(0, 0), new Point(r.Width, r.Height), Color.FromArgb(67, 84, 100), Color.FromArgb(85, 111, 133));
                    e.Graphics.FillRectangle(new SolidBrush(Color.White), r);
                    e.Graphics.DrawString(s, fn, new SolidBrush(Shared.Shared.FontColor), r, sf);
                    e.DrawFocusRectangle();
                }
                else
                {
                    fn = this.Font;
                    sf = new StringFormat();
                    sf.Alignment = StringAlignment.Near;
                    s = this.Items[e.Index].ToString();
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(67, 84, 100)), r);
                    e.Graphics.DrawString(s, fn, new SolidBrush(Color.White), r, sf);                  
                }
            }
        }
    }
}
