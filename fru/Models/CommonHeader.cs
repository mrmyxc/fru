using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fru.Models
{
    public class CommonHeader
    {
        public byte formatVersion;
        public byte iOffset;
        public byte cOffset;
        public byte bOffset;
        public byte prOffset;
        public byte mOffset;
        public byte paOffset;
        public byte checksum;

        public CommonHeader()
        {
            formatVersion = 0;
            iOffset = 0;
            cOffset = 0;
            bOffset = 0;
            prOffset = 0;
            mOffset = 0;
            paOffset = 0;
            checksum = 0;
        }

        public CommonHeader(List<byte> b)
        {
            formatVersion = b[0];
            iOffset = b[1];
            cOffset = b[2];
            bOffset = b[3];
            prOffset = b[4];
            mOffset = b[5];
            paOffset = b[6];
            checksum = b[7];
        }

        public void GetCommonHeader(List<byte> b)
        {
            formatVersion = b[0];
            iOffset = b[1];
            cOffset = b[2];
            bOffset = b[3];
            prOffset = b[4];
            mOffset = b[5];
            paOffset = b[6];
            checksum = b[7];
        }
    }

}
