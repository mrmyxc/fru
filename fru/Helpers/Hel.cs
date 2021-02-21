using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace fru.Helpers
{
    public enum TypeCode
    {
        [Description("Binary/Unspecified [0]")]
        Binary_Unspecified = 0,
        [Description("BCD Plus [1]")]
        BCDPlus = 1,
        [Description("ASCII-6 Bit [2]")]
        ASCII_6Bit = 2,
        [Description("Use Language Code [3]")]
        UseLanguageCode = 3
    }

    public struct TypeLength
    {
        public TypeCode type;
        public int length;
    }

    public struct TLString
    {
        public TypeLength typeLength;
        public string value;
    }

    public enum LanguageCode
        {
            [Description("English [0]")]
            English = 0,
            [Description("Afar [1]")]
            Afar = 1,
            [Description("Abkhazian [2]")]
            Abkhazian = 2,
            [Description("Afrikaans [3]")]
            Afrikaans = 3,
            [Description("Amharic [4]")]
            Amharic = 4,
            [Description("Arabic [5]")]
            Arabic = 5,
            [Description("Assamese [6]")]
            Assamese = 6,
            [Description("Aymara [7]")]
            Aymara = 7,
            [Description("Azerbaijani [8]")]
            Azerbaijani = 8,
            [Description("Bashkir [9]")]
            Bashkir = 9,
            [Description("Byelorussian [10]")]
            Byelorussian = 10,
            [Description("Bulgarian [11]")]
            Bulgarian = 11,
            [Description("Bihari [12]")]
            Bihari = 12,
            [Description("Bislama [13]")]
            Bislama = 13,
            [Description("Bengali;Bangla [14]")]
            Bengali_Bangla = 14,
            [Description("Tibetan [15]")]
            Tibetan = 15,
            [Description("Breton [16]")]
            Breton = 16,
            [Description("Catalan [17]")]
            Catalan = 17,
            [Description("Corsican [18]")]
            Corsican = 18,
            [Description("Czech [19]")]
            Czech = 19,
            [Description("Welsh [20]")]
            Welsh = 20,
            [Description("Danish [21]")]
            Danish = 21,
            [Description("German [22]")]
            German = 22,
            [Description("Bhutani [23]")]
            Bhutani = 23,
            [Description("Greek [24]")]
            Greek = 24,
            [Description("English [25]")]
            English_2 = 25,
            [Description("Esperanto [26]")]
            Esperanto = 26,
            [Description("Spanish [27]")]
            Spanish = 27,
            [Description("Estonian [28]")]
            Estonian = 28,
            [Description("Basque [29]")]
            Basque = 29,
            [Description("Persian [30]")]
            Persian = 30,
            [Description("Finnish [31]")]
            Finnish = 31,
            [Description("Fiji [32]")]
            Fiji = 32,
            [Description("Faeroese [33]")]
            Faeroese = 33,
            [Description("French [34]")]
            French = 34,
            [Description("Frisian [35]")]
            Frisian = 35,
            [Description("Irish [36]")]
            Irish = 36,
            [Description("Scots Gaelic [37]")]
            Scots_Gaelic = 37,
            [Description("Galician [38]")]
            Galician = 38,
            [Description("Guarani [39]")]
            Guarani = 39,
            [Description("Gujarati [40]")]
            Gujarati = 40,
            [Description("Hausa [41]")]
            Hausa = 41,
            [Description("Hindi [42]")]
            Hindi = 42,
            [Description("Croatian [43]")]
            Croatian = 43,
            [Description("Hungarian [44]")]
            Hungarian = 44,
            [Description("Armenian [45]")]
            Armenian = 45,
            [Description("Interlingua [46]")]
            Interlingua = 46,
            [Description("Interlingue [47]")]
            Interlingue = 47,
            [Description("Inupiak [48]")]
            Inupiak = 48,
            [Description("Indonesian [49]")]
            Indonesian = 49,
            [Description("Icelandic [50]")]
            Icelandic = 50,
            [Description("Italian [51]")]
            Italian = 51,
            [Description("Hebrew [52]")]
            Hebrew = 52,
            [Description("Japanese [53]")]
            Japanese = 53,
            [Description("Yiddish [54]")]
            Yiddish = 54,
            [Description("Javanese [55]")]
            Javanese = 55,
            [Description("Georgian [56]")]
            Georgian = 56,
            [Description("Kazakh [57]")]
            Kazakh = 57,
            [Description("Greenlandic [58]")]
            Greenlandic = 58,
            [Description("Cambodian [59]")]
            Cambodian = 59,
            [Description("Kannada [60]")]
            Kannada = 60,
            [Description("Korean [61]")]
            Korean = 61,
            [Description("Kashmiri [62]")]
            Kashmiri = 62,
            [Description("Kurdish [63]")]
            Kurdish = 63,
            [Description("Kirghiz [64]")]
            Kirghiz = 64,
            [Description("Latin [65]")]
            Latin = 65,
            [Description("Lingala [66]")]
            Lingala = 66,
            [Description("Laothian [67]")]
            Laothian = 67,
            [Description("Lithuanian [68]")]
            Lithuanian = 68,
            [Description("Latvian;Lettish [69]")]
            Latvian_Lettish = 69,
            [Description("Malagasy [70]")]
            Malagasy = 70,
            [Description("Maori [71]")]
            Maori = 71,
            [Description("Macedonian [72]")]
            Macedonian = 72,
            [Description("Malayalam [73]")]
            Malayalam = 73,
            [Description("Mongolian [74]")]
            Mongolian = 74,
            [Description("Moldavian [75]")]
            Moldavian = 75,
            [Description("Marathi [76]")]
            Marathi = 76,
            [Description("Malay [77]")]
            Malay = 77,
            [Description("Maltese [78]")]
            Maltese = 78,
            [Description("Burmese [79]")]
            Burmese = 79,
            [Description("Nauru [80]")]
            Nauru = 80,
            [Description("Nepali [81]")]
            Nepali = 81,
            [Description("Dutch [82]")]
            Dutch = 82,
            [Description("Norwegian [83]")]
            Norwegian = 83,
            [Description("Occitan [84]")]
            Occitan = 84,
            [Description("(Afan) Oromo [85]")]
            Afan_Oromo = 85,
            [Description("Oriya [86]")]
            Oriya = 86,
            [Description("Punjabi [87]")]
            Punjabi = 87,
            [Description("Polish [88]")]
            Polish = 88,
            [Description("Pashto;Pushto [89]")]
            Pashto_Pushto = 89,
            [Description("Portuguese [90]")]
            Portuguese = 90,
            [Description("Quechua [91]")]
            Quechua = 91,
            [Description("Rhaeto-Romance [92]")]
            Rhaeto_Romance = 92,
            [Description("Kirundi [93]")]
            Kirundi = 93,
            [Description("Romanian [94]")]
            Romanian = 94,
            [Description("Russian [95]")]
            Russian = 95,
            [Description("Kinyarwanda [96]")]
            Kinyarwanda = 96,
            [Description("Sanskrit [97]")]
            Sanskrit = 97,
            [Description("Sindhi [98]")]
            Sindhi = 98,
            [Description("Sangro [99]")]
            Sangro = 99,
            [Description("Serbo-Croatian [100]")]
            Serbo_Croatian = 100,
            [Description("Singhalese [101]")]
            Singhalese = 101,
            [Description("Slovak [102]")]
            Slovak = 102,
            [Description("Slovenian [103]")]
            Slovenian = 103,
            [Description("Samoan [104]")]
            Samoan = 104,
            [Description("Shona [105]")]
            Shona = 105,
            [Description("Somali [106]")]
            Somali = 106,
            [Description("Albanian [107]")]
            Albanian = 107,
            [Description("Serbian [108]")]
            Serbian = 108,
            [Description("Siswati [109]")]
            Siswati = 109,
            [Description("Sesotho [110]")]
            Sesotho = 110,
            [Description("Sudanese [111]")]
            Sudanese = 111,
            [Description("Swedish [112]")]
            Swedish = 112,
            [Description("Swahili [113]")]
            Swahili = 113,
            [Description("Tamil [114]")]
            Tamil = 114,
            [Description("Tegulu [115]")]
            Tegulu = 115,
            [Description("Tajik [116]")]
            Tajik = 116,
            [Description("Thai [117]")]
            Thai = 117,
            [Description("Tigrinya [118]")]
            Tigrinya = 118,
            [Description("Turkmen [119]")]
            Turkmen = 119,
            [Description("Tagalog [120]")]
            Tagalog = 120,
            [Description("Setswana [121]")]
            Setswana = 121,
            [Description("Tonga [122]")]
            Tonga = 122,
            [Description("Turkish [123]")]
            Turkish = 123,
            [Description("Tsonga [124]")]
            Tsonga = 124,
            [Description("Tatar [125]")]
            Tatar = 125,
            [Description("Twi [126]")]
            Twi = 126,
            [Description("Ukrainian [127]")]
            Ukrainian = 127,
            [Description("Urdu [128]")]
            Urdu = 128,
            [Description("Uzbek [129]")]
            Uzbek = 129,
            [Description("Vietnamese [130]")]
            Vietnamese = 130,
            [Description("Volapuk [131]")]
            Volapuk = 131,
            [Description("Wolof [132]")]
            Wolof = 132,
            [Description("Xhosa [133]")]
            Xhosa = 133,
            [Description("Yoruba [134]")]
            Yoruba = 134,
            [Description("Chinese [135]")]
            Chinese = 135,
            [Description("Zulu [136]")]
            Zulu = 136,
        }
    

    public static class Hel
    {

        // 00:00 1/1/96
        public static DateTime timeStartOffset = new DateTime(1996, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public static TypeLength GetTypeLength(byte tl)
        {
            TypeLength tlen = new TypeLength();

            tlen.type = (TypeCode)((tl >> 6) & 0x03);
            tlen.length = tl & 0x3F;

            return tlen;
        }

        public static byte GetTypeLengthByte(TypeLength tl)
        {
            byte typePart = (byte)tl.type;

            return (byte)((byte)(typePart << 6) | (byte)tl.length);
        }

        public static List<byte> ConvertTLString(TLString tLString)
        {
            List<byte> tlsb = new List<byte>();

            tlsb.Add(GetTypeLengthByte(tLString.typeLength));

            foreach (byte eb in Encoding.UTF8.GetBytes(tLString.value))
            {
                tlsb.Add(eb);
            }

            return tlsb;
        }

        private static double GetFruMinutes(this DateTime dateTime)
        {
            var time = dateTime.ToUniversalTime() - timeStartOffset;

            return time.TotalMinutes;
        }

        private static DateTime GetFruDateTime(double minutes)
        {
            return timeStartOffset.AddMinutes(minutes);
        }
    }
}
