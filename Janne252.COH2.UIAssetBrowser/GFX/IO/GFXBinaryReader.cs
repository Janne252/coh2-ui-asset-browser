using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Janne252.COH2.UIAssetBrowser.GFX;
using System.Windows.Forms;

namespace Janne252.COH2.UIAssetBrowser
{
    class GFXBinaryReader:BinaryReader
    {

        public GFXBinaryReader(FileStream input) : base(input)
        {

        }

        /// <summary>
        /// Reads the header of the provided *.gfx file.
        /// </summary>
        /// <returns>Returns the read header.</returns>
        public GFXHeader ReadHeader()
        {
            GFXHeader header = new GFXHeader();
            header.Signature = Encoding.Default.GetString(this.ReadBytes(3));
            header.Version = this.ReadByte();
            header.FileSize = this.ReadUInt32();
            header.DisplayRekt = this.ReadBytes(10);
            header.FrameRateFirstByte = this.ReadByte();
            header.FrameRate = this.ReadByte();
            header.FrameCount = this.ReadUInt16();

            return header;
        }

        /// <summary>
        /// Reads the next Tag in the provided *.gfx file.
        /// </summary>
        /// <returns>Returns the parsed Tag.</returns>
        public GFXBaseTag ReadTag()
        {
            uint num = ReadUInt16();
            uint tagId = num >> 6;

            uint tagLength = num - (tagId << 6);

            if (tagLength == 63)
                tagLength = ReadUInt32();

            switch (tagId)
            {
                case 56:
                    return new ExportAssetsTag(this, tagId, tagLength);
                case 76:
                    return new ExportAssetsTag(this, tagId, tagLength);
                case 1008:
                    return new DefineSubImageTag(this, tagId, tagLength);
                case 1009:
                    return new DefineExternalmage2Tag(this, tagId, tagLength);
                default:
                    return new GFXBaseTag(this, tagId, tagLength, true);
            }
        }

        /// <summary>
        /// Reads a null-terminated string.
        /// </summary>
        /// <returns>Returns the string.</returns>
        public string ReadNullTerminatedString()
        {
            StringBuilder buffer = new StringBuilder();

            Char c;
            while((int)(c = ReadChar()) != 0)
            {
                buffer.Append(c);
            }
            return buffer.ToString();
        }
    }
}
