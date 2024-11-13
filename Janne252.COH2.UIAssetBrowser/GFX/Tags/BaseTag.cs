using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Janne252.COH2.UIAssetBrowser.GFX
{
    class GFXBaseTag
    {
        public byte[] data;
        public uint TagId;

        public GFXBaseTag(GFXBinaryReader reader, uint tagId, uint tagLength, bool readData = false)
        {
            TagId = tagId;

            if (readData)
            {
                data = reader.ReadBytes((int)tagLength);

                /*
                string stuff = Encoding.Default.GetString(data);

                if (stuff.IndexOf("FrameBraceEnabled") != -1)
                {

                    File.WriteAllBytes("test.bin", data);   
                    bool found = true;
                }
                */
            }
        }
    }
}
