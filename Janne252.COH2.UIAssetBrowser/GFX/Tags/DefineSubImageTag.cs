using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Janne252.COH2.UIAssetBrowser.GFX
{
    class DefineSubImageTag:GFXBaseTag
    {
        public UInt16 characterId;
        public UInt16 imageCharacterId;
        public UInt16 x1;
        public UInt16 y1;
        public UInt16 x2;
        public UInt16 y2;
        public UInt16 width;
        public UInt16 height;
        public string name = "<subImage>";
        public List<ExportAssetSymbol> symbols = new List<ExportAssetSymbol>();
        public List<string> aliases = new List<string>();
        public string aliasesList = "";
        public Rectangle rectangle;
        public DefineExternalmage2Tag parentImage;
        public volatile Bitmap bitmap;
        public bool hasAliases = false;
        public TreeNode treeNode;
        public bool treeNodeRemoved = false;
        public DefineSubImageTag(GFXBinaryReader reader, uint tagId, uint tagLength):base(reader, tagId, tagLength)
        {
            characterId = reader.ReadUInt16();
            imageCharacterId = reader.ReadUInt16();
            x1 = reader.ReadUInt16();
            y1 = reader.ReadUInt16();
            x2 = reader.ReadUInt16();
            y2 = reader.ReadUInt16();
            width = (UInt16)(x2 - x1);
            height = (UInt16)(y2 - y1);
            rectangle = new Rectangle(x1, y1, width, height);
        }

        public void HideTreeNode()
        {
            treeNode?.Remove();
            treeNodeRemoved = true;
        }

        public void ShowTreeNode()
        {
            if (treeNodeRemoved || treeNode.TreeView == null)
            {
                treeNodeRemoved = false;
                parentImage.treeNode.Nodes.Add(treeNode);
            }
        }

        public string GetExportFilePath(string rootPath, bool useParentSubFolder = false, string extension = ".png")
        {
            string path = rootPath;

            if (useParentSubFolder)
                path = Path.Combine(path, parentImage._fileName);

            return Path.Combine(path, name + extension);
        }

        public TreeNode GetTreeNode()
        {
            if (this.treeNode == null)
            {
                treeNode = new TreeNode(name, 2, 2);
                treeNode.Tag = new GFXTreeNodeTag(null, this);

                TreeNode detailsTreeNode = treeNode.Nodes.Add("", "Details", 3, 3);

                TreeNode aliasesTreeNode = treeNode.Nodes.Add("", "Aliases", 5, 5);
                ExportAssetSymbol assetSymbol;


                for (int i = 0; i < aliases.Count; i++)
                {
                    assetSymbol = symbols[i];
                    aliasesTreeNode.Nodes.Add(assetSymbol.name);
                }

                detailsTreeNode.Nodes.Add("", $"Parent: {parentImage._fileName}", 1, 1);
                TreeNode extraDetailsTreeNode = detailsTreeNode.Nodes.Add("", "Locations", 3, 3);
                TreeNode sizeTreeNode = detailsTreeNode.Nodes.Add("", "Dimensions", 3, 3);
                sizeTreeNode.Nodes.Add("", $"Width: {width}", 4, 4);

                sizeTreeNode.Nodes.Add("", $"Height: {height}", 4, 4);
                extraDetailsTreeNode.Nodes.Add("", $"X1: {x1}", 4, 4);
                extraDetailsTreeNode.Nodes.Add("", $"Y1: {y1}", 4, 4);
                extraDetailsTreeNode.Nodes.Add("", $"X2: {x2}", 4, 4);
                extraDetailsTreeNode.Nodes.Add("", $"Y2: {y2}", 4, 4);

                // treeNode.ExpandAll();
            }
            return treeNode;
        }

        public void AddSymbol(ExportAssetSymbol newSymbol)
        {
            ExportAssetSymbol existingSymbol;
            bool found = false;
            for (int i = 0; i < symbols.Count; i++)
            {
                existingSymbol = symbols[i];
                if (existingSymbol.name == newSymbol.name)
                {
                    found = true;
                    break;
                }

            }
            if (!found)
            {
                if (symbols.Count == 0)
                    name = newSymbol.name;

                symbols.Add(newSymbol);
            }

            UpdateAliases();
        }

        public void DisposeBitmap()
        {
            if (bitmap != null)
                bitmap.Dispose();

            bitmap = null;
        }

        private void UpdateAliases()
        {
            aliases.Clear();
            if (symbols.Count > 1)
            {
                ExportAssetSymbol existingSymbol;
                for (int i = 1; i < symbols.Count; i++)
                {
                    existingSymbol = symbols[i];
                    aliases.Add(existingSymbol.name);
                    hasAliases = true;
                }
            }

            aliasesList = String.Join(", ", aliases);
        }

        public object[] GetDataRow()
        {

            return new object[] { name, aliasesList, width, height, parentImage._fileName, this };
        }

        public Bitmap GetBitmap()
        {
            if (bitmap == null)
            {
                Bitmap parentBitmap = parentImage.GetBitmap();

                bitmap = parentBitmap.Clone(rectangle, parentBitmap.PixelFormat);
            }
            return bitmap;
        }
    }
}
