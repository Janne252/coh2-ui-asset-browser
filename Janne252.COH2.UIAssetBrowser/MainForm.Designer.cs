namespace Janne252.COH2.UIAssetBrowser
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip_mainForm = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator_beforeExit = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearMemoryToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.loadAllParentImagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.treeView_extImages = new System.Windows.Forms.TreeView();
            this.contextMenuStrip_treeView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exportToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList_icons = new System.Windows.Forms.ImageList(this.components);
            this.tabControl_views = new System.Windows.Forms.TabControl();
            this.tabPage_listView = new System.Windows.Forms.TabPage();
            this.dataGridView_subImages = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip_listView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel_columns = new System.Windows.Forms.Panel();
            this.checkBox_columnParent = new System.Windows.Forms.CheckBox();
            this.checkBox_columnHeight = new System.Windows.Forms.CheckBox();
            this.checkBox_columnWidth = new System.Windows.Forms.CheckBox();
            this.checkBox_columnAliases = new System.Windows.Forms.CheckBox();
            this.tabPage_treeView = new System.Windows.Forms.TabPage();
            this.panel_treeviewButtons = new System.Windows.Forms.Panel();
            this.button_collapseAll = new System.Windows.Forms.Button();
            this.button_expandAll = new System.Windows.Forms.Button();
            this.panel_filters = new System.Windows.Forms.Panel();
            this.checkBox_filtersParent = new System.Windows.Forms.CheckBox();
            this.checkBox_filtersHeight = new System.Windows.Forms.CheckBox();
            this.checkBox_filtersWidth = new System.Windows.Forms.CheckBox();
            this.comboBox_parentImage = new System.Windows.Forms.ComboBox();
            this.numericUpDown_filterHeight = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_filterWidth = new System.Windows.Forms.NumericUpDown();
            this.button_advancedFilter = new System.Windows.Forms.Button();
            this.textBox_filter = new System.Windows.Forms.TextBox();
            this.splitContainer_mainForm = new System.Windows.Forms.SplitContainer();
            this.panel_tabControlSpacerBottom = new System.Windows.Forms.Panel();
            this.panel_tabControlSpacerRight = new System.Windows.Forms.Panel();
            this.panel_tabControlSpacerLeft = new System.Windows.Forms.Panel();
            this.pictureBox_image = new System.Windows.Forms.PictureBox();
            this.statusStrip_mainForm = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel_iconCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_splitter = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_main = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar_mainForm = new System.Windows.Forms.ToolStripProgressBar();
            this.menuStrip_mainForm.SuspendLayout();
            this.contextMenuStrip_treeView.SuspendLayout();
            this.tabControl_views.SuspendLayout();
            this.tabPage_listView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_subImages)).BeginInit();
            this.contextMenuStrip_listView.SuspendLayout();
            this.panel_columns.SuspendLayout();
            this.tabPage_treeView.SuspendLayout();
            this.panel_treeviewButtons.SuspendLayout();
            this.panel_filters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_filterHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_filterWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_mainForm)).BeginInit();
            this.splitContainer_mainForm.Panel1.SuspendLayout();
            this.splitContainer_mainForm.Panel2.SuspendLayout();
            this.splitContainer_mainForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_image)).BeginInit();
            this.statusStrip_mainForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip_mainForm
            // 
            this.menuStrip_mainForm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.menuStrip_mainForm.Location = new System.Drawing.Point(0, 0);
            this.menuStrip_mainForm.Name = "menuStrip_mainForm";
            this.menuStrip_mainForm.Size = new System.Drawing.Size(846, 24);
            this.menuStrip_mainForm.TabIndex = 0;
            this.menuStrip_mainForm.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.exportAllToolStripMenuItem,
            this.toolStripSeparator_beforeExit,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = global::Janne252.COH2.UIAssetBrowser.Properties.Resources.openFile;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // exportAllToolStripMenuItem
            // 
            this.exportAllToolStripMenuItem.Enabled = false;
            this.exportAllToolStripMenuItem.Image = global::Janne252.COH2.UIAssetBrowser.Properties.Resources.eportAll;
            this.exportAllToolStripMenuItem.Name = "exportAllToolStripMenuItem";
            this.exportAllToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.exportAllToolStripMenuItem.Text = "Export All";
            this.exportAllToolStripMenuItem.Click += new System.EventHandler(this.exportAllToolStripMenuItem_Click);
            // 
            // toolStripSeparator_beforeExit
            // 
            this.toolStripSeparator_beforeExit.Name = "toolStripSeparator_beforeExit";
            this.toolStripSeparator_beforeExit.Size = new System.Drawing.Size(121, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearMemoryToolStripMenuItem1,
            this.loadAllParentImagesToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // clearMemoryToolStripMenuItem1
            // 
            this.clearMemoryToolStripMenuItem1.Enabled = false;
            this.clearMemoryToolStripMenuItem1.Image = global::Janne252.COH2.UIAssetBrowser.Properties.Resources.clearMemory;
            this.clearMemoryToolStripMenuItem1.Name = "clearMemoryToolStripMenuItem1";
            this.clearMemoryToolStripMenuItem1.Size = new System.Drawing.Size(195, 22);
            this.clearMemoryToolStripMenuItem1.Text = "Clear Memory";
            this.clearMemoryToolStripMenuItem1.Click += new System.EventHandler(this.clearMemoryToolStripMenuItem1_Click);
            // 
            // loadAllParentImagesToolStripMenuItem
            // 
            this.loadAllParentImagesToolStripMenuItem.Enabled = false;
            this.loadAllParentImagesToolStripMenuItem.Image = global::Janne252.COH2.UIAssetBrowser.Properties.Resources.loadAll;
            this.loadAllParentImagesToolStripMenuItem.Name = "loadAllParentImagesToolStripMenuItem";
            this.loadAllParentImagesToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.loadAllParentImagesToolStripMenuItem.Text = "Load All Parent Images";
            this.loadAllParentImagesToolStripMenuItem.Click += new System.EventHandler(this.loadAllParentImagesToolStripMenuItem_Click);
            // 
            // treeView_extImages
            // 
            this.treeView_extImages.ContextMenuStrip = this.contextMenuStrip_treeView;
            this.treeView_extImages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView_extImages.ImageIndex = 0;
            this.treeView_extImages.ImageList = this.imageList_icons;
            this.treeView_extImages.Location = new System.Drawing.Point(3, 3);
            this.treeView_extImages.Name = "treeView_extImages";
            this.treeView_extImages.SelectedImageIndex = 0;
            this.treeView_extImages.Size = new System.Drawing.Size(322, 369);
            this.treeView_extImages.TabIndex = 1;
            this.treeView_extImages.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_extImages_AfterSelect);
            // 
            // contextMenuStrip_treeView
            // 
            this.contextMenuStrip_treeView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportToolStripMenuItem1});
            this.contextMenuStrip_treeView.Name = "contextMenuStrip_treeView";
            this.contextMenuStrip_treeView.Size = new System.Drawing.Size(108, 26);
            // 
            // exportToolStripMenuItem1
            // 
            this.exportToolStripMenuItem1.Name = "exportToolStripMenuItem1";
            this.exportToolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
            this.exportToolStripMenuItem1.Text = "Export";
            this.exportToolStripMenuItem1.Click += new System.EventHandler(this.exportToolStripMenuItem1_Click);
            // 
            // imageList_icons
            // 
            this.imageList_icons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList_icons.ImageStream")));
            this.imageList_icons.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList_icons.Images.SetKeyName(0, "imageList_package.png");
            this.imageList_icons.Images.SetKeyName(1, "imageList_extImage.png");
            this.imageList_icons.Images.SetKeyName(2, "imageList_subImage.png");
            this.imageList_icons.Images.SetKeyName(3, "imageList_properties.png");
            this.imageList_icons.Images.SetKeyName(4, "imageList_settings.png");
            this.imageList_icons.Images.SetKeyName(5, "imageList_aliases.png");
            // 
            // tabControl_views
            // 
            this.tabControl_views.Controls.Add(this.tabPage_listView);
            this.tabControl_views.Controls.Add(this.tabPage_treeView);
            this.tabControl_views.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_views.Location = new System.Drawing.Point(5, 0);
            this.tabControl_views.Name = "tabControl_views";
            this.tabControl_views.SelectedIndex = 0;
            this.tabControl_views.Size = new System.Drawing.Size(336, 437);
            this.tabControl_views.TabIndex = 2;
            this.tabControl_views.SelectedIndexChanged += new System.EventHandler(this.tabControl_views_SelectedIndexChanged);
            // 
            // tabPage_listView
            // 
            this.tabPage_listView.Controls.Add(this.dataGridView_subImages);
            this.tabPage_listView.Controls.Add(this.panel_columns);
            this.tabPage_listView.Location = new System.Drawing.Point(4, 22);
            this.tabPage_listView.Name = "tabPage_listView";
            this.tabPage_listView.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_listView.Size = new System.Drawing.Size(328, 411);
            this.tabPage_listView.TabIndex = 1;
            this.tabPage_listView.Text = "List View";
            this.tabPage_listView.UseVisualStyleBackColor = true;
            // 
            // dataGridView_subImages
            // 
            this.dataGridView_subImages.AllowUserToAddRows = false;
            this.dataGridView_subImages.AllowUserToDeleteRows = false;
            this.dataGridView_subImages.AllowUserToOrderColumns = true;
            this.dataGridView_subImages.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_subImages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_subImages.ContextMenuStrip = this.contextMenuStrip_listView;
            this.dataGridView_subImages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_subImages.Location = new System.Drawing.Point(3, 26);
            this.dataGridView_subImages.Name = "dataGridView_subImages";
            this.dataGridView_subImages.Size = new System.Drawing.Size(322, 382);
            this.dataGridView_subImages.TabIndex = 0;
            this.dataGridView_subImages.SelectionChanged += new System.EventHandler(this.dataGridView_subImages_SelectionChanged);
            // 
            // contextMenuStrip_listView
            // 
            this.contextMenuStrip_listView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportToolStripMenuItem});
            this.contextMenuStrip_listView.Name = "contextMenuStrip_export";
            this.contextMenuStrip_listView.Size = new System.Drawing.Size(153, 48);
            this.contextMenuStrip_listView.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_export_Opening);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exportToolStripMenuItem.Text = "Export";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // panel_columns
            // 
            this.panel_columns.Controls.Add(this.checkBox_columnParent);
            this.panel_columns.Controls.Add(this.checkBox_columnHeight);
            this.panel_columns.Controls.Add(this.checkBox_columnWidth);
            this.panel_columns.Controls.Add(this.checkBox_columnAliases);
            this.panel_columns.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_columns.Location = new System.Drawing.Point(3, 3);
            this.panel_columns.Name = "panel_columns";
            this.panel_columns.Size = new System.Drawing.Size(322, 23);
            this.panel_columns.TabIndex = 2;
            // 
            // checkBox_columnParent
            // 
            this.checkBox_columnParent.AutoSize = true;
            this.checkBox_columnParent.Location = new System.Drawing.Point(192, 4);
            this.checkBox_columnParent.Name = "checkBox_columnParent";
            this.checkBox_columnParent.Size = new System.Drawing.Size(57, 17);
            this.checkBox_columnParent.TabIndex = 3;
            this.checkBox_columnParent.Text = "Parent";
            this.checkBox_columnParent.UseVisualStyleBackColor = true;
            this.checkBox_columnParent.CheckedChanged += new System.EventHandler(this.checkBox_columnParent_CheckedChanged);
            // 
            // checkBox_columnHeight
            // 
            this.checkBox_columnHeight.AutoSize = true;
            this.checkBox_columnHeight.Checked = true;
            this.checkBox_columnHeight.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_columnHeight.Location = new System.Drawing.Point(129, 4);
            this.checkBox_columnHeight.Name = "checkBox_columnHeight";
            this.checkBox_columnHeight.Size = new System.Drawing.Size(57, 17);
            this.checkBox_columnHeight.TabIndex = 2;
            this.checkBox_columnHeight.Text = "Height";
            this.checkBox_columnHeight.UseVisualStyleBackColor = true;
            this.checkBox_columnHeight.CheckedChanged += new System.EventHandler(this.checkBox_columnHeight_CheckedChanged);
            // 
            // checkBox_columnWidth
            // 
            this.checkBox_columnWidth.AutoSize = true;
            this.checkBox_columnWidth.Checked = true;
            this.checkBox_columnWidth.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_columnWidth.Location = new System.Drawing.Point(69, 4);
            this.checkBox_columnWidth.Name = "checkBox_columnWidth";
            this.checkBox_columnWidth.Size = new System.Drawing.Size(54, 17);
            this.checkBox_columnWidth.TabIndex = 1;
            this.checkBox_columnWidth.Text = "Width";
            this.checkBox_columnWidth.UseVisualStyleBackColor = true;
            this.checkBox_columnWidth.CheckedChanged += new System.EventHandler(this.checkBox_columnWidth_CheckedChanged);
            // 
            // checkBox_columnAliases
            // 
            this.checkBox_columnAliases.AutoSize = true;
            this.checkBox_columnAliases.Location = new System.Drawing.Point(4, 4);
            this.checkBox_columnAliases.Name = "checkBox_columnAliases";
            this.checkBox_columnAliases.Size = new System.Drawing.Size(59, 17);
            this.checkBox_columnAliases.TabIndex = 0;
            this.checkBox_columnAliases.Text = "Aliases";
            this.checkBox_columnAliases.UseVisualStyleBackColor = true;
            this.checkBox_columnAliases.CheckedChanged += new System.EventHandler(this.checkBox_columnAliases_CheckedChanged);
            // 
            // tabPage_treeView
            // 
            this.tabPage_treeView.Controls.Add(this.treeView_extImages);
            this.tabPage_treeView.Controls.Add(this.panel_treeviewButtons);
            this.tabPage_treeView.Location = new System.Drawing.Point(4, 22);
            this.tabPage_treeView.Name = "tabPage_treeView";
            this.tabPage_treeView.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_treeView.Size = new System.Drawing.Size(328, 411);
            this.tabPage_treeView.TabIndex = 0;
            this.tabPage_treeView.Text = "Tree View";
            this.tabPage_treeView.UseVisualStyleBackColor = true;
            // 
            // panel_treeviewButtons
            // 
            this.panel_treeviewButtons.Controls.Add(this.button_collapseAll);
            this.panel_treeviewButtons.Controls.Add(this.button_expandAll);
            this.panel_treeviewButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_treeviewButtons.Location = new System.Drawing.Point(3, 372);
            this.panel_treeviewButtons.Name = "panel_treeviewButtons";
            this.panel_treeviewButtons.Size = new System.Drawing.Size(322, 36);
            this.panel_treeviewButtons.TabIndex = 2;
            // 
            // button_collapseAll
            // 
            this.button_collapseAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_collapseAll.Location = new System.Drawing.Point(238, 7);
            this.button_collapseAll.Name = "button_collapseAll";
            this.button_collapseAll.Size = new System.Drawing.Size(75, 23);
            this.button_collapseAll.TabIndex = 1;
            this.button_collapseAll.Text = "Collapse All";
            this.button_collapseAll.UseVisualStyleBackColor = true;
            this.button_collapseAll.Click += new System.EventHandler(this.button_collapseAll_Click);
            // 
            // button_expandAll
            // 
            this.button_expandAll.Location = new System.Drawing.Point(3, 7);
            this.button_expandAll.Name = "button_expandAll";
            this.button_expandAll.Size = new System.Drawing.Size(75, 23);
            this.button_expandAll.TabIndex = 0;
            this.button_expandAll.Text = "Expand All";
            this.button_expandAll.UseVisualStyleBackColor = true;
            this.button_expandAll.Click += new System.EventHandler(this.button_expandAll_Click);
            // 
            // panel_filters
            // 
            this.panel_filters.BackColor = System.Drawing.Color.White;
            this.panel_filters.Controls.Add(this.checkBox_filtersParent);
            this.panel_filters.Controls.Add(this.checkBox_filtersHeight);
            this.panel_filters.Controls.Add(this.checkBox_filtersWidth);
            this.panel_filters.Controls.Add(this.comboBox_parentImage);
            this.panel_filters.Controls.Add(this.numericUpDown_filterHeight);
            this.panel_filters.Controls.Add(this.numericUpDown_filterWidth);
            this.panel_filters.Controls.Add(this.button_advancedFilter);
            this.panel_filters.Controls.Add(this.textBox_filter);
            this.panel_filters.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_filters.Location = new System.Drawing.Point(5, 442);
            this.panel_filters.Name = "panel_filters";
            this.panel_filters.Size = new System.Drawing.Size(336, 26);
            this.panel_filters.TabIndex = 1;
            // 
            // checkBox_filtersParent
            // 
            this.checkBox_filtersParent.AutoSize = true;
            this.checkBox_filtersParent.Location = new System.Drawing.Point(7, 68);
            this.checkBox_filtersParent.Name = "checkBox_filtersParent";
            this.checkBox_filtersParent.Size = new System.Drawing.Size(60, 17);
            this.checkBox_filtersParent.TabIndex = 12;
            this.checkBox_filtersParent.Text = "Parent:";
            this.checkBox_filtersParent.UseVisualStyleBackColor = true;
            this.checkBox_filtersParent.CheckedChanged += new System.EventHandler(this.checkBox_filtersParent_CheckedChanged);
            // 
            // checkBox_filtersHeight
            // 
            this.checkBox_filtersHeight.AutoSize = true;
            this.checkBox_filtersHeight.Checked = true;
            this.checkBox_filtersHeight.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_filtersHeight.Location = new System.Drawing.Point(144, 34);
            this.checkBox_filtersHeight.Name = "checkBox_filtersHeight";
            this.checkBox_filtersHeight.Size = new System.Drawing.Size(60, 17);
            this.checkBox_filtersHeight.TabIndex = 11;
            this.checkBox_filtersHeight.Text = "Height:";
            this.checkBox_filtersHeight.UseVisualStyleBackColor = true;
            this.checkBox_filtersHeight.CheckedChanged += new System.EventHandler(this.checkBox_filtersHeight_CheckedChanged);
            // 
            // checkBox_filtersWidth
            // 
            this.checkBox_filtersWidth.AutoSize = true;
            this.checkBox_filtersWidth.Checked = true;
            this.checkBox_filtersWidth.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_filtersWidth.Location = new System.Drawing.Point(7, 34);
            this.checkBox_filtersWidth.Name = "checkBox_filtersWidth";
            this.checkBox_filtersWidth.Size = new System.Drawing.Size(57, 17);
            this.checkBox_filtersWidth.TabIndex = 10;
            this.checkBox_filtersWidth.Text = "Width:";
            this.checkBox_filtersWidth.UseVisualStyleBackColor = true;
            this.checkBox_filtersWidth.CheckedChanged += new System.EventHandler(this.checkBox_filtersWidth_CheckedChanged);
            // 
            // comboBox_parentImage
            // 
            this.comboBox_parentImage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_parentImage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_parentImage.FormattingEnabled = true;
            this.comboBox_parentImage.Location = new System.Drawing.Point(70, 64);
            this.comboBox_parentImage.Name = "comboBox_parentImage";
            this.comboBox_parentImage.Size = new System.Drawing.Size(205, 21);
            this.comboBox_parentImage.TabIndex = 9;
            this.comboBox_parentImage.SelectedIndexChanged += new System.EventHandler(this.comboBox_parentImage_SelectedIndexChanged);
            // 
            // numericUpDown_filterHeight
            // 
            this.numericUpDown_filterHeight.Location = new System.Drawing.Point(207, 32);
            this.numericUpDown_filterHeight.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDown_filterHeight.Name = "numericUpDown_filterHeight";
            this.numericUpDown_filterHeight.Size = new System.Drawing.Size(68, 20);
            this.numericUpDown_filterHeight.TabIndex = 7;
            this.numericUpDown_filterHeight.Value = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.numericUpDown_filterHeight.ValueChanged += new System.EventHandler(this.numericUpDown_filterHeight_ValueChanged);
            // 
            // numericUpDown_filterWidth
            // 
            this.numericUpDown_filterWidth.Location = new System.Drawing.Point(70, 32);
            this.numericUpDown_filterWidth.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDown_filterWidth.Name = "numericUpDown_filterWidth";
            this.numericUpDown_filterWidth.Size = new System.Drawing.Size(68, 20);
            this.numericUpDown_filterWidth.TabIndex = 6;
            this.numericUpDown_filterWidth.Value = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.numericUpDown_filterWidth.ValueChanged += new System.EventHandler(this.numericUpDown_filterWidth_ValueChanged);
            // 
            // button_advancedFilter
            // 
            this.button_advancedFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_advancedFilter.Location = new System.Drawing.Point(281, 5);
            this.button_advancedFilter.Name = "button_advancedFilter";
            this.button_advancedFilter.Size = new System.Drawing.Size(48, 22);
            this.button_advancedFilter.TabIndex = 1;
            this.button_advancedFilter.Text = "More...";
            this.button_advancedFilter.UseVisualStyleBackColor = true;
            this.button_advancedFilter.Click += new System.EventHandler(this.button_advancedFilter_Click);
            // 
            // textBox_filter
            // 
            this.textBox_filter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_filter.Location = new System.Drawing.Point(7, 6);
            this.textBox_filter.Name = "textBox_filter";
            this.textBox_filter.Size = new System.Drawing.Size(268, 20);
            this.textBox_filter.TabIndex = 0;
            this.textBox_filter.TextChanged += new System.EventHandler(this.textBox_filter_TextChanged);
            // 
            // splitContainer_mainForm
            // 
            this.splitContainer_mainForm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer_mainForm.Location = new System.Drawing.Point(0, 27);
            this.splitContainer_mainForm.Name = "splitContainer_mainForm";
            // 
            // splitContainer_mainForm.Panel1
            // 
            this.splitContainer_mainForm.Panel1.Controls.Add(this.tabControl_views);
            this.splitContainer_mainForm.Panel1.Controls.Add(this.panel_tabControlSpacerBottom);
            this.splitContainer_mainForm.Panel1.Controls.Add(this.panel_filters);
            this.splitContainer_mainForm.Panel1.Controls.Add(this.panel_tabControlSpacerRight);
            this.splitContainer_mainForm.Panel1.Controls.Add(this.panel_tabControlSpacerLeft);
            this.splitContainer_mainForm.Panel1.Resize += new System.EventHandler(this.splitContainer_mainForm_Panel1_Resize);
            // 
            // splitContainer_mainForm.Panel2
            // 
            this.splitContainer_mainForm.Panel2.Controls.Add(this.pictureBox_image);
            this.splitContainer_mainForm.Size = new System.Drawing.Size(844, 468);
            this.splitContainer_mainForm.SplitterDistance = 346;
            this.splitContainer_mainForm.TabIndex = 3;
            // 
            // panel_tabControlSpacerBottom
            // 
            this.panel_tabControlSpacerBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_tabControlSpacerBottom.Location = new System.Drawing.Point(5, 437);
            this.panel_tabControlSpacerBottom.Name = "panel_tabControlSpacerBottom";
            this.panel_tabControlSpacerBottom.Size = new System.Drawing.Size(336, 5);
            this.panel_tabControlSpacerBottom.TabIndex = 3;
            // 
            // panel_tabControlSpacerRight
            // 
            this.panel_tabControlSpacerRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel_tabControlSpacerRight.Location = new System.Drawing.Point(341, 0);
            this.panel_tabControlSpacerRight.Name = "panel_tabControlSpacerRight";
            this.panel_tabControlSpacerRight.Size = new System.Drawing.Size(5, 468);
            this.panel_tabControlSpacerRight.TabIndex = 4;
            // 
            // panel_tabControlSpacerLeft
            // 
            this.panel_tabControlSpacerLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_tabControlSpacerLeft.Location = new System.Drawing.Point(0, 0);
            this.panel_tabControlSpacerLeft.Name = "panel_tabControlSpacerLeft";
            this.panel_tabControlSpacerLeft.Size = new System.Drawing.Size(5, 468);
            this.panel_tabControlSpacerLeft.TabIndex = 3;
            // 
            // pictureBox_image
            // 
            this.pictureBox_image.BackColor = System.Drawing.Color.White;
            this.pictureBox_image.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox_image.BackgroundImage")));
            this.pictureBox_image.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_image.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox_image.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_image.Name = "pictureBox_image";
            this.pictureBox_image.Size = new System.Drawing.Size(494, 468);
            this.pictureBox_image.TabIndex = 0;
            this.pictureBox_image.TabStop = false;
            // 
            // statusStrip_mainForm
            // 
            this.statusStrip_mainForm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel_iconCount,
            this.toolStripStatusLabel_splitter,
            this.toolStripStatusLabel_main,
            this.toolStripProgressBar_mainForm});
            this.statusStrip_mainForm.Location = new System.Drawing.Point(0, 498);
            this.statusStrip_mainForm.Name = "statusStrip_mainForm";
            this.statusStrip_mainForm.Size = new System.Drawing.Size(846, 22);
            this.statusStrip_mainForm.TabIndex = 4;
            this.statusStrip_mainForm.Text = "statusStrip1";
            this.statusStrip_mainForm.SizeChanged += new System.EventHandler(this.statusStrip_mainForm_SizeChanged);
            // 
            // toolStripStatusLabel_iconCount
            // 
            this.toolStripStatusLabel_iconCount.Name = "toolStripStatusLabel_iconCount";
            this.toolStripStatusLabel_iconCount.Size = new System.Drawing.Size(44, 17);
            this.toolStripStatusLabel_iconCount.Text = "0 icons";
            // 
            // toolStripStatusLabel_splitter
            // 
            this.toolStripStatusLabel_splitter.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusLabel_splitter.Name = "toolStripStatusLabel_splitter";
            this.toolStripStatusLabel_splitter.Size = new System.Drawing.Size(4, 17);
            // 
            // toolStripStatusLabel_main
            // 
            this.toolStripStatusLabel_main.Name = "toolStripStatusLabel_main";
            this.toolStripStatusLabel_main.Size = new System.Drawing.Size(16, 17);
            this.toolStripStatusLabel_main.Text = "...";
            this.toolStripStatusLabel_main.TextChanged += new System.EventHandler(this.toolStripStatusLabel_main_TextChanged);
            // 
            // toolStripProgressBar_mainForm
            // 
            this.toolStripProgressBar_mainForm.AutoSize = false;
            this.toolStripProgressBar_mainForm.Name = "toolStripProgressBar_mainForm";
            this.toolStripProgressBar_mainForm.Size = new System.Drawing.Size(200, 16);
            this.toolStripProgressBar_mainForm.Step = 1;
            this.toolStripProgressBar_mainForm.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 520);
            this.Controls.Add(this.statusStrip_mainForm);
            this.Controls.Add(this.splitContainer_mainForm);
            this.Controls.Add(this.menuStrip_mainForm);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip_mainForm;
            this.MinimumSize = new System.Drawing.Size(862, 559);
            this.Name = "MainForm";
            this.Text = "COH2 UI Asset Browser v. 2.0 by Janne252";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip_mainForm.ResumeLayout(false);
            this.menuStrip_mainForm.PerformLayout();
            this.contextMenuStrip_treeView.ResumeLayout(false);
            this.tabControl_views.ResumeLayout(false);
            this.tabPage_listView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_subImages)).EndInit();
            this.contextMenuStrip_listView.ResumeLayout(false);
            this.panel_columns.ResumeLayout(false);
            this.panel_columns.PerformLayout();
            this.tabPage_treeView.ResumeLayout(false);
            this.panel_treeviewButtons.ResumeLayout(false);
            this.panel_filters.ResumeLayout(false);
            this.panel_filters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_filterHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_filterWidth)).EndInit();
            this.splitContainer_mainForm.Panel1.ResumeLayout(false);
            this.splitContainer_mainForm.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_mainForm)).EndInit();
            this.splitContainer_mainForm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_image)).EndInit();
            this.statusStrip_mainForm.ResumeLayout(false);
            this.statusStrip_mainForm.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip_mainForm;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator_beforeExit;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TreeView treeView_extImages;
        private System.Windows.Forms.TabControl tabControl_views;
        private System.Windows.Forms.TabPage tabPage_treeView;
        private System.Windows.Forms.Panel panel_treeviewButtons;
        private System.Windows.Forms.Button button_collapseAll;
        private System.Windows.Forms.Button button_expandAll;
        private System.Windows.Forms.TabPage tabPage_listView;
        private System.Windows.Forms.SplitContainer splitContainer_mainForm;
        private System.Windows.Forms.StatusStrip statusStrip_mainForm;
        private System.Windows.Forms.DataGridView dataGridView_subImages;
        private System.Windows.Forms.Panel panel_filters;
        private System.Windows.Forms.TextBox textBox_filter;
        private System.Windows.Forms.PictureBox pictureBox_image;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearMemoryToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem loadAllParentImagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_main;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_listView;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar_mainForm;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_treeView;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem1;
        private System.Windows.Forms.ImageList imageList_icons;
        private System.Windows.Forms.Button button_advancedFilter;
        private System.Windows.Forms.NumericUpDown numericUpDown_filterWidth;
        private System.Windows.Forms.NumericUpDown numericUpDown_filterHeight;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_iconCount;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_splitter;
        private System.Windows.Forms.ComboBox comboBox_parentImage;
        private System.Windows.Forms.Panel panel_columns;
        private System.Windows.Forms.CheckBox checkBox_columnAliases;
        private System.Windows.Forms.CheckBox checkBox_columnParent;
        private System.Windows.Forms.CheckBox checkBox_columnHeight;
        private System.Windows.Forms.CheckBox checkBox_columnWidth;
        private System.Windows.Forms.Panel panel_tabControlSpacerLeft;
        private System.Windows.Forms.Panel panel_tabControlSpacerRight;
        private System.Windows.Forms.Panel panel_tabControlSpacerBottom;
        private System.Windows.Forms.CheckBox checkBox_filtersHeight;
        private System.Windows.Forms.CheckBox checkBox_filtersWidth;
        private System.Windows.Forms.CheckBox checkBox_filtersParent;
    }
}

