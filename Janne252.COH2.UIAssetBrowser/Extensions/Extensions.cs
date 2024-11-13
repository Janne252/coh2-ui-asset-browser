using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using Janne252.COH2.UIAssetBrowser.GFX;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Janne252.COH2.UIAssetBrowser
{
    public static class Extensions
    {
        public static string PrepareForDataBindingFilter(this string value)
        {
            StringBuilder builder = new StringBuilder();

            foreach (char c in value)
            {
                if (c == '%' || c == '_' || c == '[' || c == ']' || c == '!' || c == '^')
                    builder.Append("[" + c + "]");
                else
                    builder.Append(c);
            }

            return builder.ToString();
        }

        public static void SaveBitmap(this Bitmap bitmap, string filename, ImageFormat format = null)
        {
            string rootDir = Path.GetDirectoryName(filename);
            if (!Directory.Exists(rootDir))
                Directory.CreateDirectory(rootDir);

            if (format == null)
                bitmap.Save(filename);
            else
                bitmap.Save(filename, format);
        }

        public static void SuspendDrawing(this TreeView treeView)
        {
            NativeMethods.SuspendDrawing(treeView);
        }

        public static void ResumeDrawing(this TreeView treeView)
        {
            NativeMethods.ResumeDrawing(treeView);
        }
    }


    public static class FilePath
    {
        public static string SetExtension(string filePath, string extension = "")
        {
            return Path.Combine(Path.GetDirectoryName(filePath), Path.GetFileNameWithoutExtension(filePath) + extension);
        }
    }

    class GFXTreeNodeTag
    {
        public DefineExternalmage2Tag extImage;
        public DefineSubImageTag subImage;

        public GFXTreeNodeTag(DefineExternalmage2Tag extImage = null, DefineSubImageTag subImage = null)
        {
            this.extImage = extImage;
            this.subImage = subImage;
        }
    }

    class DrawingControl
    {

    }



}
