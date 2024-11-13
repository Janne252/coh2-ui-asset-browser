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
using Janne252.COH2.UIAssetBrowser.GFX;
using FreeImageAPI;
using System.Threading;
using System.Diagnostics;

namespace Janne252.COH2.UIAssetBrowser
{
    public partial class MainForm : Form
    {
        string[] args = { };

        public MainForm(string[] args)
        {
            InitializeComponent();
            this.args = args;
        }

       private static Int32 s_nShowMainFormMessage = NativeMethods.RegisterWindowMessage("WM_SHOWMAINFORM");

        /// <summary>
        /// Gets the numeral identifier for the custom WM_SHOWMAINFORM window message type.
        /// </summary>
       public static Int32 ShowMainFormMessageIdentifier
        {
            get
            {
                return s_nShowMainFormMessage;
            }
        }
        
        /// <summary>
        /// Processes window events.
        /// </summary>
        /// <param name="pMessage">The message that is to be processed.</param>
        protected override void WndProc(ref Message pMessage)
        {
            base.WndProc(ref pMessage);
            if (pMessage.Msg == MainForm.ShowMainFormMessageIdentifier)
            {
                string loadArgsFile = MainForm.GetLoadArgsPath();
                if (File.Exists(loadArgsFile))
                {
                    string arg = File.ReadAllText(loadArgsFile);
                    if (File.Exists(arg))
                        OpenGFX(arg);
                }
                this.WindowState = FormWindowState.Minimized;
                this.TopMost = true;
                this.Focus();
                this.BringToFront();
                this.Show();
                this.Restore();
                //this.WindowState = FormWindowState.Normal;
            }
        }
        
        GFXParser parser;
        string filePath = "";
        DefineSubImageTag currentSubImage;
        bool allowPictureBoxSizeModeUpdate = true;
        bool advancedFilter = false;
        bool filterTreeview = false;
        bool instantFilter = true;

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox_image.Image = null;
            UpdatePictureBoxSizeMode();
            statusStrip_mainForm_SizeChanged();

