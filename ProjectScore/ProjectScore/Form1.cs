using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using Office;
using Spire.Doc;
using Spire.Doc.Documents;
using Spire.Doc.Fields;

namespace ProjectScore
{
    public partial class Form1 : Form
    {

        string scoreTemplatePath = "";
        XmlDocument doc = new XmlDocument();
        int currentEditRow = 0, currentEditCol = 0;
        string beforeEditGroupId;
        XmlNode group = null;
        SetScale setScale = new SetScale();
        string saveToWord = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tabControlEx1.Visible = false;       
            
        }
        public string XmlValidationByXsd(string xmlFile, string xsdFile, string namespaceUrl = null)
        {
            StringBuilder sb = new StringBuilder();
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.ValidationType = ValidationType.Schema;
            settings.Schemas.Add(namespaceUrl, xsdFile);
            settings.ValidationEventHandler += (x, y) =>
            {
                sb.AppendFormat("{0}|", y.Message);
            };
            using (XmlReader reader = XmlReader.Create(xmlFile, settings))
            {
                try
                {
                    while (reader.Read()) ;
                }
                catch (XmlException ex)
                {
                    sb.AppendFormat("{0}|", ex.Message);
                }
            }
            return sb.ToString();
        }
        private void loadGroupTab()
        {
            groupDataView1.RowHeadersVisible = false;
            groupDataView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            groupDataView1.AllowUserToAddRows = false;
            groupDataView1.AllowUserToResizeRows = false;
            groupDataView1.AllowUserToResizeColumns = false;
            groupDataView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            groupDataView1.EditMode = DataGridViewEditMode.EditProgrammatically;

            groupDataView1.Rows.Clear();
            doc.Load(scoreTemplatePath);
            XmlNodeList groups = doc.SelectNodes("class/小组集合/小组实例/小组");
            foreach (XmlNode group in groups)
            {
                XmlNodeList modules = group.SelectNodes("小组成员/成员信息");
                int index, j;
                foreach (XmlNode module in modules)
                {
                    XmlNodeList elements = group.SelectSingleNode("小组信息").ChildNodes;
                    j = 0;
                    index = groupDataView1.Rows.Add();
                    foreach (XmlNode element in elements)
                    {
                        groupDataView1.Rows[index].Cells[j].Value = element.InnerXml;
                        ++j;
                    }
                    if (module.ChildNodes[5].InnerXml != "0")
                    {
                        groupDataView1.Rows[index].Cells[0].ReadOnly = true;
                        groupDataView1.Rows[index].Cells[1].ReadOnly = true;
                    }
                    //小组序号、项目名称设置为只读
                    elements = module.ChildNodes;
                    foreach (XmlNode element in elements)
                    {
                        groupDataView1.Rows[index].Cells[j].Value = element.InnerXml;
                        ++j;
                    }
                }
            }
            this.groupDataView1.MergeColumnNames.Add("Column1");
            this.groupDataView1.MergeColumnNames.Add("Column2");
        }

