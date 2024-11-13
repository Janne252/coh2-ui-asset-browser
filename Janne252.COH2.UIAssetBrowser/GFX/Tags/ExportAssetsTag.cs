using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Janne252.COH2.UIAssetBrowser.GFX
{
    class ExportAssetsTag:GFXBaseTag
    {
        public uint numSymbols;
        public List<ExportAssetSymbol> symbols = new List<ExportAssetSymbol>();
        public ExportAssetsTag(GFXBinaryReader reader, uint tagId, uint tagLength) : base(reader, tagId, tagLength)
        {
            numSymbols = reader.ReadUInt16();
            uint end = (uint)reader.BaseStream.Position + tagLength - 2; //2 = reserved for symbolCount
            //MessageBox.Show($"end: {end}");
            while(reader.BaseStream.Position < end)
            {
                AddSymbol(reader.ReadUInt16(), reader.ReadNullTerminatedString());
            }

            //MessageBox.Show($"Read {symbols.Count} ({aliasCount} aliases) symbols. ({numSymbols})");
        }

        public void AddSymbol(uint subImageId, string name)
        {
            symbols.Add(new ExportAssetSymbol(subImageId, name));
           /* if (symbols.ContainsKey(subImageId))
            {
                aliasCount++;
                symbols[subImageId].aliases.Add(new GFXExportAssetSymbol(subImageId, name));
            }
            else
            {
                symbols.Add(subImageId, new GFXExportAssetSymbol(subImageId, name));
            }*/
        }
    }

    class ExportAssetSymbol
    {
        public uint subImageId;
        public string name;

        public ExportAssetSymbol(uint subImageId, string name)
        {
            this.subImageId = subImageId;
            this.name = name;
        }

        // public List<ExportAssetSymbol> aliases = new List<ExportAssetSymbol>();
    }
}
