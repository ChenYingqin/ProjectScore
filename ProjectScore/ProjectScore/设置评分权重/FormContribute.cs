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
    public partial class FormContribute : Form
    {
        XmlDocument doc;
        public FormContribute(XmlDocument document)
        {
            InitializeComponent();
            doc = document;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            int num = 0;
            try
            {
                int x = int.Parse(textBoxEx1.Text.Trim());
                int y = int.Parse(textBoxEx2.Text.Trim());
                num = x + y;
                if (x<0 || y<0 || x>100 || y>100 || num!=100)
                {
                    MessageBox.Show("设置失败，请检查输入数据！", "信息提示", MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                else
                {
                    XmlNode node = doc.SelectSingleNode("class/贡献度评分权重/计划设计阶段");
                    node.InnerXml = textBoxEx1.Text.Trim();
                    node = doc.SelectSingleNode("class/贡献度评分权重/编码测试阶段");
                    node.InnerXml = textBoxEx2.Text.Trim();
                    MessageBox.Show("设置成功！", "信息提示", MessageBoxButtons.OK,MessageBoxIcon.None);
                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show("设置失败，输入的数据不符合规范！", "信息提示", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("确定放弃修改吗？", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            this.Close();
        }

        private void FormContribute_Load(object sender, EventArgs e)
        {
            XmlNode node = doc.SelectSingleNode("class/贡献度评分权重/计划设计阶段");
            textBoxEx1.Text = node.InnerXml;
            node = doc.SelectSingleNode("class/贡献度评分权重/编码测试阶段");
            textBoxEx2.Text = node.InnerXml;
        }
    }
}