        private void tabControlEx1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlEx1.SelectedIndex == 0)
            {
                loadGroupTab();
            }
            else if (tabControlEx1.SelectedIndex == 1)
            {
                loadDocumentTab();
            }
            else if (tabControlEx1.SelectedIndex == 2)
            {
                loadTeacherTab();
                loadTeacherTab2();
            }
            else if (tabControlEx1.SelectedIndex == 3)
            {
                loadMutualTab();
                loadMutualTab2();
            }
            else if (tabControlEx1.SelectedIndex == 4)
            {
                loadContributeTab();
                loadContributeTab2();
            }
            else if (tabControlEx1.SelectedIndex == 5)
            {
                loadTreeView();
            }
            else if (tabControlEx1.SelectedIndex == 6)
            {
                loadTeamScore();
            }
        }

        private void btnCreateScoreTemplate_Click(object sender, EventArgs e)
        {
            File.Copy(@".\Demo.xml", @".\temp.xml", true);
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "*.xml|*.xml";
            sfd.RestoreDirectory = true;
            String localFilePath = "";
            if (sfd.ShowDialog() == DialogResult.OK && sfd.FileName.Length > 0)
            {
                localFilePath = sfd.FileName.ToString();
                File.Copy(@".\temp.xml", localFilePath, true);
                File.Delete(@".\temp.xml");
                scoreTemplatePath = localFilePath;
                MessageBox.Show("成功创建评分模板！");
                //将评分模板中的小组模板复制一组数据到新创建的评分模板中
                /*doc.Load(scoreTemplatePath);
                XmlNode groupTemplate = doc.SelectSingleNode("/root/template/group");
                XmlNode root = doc.SelectSingleNode("/root");
                XmlNode group = groupTemplate.CloneNode(true);
                root.AppendChild(group);
                doc.Save(scoreTemplatePath);*/
            }
        }

        private void btnLoadtScoreTemplate_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "*.xml|*.xml";
            if (ofd.ShowDialog() == DialogResult.OK && ofd.FileName.Length > 0)
            {
                scoreTemplatePath = ofd.FileName.ToString();
                string str = XmlValidationByXsd(scoreTemplatePath, "xsdXml.xml", null);
                if(str!="")
                {
                    MessageBox.Show("加载失败，评分模板错误！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                } 
                MessageBox.Show("成功加载评分模板！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.None);
                loadGroupTab();
                tabControlEx1.Visible = true;
                refreshComboxEx();
                if (comboBoxEx.Items.Count != 0)
                {
                    comboBoxEx.SelectedIndex = 0;
                    labGroupId.Text = comboBoxEx.Text;
                    getGroupInfo();
                }
                labCurrentTemplate.Text = Path.GetFileName(ofd.FileName);
            }
        }

        /* private void btnConserve_Click(object sender, EventArgs e)
         {
             if (tabControlEx1.SelectedIndex == 0)
             {
                 //dataGridViewToWord(ref groupDataView1);
             }
             else if (tabControlEx1.SelectedIndex == 1)
             {
                 dataGridViewToWord(ref dgvTeacherScore);
             }
             else if (tabControlEx1.SelectedIndex == 2)
             {
                // dataGridViewToWord();
             }
             else if (tabControlEx1.SelectedIndex == 3)
             {
                 dataGridViewToWord(ref dgvSetUpScale);
             }
             else if (tabControlEx1.SelectedIndex == 4)
             {
                 dataGridViewToWord(ref dgvTeamScore);
             }
             else if (tabControlEx1.SelectedIndex == 5)
             {
                 dataGridViewToWord(ref dgvDocument);
             }
             else if (tabControlEx1.SelectedIndex == 6)
             {
                 dataGridViewToWord(ref dgvContribute);
             }

         }*/

        private void groupDataView1_DoubleClick(object sender, EventArgs e)
        {
            groupDataView1.BeginEdit(true);
            //Console.WriteLine("this is doubleclick");
        }
        private void groupDataView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Console.WriteLine("this is cellendedit");
            if (groupDataView1.CurrentRow.Cells[0].Value == null)
                return;
            XmlNodeList groups = doc.SelectNodes("class/小组集合/小组实例/小组");
            string groupId = groupDataView1.Rows[currentEditRow].Cells[0].Value.ToString();
            if (currentEditCol == 0)
            {
                //校验输入的小组序号是否小于65535
                try
                {
                    int a = Int32.Parse(groupId);
                }
                catch
                {
                    MessageBox.Show("请输入小于65535的数字！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (beforeEditGroupId != groupId)
                {
                    //判断修改之后的组号是否已经存在，如果存在，则不能修改
                    bool judge = false;
                    foreach (XmlNode group in groups)
                    {
                        if (group.ChildNodes[0].ChildNodes[0].InnerXml == groupId)
                        {
                            judge = true;
                            break;
                        }
                    }
                    if (judge)//不能修改
                    {
                        MessageBox.Show("修改失败，小组序号已经存在！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        groupDataView1.Rows[currentEditRow].Cells[0].Value = beforeEditGroupId;
                        groupDataView1.RefreshEdit();
                    }
                    else
                    {
                        foreach (XmlNode group in groups)
                        {
                            if (group.ChildNodes[0].ChildNodes[0].InnerXml == beforeEditGroupId)
                            {
                                group.ChildNodes[0].ChildNodes[0].InnerXml = groupId;

                                //修改当前小组自评项
                                XmlNodeList modules = group.SelectNodes("自评互评表/小组");
                                modules[0].ChildNodes[0].ChildNodes[0].InnerXml = groupId;
                                //修改其他小组相关互评项
                                foreach (XmlNode grp in groups)
                                {
                                    if (grp.ChildNodes[0].ChildNodes[0].InnerXml != beforeEditGroupId)
                                    {
                                        modules = grp.SelectNodes("自评互评表/小组");
                                        foreach (XmlNode node in modules)
                                        {
                                            if (node.ChildNodes[0].ChildNodes[0].InnerXml == beforeEditGroupId)
                                            {
                                                node.ChildNodes[0].ChildNodes[0].InnerXml = groupId;
                                            }
                                        }
                                    }
                                }
                                doc.Save(scoreTemplatePath);
                                refreshComboxEx();
                                break;
                            }
                        }
                    }
                }


                return;
            }
            foreach (XmlNode group in groups)
            {
                if (group.ChildNodes[0].ChildNodes[0].InnerXml == groupId)
                {
                    if (currentEditCol < 2)
                    {
                        group.ChildNodes[0].ChildNodes[currentEditCol].InnerXml = groupDataView1.Rows[currentEditRow].Cells[currentEditCol].Value.ToString();
                    }
                    else
                    {
                        int index = int.Parse(groupDataView1.Rows[currentEditRow].Cells[7].Value.ToString());
                        if (groupDataView1.Rows[currentEditRow].Cells[currentEditCol].Value == null)
                        {
                            group.ChildNodes[1].ChildNodes[index].ChildNodes[currentEditCol - 2].InnerXml = " ";
                        }
                        else
                        {
                            group.ChildNodes[1].ChildNodes[index].ChildNodes[currentEditCol - 2].InnerXml = groupDataView1.Rows[currentEditRow].Cells[currentEditCol].Value.ToString();
                        }
                    }
                    break;
                }
            }
            doc.Save(scoreTemplatePath);
            refreshComboxEx();
        }

        private void groupDataView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupDataView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (groupDataView1.CurrentRow == null || groupDataView1.CurrentRow.Index == -1)
                return;
            if (e.Button == MouseButtons.Right)
            {
                if (groupDataView1.CurrentRow.Cells[7].Value.ToString() == "0")
                {
                    if (groupDataView1.CurrentRow.Index == 0)
                        cmsGroup1.Items[1].Visible = false;
                    else
                        cmsGroup1.Items[1].Visible = true;
                    cmsGroup1.Show(Cursor.Position);
                }
                else
                {
                    cmsGroup2.Show(Cursor.Position);
                }
            }

        }

        private void cmsGroup1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.MergeIndex == 0)
            {
                XmlNode groupTemplate = doc.SelectSingleNode("class/小组集合/小组模板/小组");
                XmlNodeList groups = doc.SelectSingleNode("class/小组集合/小组实例").ChildNodes;
                int index;
                try
                {
                    index = int.Parse(groups[groups.Count - 1].ChildNodes[0].ChildNodes[0].InnerXml);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("小组序号是小于65535的数字！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine(ex.ToString());
                    return;
                }
                XmlNode group = groupTemplate.CloneNode(true);
                group.ChildNodes[0].ChildNodes[0].InnerXml = (index + 1).ToString();
                XmlNode root = doc.SelectSingleNode("class/小组集合/小组实例");
                root.AppendChild(group);
                //添加期中考核自评互评小组
                XmlNode mutualScore = group.SelectSingleNode("自评互评教师评综合成绩/期中考核/自评互评表");
                mutualScore.ChildNodes[0].ParentNode.RemoveChild(mutualScore.ChildNodes[0]);
                XmlNode element;
                foreach (XmlNode node in groups)
                {
                    //从小组模板的自评互评表中复制一个节点出来
                    element = doc.SelectSingleNode("class/小组集合/小组模板/小组/自评互评教师评综合成绩/期中考核/自评互评表/小组").CloneNode(true);
                    element.ChildNodes[0].InnerXml = node.ChildNodes[0].ChildNodes[0].InnerXml;
                    mutualScore.AppendChild(element);
                }

                //为其他小组添加当前小组的互评项        
                for (int i = 0; i < groups.Count - 1; ++i)
                {
                    mutualScore = groups[i].SelectSingleNode("自评互评教师评综合成绩/期中考核/自评互评表");
                    element = doc.SelectSingleNode("class/小组集合/小组模板/小组/自评互评教师评综合成绩/期中考核/自评互评表/小组").CloneNode(true);
                    element.ChildNodes[0].InnerXml = (index + 1).ToString();
                    mutualScore.AppendChild(element);
                }

                //添加项目验收自评互评小组
                mutualScore = group.SelectSingleNode("自评互评教师评综合成绩/项目验收/自评互评表");
                mutualScore.ChildNodes[0].ParentNode.RemoveChild(mutualScore.ChildNodes[0]);
                foreach (XmlNode node in groups)
                {
                    //从小组模板的自评互评表中复制一个节点出来
                    element = doc.SelectSingleNode("class/小组集合/小组模板/小组/自评互评教师评综合成绩/项目验收/自评互评表/小组").CloneNode(true);
                    element.ChildNodes[0].InnerXml = node.ChildNodes[0].ChildNodes[0].InnerXml;
                    mutualScore.AppendChild(element);
                }
                root = doc.SelectSingleNode("class/小组集合/小组实例");
                //为其他小组添加当前小组的互评项        
                for (int i = 0; i < groups.Count - 1; ++i)
                {
                    mutualScore = groups[i].SelectSingleNode("自评互评教师评综合成绩/项目验收/自评互评表");
                    element = doc.SelectSingleNode("class/小组集合/小组模板/小组/自评互评教师评综合成绩/项目验收/自评互评表/小组").CloneNode(true);
                    element.ChildNodes[0].InnerXml = (index + 1).ToString();
                    mutualScore.AppendChild(element);
                }
            }
            else if (e.ClickedItem.MergeIndex == 1)
            {
                XmlNodeList groups = doc.SelectNodes("class/小组集合/小组实例/小组");
                string groupId = groupDataView1.CurrentRow.Cells[0].Value.ToString();
                foreach (XmlNode group in groups)
                {
                    if (group.ChildNodes[0].ChildNodes[0].InnerXml == groupId)
                    {
                        group.ParentNode.RemoveChild(group);
                        doc.Save(scoreTemplatePath);
                        break;
                    }
                }
                //删除其他小组下的相关评分项
                groups = doc.SelectNodes("class/小组集合/小组实例/小组");
                foreach (XmlNode group in groups)
                {
                    //删除期中考核自评互评表
                    XmlNodeList modules = group.SelectNodes("自评互评教师评综合成绩/期中考核/自评互评表/小组");
                    foreach (XmlNode module in modules)
                    {
                        if (module.ChildNodes[0].InnerXml == groupId)
                        {
                            module.ParentNode.RemoveChild(module);
                            break;
                        }
                    }
                    //删除项目验收自评互评表
                    modules = group.SelectNodes("自评互评教师评综合成绩/项目验收/自评互评表/小组");
                    foreach (XmlNode module in modules)
                    {
                        if (module.ChildNodes[0].InnerXml == groupId)
                        {
                            module.ParentNode.RemoveChild(module);
                            break;
                        }
                    }
                }
            }
            else if (e.ClickedItem.MergeIndex == 2)
            {
                XmlNodeList groups = doc.SelectNodes("class/小组集合/小组实例/小组");
                string groupId = groupDataView1.CurrentRow.Cells[0].Value.ToString();
                foreach (XmlNode group in groups)
                {
                    if (group.ChildNodes[0].ChildNodes[0].InnerXml == groupId)
                    {
                        XmlNode element = doc.SelectSingleNode("class/小组集合/小组模板/小组/小组成员/成员信息").CloneNode(true);

                        int index = group.SelectNodes("小组成员/成员信息").Count;
                        element.ChildNodes[5].InnerXml = index.ToString();
                        group.ChildNodes[1].AppendChild(element);
                        //添加小组成绩表成员
                        element = doc.SelectSingleNode("class/小组集合/小组模板/小组/小组成绩表/成员成绩").CloneNode(true);
                        XmlNode teamScore = group.SelectSingleNode("小组成绩表");
                        teamScore.AppendChild(element);
                        //添加计划设计阶段小组贡献表成员
                        element = doc.SelectSingleNode("class/小组集合/小组模板/小组/小组贡献表/计划设计阶段/成员贡献").CloneNode(true);
                        XmlNode contributeScore = group.SelectSingleNode("小组贡献表/计划设计阶段");
                        contributeScore.AppendChild(element);
                        //添加编码测试阶段小组贡献表成员
                        element = doc.SelectSingleNode("class/小组集合/小组模板/小组/小组贡献表/编码测试阶段/成员贡献").CloneNode(true);
                        contributeScore = group.SelectSingleNode("小组贡献表/编码测试阶段");
                        contributeScore.AppendChild(element);
                        break;
                    }
                }
            }
            doc.Save(scoreTemplatePath);
            loadGroupTab();
            refreshComboxEx();
        }

        private void cmsGroup2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.MergeIndex == 0)
            {
                XmlNodeList groups = doc.SelectNodes("class/小组集合/小组实例/小组");
                string groupId = groupDataView1.CurrentRow.Cells[0].Value.ToString();
                for (int i = 0; i < groups.Count; ++i)
                {
                    if (groups[i].ChildNodes[0].ChildNodes[0].InnerXml == groupId)
                    {
                        int index = int.Parse(groupDataView1.CurrentRow.Cells[7].Value.ToString());
                        XmlNode element = groups[i].ChildNodes[1].ChildNodes[index];
                        element.ParentNode.RemoveChild(element);

                        groups = doc.SelectNodes("class/小组集合/小组实例/小组");
                        XmlNodeList modules = groups[i].ChildNodes[1].ChildNodes;
                        for (int j = index; j < modules.Count; ++j)
                        {
                            int k = int.Parse(modules[j].ChildNodes[5].InnerXml);
                            modules[j].ChildNodes[5].InnerXml = (k - 1).ToString();
                        }
                        //删除小组成绩表成员
                        XmlNode teamScore = groups[i].SelectSingleNode("小组成绩表");
                        element = teamScore.ChildNodes[index];
                        element.ParentNode.RemoveChild(element);
                        //删除计划设计阶段小组贡献表成员
                        XmlNode contributeScore = groups[i].SelectSingleNode("小组贡献表/计划设计阶段");
                        element = contributeScore.ChildNodes[index];
                        element.ParentNode.RemoveChild(element);
                        //删除编码测试阶段小组贡献表成员
                        contributeScore = groups[i].SelectSingleNode("小组贡献表/编码测试阶段");
                        element = contributeScore.ChildNodes[index];
                        element.ParentNode.RemoveChild(element);
                        break;
                    }
                }
            }
            doc.Save(scoreTemplatePath);
            loadGroupTab();
        }
        private void refreshComboxEx()
        {
            comboBoxEx.Items.Clear();
            XmlNodeList groups = doc.SelectNodes("class/小组集合/小组实例/小组");
            for (int i = 0; i < groups.Count; ++i)
            {
                string index = groups[i].ChildNodes[0].ChildNodes[0].InnerXml;
                comboBoxEx.Items.Add(index);
            }
        }
        private void comboBoxEx_SelectedIndexChanged(object sender, EventArgs e)
        {
            labGroupId.Text = comboBoxEx.Text;
            getGroupInfo();

        }
        /// <summary>
        /// 获取当前组号
        /// </summary>
        private void getGroupInfo()
        {
            XmlNodeList groups = doc.SelectNodes("class/小组集合/小组实例/小组");
            foreach (XmlNode grp in groups)
            {
                if (grp.ChildNodes[0].ChildNodes[0].InnerXml == labGroupId.Text)
                {
                    group = grp;
                    break;
                }
            }
        }

        private void groupDataView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            //Console.WriteLine("this is cellbeginedit");
            currentEditRow = groupDataView1.CurrentRow.Index;
            currentEditCol = groupDataView1.CurrentCell.ColumnIndex;
            if (groupDataView1.CurrentCell.ColumnIndex == 0)
                beforeEditGroupId = groupDataView1.CurrentRow.Cells[0].Value.ToString();
        }

        /// <summary>
        /// 加载小组成绩表
        /// </summary>
        private void loadTeamScore()
        {
            dgvTeamScore.RowHeadersVisible = false;
            dgvTeamScore.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTeamScore.AllowUserToAddRows = false;
            dgvTeamScore.AllowUserToResizeRows = false;
            dgvTeamScore.AllowUserToResizeColumns = false;
            this.dgvTeamScore.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTeamScore.AllowUserToAddRows = false;
            dgvTeamScore.EditMode = DataGridViewEditMode.EditProgrammatically;

            dgvTeamScore.Rows.Clear();
            doc.Load(scoreTemplatePath);
            XmlNodeList rows = null;
            XmlNodeList groups = doc.SelectNodes("class/小组集合/小组实例/小组");

            int index;
            foreach (XmlNode group in groups)
            {
                if (group.ChildNodes[0].ChildNodes[0].InnerXml == labGroupId.Text)
                {
                    XmlNodeList modules = group.ChildNodes[1].ChildNodes;
                    for (int i = 0; i < modules.Count; ++i)
                    {
                        index = this.dgvTeamScore.Rows.Add();
                        for (int j = 0; j < 3; ++j)
                        {
                            dgvTeamScore.Rows[index].Cells[j].Value = modules[i].ChildNodes[j].InnerXml;
                        }
                    }
                    rows = group.SelectNodes("小组成绩表/成员成绩");
                    //添加成绩项数据
                    for (int i = 0; i < rows.Count; ++i)
                    {
                        for (int j = 0; j < 5; ++j)
                        {
                            dgvTeamScore.Rows[i].Cells[j + 3].Value = rows[i].ChildNodes[j].InnerXml;
                        }
                    }
                    textBoxAdvise.Text = group.SelectSingleNode("总评与建议").InnerXml;
                    break;
                }
            }
            XmlNodeList nodes = doc.SelectSingleNode("class/总成绩评分权重").ChildNodes;
            labScoreTip.Text = "注：成绩 1(" + nodes[0].InnerXml + "%)=小组分；成绩 2(" + nodes[1].InnerXml + "%)=个人小结分；成绩 3(" + nodes[2].InnerXml + "%)=个人管理分；成绩 4(" + nodes[3].InnerXml + "%)=个人贡献分";
        }
        private void dgvTeamScore_DoubleClick(object sender, EventArgs e)
        {
            if (dgvTeamScore.CurrentCell.ColumnIndex < 3)
                return;
            dgvTeamScore.BeginEdit(true);
            currentEditRow = dgvTeamScore.CurrentCell.RowIndex;
            currentEditCol = dgvTeamScore.CurrentCell.ColumnIndex;
        }

        private void dgvTeamScore_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            XmlNodeList groups = doc.SelectNodes("class/小组集合/小组实例/小组");
            foreach (XmlNode group in groups)
            {
                if (group.ChildNodes[0].ChildNodes[0].InnerXml == labGroupId.Text)
                {
                    XmlNode teamScore = group.SelectSingleNode("小组成绩表");
                    if (dgvTeamScore.Rows[currentEditRow].Cells[currentEditCol].Value == null)
                    {
                        teamScore.ChildNodes[currentEditRow].ChildNodes[currentEditCol - 3].InnerXml = " ";
                    }
                    else
                    {
                        teamScore.ChildNodes[currentEditRow].ChildNodes[currentEditCol - 3].InnerXml = dgvTeamScore.Rows[currentEditRow].Cells[currentEditCol].Value.ToString();
                    }
                    break;
                }
            }
            doc.Save(scoreTemplatePath);
        }

        /// <summary>
        /// 加载计划设计阶段小组贡献表
        /// </summary>
        private void loadContributeTab()
        {
            dgvContribute.RowHeadersVisible = false;
            dgvContribute.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvContribute.AllowUserToAddRows = false;
            dgvContribute.AllowUserToResizeRows = false;
            dgvContribute.AllowUserToResizeColumns = false;
            this.dgvContribute.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvContribute.AllowUserToAddRows = false;
            dgvContribute.EditMode = DataGridViewEditMode.EditProgrammatically;


            dgvContribute.Rows.Clear();
            doc.Load(scoreTemplatePath);
            XmlNodeList rows = null;
            XmlNodeList groups = doc.SelectNodes("class/小组集合/小组实例/小组");

            int index;
            foreach (XmlNode group in groups)
            {
                if (group.ChildNodes[0].ChildNodes[0].InnerXml == labGroupId.Text)
                {
                    XmlNodeList modules = group.ChildNodes[1].ChildNodes;
                    for (int i = 0; i < modules.Count; ++i)
                    {
                        index = this.dgvContribute.Rows.Add();
                        for (int j = 0; j < 3; ++j)
                        {
                            dgvContribute.Rows[index].Cells[j].Value = modules[i].ChildNodes[j].InnerXml;
                        }
                    }
                    rows = group.SelectNodes("小组贡献表/计划设计阶段/成员贡献");
                    //添加成绩项数据
                    for (int i = 0; i < rows.Count; ++i)
                    {
                        for (int j = 0; j < 2; ++j)
                        {
                            dgvContribute.Rows[i].Cells[j + 3].Value = rows[i].ChildNodes[j].InnerXml;
                        }
                    }
                    break;
                }
            }

        }
        /// <summary>
        /// 加载编码测试阶段小组贡献表
        /// </summary>
        private void loadContributeTab2()
        {
            dgvContribute2.RowHeadersVisible = false;
            dgvContribute2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvContribute2.AllowUserToAddRows = false;
            dgvContribute2.AllowUserToResizeRows = false;
            dgvContribute2.AllowUserToResizeColumns = false;
            this.dgvContribute2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvContribute2.AllowUserToAddRows = false;
            dgvContribute2.EditMode = DataGridViewEditMode.EditProgrammatically;


            dgvContribute2.Rows.Clear();
            doc.Load(scoreTemplatePath);
            XmlNodeList rows = null;
            XmlNodeList groups = doc.SelectNodes("class/小组集合/小组实例/小组");

            int index;
            foreach (XmlNode group in groups)
            {
                if (group.ChildNodes[0].ChildNodes[0].InnerXml == labGroupId.Text)
                {
                    XmlNodeList modules = group.ChildNodes[1].ChildNodes;
                    for (int i = 0; i < modules.Count; ++i)
                    {
                        index = this.dgvContribute2.Rows.Add();
                        for (int j = 0; j < 3; ++j)
                        {
                            dgvContribute2.Rows[index].Cells[j].Value = modules[i].ChildNodes[j].InnerXml;
                        }
                    }
                    rows = group.SelectNodes("小组贡献表/编码测试阶段/成员贡献");
                    //添加成绩项数据
                    for (int i = 0; i < rows.Count; ++i)
                    {
                        for (int j = 0; j < 2; ++j)
                        {
                            dgvContribute2.Rows[i].Cells[j + 3].Value = rows[i].ChildNodes[j].InnerXml;
                        }
                    }
                    break;
                }
            }

        }

        private void dgvContribute_DoubleClick(object sender, EventArgs e)
        {
            if (dgvContribute.CurrentCell.ColumnIndex < 3)
                return;
            dgvContribute.BeginEdit(true);
            currentEditRow = dgvContribute.CurrentCell.RowIndex;
            currentEditCol = dgvContribute.CurrentCell.ColumnIndex;
        }

        private void dgvContribute_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            XmlNodeList groups = doc.SelectNodes("class/小组集合/小组实例/小组");
            foreach (XmlNode group in groups)
            {
                if (group.ChildNodes[0].ChildNodes[0].InnerXml == labGroupId.Text)
                {
                    XmlNode contributeScore = group.SelectSingleNode("小组贡献表/计划设计阶段");
                    if (dgvContribute.Rows[currentEditRow].Cells[currentEditCol].Value == null)
                    {
                        contributeScore.ChildNodes[currentEditRow].ChildNodes[currentEditCol - 3].InnerXml = " ";
                    }
                    else
                    {
                        contributeScore.ChildNodes[currentEditRow].ChildNodes[currentEditCol - 3].InnerXml = dgvContribute.Rows[currentEditRow].Cells[currentEditCol].Value.ToString();
                    }
                    break;
                }
            }
            doc.Save(scoreTemplatePath);
        }

        /// <summary>
        /// 加载文档评分表
        /// </summary>
        private void loadDocumentTab()
        {
            dgvDocument.RowHeadersVisible = false;
            dgvDocument.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDocument.AllowUserToAddRows = false;
            dgvDocument.AllowUserToResizeRows = false;
            dgvDocument.AllowUserToResizeColumns = false;
            this.dgvDocument.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDocument.AllowUserToAddRows = false;
            dgvDocument.EditMode = DataGridViewEditMode.EditProgrammatically;

            dgvDocument.Rows.Clear();
            doc.Load(scoreTemplatePath);
            XmlNode group = null;
            XmlNodeList groups = doc.SelectNodes("class/小组集合/小组实例/小组");
            foreach (XmlNode grp in groups)
            {
                if (grp.ChildNodes[0].ChildNodes[0].InnerXml == labGroupId.Text)
                {
                    group = grp;
                    break;
                }
            }
            if (group == null)
                return;
            //获取小组评分表中评分模块及评分项的内容
            XmlNodeList titles = doc.SelectSingleNode("class/文档评分表前三列/总评分项1").ChildNodes;
            //小组评分表首行数据
            int k = this.dgvDocument.Rows.Add();
            int j = 0;
            foreach (XmlNode element in titles)
            {
                this.dgvDocument.Rows[k].Cells[j].Value = element.InnerXml;
                ++j;
            }
            //获取真实的文档评分表评分权重
            this.dgvDocument.Rows[k].Cells[2].Value = doc.SelectSingleNode("class/总成绩评分权重/小组文档分").InnerXml + "%";


            XmlNodeList moduleList = doc.SelectNodes("class/文档评分表前三列/评分模块集合1/评分模块1");
            foreach (XmlNode module in moduleList)
            {
                int i = 0;
                j = 0;
                //小组评分表评分模块
                XmlNodeList elementList = module.SelectSingleNode("评分模块内容1").ChildNodes;
                i = this.dgvDocument.Rows.Add();
                foreach (XmlNode element in elementList)
                {
                    this.dgvDocument.Rows[i].Cells[j].Value = element.InnerXml;
                    ++j;
                }
                //小组评分表评分项
                XmlNodeList contentList = module.SelectNodes("评分项集合1/评分项1");
                foreach (XmlNode content in contentList)
                {
                    XmlNodeList elements = content.ChildNodes;
                    j = 0;
                    i = this.dgvDocument.Rows.Add();
                    foreach (XmlNode element in elements)
                    {
                        this.dgvDocument.Rows[i].Cells[j].Value = element.InnerXml;
                        ++j;
                    }
                }
            }

            //获取小组评分表评分数据
            titles = group.SelectSingleNode("文档评分表后三列/总评分项2").ChildNodes;
            //小组评分表首行数据
            k = 0;
            j = 3;
            foreach (XmlNode element in titles)
            {
                this.dgvDocument.Rows[k].Cells[j].Value = element.InnerXml;
                ++j;
            }
            moduleList = group.SelectNodes("文档评分表后三列/评分模块集合2/评分模块2");
            foreach (XmlNode module in moduleList)
            {
                j = 3;
                //小组评分表评分模块
                XmlNodeList elementList = module.SelectSingleNode("评分模块内容2").ChildNodes;
                ++k;
                foreach (XmlNode element in elementList)
                {
                    this.dgvDocument.Rows[k].Cells[j].Value = element.InnerXml;
                    ++j;
                }
                //小组评分表评分项
                XmlNodeList contentList = module.SelectNodes("评分项集合2/评分项2");
                foreach (XmlNode content in contentList)
                {
                    XmlNodeList elements = content.ChildNodes;
                    j = 3;
                    ++k;
                    foreach (XmlNode element in elements)
                    {
                        this.dgvDocument.Rows[k].Cells[j].Value = element.InnerXml;
                        ++j;
                    }
                }
            }
        }

        private void cmsDocument2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            XmlNodeList groups = doc.SelectNodes("class/小组集合/小组实例/小组");
            XmlNode groupTemplate = doc.SelectSingleNode("class/小组集合/小组模板/小组");
            String[] str = dgvDocument.CurrentRow.Cells[0].Value.ToString().Split('-');
            int moduleIndex = int.Parse(str[0]) - 1;
            int elementIndex = int.Parse(str[1]) - 1;
            //XmlNodeList modules = group.SelectNodes("documentScore/module");
            XmlNodeList modulesTemplate = doc.SelectNodes("class/文档评分表前三列/评分模块集合1/评分模块1");
            //XmlNode element = modules[moduleIndex].ChildNodes[1].ChildNodes[elementIndex];
            XmlNode elementTemplate = modulesTemplate[moduleIndex].ChildNodes[1].ChildNodes[elementIndex];
            if (e.ClickedItem.MergeIndex == 0)
            {
                //添加评分项前3列
                XmlElement element1 = doc.CreateElement("评分项1");
                XmlElement element2 = doc.CreateElement("序号");
                element2.InnerXml = (moduleIndex + 1).ToString() + "-" + (elementIndex + 2).ToString();
                element1.AppendChild(element2);
                element2 = doc.CreateElement("评分指标");
                element1.AppendChild(element2);
                element2 = doc.CreateElement("权重");
                element1.AppendChild(element2);
                elementTemplate.ParentNode.InsertAfter(element1, elementTemplate);
                //后面的评分项序号都需要加一
                for (int i = elementIndex + 1; i < modulesTemplate[moduleIndex].ChildNodes[1].ChildNodes.Count; ++i)
                {
                    modulesTemplate[moduleIndex].ChildNodes[1].ChildNodes[i].ChildNodes[0].InnerXml = (moduleIndex + 1).ToString() + "-" + (i + 1).ToString();
                }
                //添加评分项后3列
                for (int i = 0; i < groups.Count + 1; ++i)
                {
                    if (i == groups.Count)
                        group = groupTemplate;
                    else
                        group = groups[i];
                    XmlNodeList modules = group.SelectNodes("文档评分表后三列/评分模块集合2/评分模块2");
                    XmlNode element = modules[moduleIndex].ChildNodes[1].ChildNodes[elementIndex];
                    element1 = doc.CreateElement("评分项2");
                    element2 = doc.CreateElement("得分");
                    element1.AppendChild(element2);
                    element2 = doc.CreateElement("加权分");
                    element1.AppendChild(element2);
                    element2 = doc.CreateElement("备注");
                    element1.AppendChild(element2);
                    element.ParentNode.InsertAfter(element1, element);
                }

            }
            else if (e.ClickedItem.MergeIndex == 1)
            {
                //删除评分项前3列
                elementTemplate.ParentNode.RemoveChild(elementTemplate);
                modulesTemplate = doc.SelectNodes("class/文档评分表前三列/评分模块集合1/评分模块1");
                //后面的评分项序号都需要减一
                XmlNodeList elements = modulesTemplate[moduleIndex].ChildNodes[1].ChildNodes;
                for (int i = elementIndex; i < elements.Count; ++i)
                {
                    elements[i].ChildNodes[0].InnerXml = (moduleIndex + 1).ToString() + "-" + (i + 1).ToString();
                }
                //删除评分项后3列
                for (int i = 0; i < groups.Count + 1; ++i)
                {
                    if (i == groups.Count)
                        group = groupTemplate;
                    else
                        group = groups[i];
                    XmlNodeList modules = group.SelectNodes("文档评分表后三列/评分模块集合2/评分模块2");
                    XmlNode element = modules[moduleIndex].ChildNodes[1].ChildNodes[elementIndex];
                    element.ParentNode.RemoveChild(element);
                }
            }
            doc.Save(scoreTemplatePath);
            loadDocumentTab();
        }

        private void dgvDocument_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvDocument.CurrentRow.Index == -1)
                return;
            if (e.Button == MouseButtons.Right && dgvDocument.CurrentRow.Index > -1)
            {

                if (dgvDocument.CurrentRow.Cells[0].Value.ToString().Contains("-") && dgvDocument.CurrentRow.Index > 0)
                {
                    cmsDocument2.Show(Cursor.Position);
                }
                else
                {
                    cmsDocument1.Show(Cursor.Position);
                    if (dgvDocument.CurrentRow.Index == 0)
                    {
                        cmsDocument1.Items[1].Visible = false;
                        cmsDocument1.Items[2].Visible = false;
                    }
                    else
                    {
                        cmsDocument1.Items[1].Visible = true;
                        cmsDocument1.Items[2].Visible = true;
                    }
                }
            }
        }

        private void dgvDocument_DoubleClick(object sender, EventArgs e)
        {
            if (dgvDocument.CurrentRow.Index == -1)
                return;
            dgvDocument.BeginEdit(true);
            currentEditRow = dgvDocument.CurrentRow.Index;
            currentEditCol = dgvDocument.CurrentCell.ColumnIndex;
        }

        private void dgvDocument_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //如果编辑的列序号小于三
            if (currentEditCol < 3)
            {
                if (currentEditRow == 0)
                {
                    XmlNodeList elements = doc.SelectSingleNode("class/文档评分表前三列/总评分项1").ChildNodes;
                    if (dgvDocument.Rows[currentEditRow].Cells[currentEditCol].Value == null)
                    {
                        elements[currentEditCol].InnerXml = " ";
                    }
                    else
                    {
                        elements[currentEditCol].InnerXml = dgvDocument.Rows[currentEditRow].Cells[currentEditCol].Value.ToString();
                    }
                    doc.Save(scoreTemplatePath);
                    return;
                }
                string judge = dgvDocument.Rows[currentEditRow].Cells[0].Value.ToString();
                XmlNodeList modules = doc.SelectNodes("class/文档评分表前三列/评分模块集合1/评分模块1");
                if (judge.Contains("-"))//评分项
                {
                    string[] str = judge.Split('-');
                    int moduleIndex = int.Parse(str[0]) - 1;
                    int elementIndex = int.Parse(str[1]) - 1;
                    if (dgvDocument.Rows[currentEditRow].Cells[currentEditCol].Value == null)
                    {
                        modules[moduleIndex].ChildNodes[1].ChildNodes[elementIndex].ChildNodes[currentEditCol].InnerXml = " ";
                    }
                    else
                    {
                        modules[moduleIndex].ChildNodes[1].ChildNodes[elementIndex].ChildNodes[currentEditCol].InnerXml = dgvDocument.Rows[currentEditRow].Cells[currentEditCol].Value.ToString();
                    }
                }
                else//评分模块
                {
                    int moduleIndex = int.Parse(judge) - 1;
                    if (dgvDocument.Rows[currentEditRow].Cells[currentEditCol].Value == null)
                    {
                        modules[moduleIndex].ChildNodes[0].ChildNodes[currentEditCol].InnerXml = " ";
                    }
                    else
                    {
                        modules[moduleIndex].ChildNodes[0].ChildNodes[currentEditCol].InnerXml = dgvDocument.Rows[currentEditRow].Cells[currentEditCol].Value.ToString();
                    }

                }
            }
            else
            {
                XmlNodeList groups = doc.SelectNodes("class/小组集合/小组实例/小组");
                foreach (XmlNode grp in groups)
                {
                    if (grp.ChildNodes[0].ChildNodes[0].InnerXml == labGroupId.Text)
                    {
                        group = grp;
                        break;
                    }
                }
                if (currentEditRow == 0)
                {
                    XmlNodeList elements = group.SelectSingleNode("文档评分表后三列/总评分项2").ChildNodes;
                    if (dgvDocument.Rows[currentEditRow].Cells[currentEditCol].Value == null)
                    {
                        elements[currentEditCol - 3].InnerXml = " ";
                    }
                    else
                    {
                        elements[currentEditCol - 3].InnerXml = dgvDocument.Rows[currentEditRow].Cells[currentEditCol].Value.ToString();
                    }
                    doc.Save(scoreTemplatePath);
                    return;
                }
                string judge = dgvDocument.Rows[currentEditRow].Cells[0].Value.ToString();
                XmlNodeList modules = group.SelectNodes("文档评分表后三列/评分模块集合2/评分模块2");
                if (judge.Contains("-"))//评分项
                {
                    string[] str = judge.Split('-');
                    int moduleIndex = int.Parse(str[0]) - 1;
                    int elementIndex = int.Parse(str[1]) - 1;
                    if (dgvDocument.Rows[currentEditRow].Cells[currentEditCol].Value == null)
                    {
                        modules[moduleIndex].ChildNodes[1].ChildNodes[elementIndex].ChildNodes[currentEditCol - 3].InnerXml = " ";
                    }
                    else
                    {
                        modules[moduleIndex].ChildNodes[1].ChildNodes[elementIndex].ChildNodes[currentEditCol - 3].InnerXml = dgvDocument.Rows[currentEditRow].Cells[currentEditCol].Value.ToString();
                    }
                }
                else//评分模块
                {
                    int moduleIndex = int.Parse(judge) - 1;
                    if (dgvDocument.Rows[currentEditRow].Cells[currentEditCol].Value == null)
                    {
                        modules[moduleIndex].ChildNodes[0].ChildNodes[currentEditCol - 3].InnerXml = " ";
                    }
                    else
                    {
                        modules[moduleIndex].ChildNodes[0].ChildNodes[currentEditCol - 3].InnerXml = dgvDocument.Rows[currentEditRow].Cells[currentEditCol].Value.ToString();
                    }

                }
            }
            doc.Save(scoreTemplatePath);
        }

        private void cmsDocument1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            XmlNodeList groups = doc.SelectNodes("class/小组集合/小组实例/小组");
            XmlNode groupTemplate = doc.SelectSingleNode("class/小组集合/小组模板/小组");
            XmlNodeList modulesTemplate = doc.SelectNodes("class/文档评分表前三列/评分模块集合1/评分模块1");
            if (dgvDocument.CurrentRow.Index == 0)
            {
                //插入评分模块前3列
                XmlElement module = doc.CreateElement("评分模块1");
                XmlElement title = doc.CreateElement("评分模块内容1");
                module.AppendChild(title);
                XmlElement element = doc.CreateElement("序号");
                element.InnerXml = 1.ToString();
                title.AppendChild(element);
                element = doc.CreateElement("评分指标");
                title.AppendChild(element);
                element = doc.CreateElement("权重");
                title.AppendChild(element);
                XmlElement content = doc.CreateElement("评分项集合1");
                content.InnerXml = " ";
                module.AppendChild(content);
                //
                if (modulesTemplate.Count == 0)
                {
                    XmlNode documentScore = doc.SelectSingleNode("class/文档评分表前三列/评分模块集合1");
                    documentScore.AppendChild(module);
                }
                else
                {
                    modulesTemplate[0].ParentNode.InsertBefore(module, modulesTemplate[0]);
                }
                //该模块及后面的所有序号都需要加一
                for (int i = 0; i < modulesTemplate.Count; ++i)
                {
                    string number = modulesTemplate[i].ChildNodes[0].ChildNodes[0].InnerXml;
                    modulesTemplate[i].ChildNodes[0].ChildNodes[0].InnerXml = (int.Parse(number) + 1).ToString();
                    XmlNodeList nodes = modulesTemplate[i].ChildNodes[1].ChildNodes;
                    if (nodes == null)
                        continue;
                    for (int j = 0; j < nodes.Count; ++j)
                    {
                        number = modulesTemplate[i].ChildNodes[0].ChildNodes[0].InnerXml;
                        nodes[j].ChildNodes[0].InnerXml = (int.Parse(number)).ToString() + "-" + (j + 1).ToString();
                    }
                }
                //给所有小组插入评分模块后3列
                for (int i = 0; i < groups.Count + 1; ++i)
                {
                    if (i == groups.Count)
                        group = groupTemplate;
                    else
                        group = groups[i];
                    XmlNodeList modules = group.SelectNodes("文档评分表后三列/评分模块集合2/评分模块2");
                    module = doc.CreateElement("评分模块2");
                    title = doc.CreateElement("评分模块内容2");
                    module.AppendChild(title);

                    element = doc.CreateElement("得分");
                    title.AppendChild(element);
                    element = doc.CreateElement("加权分");
                    title.AppendChild(element);
                    element = doc.CreateElement("备注");
                    title.AppendChild(element);

                    content = doc.CreateElement("评分项集合2");
                    module.AppendChild(content);
                    //
                    if (modules.Count == 0)
                    {
                        XmlNode documentScore = group.SelectSingleNode("文档评分表后三列/评分模块集合2");
                        documentScore.AppendChild(module);
                    }
                    else
                    {
                        modules[0].ParentNode.InsertBefore(module, modules[0]);
                    }
                }
                doc.Save(scoreTemplatePath);
                loadDocumentTab();
                return;
            }
            int moduleIndex = int.Parse(dgvDocument.CurrentRow.Cells[0].Value.ToString());
            if (e.ClickedItem.MergeIndex == 0)
            {
                //添加评分模块前3列
                XmlElement module = doc.CreateElement("评分模块1");
                modulesTemplate[moduleIndex - 1].ParentNode.InsertAfter(module, modulesTemplate[moduleIndex - 1]);
                XmlElement title = doc.CreateElement("评分模块内容1");

                module.AppendChild(title);
                XmlElement element = doc.CreateElement("序号");
                element.InnerXml = (moduleIndex + 1).ToString();
                title.AppendChild(element);
                element = doc.CreateElement("评分指标");
                title.AppendChild(element);
                element = doc.CreateElement("权重");
                title.AppendChild(element);
                XmlElement content = doc.CreateElement("评分项集合1");
                module.AppendChild(content);

                //该模块及后面的所有序号都需要加一
                for (int i = moduleIndex + 1; i < modulesTemplate.Count; ++i)
                {
                    string number = modulesTemplate[i].ChildNodes[0].ChildNodes[0].InnerXml;
                    modulesTemplate[i].ChildNodes[0].ChildNodes[0].InnerXml = (int.Parse(number) + 1).ToString();
                    XmlNodeList nodes = modulesTemplate[i].ChildNodes[1].ChildNodes;
                    if (nodes == null)
                        continue;
                    for (int j = 0; j < nodes.Count; ++j)
                    {
                        number = modulesTemplate[i].ChildNodes[0].ChildNodes[0].InnerXml;
                        nodes[j].ChildNodes[0].InnerXml = (int.Parse(number)).ToString() + "-" + (j + 1).ToString();
                    }
                }

                //添加评分模块后3列
                for (int i = 0; i < groups.Count + 1; ++i)
                {
                    if (i == groups.Count)
                        group = groupTemplate;
                    else
                        group = groups[i];
                    XmlNodeList modules = group.SelectNodes("文档评分表后三列/评分模块集合2/评分模块2");
                    module = doc.CreateElement("评分模块2");
                    modules[moduleIndex - 1].ParentNode.InsertAfter(module, modules[moduleIndex - 1]);
                    title = doc.CreateElement("评分模块内容2");

                    module.AppendChild(title);
                    element = doc.CreateElement("得分");
                    title.AppendChild(element);
                    element = doc.CreateElement("加权分");
                    title.AppendChild(element);
                    element = doc.CreateElement("备注");
                    title.AppendChild(element);

                    content = doc.CreateElement("评分项集合2");
                    module.AppendChild(content);
                }
            }
            else if (e.ClickedItem.MergeIndex == 1)
            {
                //删除评分模块前3列
                modulesTemplate[moduleIndex - 1].ParentNode.RemoveChild(modulesTemplate[moduleIndex - 1]);
                modulesTemplate = doc.SelectNodes("class/文档评分表前三列/评分模块集合1/评分模块1");
                //该模块及后面的所有序号都需要减一
                for (int i = moduleIndex - 1; i < modulesTemplate.Count; ++i)
                {
                    string number = modulesTemplate[i].ChildNodes[0].ChildNodes[0].InnerXml;
                    modulesTemplate[i].ChildNodes[0].ChildNodes[0].InnerXml = (int.Parse(number) - 1).ToString();

                    XmlNodeList nodes = modulesTemplate[i].ChildNodes[1].ChildNodes;
                    if (nodes == null)
                        continue;
                    for (int j = 0; j < nodes.Count; ++j)
                    {
                        number = modulesTemplate[i].ChildNodes[0].ChildNodes[0].InnerXml;
                        nodes[j].ChildNodes[0].InnerXml = (int.Parse(number)).ToString() + "-" + (j + 1).ToString();
                    }
                }
                //删除评分模块后3列
                for (int i = 0; i < groups.Count + 1; ++i)
                {
                    if (i == groups.Count)
                        group = groupTemplate;
                    else
                        group = groups[i];
                    XmlNodeList modules = group.SelectNodes("文档评分表后三列/评分模块集合2/评分模块2");
                    modules[moduleIndex - 1].ParentNode.RemoveChild(modules[moduleIndex - 1]);
                    modules = group.SelectNodes("文档评分表后三列/评分模块集合2/评分模块2");
                }
            }
            else if (e.ClickedItem.MergeIndex == 2)
            {
                //添加评分项前3列
                XmlNodeList elements = modulesTemplate[moduleIndex - 1].ChildNodes[1].ChildNodes;
                XmlElement element1 = doc.CreateElement("评分项1");
                XmlElement element2 = doc.CreateElement("序号");
                element2.InnerXml = moduleIndex.ToString() + "-1";
                element1.AppendChild(element2);
                element2 = doc.CreateElement("评分指标");
                element1.AppendChild(element2);
                element2 = doc.CreateElement("权重");
                element1.AppendChild(element2);
                if (elements == null || elements.Count == 0)
                {
                    modulesTemplate[moduleIndex - 1].ChildNodes[1].AppendChild(element1);
                }
                else
                {
                    elements[0].ParentNode.InsertBefore(element1, elements[0]);
                    //当前模块后的评分项序号都加一
                    for (int j = 0; j < elements.Count; ++j)
                    {
                        elements[j].ChildNodes[0].InnerXml = moduleIndex.ToString() + "-" + (j + 1).ToString();
                    }
                }
                //添加评分项后3列
                for (int i = 0; i < groups.Count + 1; ++i)
                {
                    if (i == groups.Count)
                        group = groupTemplate;
                    else
                        group = groups[i];
                    XmlNodeList modules = group.SelectNodes("文档评分表后三列/评分模块集合2/评分模块2");
                    elements = modules[moduleIndex - 1].ChildNodes[1].ChildNodes;
                    element1 = doc.CreateElement("评分项2");
                    element2 = doc.CreateElement("得分");
                    element1.AppendChild(element2);
                    element2 = doc.CreateElement("加权分");
                    element1.AppendChild(element2);
                    element2 = doc.CreateElement("备注");
                    element1.AppendChild(element2);

                    if (elements == null || elements.Count == 0)
                    {
                        modules[moduleIndex - 1].ChildNodes[1].AppendChild(element1);
                    }
                    else
                    {
                        elements[0].ParentNode.InsertBefore(element1, elements[0]);
                    }
                }
            }
            doc.Save(scoreTemplatePath);
            loadDocumentTab();
        }


        /// <summary>
        /// 加载期中考核教师评分表
        /// </summary>
        private void loadTeacherTab()
        {
            dgvTeacherScore1.RowHeadersVisible = false;
            dgvTeacherScore1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTeacherScore1.AllowUserToAddRows = false;
            dgvTeacherScore1.AllowUserToResizeRows = false;
            dgvTeacherScore1.AllowUserToResizeColumns = false;
            this.dgvTeacherScore1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTeacherScore1.AllowUserToAddRows = false;
            dgvTeacherScore1.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvTeacherScore1.Columns[0].ReadOnly = true;

            dgvTeacherScore1.Rows.Clear();
            doc.Load(scoreTemplatePath);
            XmlNodeList groups = doc.SelectNodes("class/小组集合/小组实例/小组");
            foreach (XmlNode group in groups)
            {
                XmlNodeList elements = group.SelectSingleNode("自评互评教师评综合成绩/期中考核/教师评分项").ChildNodes;
                int index = dgvTeacherScore1.Rows.Add();
                dgvTeacherScore1.Rows[index].Cells[0].Value = group.ChildNodes[0].ChildNodes[0].InnerXml;
                for (int i = 0; i < elements.Count; ++i)
                {
                    dgvTeacherScore1.Rows[index].Cells[i + 1].Value = elements[i].InnerXml;
                }
            }
        }
        /// <summary>
        /// 加载项目验收教师评分表
        /// </summary>
        private void loadTeacherTab2()
        {
            dgvTeacherScore2.RowHeadersVisible = false;
            dgvTeacherScore2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTeacherScore2.AllowUserToAddRows = false;
            dgvTeacherScore2.AllowUserToResizeRows = false;
            dgvTeacherScore2.AllowUserToResizeColumns = false;
            this.dgvTeacherScore2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTeacherScore2.AllowUserToAddRows = false;
            dgvTeacherScore2.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvTeacherScore2.Columns[0].ReadOnly = true;

            dgvTeacherScore2.Rows.Clear();
            doc.Load(scoreTemplatePath);
            XmlNodeList groups = doc.SelectNodes("class/小组集合/小组实例/小组");
            foreach (XmlNode group in groups)
            {
                XmlNodeList elements = group.SelectSingleNode("自评互评教师评综合成绩/项目验收/教师评分项").ChildNodes;
                int index = dgvTeacherScore2.Rows.Add();
                dgvTeacherScore2.Rows[index].Cells[0].Value = group.ChildNodes[0].ChildNodes[0].InnerXml;
                for (int i = 0; i < elements.Count; ++i)
                {
                    dgvTeacherScore2.Rows[index].Cells[i + 1].Value = elements[i].InnerXml;
                }
            }
        }

        private void dgvTeacherScore_DoubleClick(object sender, EventArgs e)
        {
            dgvTeacherScore1.BeginEdit(true);
            currentEditRow = dgvTeacherScore1.CurrentRow.Index;
            currentEditCol = dgvTeacherScore1.CurrentCell.ColumnIndex;
        }


        private void dgvTeacherScore_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string groupId = dgvTeacherScore1.Rows[currentEditRow].Cells[0].Value.ToString();
            XmlNodeList groups = doc.SelectNodes("class/小组集合/小组实例/小组");
            foreach (XmlNode group in groups)
            {
                if (group.ChildNodes[0].ChildNodes[0].InnerXml == groupId)
                {
                    XmlNodeList elements = group.SelectSingleNode("自评互评教师评综合成绩/期中考核/教师评分项").ChildNodes;
                    if (dgvTeacherScore1.Rows[currentEditRow].Cells[currentEditCol].Value == null)
                    {
                        elements[currentEditCol - 1].InnerXml = " ";
                    }
                    else
                    {
                        elements[currentEditCol - 1].InnerXml = dgvTeacherScore1.Rows[currentEditRow].Cells[currentEditCol].Value.ToString();
                    }
                    break;
                }
            }
            doc.Save(scoreTemplatePath);
        }


        /// <summary>
        /// 加载期中考核自评互评表
        /// </summary>
        private void loadMutualTab()
        {
            dgvMutual.RowHeadersVisible = false;
            dgvMutual.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMutual.AllowUserToAddRows = false;
            dgvMutual.AllowUserToResizeRows = false;
            dgvMutual.AllowUserToResizeColumns = false;
            dgvMutual.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMutual.EditMode = DataGridViewEditMode.EditProgrammatically;

            dgvMutual.Rows.Clear();
            doc.Load(scoreTemplatePath);
            XmlNodeList groups = doc.SelectNodes("class/小组集合/小组实例/小组");
            foreach (XmlNode group in groups)
            {
                if (group.ChildNodes[0].ChildNodes[0].InnerXml == labGroupId.Text)
                {
                    XmlNodeList modules = group.SelectNodes("自评互评教师评综合成绩/期中考核/自评互评表/小组");
                    foreach (XmlNode module in modules)
                    {
                        int index = dgvMutual.Rows.Add();
                        XmlNodeList elements = module.ChildNodes;
                        for (int i = 0; i < elements.Count; ++i)
                        {
                            dgvMutual.Rows[index].Cells[i].Value = elements[i].InnerXml;
                        }
                    }
                    break;
                }
            }
        }
        /// <summary>
        /// 加载项目验收自评互评表
        /// </summary>
        private void loadMutualTab2()
        {
            dgvMutual2.RowHeadersVisible = false;
            dgvMutual2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMutual2.AllowUserToAddRows = false;
            dgvMutual2.AllowUserToResizeRows = false;
            dgvMutual2.AllowUserToResizeColumns = false;
            dgvMutual2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMutual2.EditMode = DataGridViewEditMode.EditProgrammatically;

            dgvMutual2.Rows.Clear();
            doc.Load(scoreTemplatePath);
            XmlNodeList groups = doc.SelectNodes("class/小组集合/小组实例/小组");
            foreach (XmlNode group in groups)
            {
                if (group.ChildNodes[0].ChildNodes[0].InnerXml == labGroupId.Text)
                {
                    XmlNodeList modules = group.SelectNodes("自评互评教师评综合成绩/项目验收/自评互评表/小组");
                    foreach (XmlNode module in modules)
                    {
                        int index = dgvMutual2.Rows.Add();
                        XmlNodeList elements = module.ChildNodes;
                        for (int i = 0; i < elements.Count; ++i)
                        {
                            dgvMutual2.Rows[index].Cells[i].Value = elements[i].InnerXml;
                        }
                    }
                    break;
                }
            }
        }

        private void dgvMutual_DoubleClick(object sender, EventArgs e)
        {
            dgvMutual.BeginEdit(true);
            dgvMutual.Columns[0].ReadOnly = true;
            currentEditRow = dgvMutual.CurrentRow.Index;
            currentEditCol = dgvMutual.CurrentCell.ColumnIndex;
        }

        private void dgvMutual_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            XmlNodeList groups = doc.SelectNodes("class/小组集合/小组实例/小组");
            foreach (XmlNode grp in groups)
            {
                if (grp.ChildNodes[0].ChildNodes[0].InnerXml == labGroupId.Text)
                {
                    group = grp;
                    break;
                }
            }
            XmlNodeList modules = group.SelectNodes("自评互评教师评综合成绩/期中考核/自评互评表/小组");
            string groupId = dgvMutual.Rows[currentEditRow].Cells[0].Value.ToString();
            foreach (XmlNode module in modules)
            {
                if (module.ChildNodes[0].InnerXml == groupId)
                {
                    XmlNodeList elements = module.ChildNodes;
                    if (dgvMutual.Rows[currentEditRow].Cells[currentEditCol].Value == null)
                    {
                        elements[currentEditCol].InnerXml = " ";
                    }
                    else
                    {
                        elements[currentEditCol].InnerXml = dgvMutual.Rows[currentEditRow].Cells[currentEditCol].Value.ToString();
                    }
                    break;
                }
            }
            doc.Save(scoreTemplatePath);
        }

        private void dgvMutual2_DoubleClick(object sender, EventArgs e)
        {
            dgvMutual2.BeginEdit(true);
            dgvMutual2.Columns[0].ReadOnly = true;
            currentEditRow = dgvMutual2.CurrentRow.Index;
            currentEditCol = dgvMutual2.CurrentCell.ColumnIndex;
        }

        private void dgvMutual2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            XmlNodeList groups = doc.SelectNodes("class/小组集合/小组实例/小组");
            foreach (XmlNode grp in groups)
            {
                if (grp.ChildNodes[0].ChildNodes[0].InnerXml == labGroupId.Text)
                {
                    group = grp;
                    break;
                }
            }
            XmlNodeList modules = group.SelectNodes("自评互评教师评综合成绩/项目验收/自评互评表/小组");
            string groupId = dgvMutual2.Rows[currentEditRow].Cells[0].Value.ToString();
            foreach (XmlNode module in modules)
            {
                if (module.ChildNodes[0].InnerXml == groupId)
                {
                    XmlNodeList elements = module.ChildNodes;
                    if (dgvMutual2.Rows[currentEditRow].Cells[currentEditCol].Value == null)
                    {
                        elements[currentEditCol].InnerXml = " ";
                    }
                    else
                    {
                        elements[currentEditCol].InnerXml = dgvMutual2.Rows[currentEditRow].Cells[currentEditCol].Value.ToString();
                    }
                    break;
                }
            }
            doc.Save(scoreTemplatePath);
        }

        private void dgvTeacherScore2_DoubleClick(object sender, EventArgs e)
        {
            dgvTeacherScore2.BeginEdit(true);
            currentEditRow = dgvTeacherScore2.CurrentRow.Index;
            currentEditCol = dgvTeacherScore2.CurrentCell.ColumnIndex;
        }

        private void dgvTeacherScore2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string groupId = dgvTeacherScore2.Rows[currentEditRow].Cells[0].Value.ToString();
            XmlNodeList groups = doc.SelectNodes("class/小组集合/小组实例/小组");
            foreach (XmlNode group in groups)
            {
                if (group.ChildNodes[0].ChildNodes[0].InnerXml == groupId)
                {
                    XmlNodeList elements = group.SelectSingleNode("自评互评教师评综合成绩/项目验收/教师评分项").ChildNodes;
                    if (dgvTeacherScore2.Rows[currentEditRow].Cells[currentEditCol].Value == null)
                    {
                        elements[currentEditCol - 1].InnerXml = " ";
                    }
                    else
                    {
                        elements[currentEditCol - 1].InnerXml = dgvTeacherScore2.Rows[currentEditRow].Cells[currentEditCol].Value.ToString();
                    }
                    break;
                }
            }
            doc.Save(scoreTemplatePath);
        }
        private void loadTreeView()
        {
            XmlNodeList nodes = doc.SelectSingleNode("class/总成绩评分权重").ChildNodes;
            treeView1.Nodes[0].Nodes[0].Text = "小组文档分(" + nodes[0].InnerXml + "%)";
            treeView1.Nodes[0].Nodes[1].Text = "个人小结分(" + nodes[1].InnerXml + "%)";
            treeView1.Nodes[0].Nodes[2].Text = "个人管理分(" + nodes[2].InnerXml + "%)";
            treeView1.Nodes[0].Nodes[3].Text = "个人贡献分(" + nodes[3].InnerXml + "%)";
            XmlNode node = doc.SelectSingleNode("class/自评互评教师评综合权重/期中考核/权重");
            treeView1.Nodes[0].Nodes[3].Nodes[1].Nodes[0].Nodes[0].Text = "期中考核(" + node.InnerXml + "%)";
            node = doc.SelectSingleNode("class/自评互评教师评综合权重/项目验收/权重");
            treeView1.Nodes[0].Nodes[3].Nodes[1].Nodes[0].Nodes[1].Text = "项目验收(" + node.InnerXml + "%)";

            node = doc.SelectSingleNode("class/自评互评教师评综合权重/期中考核/自评互评/权重");
            treeView1.Nodes[0].Nodes[3].Nodes[1].Nodes[0].Nodes[0].Nodes[0].Text = "自评互评(" + node.InnerXml + "%)";
            node = doc.SelectSingleNode("class/自评互评教师评综合权重/期中考核/教师评分/权重");
            treeView1.Nodes[0].Nodes[3].Nodes[1].Nodes[0].Nodes[0].Nodes[1].Text = "教师评分(" + node.InnerXml + "%)";

            node = doc.SelectSingleNode("class/自评互评教师评综合权重/项目验收/自评互评/权重");
            treeView1.Nodes[0].Nodes[3].Nodes[1].Nodes[0].Nodes[1].Nodes[0].Text = "自评互评(" + node.InnerXml + "%)";
            node = doc.SelectSingleNode("class/自评互评教师评综合权重/项目验收/教师评分/权重");
            treeView1.Nodes[0].Nodes[3].Nodes[1].Nodes[0].Nodes[1].Nodes[1].Text = "教师评分(" + node.InnerXml + "%)";

            node = doc.SelectSingleNode("class/贡献度评分权重/计划设计阶段");
            treeView1.Nodes[0].Nodes[3].Nodes[0].Nodes[0].Text = "计划设计阶段(" + node.InnerXml + "%)";
            node = doc.SelectSingleNode("class/贡献度评分权重/编码测试阶段");
            treeView1.Nodes[0].Nodes[3].Nodes[0].Nodes[1].Text = "编码测试阶段(" + node.InnerXml + "%)";
            treeView1.ExpandAll();
        }
        private void treeView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Console.Write(treeView1.Nodes.Count);
                Form form;
                if (treeView1.SelectedNode.Tag == "个人总成绩")
                {
                    form = new FormTotalScore(doc);
                    form.ShowDialog();
                    loadTreeView();
                    doc.Save(scoreTemplatePath);
                }
                else if (treeView1.SelectedNode.Tag == "自评互评教师评综合权重")
                {
                    form = new FormMutualTeacher(doc);
                    form.ShowDialog();
                    loadTreeView();
                    doc.Save(scoreTemplatePath);
                }
                else if (treeView1.SelectedNode.Tag == "期中考核")
                {
                    form = new FormMidterm(doc);
                    form.ShowDialog();
                    loadTreeView();
                    doc.Save(scoreTemplatePath);
                }
                else if (treeView1.SelectedNode.Tag == "项目验收")
                {
                    form = new FormTerminal(doc);
                    form.ShowDialog();
                    loadTreeView();
                    doc.Save(scoreTemplatePath);
                }
                else if (treeView1.SelectedNode.Tag == "个人贡献权重")
                {
                    form = new FormContribute(doc);
                    form.ShowDialog();
                    loadTreeView();
                    doc.Save(scoreTemplatePath);
                }
            }
        }

        private void dgvContribute2_DoubleClick(object sender, EventArgs e)
        {
            if (dgvContribute2.CurrentCell.ColumnIndex < 3)
                return;
            dgvContribute2.BeginEdit(true);
            currentEditRow = dgvContribute2.CurrentCell.RowIndex;
            currentEditCol = dgvContribute2.CurrentCell.ColumnIndex;
        }

        private void dgvContribute2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            XmlNodeList groups = doc.SelectNodes("class/小组集合/小组实例/小组");
            foreach (XmlNode group in groups)
            {
                if (group.ChildNodes[0].ChildNodes[0].InnerXml == labGroupId.Text)
                {
                    XmlNode contributeScore = group.SelectSingleNode("小组贡献表/编码测试阶段");
                    if (dgvContribute.Rows[currentEditRow].Cells[currentEditCol].Value == null)
                    {
                        contributeScore.ChildNodes[currentEditRow].ChildNodes[currentEditCol - 3].InnerXml = " ";
                    }
                    else
                    {
                        contributeScore.ChildNodes[currentEditRow].ChildNodes[currentEditCol - 3].InnerXml = dgvContribute.Rows[currentEditRow].Cells[currentEditCol].Value.ToString();
                    }
                    break;
                }
            }
            doc.Save(scoreTemplatePath);
        }

        private void btnCalcGroup_Click(object sender, EventArgs e)
        {
            //计算小组分
            bool document = documentScore(); ;
            bool contribute = contributeScore();
            if (document && contribute)
            {
                loadTeamScore();
                MessageBox.Show("评分成功！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.None);
            }

        }
        private bool documentScore()
        {
            bool result = true;
            //校验评分模块及评分项的权重是否正确
            int moduleScore = 0;
            int elementScore = 0;
            XmlNode group = null;
            List<List<int>> scoreScaleList = new List<List<int>>();
            List<List<int>> scoreDataList = new List<List<int>>();
            XmlNodeList groups = doc.SelectNodes("class/小组集合/小组实例/小组");
            foreach (XmlNode grp in groups)
            {
                if (grp.ChildNodes[0].ChildNodes[0].InnerXml == labGroupId.Text)
                {
                    group = grp;
                    break;
                }
            }
            if (group == null)
                return false;
            //获取小组评分表中评分模块及评分项的内容
            XmlNodeList titles = doc.SelectSingleNode("class/文档评分表前三列/总评分项1").ChildNodes;
            //小组评分表首行数据
            int totalScale = int.Parse(doc.SelectSingleNode("class/总成绩评分权重/小组文档分").InnerXml.Trim());

            XmlNodeList moduleList = doc.SelectNodes("class/文档评分表前三列/评分模块集合1/评分模块1");
            foreach (XmlNode module in moduleList)
            {
                //小组评分表评分模块
                List<int> mdList = new List<int>();
                XmlNodeList elementList = module.SelectSingleNode("评分模块内容1").ChildNodes;
                try
                {
                    int x = int.Parse(elementList[2].InnerXml.Trim().Split('%')[0]);
                    if (x < 0 || x > 100)
                    {
                        MessageBox.Show("评分失败，文档评分表" + elementList[1].InnerXml + "评分阶段的权重数据错误！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    else
                    {
                        mdList.Add(x);
                        moduleScore += x;
                    }
                }
                catch
                {
                    MessageBox.Show("评分失败，文档评分表" + elementList[1].InnerXml + "评分阶段的权重数据不符合规范！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                //小组评分表评分项
                elementScore = 0;
                XmlNodeList contentList = module.SelectNodes("评分项集合1/评分项1");
                foreach (XmlNode content in contentList)
                {
                    XmlNodeList elements = content.ChildNodes;
                    try
                    {
                        int x = int.Parse(elements[2].InnerXml.Trim().Split('%')[0]);
                        if (x < 0 || x > 100)
                        {
                            MessageBox.Show("评分失败，文档评分表" + elementList[1].InnerXml + "评分阶段下的" + elements[1] + "权重数据错误！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                        else
                        {
                            mdList.Add(x);
                            elementScore += x;
                        }
                    }
                    catch
                    {
                        MessageBox.Show("评分失败，文档评分表" + elementList[1].InnerXml + "评分阶段的权重数据不符合规范！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                if (elementScore != 100)
                {
                    MessageBox.Show("评分失败，文档评分表" + elementList[1].InnerXml + "评分阶段下的权重数据之和不等于100！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                scoreScaleList.Add(mdList);
            }
            if (moduleScore != 100)
            {
                MessageBox.Show("评分失败，文档评分表各个评分阶段的权重数据之和不等于100！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }



            //获取小组评分表评分数据
            titles = group.SelectSingleNode("文档评分表后三列/总评分项2").ChildNodes;
            //小组评分表首行数据
            moduleList = group.SelectNodes("文档评分表后三列/评分模块集合2/评分模块2");
            List<double> mdScore = new List<double>();
            for (int i = 0; i < moduleList.Count; ++i)
            {
                //小组评分表评分模块
                XmlNodeList elementList = moduleList[i].SelectSingleNode("评分模块内容2").ChildNodes;
                List<int> list = new List<int>();
                list.Add(0);
                //小组评分表评分项
                XmlNodeList contentList = moduleList[i].SelectNodes("评分项集合2/评分项2");
                for (int j = 0; j < contentList.Count; ++j)
                {
                    XmlNodeList elements = contentList[j].ChildNodes;
                    try
                    {
                        int x = int.Parse(elements[0].InnerXml.Trim());
                        if (x < 0 || x > 100)
                        {
                            MessageBox.Show("评分失败，文档评分表的评分数据有错误！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                        else
                        {
                            list.Add(x);
                            double data = scoreScaleList[i][j + 1] * x / 100.0;
                            elements[1].InnerXml = data.ToString("0.00");
                            doc.Save(scoreTemplatePath);
                        }
                    }
                    catch
                    {
                        MessageBox.Show("评分失败，文档评分表的评分数据不符合规范！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                double num = 0.0;
                for (int k = 1; k < list.Count; ++k)
                {
                    num += list[k] * scoreScaleList[i][k] / 100.0;
                }
                mdScore.Add(num);
                elementList[0].InnerXml = num.ToString("0.00");
                elementList[1].InnerXml = (num * scoreScaleList[i][0] / 100.0).ToString("0.00");
                doc.Save(scoreTemplatePath);
                scoreDataList.Add(list);
            }
            double totalScore = 0;
            for (int i = 0; i < scoreDataList.Count; ++i)
            {
                totalScore += mdScore[i] * scoreScaleList[i][0] / 100.0;
            }
            titles[0].InnerXml = totalScore.ToString("0.00");
            titles[1].InnerXml = (totalScore * totalScale / 100.0).ToString("0.00");
            XmlNodeList elementsScore = group.SelectNodes("小组成绩表/成员成绩");
            //获得小组成员成绩文档分
            for (int i = 0; i < elementsScore.Count; ++i)
            {
                elementsScore[i].ChildNodes[0].InnerXml = totalScore.ToString("0.00");
            }
            //获得小组成员管理分
            for (int i = 0; i < elementsScore.Count; ++i)
            {
                elementsScore[i].ChildNodes[2].InnerXml = mdScore[i].ToString("0.00");
            }
            doc.Save(scoreTemplatePath);
            return true;
        }
        private bool contributeScore()
        {
            double midtermScore = 0;
            double terminalScore = 0;
            //校验期中考核阶段
            XmlNode group = null;
            XmlNodeList groups = doc.SelectNodes("class/小组集合/小组实例/小组");
            foreach (XmlNode grp in groups)
            {
                if (grp.ChildNodes[0].ChildNodes[0].InnerXml == labGroupId.Text)
                {
                    group = grp;
                    break;
                }
            }
            if (group == null)
                return false;
            XmlNodeList groupMutual = group.SelectNodes("自评互评教师评综合成绩/期中考核/自评互评表/小组");
            int groupMutualTotal = 0;
            List<int> mutualScale = new List<int>();
            mutualScale.Add(20);
            mutualScale.Add(30);
            mutualScale.Add(40);
            mutualScale.Add(10);
            double totalMutualScore = 0;
            foreach (XmlNode element in groupMutual)
            {
                XmlNodeList node = element.ChildNodes;
                double mutualScore = 0;
                for (int i = 2; i < node.Count - 1; ++i)
                {
                    try
                    {
                        int score = int.Parse(node[i].InnerXml.Trim());
                        if (score < 0 || score > 100)
                        {
                            MessageBox.Show("评分失败，该小组期中考核阶段自评互评表的评分数据错误！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                        mutualScore += score * mutualScale[i - 2] / 100.0;
                    }
                    catch
                    {
                        MessageBox.Show("评分失败，该小组期中考核阶段自评互评表的评分数据不符合规范！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                totalMutualScore += mutualScore;
                node[6].InnerXml = mutualScore.ToString();
                doc.Save(scoreTemplatePath);
            }
            totalMutualScore /= groupMutual.Count;

            XmlNodeList nodes = group.SelectSingleNode("自评互评教师评综合成绩/期中考核/教师评分项").ChildNodes;
            double teacherScore = 0;
            for (int i = 1; i < nodes.Count - 1; ++i)
            {
                try
                {
                    int score = int.Parse(nodes[i].InnerXml.Trim());
                    if (score < 0 || score > 100)
                    {
                        MessageBox.Show("评分失败，该小组期中考核阶段教师评分表的评分数据错误！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    teacherScore += score * mutualScale[i - 1] / 100.0;
                }
                catch
                {
                    MessageBox.Show("评分失败，该小组期中考核阶段教师评分表的评分数据不符合规范！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            nodes[5].InnerXml = teacherScore.ToString();
            doc.Save(scoreTemplatePath);

            int midtermScale = int.Parse(doc.SelectSingleNode("class/自评互评教师评综合权重/期中考核/权重").InnerXml);
            int terminalScale = int.Parse(doc.SelectSingleNode("class/自评互评教师评综合权重/项目验收/权重").InnerXml);
            int mutualScale1 = int.Parse(doc.SelectSingleNode("class/自评互评教师评综合权重/期中考核/自评互评/权重").InnerXml);
            int teacherScale1 = int.Parse(doc.SelectSingleNode("class/自评互评教师评综合权重/期中考核/教师评分/权重").InnerXml);
            int mutualScale2 = int.Parse(doc.SelectSingleNode("class/自评互评教师评综合权重/项目验收/自评互评/权重").InnerXml);
            int teacherScale2 = int.Parse(doc.SelectSingleNode("class/自评互评教师评综合权重/项目验收/教师评分/权重").InnerXml);

            midtermScore = mutualScale1 * totalMutualScore + teacherScale1 * teacherScore;

            groupMutual = group.SelectNodes("自评互评教师评综合成绩/项目验收/自评互评表/小组");
            groupMutualTotal = 0;
            mutualScale = new List<int>();
            mutualScale.Add(30);
            mutualScale.Add(40);
            mutualScale.Add(20);
            mutualScale.Add(10);
            totalMutualScore = 0;
            foreach (XmlNode element in groupMutual)
            {
                XmlNodeList node = element.ChildNodes;
                double mutualScore = 0;
                for (int i = 2; i < node.Count - 1; ++i)
                {
                    try
                    {
                        int score = int.Parse(node[i].InnerXml.Trim());
                        if (score < 0 || score > 100)
                        {
                            MessageBox.Show("评分失败，该小组项目验收阶段自评互评表的评分数据错误！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                        mutualScore += score * mutualScale[i - 2] / 100.0;

                    }
                    catch
                    {
                        MessageBox.Show("评分失败，该小组项目验收阶段自评互评表的评分数据不符合规范！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                totalMutualScore += mutualScore;
                node[6].InnerXml = mutualScore.ToString();
                doc.Save(scoreTemplatePath);
            }
            totalMutualScore /= groupMutual.Count;

            nodes = group.SelectSingleNode("自评互评教师评综合成绩/项目验收/教师评分项").ChildNodes;
            teacherScore = 0;
            for (int i = 1; i < nodes.Count - 1; ++i)
            {
                try
                {
                    int score = int.Parse(nodes[i].InnerXml.Trim());
                    if (score < 0 || score > 100)
                    {
                        MessageBox.Show("评分失败，该小组项目验收阶段教师评分表的评分数据错误！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    teacherScore += score * mutualScale[i - 1] / 100.0;
                }
                catch
                {
                    MessageBox.Show("评分失败，该小组项目验收阶段教师评分表的评分数据不符合规范！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            nodes[5].InnerXml = teacherScore.ToString();
            doc.Save(scoreTemplatePath);

            terminalScore = mutualScale2 * totalMutualScore + teacherScale2 * teacherScore;
            double mutualTeacherScore = midtermScore * midtermScale / 100.0 + terminalScore * terminalScale / 100.0;
            int teammate = group.SelectNodes("小组成员/成员信息").Count;

            int contributeScale1 = int.Parse(doc.SelectSingleNode("class/贡献度评分权重/计划设计阶段").InnerXml);
            int contributeScale2 = int.Parse(doc.SelectSingleNode("class/贡献度评分权重/编码测试阶段").InnerXml);
            int contributeScore1 = 0;
            int contributeScore2 = 0;
            double contributeScale = 0;

            XmlNodeList groupScore = group.SelectNodes("小组成绩表/成员成绩");
            XmlNodeList contributeTab1 = group.SelectNodes("小组贡献表/计划设计阶段/成员贡献");
            XmlNodeList contributeTab2 = group.SelectNodes("小组贡献表/编码测试阶段/成员贡献");
            for (int i = 0; i < groupScore.Count; ++i)
            {
                try
                {
                    contributeScore1 = int.Parse(contributeTab1[i].ChildNodes[0].InnerXml.Trim());
                    if (contributeScore1 < 0 || contributeScore1 > 100)
                    {
                        MessageBox.Show("评分失败，该小组计划设计阶段小组贡献表的评分数据错误！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                catch
                {
                    MessageBox.Show("评分失败，该小组计划设计阶段小组贡献表的评分数据不符合规范！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                try
                {
                    contributeScore2 = int.Parse(contributeTab2[i].ChildNodes[0].InnerXml.Trim());
                    if (contributeScore1 < 0 || contributeScore1 > 100)
                    {
                        MessageBox.Show("评分失败，该小组编码测试阶段小组贡献表的评分数据错误！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                catch
                {
                    MessageBox.Show("评分失败，该小组编码测试阶段小组贡献表的评分数据不符合规范！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                contributeScale = contributeScore1 * contributeScale1 / 100.0 + contributeScore2 * contributeScale2 / 100.0;
                double result = contributeScale * mutualTeacherScore * groupScore.Count / 100.0;
                if (result > 10000)
                    result = 100;
                else
                    result = result / 100.0;
                groupScore[i].ChildNodes[3].InnerXml = result.ToString("0.00");
                doc.Save(scoreTemplatePath);
            }

            return true;
        }

        private void btnCalcPersonal_Click(object sender, EventArgs e)
        {
            List<int> scale = new List<int>();
            XmlNodeList scaleList = doc.SelectSingleNode("class/总成绩评分权重").ChildNodes;
            foreach (XmlNode node in scaleList)
            {
                scale.Add(int.Parse(node.InnerXml));
            }
            XmlNode group = null;
            XmlNodeList groups = doc.SelectNodes("class/小组集合/小组实例/小组");
            foreach (XmlNode grp in groups)
            {
                if (grp.ChildNodes[0].ChildNodes[0].InnerXml == labGroupId.Text)
                {
                    group = grp;
                    break;
                }
            }
            if (group == null)
                return;
            XmlNodeList elements = group.SelectNodes("小组成绩表/成员成绩");

            foreach (XmlNode element in elements)
            {
                double score = 0.0;
                XmlNodeList scoreList = element.ChildNodes;
                for (int i = 0; i < scoreList.Count - 1; ++i)
                {
                    try
                    {
                        double data = double.Parse(scoreList[i].InnerXml);
                        if (data < 0 || data > 100)
                        {
                            MessageBox.Show("评分失败，小组成绩表的评分数据错误！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        score += data * scale[i];
                    }
                    catch
                    {
                        MessageBox.Show("评分失败，小组成绩表的评分数据不符合规范！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                score += 50;
                int result = (int)score / 100;
                element.ChildNodes[4].InnerXml = result.ToString();
            }
            doc.Save(scoreTemplatePath);
            loadTeamScore();
            MessageBox.Show("评分成功！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.None);
        }

        private void btnAdvise_Click(object sender, EventArgs e)
        {
            XmlNode group = null;
            XmlNodeList groups = doc.SelectNodes("class/小组集合/小组实例/小组");
            foreach (XmlNode grp in groups)
            {
                if (grp.ChildNodes[0].ChildNodes[0].InnerXml == labGroupId.Text)
                {
                    group = grp;
                    break;
                }
            }
            if (group == null)
                return;
            XmlNode node = group.SelectSingleNode("总评与建议");
            node.InnerXml = textBoxAdvise.Text;
            doc.Save(scoreTemplatePath);
        }

        private void btnConserve_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "*.docx|*.docx";
            sfd.RestoreDirectory = true;
            String localFilePath = "";
            if (sfd.ShowDialog() == DialogResult.OK && sfd.FileName.Length > 0)
            {
                saveToWord= sfd.FileName.ToString();
                printToWord();
                MessageBox.Show("导出Word成功！","信息提示",MessageBoxButtons.OK,MessageBoxIcon.None);               
            }
            
        }
        private void printToWord()
        {
            XmlNodeList groups = doc.SelectNodes("class/小组集合/小组实例/小组");
            string temp = labGroupId.Text;
            Document docu = new Document();
            for (int k = 0; k < groups.Count; ++k)
            {
                labGroupId.Text = groups[k].SelectSingleNode("小组信息/分组号").InnerXml;
                loadTeamScore();
                Section section1 = docu.AddSection();
                Paragraph title = section1.AddParagraph();
                title.Format.HorizontalAlignment = Spire.Doc.Documents.HorizontalAlignment.Center;
                TextRange textRange = title.AppendText("《大型应用软件综合课程设计》小组评分表");
                textRange.CharacterFormat.FontName = "微软雅黑";
                textRange.CharacterFormat.FontSize = 16;
                textRange.CharacterFormat.Bold = true;
                Table table1 = section1.AddTable(true);
                int row = dgvTeamScore.Rows.Count + 3;
                int col = dgvTeamScore.Columns.Count;
                table1.ResetCells(row, col);
                table1.TableFormat.Borders.Left.BorderType = Spire.Doc.Documents.BorderStyle.Hairline;
                table1.TableFormat.Borders.Left.Color = Color.Empty;

                TableRow FROW = table1.Rows[0];
                FROW.IsHeader = true;
                FROW.Height = 23;


                string data = "  ";
                XmlNode group = groups[k];
                data += "组号：  ";
                data += labGroupId.Text;
                data += "&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp";
                data += "项目：  ";
                data += group.SelectSingleNode("小组信息/项目名称").InnerXml;

                Paragraph p = FROW.Cells[0].AddParagraph();
                FROW.Cells[0].CellFormat.VerticalAlignment = VerticalAlignment.Middle;
                p.Format.HorizontalAlignment = Spire.Doc.Documents.HorizontalAlignment.Center;
                TextRange TR = p.AppendText(data);
                TR.CharacterFormat.FontName = "微软雅黑";
                TR.CharacterFormat.FontSize = 12;
                TR.CharacterFormat.Bold = true;

                table1.ApplyHorizontalMerge(0, 0, 7);

                for (int r = 0; r < dgvTeamScore.Rows.Count + 1; r++)
                {
                    TableRow DataRow = table1.Rows[r + 1];
                    //Row Height
                    DataRow.Height = 20;
                    //C Represents Column.
                    for (int c = 0; c < dgvTeamScore.Columns.Count; c++)
                    {
                        //Cell Alignment
                        DataRow.Cells[c].CellFormat.VerticalAlignment = VerticalAlignment.Middle;
                        //Fill Data in Rows
                        Paragraph p1 = DataRow.Cells[c].AddParagraph();
                        TextRange TR1;
                        if (r == 0)
                            TR1 = p1.AppendText(dgvTeamScore.Columns[c].HeaderText);
                        else
                            TR1 = p1.AppendText(dgvTeamScore.Rows[r - 1].Cells[c].Value.ToString());
                        //Format Cells
                        p1.Format.HorizontalAlignment = Spire.Doc.Documents.HorizontalAlignment.Left;
                        TR1.CharacterFormat.FontName = "微软雅黑";
                        TR1.CharacterFormat.FontSize = (float)10.0;
                    }
                }


                TableRow newRow = table1.Rows[row - 1];
                Paragraph p2 = newRow.Cells[0].AddParagraph();
                TextRange TR2 = p2.AppendText(labScoreTip.Text);
                p2.Format.HorizontalAlignment = Spire.Doc.Documents.HorizontalAlignment.Left;
                TR2.CharacterFormat.FontName = "微软雅黑";
                TR2.CharacterFormat.FontSize = (float)10.0;
                table1.ApplyHorizontalMerge(row - 1, 0, 7);

                for (int i = 0; i < table1.Rows.Count; ++i)
                    table1.Rows[i].Cells[0].Width = (float)87.82;
                for (int i = 0; i < table1.Rows.Count; ++i)
                    table1.Rows[i].Cells[1].Width = (float)48.88;
                for (int i = 0; i < table1.Rows.Count; ++i)
                    table1.Rows[i].Cells[2].Width = (float)81.87;
                for (int i = 0; i < table1.Rows.Count; ++i)
                    table1.Rows[i].Cells[3].Width = (float)41.36;
                for (int i = 0; i < table1.Rows.Count; ++i)
                    table1.Rows[i].Cells[4].Width = (float)41.36;
                for (int i = 0; i < table1.Rows.Count; ++i)
                    table1.Rows[i].Cells[5].Width = (float)41.36;
                for (int i = 0; i < table1.Rows.Count; ++i)
                    table1.Rows[i].Cells[6].Width = (float)41.36;
                for (int i = 0; i < table1.Rows.Count; ++i)
                    table1.Rows[i].Cells[7].Width = (float)34.56;
                //table2信息
                loadDocumentTab();
                Table table2 = section1.AddTable(true);
                row = dgvDocument.Rows.Count + 4;
                col = 6;
                table2.ResetCells(row, col);
                for (int r = 0; r < dgvDocument.Rows.Count + 1; r++)
                {
                    TableRow DataRow = table2.Rows[r];
                    //Row Height
                    DataRow.Height = 20;
                    //C Represents Column.
                    for (int c = 0; c < dgvDocument.Columns.Count; c++)
                    {
                        //Cell Alignment
                        DataRow.Cells[c].CellFormat.VerticalAlignment = VerticalAlignment.Middle;
                        //Fill Data in Rows
                        Paragraph p1 = DataRow.Cells[c].AddParagraph();
                        TextRange TR1;
                        if (r == 0)
                            TR1 = p1.AppendText(dgvDocument.Columns[c].HeaderText);
                        else
                            TR1 = p1.AppendText(dgvDocument.Rows[r - 1].Cells[c].Value.ToString());
                        //Format Cells
                        p1.Format.HorizontalAlignment = Spire.Doc.Documents.HorizontalAlignment.Left;
                        TR1.CharacterFormat.FontName = "微软雅黑";
                        TR1.CharacterFormat.FontSize = (float)10.0;
                    }
                }
                for (int i = 0; i < table2.Rows.Count; ++i)
                    table2.Rows[i].Cells[0].Width = (float)35.98;
                for (int i = 0; i < table2.Rows.Count; ++i)
                    table2.Rows[i].Cells[1].Width = (float)91.50;
                for (int i = 0; i < table2.Rows.Count; ++i)
                    table2.Rows[i].Cells[2].Width = (float)40.51;
                for (int i = 0; i < table2.Rows.Count; ++i)
                    table2.Rows[i].Cells[3].Width = (float)44.19;
                for (int i = 0; i < table2.Rows.Count; ++i)
                    table2.Rows[i].Cells[4].Width = (float)41.19;
                for (int i = 0; i < table2.Rows.Count; ++i)
                    table2.Rows[i].Cells[5].Width = (float)180;
                table2.ApplyHorizontalMerge(row - 3, 0, 5);
                table2.ApplyHorizontalMerge(row - 2, 0, 5);
                table2.ApplyHorizontalMerge(row - 1, 0, 5);
                //倒数第三行
                data = "总评与建议：";
                FROW = table2.Rows[row - 3];
                p = FROW.Cells[0].AddParagraph();
                FROW.Cells[0].CellFormat.VerticalAlignment = VerticalAlignment.Middle;
                p.Format.HorizontalAlignment = Spire.Doc.Documents.HorizontalAlignment.Left;
                TR = p.AppendText(data);
                TR.CharacterFormat.FontName = "微软雅黑";
                TR.CharacterFormat.FontSize = 12;
                TR.CharacterFormat.Bold = true;
                //倒数第二行
                data = group.SelectSingleNode("总评与建议").InnerXml;
                FROW = table2.Rows[row - 2];
                p = FROW.Cells[0].AddParagraph();
                FROW.Cells[0].CellFormat.VerticalAlignment = VerticalAlignment.Middle;
                p.Format.HorizontalAlignment = Spire.Doc.Documents.HorizontalAlignment.Left;
                TR = p.AppendText(data);
                TR.CharacterFormat.FontName = "微软雅黑";
                TR.CharacterFormat.FontSize = 10;
                //倒数第一行
                data = "任课老师签名：               ";
                data += "时间：      ";
                FROW = table2.Rows[row - 1];
                p = FROW.Cells[0].AddParagraph();
                FROW.Cells[0].CellFormat.VerticalAlignment = VerticalAlignment.Middle;
                p.Format.HorizontalAlignment = Spire.Doc.Documents.HorizontalAlignment.Left;
                TR = p.AppendText(data);
                TR.CharacterFormat.FontName = "微软雅黑";
                TR.CharacterFormat.FontSize = 12;
                TR.CharacterFormat.Bold = true;

                data = "年     月     日";
                TR = p.AppendText(data);
                TR.CharacterFormat.FontName = "微软雅黑";
                TR.CharacterFormat.FontSize = 10;
                p.AppendBreak(BreakType.PageBreak);
            }                
            docu.SaveToFile(saveToWord, FileFormat.Html);
            //System.Diagnostics.Process.Start(saveToWord);
            labGroupId.Text = temp;
        }
    }
}
