using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FreeImageAPI;
using System.IO;

namespace Janne252.COH2.UIAssetBrowser.GFX
{
    class DefineExternalmage2Tag:GFXBaseTag
    {
        public UInt32 characterId;
        public UInt16 bitmapFormat;
        public UInt16 targetWidth;
        public UInt16 targetHeight;
        public uint exportNameLenght;
        public string exportName;
        public uint fileNameLenght;
        public string fileName;
        public string _fileName;
        public string fullFilePath;
        public volatile Bitmap bitmap;
        public TreeNode treeNode;
        public List<DefineSubImageTag> subImages = new List<DefineSubImageTag>();

        public DefineExternalmage2Tag(GFXBinaryReader reader, uint tagId, uint tagLength): base(reader, tagId, tagLength)
        {
            byte[] _data = reader.ReadBytes(4);
            characterId = BitConverter.ToUInt16(new byte[] { _data[0], _data[1] }, 0);
            //MessageBox.Show($"characterId first 2: {BitConverter.ToUInt16(new byte[] {characerIdBytes[0], characerIdBytes[1]}, 0)}");
            bitmapFormat = reader.ReadUInt16();
            targetWidth = reader.ReadUInt16();
            targetHeight = reader.ReadUInt16();
            exportNameLenght = reader.ReadByte();
            //MessageBox.Show($"exportNameLenght: {extImage.exportNameLenght}");
            exportName = Encoding.Default.GetString(reader.ReadBytes((int)exportNameLenght));
            //MessageBox.Show($"exportName: {extImage.exportName}");
            fileNameLenght = reader.ReadByte();
            //MessageBox.Show($"fileNameLenght: {extImage.fileNameLenght}");
            fileName = Encoding.Default.GetString(reader.ReadBytes((int)fileNameLenght));
            _fileName = Path.GetFileNameWithoutExtension(fileName);
            //MessageBox.Show($"fileName: {extImage.fileName}, characterId first 2: {BitConverter.ToUInt16(new byte[] { characerIdBytes[0], characerIdBytes[1] }, 0)}");
        }

        public Bitmap GetBitmap()
        {
            if (bitmap == null)
            {
                FIBITMAP map = FreeImage.Load(FREE_IMAGE_FORMAT.FIF_DDS, fullFilePath, FREE_IMAGE_LOAD_FLAGS.DEFAULT);
                if (!map.IsNull)
                {
                    bitmap = FreeImage.GetBitmap(map);
                    FreeImage.Unload(map);
                }
                else
                {
                    return null;
                }
            }

            return bitmap;
        }

        public void DisposeBitmap(bool disposeSubImages = true)
        {
            if (bitmap != null)
                bitmap.Dispose();

            bitmap = null;

            if (disposeSubImages)
                DisposeSubImageBitmaps();
        }

        public void LoadSubImages()
        {
            for (int i = 0; i < subImages.Count; i++)
            {
                subImages[i].GetBitmap();
            }
        }

        public void DisposeSubImageBitmaps()
        {
            for (int i = 0; i < subImages.Count; i++)
            {
                subImages[i].DisposeBitmap();
            }
        }

        public TreeNode GetTreeNode()
        {
            if (treeNode == null)
            {
                treeNode = new TreeNode(_fileName + ".dds", 1, 1);
                treeNode.Tag = new GFXTreeNodeTag(this);

                DefineSubImageTag subImage;
                for (int i = 0; i < subImages.Count; i++)
                {
                    subImage = subImages[i];
                    treeNode.Nodes.Add(subImage.GetTreeNode());
                }
            }
            return treeNode;
        }

        public void AddSubImage(DefineSubImageTag subImage)
        {
            subImages.Add(subImage);
            subImage.parentImage = this;
        }
    }
}
