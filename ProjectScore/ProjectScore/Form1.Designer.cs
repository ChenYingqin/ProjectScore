namespace ProjectScore
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("小组文档分（70%）");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("个人小结分（10%）");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("个人管理分（10%）");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("计划设计阶段（50%）");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("编码测试阶段（50%）");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("个人贡献权重", new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode5});
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("自评互评（40%）");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("教师评分（60%）");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("期中考核（50%）", new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode8});
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("自评互评（40%）");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("教师评分（60%）");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("项目验收（50%）", new System.Windows.Forms.TreeNode[] {
            treeNode10,
            treeNode11});
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("自评互评教师评综合权重", new System.Windows.Forms.TreeNode[] {
            treeNode9,
            treeNode12});
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("小组人数");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("总贡献分", new System.Windows.Forms.TreeNode[] {
            treeNode13,
            treeNode14});
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("个人贡献分（10%）", new System.Windows.Forms.TreeNode[] {
            treeNode6,
            treeNode15});
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("个人总成绩", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode16});
            this.titlePanel1 = new TitlePanel.TitlePanel();
            this.btnConserve = new IButton.IButton();
            this.btnCreateScoreTemplate = new IButton.IButton();
            this.btnLoadtScoreTemplate = new IButton.IButton();
            this.labGroupId = new System.Windows.Forms.Label();
            this.cmsGroup1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.添加小组ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除小组ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加小组成员ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsGroup2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.labCurrentTemplate = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmsDocument1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsDocument2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.添加评分项ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除评分项ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comboBoxEx = new JWBControl.ComboBoxEx();
            this.tabControlEx1 = new WinTabControl.TabControlEx();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupDataView1 = new ProjectScore.GroupDataView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.dgvDocument = new System.Windows.Forms.DataGridView();
            this.Column27 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column28 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column29 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column30 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column31 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column32 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.dgvTeacherScore2 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvTeacherScore1 = new System.Windows.Forms.DataGridView();
            this.Column33 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column34 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column35 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column36 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column37 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column38 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column39 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.dgvMutual2 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvMutual = new System.Windows.Forms.DataGridView();
            this.Column40 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column41 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column42 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column43 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column44 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column45 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column46 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dgvContribute2 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvContribute = new System.Windows.Forms.DataGridView();
            this.Column22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column23 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column24 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column25 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column26 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.labScoreTip = new System.Windows.Forms.Label();
            this.btnAdvise = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxAdvise = new JWBControl.TextBoxEx();
            this.btnCalcPersonal = new System.Windows.Forms.Button();
            this.btnCalcGroup = new System.Windows.Forms.Button();
            this.dgvTeamScore = new System.Windows.Forms.DataGridView();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsGroup1.SuspendLayout();
            this.cmsGroup2.SuspendLayout();
            this.cmsDocument1.SuspendLayout();
            this.cmsDocument2.SuspendLayout();
            this.tabControlEx1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupDataView1)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocument)).BeginInit();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeacherScore2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeacherScore1)).BeginInit();
            this.tabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMutual2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMutual)).BeginInit();
            this.tabPage7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContribute2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContribute)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeamScore)).BeginInit();
            this.SuspendLayout();
            // 
            // titlePanel1
            // 
            this.titlePanel1.BackColor = System.Drawing.Color.Transparent;
            this.titlePanel1.BorderColor = System.Drawing.Color.Gray;
            this.titlePanel1.ColorLabelHeigt = 20;
            this.titlePanel1.ColorLabelWidth = 10;
            this.titlePanel1.LabelColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.titlePanel1.Location = new System.Drawing.Point(35, 21);
            this.titlePanel1.Name = "titlePanel1";
            this.titlePanel1.PanelColor = System.Drawing.Color.White;
            this.titlePanel1.Size = new System.Drawing.Size(184, 521);
            this.titlePanel1.TabIndex = 0;
            this.titlePanel1.Title = "菜单";
            this.titlePanel1.TitleFont = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.titlePanel1.TitleForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // btnConserve
            // 
            this.btnConserve.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnConserve.BackColor = System.Drawing.Color.Transparent;
            this.btnConserve.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnConserve.BtnStyle = IButton.ButtonStyle.Save;
            this.btnConserve.EnableImage = ((System.Drawing.Image)(resources.GetObject("btnConserve.EnableImage")));
            this.btnConserve.FlatAppearance.BorderSize = 0;
            this.btnConserve.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConserve.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnConserve.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.btnConserve.FrameColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(102)))), ((int)(((byte)(128)))));
            this.btnConserve.GapBetweenImgAndLeft = 20;
            this.btnConserve.GapBetweenImgAndText = 30;
            this.btnConserve.Image = ((System.Drawing.Image)(resources.GetObject("btnConserve.Image")));
            this.btnConserve.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConserve.Location = new System.Drawing.Point(57, 480);
            this.btnConserve.Name = "btnConserve";
            this.btnConserve.OnMouseDownColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            this.btnConserve.OnMouseEnterColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            this.btnConserve.Radius = 3F;
            this.btnConserve.Size = new System.Drawing.Size(146, 35);
            this.btnConserve.TabIndex = 2;
            this.btnConserve.Text = "保存到word";
            this.btnConserve.UseVisualStyleBackColor = false;
            this.btnConserve.Click += new System.EventHandler(this.btnConserve_Click);
            // 
            // btnCreateScoreTemplate
            // 
            this.btnCreateScoreTemplate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCreateScoreTemplate.BackColor = System.Drawing.Color.Transparent;
            this.btnCreateScoreTemplate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCreateScoreTemplate.BtnStyle = IButton.ButtonStyle.Other;
            this.btnCreateScoreTemplate.EnableImage = ((System.Drawing.Image)(resources.GetObject("btnCreateScoreTemplate.EnableImage")));
            this.btnCreateScoreTemplate.FlatAppearance.BorderSize = 0;
            this.btnCreateScoreTemplate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateScoreTemplate.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnCreateScoreTemplate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.btnCreateScoreTemplate.FrameColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(116)))), ((int)(((byte)(201)))));
            this.btnCreateScoreTemplate.GapBetweenImgAndLeft = 0;
            this.btnCreateScoreTemplate.GapBetweenImgAndText = 0;
            this.btnCreateScoreTemplate.Image = ((System.Drawing.Image)(resources.GetObject("btnCreateScoreTemplate.Image")));
            this.btnCreateScoreTemplate.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCreateScoreTemplate.Location = new System.Drawing.Point(57, 139);
            this.btnCreateScoreTemplate.Name = "btnCreateScoreTemplate";
            this.btnCreateScoreTemplate.OnMouseDownColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(241)))), ((int)(((byte)(245)))));
            this.btnCreateScoreTemplate.OnMouseEnterColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(241)))), ((int)(((byte)(249)))));
            this.btnCreateScoreTemplate.Radius = 4F;
            this.btnCreateScoreTemplate.Size = new System.Drawing.Size(130, 35);
            this.btnCreateScoreTemplate.TabIndex = 53;
            this.btnCreateScoreTemplate.Text = "创建评分模板";
            this.btnCreateScoreTemplate.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCreateScoreTemplate.UseVisualStyleBackColor = false;
            this.btnCreateScoreTemplate.Click += new System.EventHandler(this.btnCreateScoreTemplate_Click);
            // 
            // btnLoadtScoreTemplate
            // 
            this.btnLoadtScoreTemplate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnLoadtScoreTemplate.BackColor = System.Drawing.Color.Transparent;
            this.btnLoadtScoreTemplate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnLoadtScoreTemplate.BtnStyle = IButton.ButtonStyle.Other;
            this.btnLoadtScoreTemplate.EnableImage = ((System.Drawing.Image)(resources.GetObject("btnLoadtScoreTemplate.EnableImage")));
            this.btnLoadtScoreTemplate.FlatAppearance.BorderSize = 0;
            this.btnLoadtScoreTemplate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadtScoreTemplate.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnLoadtScoreTemplate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.btnLoadtScoreTemplate.FrameColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(116)))), ((int)(((byte)(201)))));
            this.btnLoadtScoreTemplate.GapBetweenImgAndLeft = 0;
            this.btnLoadtScoreTemplate.GapBetweenImgAndText = 0;
            this.btnLoadtScoreTemplate.Image = ((System.Drawing.Image)(resources.GetObject("btnLoadtScoreTemplate.Image")));
            this.btnLoadtScoreTemplate.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnLoadtScoreTemplate.Location = new System.Drawing.Point(57, 202);
            this.btnLoadtScoreTemplate.Name = "btnLoadtScoreTemplate";
            this.btnLoadtScoreTemplate.OnMouseDownColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(241)))), ((int)(((byte)(245)))));
            this.btnLoadtScoreTemplate.OnMouseEnterColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(241)))), ((int)(((byte)(249)))));
            this.btnLoadtScoreTemplate.Radius = 4F;
            this.btnLoadtScoreTemplate.Size = new System.Drawing.Size(130, 35);
            this.btnLoadtScoreTemplate.TabIndex = 54;
            this.btnLoadtScoreTemplate.Text = "加载评分模板";
            this.btnLoadtScoreTemplate.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnLoadtScoreTemplate.UseVisualStyleBackColor = false;
            this.btnLoadtScoreTemplate.Click += new System.EventHandler(this.btnLoadtScoreTemplate_Click);
            // 
            // labGroupId
            // 
            this.labGroupId.AutoSize = true;
            this.labGroupId.BackColor = System.Drawing.Color.White;
            this.labGroupId.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labGroupId.Location = new System.Drawing.Point(117, 266);
            this.labGroupId.Name = "labGroupId";
            this.labGroupId.Size = new System.Drawing.Size(26, 21);
            this.labGroupId.TabIndex = 170;
            this.labGroupId.Text = "无";
            // 
            // cmsGroup1
            // 
            this.cmsGroup1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加小组ToolStripMenuItem,
            this.删除小组ToolStripMenuItem,
            this.添加小组成员ToolStripMenuItem});
            this.cmsGroup1.Name = "cmsGroup1";
            this.cmsGroup1.Size = new System.Drawing.Size(149, 70);
            this.cmsGroup1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.cmsGroup1_ItemClicked);
            // 
            // 添加小组ToolStripMenuItem
            // 
            this.添加小组ToolStripMenuItem.MergeIndex = 0;
            this.添加小组ToolStripMenuItem.Name = "添加小组ToolStripMenuItem";
            this.添加小组ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.添加小组ToolStripMenuItem.Text = "添加小组";
            // 
            // 删除小组ToolStripMenuItem
            // 
            this.删除小组ToolStripMenuItem.MergeIndex = 1;
            this.删除小组ToolStripMenuItem.Name = "删除小组ToolStripMenuItem";
            this.删除小组ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.删除小组ToolStripMenuItem.Text = "删除小组";
            // 
            // 添加小组成员ToolStripMenuItem
            // 
            this.添加小组成员ToolStripMenuItem.MergeIndex = 2;
            this.添加小组成员ToolStripMenuItem.Name = "添加小组成员ToolStripMenuItem";
            this.添加小组成员ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.添加小组成员ToolStripMenuItem.Text = "添加小组成员";
            // 
            // cmsGroup2
            // 
            this.cmsGroup2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.cmsGroup2.Name = "cmsGroup2";
            this.cmsGroup2.Size = new System.Drawing.Size(101, 26);
            this.cmsGroup2.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.cmsGroup2_ItemClicked);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.MergeIndex = 0;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Overflow = System.Windows.Forms.ToolStripItemOverflow.Always;
            this.toolStripMenuItem1.Size = new System.Drawing.Size(100, 22);
            this.toolStripMenuItem1.Text = "删除";
            // 
            // labCurrentTemplate
            // 
            this.labCurrentTemplate.AutoSize = true;
            this.labCurrentTemplate.BackColor = System.Drawing.Color.White;
            this.labCurrentTemplate.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labCurrentTemplate.Location = new System.Drawing.Point(53, 91);
            this.labCurrentTemplate.Name = "labCurrentTemplate";
            this.labCurrentTemplate.Size = new System.Drawing.Size(121, 20);
            this.labCurrentTemplate.TabIndex = 173;
            this.labCurrentTemplate.Text = "请先创建评分模板";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(53, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 21);
            this.label2.TabIndex = 174;
            this.label2.Text = "评分模板：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(59, 266);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 21);
            this.label3.TabIndex = 175;
            this.label3.Text = "组号：";
            // 
            // cmsDocument1
            // 
            this.cmsDocument1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4});
            this.cmsDocument1.Name = "contextMenuStrip1";
            this.cmsDocument1.Size = new System.Drawing.Size(149, 70);
            this.cmsDocument1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.cmsDocument1_ItemClicked);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.MergeIndex = 0;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(148, 22);
            this.toolStripMenuItem2.Text = "添加评分模块";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.MergeIndex = 1;
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(148, 22);
            this.toolStripMenuItem3.Text = "删除评分模块";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.MergeIndex = 2;
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(148, 22);
            this.toolStripMenuItem4.Text = "添加评分项";
            // 
            // cmsDocument2
            // 
            this.cmsDocument2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加评分项ToolStripMenuItem,
            this.删除评分项ToolStripMenuItem});
            this.cmsDocument2.Name = "contextMenuStrip2";
            this.cmsDocument2.Size = new System.Drawing.Size(137, 48);
            this.cmsDocument2.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.cmsDocument2_ItemClicked);
            // 
            // 添加评分项ToolStripMenuItem
            // 
            this.添加评分项ToolStripMenuItem.MergeIndex = 0;
            this.添加评分项ToolStripMenuItem.Name = "添加评分项ToolStripMenuItem";
            this.添加评分项ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.添加评分项ToolStripMenuItem.Text = "添加评分项";
            // 
            // 删除评分项ToolStripMenuItem
            // 
            this.删除评分项ToolStripMenuItem.MergeIndex = 1;
            this.删除评分项ToolStripMenuItem.Name = "删除评分项ToolStripMenuItem";
            this.删除评分项ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.删除评分项ToolStripMenuItem.Text = "删除评分项";
            // 
            // comboBoxEx
            // 
            this.comboBoxEx.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboBoxEx.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxEx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEx.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxEx.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.comboBoxEx.FormattingEnabled = true;
            this.comboBoxEx.Location = new System.Drawing.Point(57, 317);
            this.comboBoxEx.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("comboBoxEx.MouseDownImage")));
            this.comboBoxEx.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("comboBoxEx.MouseMoveImage")));
            this.comboBoxEx.Name = "comboBoxEx";
            this.comboBoxEx.NormalImage = ((System.Drawing.Image)(resources.GetObject("comboBoxEx.NormalImage")));
            this.comboBoxEx.Size = new System.Drawing.Size(136, 28);
            this.comboBoxEx.TabIndex = 169;
            this.comboBoxEx.SelectedIndexChanged += new System.EventHandler(this.comboBoxEx_SelectedIndexChanged);
            // 
            // tabControlEx1
            // 
            this.tabControlEx1.BackTabPageImage = null;
            this.tabControlEx1.Controls.Add(this.tabPage1);
            this.tabControlEx1.Controls.Add(this.tabPage4);
            this.tabControlEx1.Controls.Add(this.tabPage5);
            this.tabControlEx1.Controls.Add(this.tabPage6);
            this.tabControlEx1.Controls.Add(this.tabPage7);
            this.tabControlEx1.Controls.Add(this.tabPage2);
            this.tabControlEx1.Controls.Add(this.tabPage3);
            this.tabControlEx1.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControlEx1.ItemSize = new System.Drawing.Size(114, 25);
            this.tabControlEx1.Location = new System.Drawing.Point(225, 12);
            this.tabControlEx1.Name = "tabControlEx1";
            this.tabControlEx1.SelectedIndex = 0;
            this.tabControlEx1.Size = new System.Drawing.Size(828, 530);
            this.tabControlEx1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControlEx1.TabIndex = 1;
            this.tabControlEx1.TabMoveColorEnd = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(116)))), ((int)(((byte)(201)))));
            this.tabControlEx1.TabMoveColorState = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(116)))), ((int)(((byte)(201)))));
            this.tabControlEx1.TabOffColorEnd = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(116)))), ((int)(((byte)(201)))));
            this.tabControlEx1.TabOffColorState = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(116)))), ((int)(((byte)(201)))));
            this.tabControlEx1.TabOnColorEnd = System.Drawing.Color.White;
            this.tabControlEx1.SelectedIndexChanged += new System.EventHandler(this.tabControlEx1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupDataView1);
            this.tabPage1.Location = new System.Drawing.Point(1, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(826, 500);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "分组情况表";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupDataView1
            // 
            this.groupDataView1.ColumnHeadersHeight = 32;
            this.groupDataView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9});
            this.groupDataView1.Location = new System.Drawing.Point(3, 28);
            this.groupDataView1.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("groupDataView1.MergeColumnNames")));
            this.groupDataView1.Name = "groupDataView1";
            this.groupDataView1.RowTemplate.Height = 28;
            this.groupDataView1.Size = new System.Drawing.Size(820, 405);
            this.groupDataView1.TabIndex = 123;
            this.groupDataView1.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.groupDataView1_CellBeginEdit);
            this.groupDataView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.groupDataView1_CellContentClick);
            this.groupDataView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.groupDataView1_CellEndEdit);
            this.groupDataView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.groupDataView1_CellMouseClick);
            this.groupDataView1.DoubleClick += new System.EventHandler(this.groupDataView1_DoubleClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "1";
            this.Column1.HeaderText = "分组号";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "2";
            this.Column2.HeaderText = "项目名称";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.DataPropertyName = "3";
            this.Column3.HeaderText = "成员学号";
            this.Column3.Name = "Column3";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "姓名";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "分工";
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.HeaderText = "电话";
            this.Column7.Name = "Column7";
            // 
            // Column8
            // 
            this.Column8.HeaderText = "email";
            this.Column8.Name = "Column8";
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Column9";
            this.Column9.Name = "Column9";
            this.Column9.Visible = false;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.dgvDocument);
            this.tabPage4.Location = new System.Drawing.Point(1, 29);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(826, 500);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "文档评分表";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // dgvDocument
            // 
            this.dgvDocument.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDocument.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDocument.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column27,
            this.Column28,
            this.Column29,
            this.Column30,
            this.Column31,
            this.Column32});
            this.dgvDocument.Location = new System.Drawing.Point(5, 10);
            this.dgvDocument.Margin = new System.Windows.Forms.Padding(5);
            this.dgvDocument.Name = "dgvDocument";
            this.dgvDocument.RowTemplate.Height = 23;
            this.dgvDocument.Size = new System.Drawing.Size(816, 485);
            this.dgvDocument.TabIndex = 1;
            this.dgvDocument.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDocument_CellEndEdit);
            this.dgvDocument.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvDocument_CellMouseClick);
            this.dgvDocument.DoubleClick += new System.EventHandler(this.dgvDocument_DoubleClick);
            // 
            // Column27
            // 
            this.Column27.HeaderText = "序号";
            this.Column27.Name = "Column27";
            // 
            // Column28
            // 
            this.Column28.HeaderText = "评分指标";
            this.Column28.Name = "Column28";
            // 
            // Column29
            // 
            this.Column29.HeaderText = "权重";
            this.Column29.Name = "Column29";
            // 
            // Column30
            // 
            this.Column30.HeaderText = "得分";
            this.Column30.Name = "Column30";
            // 
            // Column31
            // 
            this.Column31.HeaderText = "加权分";
            this.Column31.Name = "Column31";
            // 
            // Column32
            // 
            this.Column32.HeaderText = "备注";
            this.Column32.Name = "Column32";
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.dgvTeacherScore2);
            this.tabPage5.Controls.Add(this.label4);
            this.tabPage5.Controls.Add(this.label1);
            this.tabPage5.Controls.Add(this.dgvTeacherScore1);
            this.tabPage5.Location = new System.Drawing.Point(1, 29);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(826, 500);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "教师评分表";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // dgvTeacherScore2
            // 
            this.dgvTeacherScore2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTeacherScore2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTeacherScore2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7});
            this.dgvTeacherScore2.Location = new System.Drawing.Point(0, 285);
            this.dgvTeacherScore2.Margin = new System.Windows.Forms.Padding(5);
            this.dgvTeacherScore2.Name = "dgvTeacherScore2";
            this.dgvTeacherScore2.RowTemplate.Height = 23;
            this.dgvTeacherScore2.Size = new System.Drawing.Size(816, 216);
            this.dgvTeacherScore2.TabIndex = 4;
            this.dgvTeacherScore2.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTeacherScore2_CellEndEdit);
            this.dgvTeacherScore2.DoubleClick += new System.EventHandler(this.dgvTeacherScore2_DoubleClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "组号";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "报告人";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "编码实现  （30%）";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "软件测试   （40%）";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "用户手册  （20%）";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "报告陈述  （10%）";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "总分";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 260);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "项目验收";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "期中考核";
            // 
            // dgvTeacherScore1
            // 
            this.dgvTeacherScore1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTeacherScore1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTeacherScore1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column33,
            this.Column34,
            this.Column35,
            this.Column36,
            this.Column37,
            this.Column38,
            this.Column39});
            this.dgvTeacherScore1.Location = new System.Drawing.Point(-1, 35);
            this.dgvTeacherScore1.Margin = new System.Windows.Forms.Padding(5);
            this.dgvTeacherScore1.Name = "dgvTeacherScore1";
            this.dgvTeacherScore1.RowTemplate.Height = 23;
            this.dgvTeacherScore1.Size = new System.Drawing.Size(816, 220);
            this.dgvTeacherScore1.TabIndex = 1;
            this.dgvTeacherScore1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTeacherScore_CellEndEdit);
            this.dgvTeacherScore1.DoubleClick += new System.EventHandler(this.dgvTeacherScore_DoubleClick);
            // 
            // Column33
            // 
            this.Column33.HeaderText = "组号";
            this.Column33.Name = "Column33";
            // 
            // Column34
            // 
            this.Column34.HeaderText = "报告人";
            this.Column34.Name = "Column34";
            // 
            // Column35
            // 
            this.Column35.HeaderText = "软件计划   （20%）";
            this.Column35.Name = "Column35";
            // 
            // Column36
            // 
            this.Column36.HeaderText = "需求分析   （30%）";
            this.Column36.Name = "Column36";
            // 
            // Column37
            // 
            this.Column37.HeaderText = "软件设计   （40%）";
            this.Column37.Name = "Column37";
            // 
            // Column38
            // 
            this.Column38.HeaderText = "报告陈述   （10%）";
            this.Column38.Name = "Column38";
            // 
            // Column39
            // 
            this.Column39.HeaderText = "总分";
            this.Column39.Name = "Column39";
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.dgvMutual2);
            this.tabPage6.Controls.Add(this.label6);
            this.tabPage6.Controls.Add(this.label5);
            this.tabPage6.Controls.Add(this.dgvMutual);
            this.tabPage6.Location = new System.Drawing.Point(1, 29);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(826, 500);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "自评互评表";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // dgvMutual2
            // 
            this.dgvMutual2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMutual2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMutual2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12,
            this.dataGridViewTextBoxColumn13,
            this.dataGridViewTextBoxColumn14});
            this.dgvMutual2.Location = new System.Drawing.Point(-1, 290);
            this.dgvMutual2.Margin = new System.Windows.Forms.Padding(5);
            this.dgvMutual2.Name = "dgvMutual2";
            this.dgvMutual2.RowTemplate.Height = 23;
            this.dgvMutual2.Size = new System.Drawing.Size(816, 210);
            this.dgvMutual2.TabIndex = 5;
            this.dgvMutual2.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMutual2_CellEndEdit);
            this.dgvMutual2.DoubleClick += new System.EventHandler(this.dgvMutual2_DoubleClick);
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "组号";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "报告人";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.HeaderText = "编码实现    （30%）";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.HeaderText = "软件测试    （40%）";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.HeaderText = "用户手册    （20%）";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.HeaderText = "报告陈述    （10%）";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.HeaderText = "总分";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 265);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 20);
            this.label6.TabIndex = 4;
            this.label6.Text = "项目验收";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 20);
            this.label5.TabIndex = 3;
            this.label5.Text = "期中考核";
            // 
            // dgvMutual
            // 
            this.dgvMutual.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMutual.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMutual.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column40,
            this.Column41,
            this.Column42,
            this.Column43,
            this.Column44,
            this.Column45,
            this.Column46});
            this.dgvMutual.Location = new System.Drawing.Point(3, 31);
            this.dgvMutual.Name = "dgvMutual";
            this.dgvMutual.RowTemplate.Height = 23;
            this.dgvMutual.Size = new System.Drawing.Size(824, 215);
            this.dgvMutual.TabIndex = 0;
            this.dgvMutual.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMutual_CellEndEdit);
            this.dgvMutual.DoubleClick += new System.EventHandler(this.dgvMutual_DoubleClick);
            // 
            // Column40
            // 
            this.Column40.HeaderText = "组号";
            this.Column40.Name = "Column40";
            // 
            // Column41
            // 
            this.Column41.HeaderText = "报告人";
            this.Column41.Name = "Column41";
            // 
            // Column42
            // 
            this.Column42.HeaderText = "软件计划    （20%）";
            this.Column42.Name = "Column42";
            // 
            // Column43
            // 
            this.Column43.HeaderText = "需求分析    （30%）";
            this.Column43.Name = "Column43";
            // 
            // Column44
            // 
            this.Column44.HeaderText = "软件设计    （40%）";
            this.Column44.Name = "Column44";
            // 
            // Column45
            // 
            this.Column45.HeaderText = "报告陈述    （10%）";
            this.Column45.Name = "Column45";
            // 
            // Column46
            // 
            this.Column46.HeaderText = "总分";
            this.Column46.Name = "Column46";
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.label8);
            this.tabPage7.Controls.Add(this.label7);
            this.tabPage7.Controls.Add(this.dgvContribute2);
            this.tabPage7.Controls.Add(this.dgvContribute);
            this.tabPage7.Location = new System.Drawing.Point(1, 29);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Size = new System.Drawing.Size(826, 500);
            this.tabPage7.TabIndex = 6;
            this.tabPage7.Text = "小组贡献表";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(3, 267);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(113, 21);
            this.label8.TabIndex = 4;
            this.label8.Text = "编码-测试阶段";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(3, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(113, 21);
            this.label7.TabIndex = 3;
            this.label7.Text = "计划-设计阶段";
            // 
            // dgvContribute2
            // 
            this.dgvContribute2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvContribute2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvContribute2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn15,
            this.dataGridViewTextBoxColumn16,
            this.dataGridViewTextBoxColumn17,
            this.dataGridViewTextBoxColumn18,
            this.dataGridViewTextBoxColumn19});
            this.dgvContribute2.Location = new System.Drawing.Point(5, 293);
            this.dgvContribute2.Margin = new System.Windows.Forms.Padding(5);
            this.dgvContribute2.Name = "dgvContribute2";
            this.dgvContribute2.RowTemplate.Height = 23;
            this.dgvContribute2.Size = new System.Drawing.Size(816, 202);
            this.dgvContribute2.TabIndex = 2;
            this.dgvContribute2.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvContribute2_CellEndEdit);
            this.dgvContribute2.DoubleClick += new System.EventHandler(this.dgvContribute2_DoubleClick);
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.HeaderText = "学号";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.HeaderText = "姓名";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.HeaderText = "角色";
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.HeaderText = "贡献分";
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            // 
            // dataGridViewTextBoxColumn19
            // 
            this.dataGridViewTextBoxColumn19.HeaderText = "主要贡献";
            this.dataGridViewTextBoxColumn19.Name = "dataGridViewTextBoxColumn19";
            // 
            // dgvContribute
            // 
            this.dgvContribute.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvContribute.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvContribute.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column22,
            this.Column23,
            this.Column24,
            this.Column25,
            this.Column26});
            this.dgvContribute.Location = new System.Drawing.Point(5, 44);
            this.dgvContribute.Margin = new System.Windows.Forms.Padding(5);
            this.dgvContribute.Name = "dgvContribute";
            this.dgvContribute.RowTemplate.Height = 23;
            this.dgvContribute.Size = new System.Drawing.Size(816, 202);
            this.dgvContribute.TabIndex = 1;
            this.dgvContribute.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvContribute_CellEndEdit);
            this.dgvContribute.DoubleClick += new System.EventHandler(this.dgvContribute_DoubleClick);
            // 
            // Column22
            // 
            this.Column22.HeaderText = "学号";
            this.Column22.Name = "Column22";
            // 
            // Column23
            // 
            this.Column23.HeaderText = "姓名";
            this.Column23.Name = "Column23";
            // 
            // Column24
            // 
            this.Column24.HeaderText = "角色";
            this.Column24.Name = "Column24";
            // 
            // Column25
            // 
            this.Column25.HeaderText = "贡献分";
            this.Column25.Name = "Column25";
            // 
            // Column26
            // 
            this.Column26.HeaderText = "主要贡献";
            this.Column26.Name = "Column26";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.treeView1);
            this.tabPage2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabPage2.Location = new System.Drawing.Point(1, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(826, 500);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "设置评分权重";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // treeView1
            // 
            this.treeView1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.treeView1.Location = new System.Drawing.Point(5, 29);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "节点1";
            treeNode1.Tag = "小组文档分";
            treeNode1.Text = "小组文档分（70%）";
            treeNode2.Name = "节点2";
            treeNode2.Tag = "个人小结分";
            treeNode2.Text = "个人小结分（10%）";
            treeNode3.Name = "节点3";
            treeNode3.Tag = "个人管理分";
            treeNode3.Text = "个人管理分（10%）";
            treeNode4.Name = "节点0";
            treeNode4.Tag = "计划设计阶段";
            treeNode4.Text = "计划设计阶段（50%）";
            treeNode5.Name = "节点1";
            treeNode5.Tag = "编码测试阶段";
            treeNode5.Text = "编码测试阶段（50%）";
            treeNode6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            treeNode6.Name = "节点5";
            treeNode6.Tag = "个人贡献权重";
            treeNode6.Text = "个人贡献权重";
            treeNode7.Name = "节点17";
            treeNode7.Tag = "自评互评";
            treeNode7.Text = "自评互评（40%）";
            treeNode8.Name = "节点18";
            treeNode8.Tag = "教师评分";
            treeNode8.Text = "教师评分（60%）";
            treeNode9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            treeNode9.Name = "节点15";
            treeNode9.Tag = "期中考核";
            treeNode9.Text = "期中考核（50%）";
            treeNode10.Name = "节点19";
            treeNode10.Tag = "自评互评";
            treeNode10.Text = "自评互评（40%）";
            treeNode11.Name = "节点20";
            treeNode11.Tag = "教师评分";
            treeNode11.Text = "教师评分（60%）";
            treeNode12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            treeNode12.Name = "节点16";
            treeNode12.Tag = "项目验收";
            treeNode12.Text = "项目验收（50%）";
            treeNode13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            treeNode13.Name = "节点13";
            treeNode13.Tag = "自评互评教师评综合权重";
            treeNode13.Text = "自评互评教师评综合权重";
            treeNode14.Name = "节点14";
            treeNode14.Text = "小组人数";
            treeNode15.Name = "节点6";
            treeNode15.Text = "总贡献分";
            treeNode16.Name = "节点4";
            treeNode16.Tag = "个人贡献分";
            treeNode16.Text = "个人贡献分（10%）";
            treeNode17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            treeNode17.ForeColor = System.Drawing.Color.Black;
            treeNode17.Name = "节点0";
            treeNode17.Tag = "个人总成绩";
            treeNode17.Text = "个人总成绩";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode17});
            this.treeView1.Size = new System.Drawing.Size(342, 468);
            this.treeView1.TabIndex = 6;
            this.treeView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseClick);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.labScoreTip);
            this.tabPage3.Controls.Add(this.btnAdvise);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.textBoxAdvise);
            this.tabPage3.Controls.Add(this.btnCalcPersonal);
            this.tabPage3.Controls.Add(this.btnCalcGroup);
            this.tabPage3.Controls.Add(this.dgvTeamScore);
            this.tabPage3.Location = new System.Drawing.Point(1, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(826, 500);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "小组成绩表";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // labScoreTip
            // 
            this.labScoreTip.AutoSize = true;
            this.labScoreTip.BackColor = System.Drawing.Color.Yellow;
            this.labScoreTip.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labScoreTip.Location = new System.Drawing.Point(25, 262);
            this.labScoreTip.Name = "labScoreTip";
            this.labScoreTip.Size = new System.Drawing.Size(783, 21);
            this.labScoreTip.TabIndex = 16;
            this.labScoreTip.Text = "注：成绩 1(70%)=小组分；成绩 2(10%)=个人小结分；成绩 3(10%)=个人管理分；成绩 4(10%)=个人贡献分 ";
            // 
            // btnAdvise
            // 
            this.btnAdvise.BackColor = System.Drawing.Color.White;
            this.btnAdvise.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAdvise.Location = new System.Drawing.Point(666, 455);
            this.btnAdvise.Name = "btnAdvise";
            this.btnAdvise.Size = new System.Drawing.Size(84, 32);
            this.btnAdvise.TabIndex = 15;
            this.btnAdvise.Text = "保存";
            this.btnAdvise.UseVisualStyleBackColor = false;
            this.btnAdvise.Click += new System.EventHandler(this.btnAdvise_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(25, 311);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(90, 21);
            this.label9.TabIndex = 14;
            this.label9.Text = "总评与建议";
            // 
            // textBoxAdvise
            // 
            this.textBoxAdvise.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBoxAdvise.Br = System.Drawing.Color.White;
            this.textBoxAdvise.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxAdvise.Location = new System.Drawing.Point(19, 344);
            this.textBoxAdvise.Mutiline = true;
            this.textBoxAdvise.Name = "textBoxAdvise";
            this.textBoxAdvise.OffColor = System.Drawing.Color.Empty;
            this.textBoxAdvise.OnColor = System.Drawing.Color.Empty;
            this.textBoxAdvise.Radius = 0;
            this.textBoxAdvise.Size = new System.Drawing.Size(641, 143);
            this.textBoxAdvise.TabIndex = 13;
            // 
            // btnCalcPersonal
            // 
            this.btnCalcPersonal.BackColor = System.Drawing.Color.White;
            this.btnCalcPersonal.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCalcPersonal.Location = new System.Drawing.Point(691, 300);
            this.btnCalcPersonal.Name = "btnCalcPersonal";
            this.btnCalcPersonal.Size = new System.Drawing.Size(125, 32);
            this.btnCalcPersonal.TabIndex = 3;
            this.btnCalcPersonal.Text = "个人成绩计算";
            this.btnCalcPersonal.UseVisualStyleBackColor = false;
            this.btnCalcPersonal.Click += new System.EventHandler(this.btnCalcPersonal_Click);
            // 
            // btnCalcGroup
            // 
            this.btnCalcGroup.BackColor = System.Drawing.Color.White;
            this.btnCalcGroup.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCalcGroup.Location = new System.Drawing.Point(544, 300);
            this.btnCalcGroup.Name = "btnCalcGroup";
            this.btnCalcGroup.Size = new System.Drawing.Size(116, 32);
            this.btnCalcGroup.TabIndex = 2;
            this.btnCalcGroup.Text = "小组成绩计算";
            this.btnCalcGroup.UseVisualStyleBackColor = false;
            this.btnCalcGroup.Click += new System.EventHandler(this.btnCalcGroup_Click);
            // 
            // dgvTeamScore
            // 
            this.dgvTeamScore.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTeamScore.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTeamScore.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column13,
            this.Column14,
            this.Column15,
            this.Column16,
            this.Column17,
            this.Column18,
            this.Column19,
            this.Column21});
            this.dgvTeamScore.Location = new System.Drawing.Point(0, 5);
            this.dgvTeamScore.Margin = new System.Windows.Forms.Padding(5);
            this.dgvTeamScore.Name = "dgvTeamScore";
            this.dgvTeamScore.RowTemplate.Height = 23;
            this.dgvTeamScore.Size = new System.Drawing.Size(816, 252);
            this.dgvTeamScore.TabIndex = 1;
            this.dgvTeamScore.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTeamScore_CellEndEdit);
            this.dgvTeamScore.DoubleClick += new System.EventHandler(this.dgvTeamScore_DoubleClick);
            // 
            // Column13
            // 
            this.Column13.HeaderText = "学号";
            this.Column13.Name = "Column13";
            // 
            // Column14
            // 
            this.Column14.HeaderText = "姓名";
            this.Column14.Name = "Column14";
            // 
            // Column15
            // 
            this.Column15.HeaderText = "角色";
            this.Column15.Name = "Column15";
            // 
            // Column16
            // 
            this.Column16.HeaderText = "成绩1";
            this.Column16.Name = "Column16";
            // 
            // Column17
            // 
            this.Column17.HeaderText = "成绩2";
            this.Column17.Name = "Column17";
            // 
            // Column18
            // 
            this.Column18.HeaderText = "成绩3";
            this.Column18.Name = "Column18";
            // 
            // Column19
            // 
            this.Column19.HeaderText = "成绩4";
            this.Column19.Name = "Column19";
            // 
            // Column21
            // 
            this.Column21.HeaderText = "总评";
            this.Column21.Name = "Column21";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1081, 581);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labCurrentTemplate);
            this.Controls.Add(this.labGroupId);
            this.Controls.Add(this.comboBoxEx);
            this.Controls.Add(this.btnConserve);
            this.Controls.Add(this.btnCreateScoreTemplate);
            this.Controls.Add(this.btnLoadtScoreTemplate);
            this.Controls.Add(this.titlePanel1);
            this.Controls.Add(this.tabControlEx1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "课程实践项目评分系统";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.cmsGroup1.ResumeLayout(false);
            this.cmsGroup2.ResumeLayout(false);
            this.cmsDocument1.ResumeLayout(false);
            this.cmsDocument2.ResumeLayout(false);
            this.tabControlEx1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupDataView1)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocument)).EndInit();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeacherScore2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeacherScore1)).EndInit();
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMutual2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMutual)).EndInit();
            this.tabPage7.ResumeLayout(false);
            this.tabPage7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContribute2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContribute)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeamScore)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TitlePanel.TitlePanel titlePanel1;
        private WinTabControl.TabControlEx tabControlEx1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.TabPage tabPage7;
        private IButton.IButton btnConserve;
        private IButton.IButton btnCreateScoreTemplate;
        private IButton.IButton btnLoadtScoreTemplate;
        private JWBControl.ComboBoxEx comboBoxEx;
        private System.Windows.Forms.Label labGroupId;
        private GroupDataView groupDataView1;
        private System.Windows.Forms.ContextMenuStrip cmsGroup1;
        private System.Windows.Forms.ToolStripMenuItem 添加小组ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除小组ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 添加小组成员ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmsGroup2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.Label labCurrentTemplate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvTeamScore;
        private System.Windows.Forms.DataGridView dgvContribute;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column22;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column23;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column24;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column25;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column26;
        private System.Windows.Forms.DataGridView dgvDocument;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column27;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column28;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column29;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column30;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column31;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column32;
        private System.Windows.Forms.ContextMenuStrip cmsDocument1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ContextMenuStrip cmsDocument2;
        private System.Windows.Forms.ToolStripMenuItem 添加评分项ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除评分项ToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgvTeacherScore1;
        private System.Windows.Forms.DataGridView dgvMutual;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.DataGridView dgvTeacherScore2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvMutual2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCalcPersonal;
        private System.Windows.Forms.Button btnCalcGroup;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dgvContribute2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;
        private System.Windows.Forms.Button btnAdvise;
        private System.Windows.Forms.Label label9;
        private JWBControl.TextBoxEx textBoxAdvise;
        private System.Windows.Forms.Label labScoreTip;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column15;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column16;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column17;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column18;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column19;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column21;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column33;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column34;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column35;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column36;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column37;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column38;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column39;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column40;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column41;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column42;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column43;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column44;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column45;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column46;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
    }
}