            if (args?.Count() > 0)
            {
                string file = args[0];
                OpenGFX(file);
            }
        }
        
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "GFX Files (*.gfx)|*.gfx";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                OpenGFX(dialog.FileName);
            }
        }

        public void OpenGFX(string gfxFilePath)
        {
            filePath = gfxFilePath;
            parser = new GFXParser(filePath);
            if (!parser.Abort)
            {
                exportAllToolStripMenuItem.Enabled = true;
                clearMemoryToolStripMenuItem1.Enabled = true;
                loadAllParentImagesToolStripMenuItem.Enabled = true;
                SetControlsEnabled(false);
                new Thread(() =>
                {
                    parser.Parse();
                    this.BeginInvoke((MethodInvoker)delegate
                    {
                        treeView_extImages.Nodes.Clear();
                        treeView_extImages.Nodes.Add(parser.treeNode);
                        dataGridView_subImages.DataSource = parser.BindingSource_SubImages;
                        dataGridView_subImages.Columns["subImage"].Visible = false;
                        SetControlsEnabled(true);
                        toolStripStatusLabel_main.Text = $"Loaded {parser.ExternalImages.Count} images with {parser.SubImages.Count} sub-images.";
                        ApplyFilter();
                        ColumnVisiblityToggle();
                        statusStrip_mainForm_SizeChanged(null, null);
                        comboBox_parentImage.DataSource = parser.DataSource_ExternalImageNames;
                    });
                }).Start();
            }
        }

        private void textBox_filter_TextChanged(object sender, EventArgs e)
        {
            if (instantFilter)
            {
                ApplyFilter();
            }
        }

        public void ApplyFilter()
        {
            string filter = textBox_filter.Text.PrepareForDataBindingFilter();

            if (parser != null)
            {
                string query = $"(Name LIKE '%{filter}%' OR Aliases LIKE '%{filter}%')";
                if (advancedFilter)
                {
                    if (checkBox_filtersWidth.Checked)
                        query = $"{query} AND Width = {numericUpDown_filterWidth.Value}";
                    if (checkBox_filtersHeight.Checked)
                        query = $"{query} AND Height = {numericUpDown_filterHeight.Value}";
                    if (checkBox_filtersParent.Checked)
                        query = $"{query} AND `Parent` LIKE '%{comboBox_parentImage.Text}%'";
                }
                parser.BindingSource_SubImages.Filter = query;

                toolStripStatusLabel_iconCount.Text = dataGridView_subImages.Rows.Count + " icons";

                if (filterTreeview)
                {
                    //List<string> times = new List<string>();
                    //Stopwatch st = new Stopwatch();
                    //st.Start();
                    DefineSubImageTag subImage;
                    DefineExternalmage2Tag extImage;
                    //for (int i = 0; i < parser.subImages.Count; i++)
                    //   parser.subImages[i].treeNode.Remove();

                    for (int i = 0; i < parser.ExternalImages.Count; i++)
                    {
                        extImage = parser.ExternalImages[i];
                        if (extImage.treeNode.IsExpanded)
                            extImage.treeNode.Nodes.Clear();
                    }

                    Dictionary<uint, bool> filteredSubImages = new Dictionary<uint, bool>();
                    for (int i = 0; i < dataGridView_subImages.Rows.Count; i++)
                    {
                        subImage = (DefineSubImageTag)dataGridView_subImages.Rows[i].Cells["SubImage"].Value;
                        filteredSubImages.Add(subImage.characterId, true);
                    }
                    //times.Add($"Get Dictionary: {st.Elapsed.Seconds}.{st.Elapsed.Milliseconds}");
                    //st.Restart();

                    for (int i = 0; i < parser.SubImages.Count; i++)
                    {
                        subImage = parser.SubImages[i];
                        if (filteredSubImages.ContainsKey(subImage.characterId))
                            subImage.ShowTreeNode();
                        else
                            subImage.HideTreeNode();
                    }

                    //times.Add($"Show/Hide Nodes: {st.Elapsed.Seconds}.{st.Elapsed.Milliseconds}");
                    //st.Restart();
                    //treeView_extImages.Sort();
                    //st.Stop();
                    //times.Add($"Sort Nodes: {st.Elapsed.Seconds}.{st.Elapsed.Milliseconds}");
                    // MessageBox.Show(String.Join("\r\n", times));
                }
            }
        }

        private void dataGridView_subImages_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView_subImages.SelectedCells.Count > 0)
            {
                DataGridViewCell selectedCell = dataGridView_subImages.SelectedCells[0];

                DataGridViewRow row = dataGridView_subImages.Rows[selectedCell.RowIndex];
                DefineSubImageTag subImage = (DefineSubImageTag)row.Cells["subImage"].Value;

                if (subImage != currentSubImage)
                {
                    if (currentSubImage != null)
                        currentSubImage.DisposeBitmap();

                    currentSubImage = subImage;

                    SetBitmap(subImage.GetBitmap());
                }
            }
        }

        private void clearMemoryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            parser?.DisposeBitmaps();
        }

        private void loadAllParentImagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            parser?.LoadBitmaps();
        }

        private void UpdatePictureBoxSizeMode()
        {
            if (allowPictureBoxSizeModeUpdate)
            {
                if (pictureBox_image.Image?.Width > pictureBox_image.Width || pictureBox_image.Image?.Height > pictureBox_image.Height)
                {
                    pictureBox_image.SizeMode = PictureBoxSizeMode.Zoom;
                }
                else if (pictureBox_image.Image?.Width <= pictureBox_image.Width && pictureBox_image?.Image.Height <= pictureBox_image.Height)
                {
                    pictureBox_image.SizeMode = PictureBoxSizeMode.CenterImage;
                }
            }
        }

        private void splitContainer_mainForm_Panel1_Resize(object sender, EventArgs e)
        {
            UpdatePictureBoxSizeMode();
        }

        private void treeView_extImages_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode selectedNode = treeView_extImages.SelectedNode;

            if (selectedNode.Tag != null)
            {
                GFXTreeNodeTag treeNodeTag = (GFXTreeNodeTag)selectedNode.Tag;

                if (treeNodeTag.subImage != null)
                    SetBitmap(treeNodeTag.subImage.GetBitmap());
                else if (treeNodeTag.extImage != null)
                    SetBitmap(treeNodeTag.extImage.GetBitmap());
            }
        }

        public void SetBitmap(Bitmap bitmap)
        {
            if (bitmap != null)
            {
                if (pictureBox_image.Image != null)
                {
                    pictureBox_image.Image.Dispose();
                }

                //Copy the bitmap to prevent issues if the original bitmap is Disposed somewhere
                pictureBox_image.Image = new Bitmap(bitmap);

                UpdatePictureBoxSizeMode();
            }
            else
            {
                if (pictureBox_image.Image != null)
                {
                    pictureBox_image.Image.Dispose();
                    pictureBox_image.Image = null;
                }
            }
        }

        private void contextMenuStrip_export_Opening(object sender, CancelEventArgs e)
        {

        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedCellCollection selectedCells = dataGridView_subImages.SelectedCells;
            int selectedCellCount = selectedCells.Count;

            if (selectedCellCount == 1)
            {
                DataGridViewCell selectedCell = dataGridView_subImages.SelectedCells[0];

                DataGridViewRow row = dataGridView_subImages.Rows[selectedCell.RowIndex];
                DefineSubImageTag subImage = (DefineSubImageTag)row.Cells["subImage"].Value;

                Bitmap bitmap = subImage.GetBitmap();
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.FileName = subImage.name + ".png";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    bitmap.SaveBitmap(dialog.FileName);

                    if (subImage.hasAliases)
                    {
                        foreach(string alias in subImage.aliases)
                        {
                            bitmap.SaveBitmap(Path.Combine(Path.GetDirectoryName(dialog.FileName), alias + ".png"));
                        }
                    }
                }
                subImage.DisposeBitmap();
            }
            else if(selectedCellCount > 1)
            {
                DataGridViewCell selectedCell;
                DataGridViewRow selectedRow;
                List<DefineSubImageTag> subImages = new List<DefineSubImageTag>();

                DefineSubImageTag subImage;
                for (int i = 0; i < selectedCellCount; i++)
                {
                    selectedCell = selectedCells[i];
                    selectedRow = dataGridView_subImages.Rows[selectedCell.RowIndex];
                    subImage = (DefineSubImageTag)selectedRow.Cells["subImage"].Value;
                    if (!subImages.Contains(subImage))
                        subImages.Add(subImage);
                }

                FolderBrowserDialog dialog = new FolderBrowserDialog();

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string rootPath = dialog.SelectedPath;

                    for (int i = 0; i < subImages.Count; i++)
                    {
                        subImage = subImages[i];
                        Bitmap bitmap = subImage.GetBitmap();
                        
                        bitmap.SaveBitmap(subImage.GetExportFilePath(rootPath));
                        if (subImage.hasAliases)
                        {
                            foreach (string alias in subImage.aliases)
                            {
                                bitmap.SaveBitmap(Path.Combine(rootPath, alias + ".png"));
                            }
                        }
                        subImage.DisposeBitmap();
                    }

                    MessageBox.Show($"Finished exporting {subImages.Count} images!", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        public void SetControlsEnabled(bool enabled)
        {
            menuStrip_mainForm.Enabled = enabled;
            splitContainer_mainForm.Enabled = enabled;
            statusStrip_mainForm.Enabled = enabled;
        }

        private void exportAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            
            if (dialog.ShowDialog() == DialogResult.OK && parser != null)
            {
                SetControlsEnabled(false);
                toolStripProgressBar_mainForm.Visible = true;
                toolStripProgressBar_mainForm.Value = 0;
                toolStripProgressBar_mainForm.Maximum = parser.SubImages.Count;
 
                new Thread(() =>
                {
                    Stopwatch sw = new Stopwatch();
                    sw.Start();
                    string rootPath = dialog.SelectedPath;

                    Parallel.ForEach(parser.ExternalImages, extImage =>
                    {
                        extImage.GetBitmap();
                        extImage.LoadSubImages();
                        Parallel.ForEach(extImage.subImages, subImage =>
                        {
                            Bitmap bitmap = subImage.GetBitmap();
                            
                            bitmap.SaveBitmap(subImage.GetExportFilePath(rootPath, true));

                            if (subImage.hasAliases)
                            {
                                string alias;
                                for (int i = 0; i < subImage.aliases.Count; i++)
                                {
                                    alias = subImage.aliases[i];
                                    bitmap.SaveBitmap(Path.Combine(rootPath, subImage.parentImage._fileName, alias + ".png"));
                                }
                            }
                            this.BeginInvoke((MethodInvoker)delegate
                            {
                                toolStripProgressBar_mainForm.Increment(1);
                            });
                            subImage.DisposeBitmap();
                        });
                        extImage.DisposeBitmap();
                    });

                    this.BeginInvoke((MethodInvoker)delegate
                    {
                        sw.Stop();
                        SetControlsEnabled(true);
                        toolStripProgressBar_mainForm.Visible = false;
                        DialogResult result = MessageBox.Show($"Finished exporting {parser.SubImages.Count} images (from {parser.ExternalImages.Count} textures) in {sw.Elapsed.Seconds}.{sw.Elapsed.Milliseconds} seconds. Would you like to open the export folder?", "Export Complete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            Process.Start(rootPath);
                        }
                    });
                }).Start();
            }
        }

        private void statusStrip_mainForm_SizeChanged(object sender = null, EventArgs e = null)
        {
            toolStripProgressBar_mainForm.Width = statusStrip_mainForm.Width - toolStripStatusLabel_main.Width - toolStripStatusLabel_iconCount.Width - 25;
        }

        private void toolStripStatusLabel_main_TextChanged(object sender, EventArgs e)
        {
            statusStrip_mainForm_SizeChanged();
        }

        private void exportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = treeView_extImages.SelectedNode;

            if (selectedNode.Tag != null)
            {
                GFXTreeNodeTag treeNodeTag = (GFXTreeNodeTag)selectedNode.Tag;

                if (treeNodeTag.subImage != null)
                {
                    using (Bitmap bitmap = treeNodeTag.subImage.GetBitmap())
                    {
                        SaveFileDialog dialog = new SaveFileDialog();
                        dialog.FileName = treeNodeTag.subImage.name + ".png";

                        if (dialog.ShowDialog() == DialogResult.OK)
                        {
                            bitmap.SaveBitmap(dialog.FileName);
                        }
                    }
                }
                else if (treeNodeTag.extImage != null)
                {
                    FolderBrowserDialog dialog = new FolderBrowserDialog();

                    if (dialog.ShowDialog() == DialogResult.OK && parser != null)
                    {
                        string rootPath = dialog.SelectedPath;
                        DefineSubImageTag subImage;
                        for (int i = 0; i < treeNodeTag.extImage.subImages.Count; i++)
                        {
                            subImage = treeNodeTag.extImage.subImages[i];

                            using (Bitmap bitmap = subImage.GetBitmap())
                            {
                                bitmap.SaveBitmap(subImage.GetExportFilePath(rootPath, true));
                            }
                        }

                        DialogResult result = MessageBox.Show($"Finished exporting {treeNodeTag.extImage.subImages.Count} images (from 1 texture). Would you like open the export folder?", "Export Complete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                            Process.Start(Path.Combine(rootPath, treeNodeTag.extImage._fileName));
                    }
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_advancedFilter_Click(object sender, EventArgs e)
        {
            if (panel_filters.Height < 100)
            {
                panel_filters.Height = 100;
                button_advancedFilter.Text = "Less...";
                advancedFilter = true;
            }
            else
            {
                button_advancedFilter.Text = "More...";
                panel_filters.Height = 26;
                advancedFilter = false;
            }

            ApplyFilter();
        }

        private void numericUpDown_filterWidth_ValueChanged(object sender, EventArgs e)
        {
            if (instantFilter)
                ApplyFilter();

            checkBox_filtersWidth.Checked = true;
        }

        private void numericUpDown_filterHeight_ValueChanged(object sender, EventArgs e)
        {
            if (instantFilter)
                ApplyFilter();

            checkBox_filtersHeight.Checked = true;
        }

        private void comboBox_parentImage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (instantFilter)
                ApplyFilter();

            // checkBox_filtersParent.Checked = true;
        }

        private void checkBox_columnAliases_CheckedChanged(object sender, EventArgs e)
        {
            ColumnVisiblityToggle();
        }

        private void checkBox_columnWidth_CheckedChanged(object sender, EventArgs e)
        {
            ColumnVisiblityToggle();
        }

        private void checkBox_columnHeight_CheckedChanged(object sender, EventArgs e)
        {
            ColumnVisiblityToggle();
        }

        private void checkBox_columnParent_CheckedChanged(object sender, EventArgs e)
        {
            ColumnVisiblityToggle();
        }

        public void ColumnVisiblityToggle()
        {
            if (dataGridView_subImages.Columns.Count > 0)
            {
                dataGridView_subImages.Columns["Aliases"].Visible = checkBox_columnAliases.Checked;
                dataGridView_subImages.Columns["Width"].Visible = checkBox_columnWidth.Checked;
                dataGridView_subImages.Columns["Height"].Visible = checkBox_columnHeight.Checked;
                dataGridView_subImages.Columns["Parent"].Visible = checkBox_columnParent.Checked;
            }
        }

        private void tabControl_views_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterTreeview = (tabControl_views.SelectedTab == tabPage_treeView);
            ApplyFilter();

            if (filterTreeview)
            {
                if (!advancedFilter)
                {
                    //button_advancedFilter_Click(null, null);
                }
            }
            else
            {
                if (advancedFilter)
                {
                    //button_advancedFilter_Click(null, null);
                }
            }
        }

        private void checkBox_filtersWidth_CheckedChanged(object sender, EventArgs e)
        {
            if (instantFilter)
                ApplyFilter();
        }

        private void checkBox_filtersHeight_CheckedChanged(object sender, EventArgs e)
        {
            if (instantFilter)
                ApplyFilter();
        }

        private void checkBox_filtersParent_CheckedChanged(object sender, EventArgs e)
        {
            if (instantFilter)
                ApplyFilter();
        }

        private void button_expandAll_Click(object sender, EventArgs e)
        {
            treeView_extImages.BeginUpdate();
            treeView_extImages.ExpandAll();
            treeView_extImages.EndUpdate();
        }

        private void button_collapseAll_Click(object sender, EventArgs e)
        {
            treeView_extImages.CollapseAll();
        }

        public static string GetTempDirectory()
        {
            string tempDirectory = Path.Combine(Path.GetTempPath(), "COH2UIAssetBrowser");
            Directory.CreateDirectory(tempDirectory);
            return tempDirectory;
        }

        public static string GetLoadArgsPath()
        {
            return Path.Combine(MainForm.GetTempDirectory(), "load.args");
        }
    }
}
