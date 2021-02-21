using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fru.Helpers;

namespace fru.Models
{
    public class BoardArea
    {
        public int mfgminutes;
        public byte formatVersion;
        private byte length;
        public int actualLength;
        public LanguageCode languageCode;
        private byte[] mfgTime;
        public TLString manufacuturer;
        public TLString serialNumber;
        public TLString productName;
        public TLString partNumber;
        public TLString fileID;
        public byte checksum;
        public int padding;

        public BoardArea()
        {
            formatVersion = 0;
            length = 0;
            languageCode = LanguageCode.English_2;
            mfgTime = new byte[] { 0, 0, 0 };
            mfgminutes = (mfgTime[0] << 16) | (mfgTime[1] << 8) | mfgTime[2];
            manufacuturer = new TLString();
            productName = new TLString();
            serialNumber = new TLString();
            partNumber = new TLString();
            fileID = new TLString();
            checksum = 0;
        }

        public BoardArea(CommonHeader ch, List<byte> b)
        {
            mfgTime = new byte[3] { 0, 0, 0 };
            GetBoardArea(ch, b);
        }

        public void GetBoardArea(CommonHeader ch, List<byte> b)
        {
            if (ch == null)
            {
                return;
            }

            if (b.Count < 8)
            {
                return;
            }

            int bI = 0;

            int bas = ch.bOffset * 8;
            this.formatVersion = b[bas + 0];
            this.length = b[bas + 1];

            this.actualLength = this.length * 8;

            this.languageCode = (LanguageCode)b[bas + 2];

            this.mfgTime = new byte[3]
            {
                    b[bas+3],
                    b[bas+4],
                    b[bas+5]
            };

            this.mfgminutes = (mfgTime[0] << 16) | (mfgTime[1] << 8) | mfgTime[2];

            int mfgt = (b[bas + 3] << 16) | (b[bas + 4] << 8) | b[bas + 5];
            DateTime dt = Hel.timeStartOffset.AddMinutes(mfgt);

            List<byte> gl = new List<byte>();

            bI = 6;
            this.manufacuturer.typeLength = Hel.GetTypeLength(b[bas + bI]);
            bI++;
            for (int i = 0; i < this.manufacuturer.typeLength.length; i++)
            {
                gl.Add(b[bas + bI + i]);
            }

            this.manufacuturer.value = Encoding.UTF8.GetString(gl.ToArray());
            bI = bI + this.manufacuturer.typeLength.length;
            Console.WriteLine("Manufacturer Name: {0}", this.manufacuturer.value);

            this.productName.typeLength = Hel.GetTypeLength(b[bas + bI]);
            bI++;
            gl.Clear();
            for (int i = 0; i < this.productName.typeLength.length; i++)
            {
                gl.Add(b[bas + bI + i]);
            }
            this.productName.value = Encoding.UTF8.GetString(gl.ToArray());
            bI = bI + this.productName.typeLength.length;
            Console.WriteLine("Product Name: {0}", this.productName.value);

            this.serialNumber.typeLength = Hel.GetTypeLength(b[bas + bI]);
            bI++;
            gl.Clear();
            for (int i = 0; i < this.serialNumber.typeLength.length; i++)
            {
                gl.Add(b[bas + bI + i]);
            }
            this.serialNumber.value = Encoding.UTF8.GetString(gl.ToArray());
            bI = bI + this.serialNumber.typeLength.length;
            Console.WriteLine("Serial Number: {0}", this.serialNumber.value);

            this.partNumber.typeLength = Hel.GetTypeLength(b[bas + bI]);
            bI++;
            gl.Clear();
            for (int i = 0; i < this.partNumber.typeLength.length; i++)
            {
                gl.Add(b[bas + bI + i]);
            }
            this.partNumber.value = Encoding.UTF8.GetString(gl.ToArray());
            bI = bI + this.partNumber.typeLength.length;
            Console.WriteLine("Part Number: {0}", this.partNumber.value);

            this.fileID.typeLength = Hel.GetTypeLength(b[bas + bI]);
            bI++;
            gl.Clear();
            for (int i = 0; i < this.fileID.typeLength.length; i++)
            {
                gl.Add(b[bas + bI + i]);
            }
            this.fileID.value = Encoding.UTF8.GetString(gl.ToArray());
            bI = bI + this.fileID.typeLength.length;
            Console.WriteLine("FRU File ID: {0}", this.fileID.value);

            if (b[bas + bI] == 0xC1)
            {
                Console.WriteLine("Ended at Index {0}. {1} bytes are padding.", bas + bI, (actualLength - 1) - bI - 1);
            }

            this.checksum = b[bas + actualLength - 1];

            bI = actualLength - 2;
            byte calculatedChecksum = 0;
            for (int i = 0; i < (actualLength - 1); i++)
            {
                calculatedChecksum += b[bas + i];
            }
            calculatedChecksum = (byte)(256 - calculatedChecksum);
        }

        public List<byte> GetBoardAreaBytes()
        {
            List<byte> bAb = new List<byte>();

            byte calculatedChecksum = 0;

            bAb.Add(this.formatVersion);
            this.length = (byte) (this.actualLength / 8);
            bAb.Add(this.length);
            bAb.Add((byte)this.languageCode);
            mfgTime[0] = (byte)((mfgminutes >> 16) & 0xFF);
            mfgTime[1] = (byte)((mfgminutes >> 8) & 0xFF);
            mfgTime[2] = (byte)((mfgminutes >> 0) & 0xFF);
            bAb.Add(this.mfgTime[0]);
            bAb.Add(this.mfgTime[1]);
            bAb.Add(this.mfgTime[2]);
            foreach (byte tlbyte in Hel.ConvertTLString(this.manufacuturer))
            {
                bAb.Add(tlbyte);
            }
            foreach (byte tlbyte in Hel.ConvertTLString(this.productName))
            {
                bAb.Add(tlbyte);
            }
            foreach (byte tlbyte in Hel.ConvertTLString(this.serialNumber))
            {
                bAb.Add(tlbyte);
            }
            foreach (byte tlbyte in Hel.ConvertTLString(this.partNumber))
            {
                bAb.Add(tlbyte);
            }
            foreach (byte tlbyte in Hel.ConvertTLString(this.fileID))
            {
                bAb.Add(tlbyte);
            }

            // end
            bAb.Add(0xC1);

            for (int i = 0; i < ((bAb.Count + 1) % 8); i++)
            {
                bAb.Add(0x00);
            }

            bAb[1] = this.length = (byte)((bAb.Count + 1) / 8);

            foreach (byte tb in bAb)
            {
                calculatedChecksum += tb;
            }
            calculatedChecksum = (byte)(256 - calculatedChecksum);

            bAb.Add(calculatedChecksum);

            return bAb;
        }

        public byte GetChecksum()
        {
            return GetBoardAreaBytes().Last();
        }
    }

}
