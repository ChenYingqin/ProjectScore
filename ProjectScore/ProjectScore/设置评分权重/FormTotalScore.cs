using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ProjectScore
{
    public partial class FormTotalScore : Form
    {
        XmlDocument doc;
        public FormTotalScore(XmlDocument document)
        {
            InitializeComponent();
            doc = document;
        }
     
        private void FormTotalScore_Load(object sender, EventArgs e)
        {                  
            XmlNodeList nodes = doc.SelectSingleNode("class/总成绩评分权重").ChildNodes;
            textBoxEx1.Text = nodes[0].InnerXml;
            textBoxEx2.Text = nodes[1].InnerXml;
            textBoxEx3.Text = nodes[2].InnerXml;
            textBoxEx4.Text = nodes[3].InnerXml;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            int num=0;
            try 
            {
                int a = int.Parse(textBoxEx1.Text.Trim());
                int b=int.Parse(textBoxEx2.Text.Trim());
                int c = int.Parse(textBoxEx3.Text.Trim());
                int d = int.Parse(textBoxEx4.Text.Trim());
                num = a + b + c + d;
                if (a<0||b<0||c<0||d<0||num!=100)
                    MessageBox.Show("设置失败，请检查输入数据！", "信息提示", MessageBoxButtons.OK);
                else
                {
                    XmlNodeList nodes = doc.SelectSingleNode("class/总成绩评分权重").ChildNodes;
                    nodes[0].InnerXml = textBoxEx1.Text.Trim();
                    nodes[1].InnerXml = textBoxEx2.Text.Trim();
                    nodes[2].InnerXml = textBoxEx3.Text.Trim();
                    nodes[3].InnerXml = textBoxEx4.Text.Trim();
                    MessageBox.Show("设置成功！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show("设置失败，输入的数据不符合规范！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("确定放弃修改吗？", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            this.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
