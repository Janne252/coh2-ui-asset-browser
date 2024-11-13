using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Janne252.COH2.UIAssetBrowser.GFX
{
    class GFXHeader
    {
        public string Signature;
        public uint Version;
        public uint FileSize;
        public byte[] DisplayRekt;
        public uint FrameRateFirstByte;
        public uint FrameRate;
        public uint FrameCount;
    }
}
