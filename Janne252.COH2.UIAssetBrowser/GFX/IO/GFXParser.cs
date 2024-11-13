using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using Janne252.COH2.UIAssetBrowser.GFX;
using System.Data;

namespace Janne252.COH2.UIAssetBrowser
{
    class GFXParser
    {
        /// <summary>
        /// Header data of the provided *.gfx file.
        /// </summary>
        public GFXHeader Header;
        /// <summary>
        /// List containing all external images defined in the provided *.gfx file.
        /// </summary>
        public List<DefineExternalmage2Tag> ExternalImages = new List<DefineExternalmage2Tag>();
        /// <summary>
        /// List containing all sub-images defined in the provided *.gfx file. Note! All sub-images are also accessible in ExternalImages.
        /// </summary>
        public List<DefineSubImageTag> SubImages = new List<DefineSubImageTag>();
        /// <summary>
        /// List containing all ExportAssetSymbols (sub-image names) defined in the provided *.gfx file.
        /// </summary>
        public List<ExportAssetSymbol> ExportAssetSymbols = new List<ExportAssetSymbol>();
        /// <summary>
        /// BindingSource containing the data of all sub-images. Can be sorted and should be used as the DataSource of a DataGridView.
        /// </summary>
        public BindingSource BindingSource_SubImages = new BindingSource();
        /// <summary>
        /// "DataSource" containing the names of all ExternalImages. Used for populating a ComboBox.
        /// </summary>
        public List<string> DataSource_ExternalImageNames = new List<string>();
        public TreeNode treeNode;
        private string ddsImagePath = "";
        public bool Abort = false;

        private string sourceFile;
        private DataTable dt_subImages = new DataTable();
        private List<GFXBaseTag> rawTags = new List<GFXBaseTag>();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sourceFile">*.gfx file to process.</param>
        public GFXParser(string sourceFile)
        {
            ddsImagePath = Path.Combine(Directory.GetParent(Path.GetDirectoryName(sourceFile)) + @"\data\ui\assets\textures\");
            string ddsImagePathAlt = Path.Combine(Directory.GetParent(Path.GetDirectoryName(sourceFile)) + @"\assets\textures\");

            if (!Directory.Exists(ddsImagePath))
            {
                if (!Directory.Exists(ddsImagePathAlt))
                {
                    MessageBox.Show($"Unable to locate '{ddsImagePathAlt}'. Entire UI archive must be extracted! Aborting.", "Error - Missing Files", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Abort = true;
                }
                else
                {
                    ddsImagePath = ddsImagePathAlt;
                }
            }

            treeNode = new TreeNode(Path.GetFileName(sourceFile), 0, 0);
            treeNode.Expand();
            this.sourceFile = sourceFile;

            BindingSource_SubImages.DataSource = dt_subImages;
            dt_subImages.Columns.Add("Name", typeof(string));
            dt_subImages.Columns.Add("Aliases", typeof(string));
            dt_subImages.Columns.Add("Width", typeof(UInt16));
            dt_subImages.Columns.Add("Height", typeof(UInt16));
            dt_subImages.Columns.Add("Parent", typeof(string));
            dt_subImages.Columns.Add("subImage", typeof(DefineSubImageTag));
        }

        /// <summary>
        /// Unloads (Disposes) all ExternalImage Bitmaps and their sub-image Bitmaps.
        /// </summary>
        public void DisposeBitmaps()
        {
            for (int i = 0; i < ExternalImages.Count; i++)
            {
                ExternalImages[i].DisposeBitmap();
            }
        }

        /// <summary>
        /// Loads all ExternalImage Bitmaps and their sub-image Bitmaps to the memory.
        /// </summary>
        public void LoadBitmaps()
        {
            for (int i = 0; i < ExternalImages.Count; i++)
            {
                ExternalImages[i].GetBitmap();
                ExternalImages[i].LoadSubImages();
            }
        }

        /// <summary>
        /// Processes the provided *.gfx File.
        /// </summary>
        public void Parse()
        {
            FileStream fs_sourceFile = new FileStream(this.sourceFile, FileMode.Open);
            GFXBinaryReader reader = new GFXBinaryReader(fs_sourceFile);
            this.Header = reader.ReadHeader();

            // Variables used in iterations
            ExportAssetSymbol assetSymbol;
            DefineSubImageTag subImage;
            DefineExternalmage2Tag extImage;

            while (reader.BaseStream.Position < reader.BaseStream.Length)
            {
                GFXBaseTag tag = reader.ReadTag();
                Type tagType = tag.GetType();

                if (tagType == typeof(DefineExternalmage2Tag))
                {
                    ExternalImages.Add((DefineExternalmage2Tag)tag);
                }
                else if(tagType == typeof(DefineSubImageTag))
                {
                    SubImages.Add((DefineSubImageTag)tag);
                }
                else if(tagType == typeof(ExportAssetsTag))
                {
                    ExportAssetSymbols.AddRange(((ExportAssetsTag)tag).symbols);
                }
                rawTags.Add(tag);
            }

            //Sort lists by name for treeView
            SubImages = SubImages.OrderBy(item => item.name).ToList();
            ExternalImages = ExternalImages.OrderBy(item => item._fileName).ToList();

            // Collect all symbols to subImages for easy access
            for (int i = 0; i < ExportAssetSymbols.Count; i++)
            {
                assetSymbol = ExportAssetSymbols[i];
                for(int j = 0; j < SubImages.Count; j++)
                {
                    subImage = SubImages[j];

                    if (assetSymbol.subImageId == subImage.characterId)
                        subImage.AddSymbol(assetSymbol);
                }
            }

            // Collect all subImages to externalImages
            for (int i = 0; i < ExternalImages.Count; i++)
            {
                extImage = ExternalImages[i];
                DataSource_ExternalImageNames.Add(extImage._fileName);
                extImage.fullFilePath = Path.Combine(ddsImagePath, FilePath.SetExtension(extImage.fileName, ".dds"));
                for (int j = 0; j < SubImages.Count; j++)
                {
                    subImage = SubImages[j];

                    if (extImage.characterId == subImage.imageCharacterId)
                        extImage.AddSubImage(subImage);
                }
            }

            for (int j = 0; j < SubImages.Count; j++)
            {
                subImage = SubImages[j];
                dt_subImages.Rows.Add(subImage.GetDataRow());
            }

            for (int i = 0; i < ExternalImages.Count; i++)
            {
                extImage = ExternalImages[i];
                treeNode.Nodes.Add(extImage.GetTreeNode());
            }
            
            //MessageBox.Show($"Read {subImages.Count} subImages. Symbols: {symbolCount} ({aliasCount}) Placed {placedSubImagesCount} subImages.");
            reader.Close();
            fs_sourceFile.Close();
        }
    }
}


