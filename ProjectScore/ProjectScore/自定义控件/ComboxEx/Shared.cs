
using System.Collections.Generic;

using System.Text;
using System.Reflection;

using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;
using System.IO;
namespace Shared
{
    public abstract class Shared
    {

        private static Assembly _assemblyWinUI = null;

        private static Bitmap drawButton = null;
        private static Bitmap scrollbarButton = null;
        private static Color fontColor = Color.FromArgb(22, 61, 101);

        public static Color FontColor
        {
            get { return fontColor; }
            set { fontColor = value; }
        }


        public static Bitmap ScrollBarButton
        {
            get
            {
                if (scrollbarButton == null)
                {
                   // scrollbarButton = new Bitmap(JWBControl.ImgResources.classroom, new Size(114, 114));
                }
                return scrollbarButton;
            }
        }

        public static Image ScrollBarUpButton
        {
            get { return ScrollBarButton.Clone(new Rectangle(0, 0, 16, 16), System.Drawing.Imaging.PixelFormat.Format32bppPArgb); }
        }

        public static Bitmap DrawButton
        {
            get
            {
                if (drawButton == null)
                {   
                    //FileStream stream=new FileStream(,FileMode.Open);
                    //drawButton = new Bitmap(JWBControl.ImgResources.arrow, new Size(64, 16));
                }
                return drawButton;
            }
        }

        public static Image NomalDrawButton
        {
            get { return DrawButton.Clone(new Rectangle(0, 0, 16, 16), System.Drawing.Imaging.PixelFormat.Format32bppPArgb); }
        }

        public static Image MouseDownDrawButton
        {
            get { return DrawButton.Clone(new Rectangle(16, 0, 16, 16), System.Drawing.Imaging.PixelFormat.Format32bppPArgb); }
        }

        public static Image MouseMoveDrawButton
        {
            get { return DrawButton.Clone(new Rectangle(32, 0, 16, 16), System.Drawing.Imaging.PixelFormat.Format32bppPArgb); }
        }

        public static Image NotEnableDrawButton
        {
            get { return DrawButton.Clone(new Rectangle(48, 0, 16, 16), System.Drawing.Imaging.PixelFormat.Format32bppPArgb); }
        }
    }
}

     

 

       