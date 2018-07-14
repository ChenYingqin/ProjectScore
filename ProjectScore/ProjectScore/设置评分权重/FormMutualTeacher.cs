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
    public partial class FormMutualTeacher : Form
    {
        XmlDocument doc;
        public FormMutualTeacher(XmlDocument document)
        {
            InitializeComponent();
            doc = document;
        }

        private void FormMutualTeacher_Load(object sender, EventArgs e)
        {
            XmlNode node = doc.SelectSingleNode("class/自评互评教师评综合权重/期中考核/权重");
            textBoxEx1.Text =  node.InnerXml;
            node = doc.SelectSingleNode("class/自评互评教师评综合权重/项目验收/权重");
            textBoxEx2.Text =  node.InnerXml;
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
                    XmlNode node = doc.SelectSingleNode("class/自评互评教师评综合权重/期中考核/权重");
                    node.InnerXml = textBoxEx1.Text.Trim();
                    node = doc.SelectSingleNode("class/自评互评教师评综合权重/项目验收/权重");
                    node.InnerXml = textBoxEx2.Text.Trim();
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
    }
}
