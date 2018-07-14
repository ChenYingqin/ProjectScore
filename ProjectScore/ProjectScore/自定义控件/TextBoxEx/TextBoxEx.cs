using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace JWBControl
{
    #region AltoTextBox

    public class TextBoxEx : Control
    {
        int radius = 5;
        public TextBox box = new TextBox();
        bool isSelect = false;
        GraphicsPath shape;
        GraphicsPath innerRect;
        Color backgroundColor;
        Color offColor;
        Color onColor;
        public int Radius { get; set; }
        public TextBoxEx()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            //SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.ResizeRedraw, true);

            box.Parent = this;
            Controls.Add(box);

            box.BorderStyle = BorderStyle.None;
            box.TextAlign = HorizontalAlignment.Left;
            box.Multiline = false;
            box.Font = Font;

            //BackColor = Color.Transparent;
            //ForeColor = Color.DimGray;
            backgroundColor = Color.White;
            box.BackColor = backgroundColor;
            Text = null;
            box.ForeColor = Color.Black;
            box.WordWrap = true;
            //Font = new Font("Comic Sans MS", 11);
            DoubleBuffered = true;
            box.KeyDown += box_KeyDown;
            box.TextChanged += box_TextChanged;
            box.MouseDoubleClick += box_MouseDoubleClick;
            box.MouseEnter += AltoTextBox_Enter;
            box.MouseLeave += AltoTextBox_MouseLeave;
            box.BringToFront();
            box.Show();
            this.SizeChanged+=TextBoxEx_SizeChanged;
        }
        public bool Mutiline {
            get
            {
                return box.Multiline;
            }
            set
            {
                box.Multiline = value;
            }
        }
        private void TextBoxEx_SizeChanged(object sender, EventArgs e)
        {
            box.Size = new Size(this.Width-radius-2,this.Height-radius-2);
            box.Location = new Point(radius, radius);
        }

        void box_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button != System.Windows.Forms.MouseButtons.Left) return;

            box.SelectAll();
        }

        void box_TextChanged(object sender, EventArgs e)
        {
            Text = box.Text;
        }
        public void SelectAll()
        {
            box.SelectAll();
        }
        void box_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                box.SelectionStart = 0;
                box.SelectionLength = Text.Length;
            }
            else
            {
                base.OnKeyDown(e);
            }
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            box.Text = Text;
        }
        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            box.Font = Font;
            Invalidate();
        }
        protected override void OnForeColorChanged(EventArgs e)
        {
            base.OnForeColorChanged(e);
            box.ForeColor = ForeColor;
            Invalidate();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            shape = new RoundedRectangleF(Width, Height, radius).Path;
            innerRect = new RoundedRectangleF(Width - 0.5f, Height - 0.5f, radius, 0.5f, 0.5f).Path;
            //if (box.Height >= Height - 4)
            //    Height = box.Height + 4;
            //box.Location = new Point(radius - 3, Height / 2 - box.Font.Height / 2);
            //box.Width = Width - (int)(radius * 1.5);

            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            //Bitmap bmp = new Bitmap(Width, Height);
            //Graphics grp = Graphics.FromImage(bmp);
            //if (isSelect)
            //    e.Graphics.DrawPath(Pens.Blue, shape);
            //else
            e.Graphics.DrawPath(Pens.Gray, shape);
            if (Enabled)
            {
                using (SolidBrush brush = new SolidBrush(backgroundColor))
                    e.Graphics.FillPath(brush, shape);
                box.BackColor = this.Br;
                box.ForeColor = Color.Black;
            }
            else
            {
                using (SolidBrush brush = new SolidBrush(Color.FromArgb(238,238,238)))
                {
                    e.Graphics.FillPath(brush, shape);
                    this.box.BackColor = Color.FromArgb(238, 238, 238);
                    box.ForeColor = Color.FromArgb(118, 118, 118);
                    //e.Graphics.FillRectangle(brush,new Rectangle(radius,radius,Width-2*radius,Height-2*radius));
                }
                     
            }
            //Transparenter.MakeTransparent(this, e.Graphics);

            base.OnPaint(e);
        }
        public Color Br
        {
            get
            {
                return backgroundColor;
            }
            set
            {
                backgroundColor = value;
                Invalidate();
            }
        }
        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                base.BackColor = value;
            }
        }
        public Color OffColor
        {
            get
            {
                return offColor;
            }
            set
            {
                offColor = value;
                Invalidate();
            }
        }
        public Color OnColor
        {
            get
            {
                return onColor;
            }
            set
            {
                onColor = value;
                Invalidate();
            }
        }
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // TextBoxEx
            // 
            this.BackColor = System.Drawing.Color.LightGray;
            this.Name = "TextBoxEx";
            this.Enter += new System.EventHandler(this.AltoTextBox_Enter);
            this.Leave += new System.EventHandler(this.AltoTextBox_MouseLeave);
            this.ResumeLayout(false);

        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            Invalidate();
            base.OnEnabledChanged(e);
        }

        private void AltoTextBox_MouseLeave(object sender, EventArgs e)
        {
            base.OnMouseLeave(e);
            Graphics g = this.CreateGraphics();
            shape = new RoundedRectangleF(Width, Height, radius).Path;
            Pen pen = new Pen(offColor, 1);
            g.DrawPath(pen, shape);  
        }

        private void AltoTextBox_Enter(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            shape = new RoundedRectangleF(Width, Height, radius).Path;
            Pen pen = new Pen(onColor, 1);
            g.DrawPath(pen, shape); 
        }
    }

    #endregion
}
