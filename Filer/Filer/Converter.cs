using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace SokobanFiler
{
    public class Converter : iConverter
    {

        private string MyCompressed;

        public string Compressed
        {
            get { return MyCompressed; }
            set { MyCompressed = value; }
        }

        private string MyExpanded;

        public string Expanded
        {
            get { return MyExpanded; }
            set { MyExpanded = value; }
        }

        public void Compress(string uncompressedLevel)
        {
            uncompressedLevel = uncompressedLevel.Trim();
            uncompressedLevel = Regex.Replace(uncompressedLevel, "\n", delegate (Match c){return "|";});
            Compressed = Regex.Replace(uncompressedLevel, @"(\S)\1*", delegate (Match m)
            {
                if (m.Groups[1].Value == "\n")
                    return "|";
                else if (m.Value.Length != 1)
                    return string.Concat(m.Value.Length, m.Groups[1].Value);
                else 
                    return m.Groups[1].Value.ToString();
            });
            //string res = "";
            //int c = 1;
            //int i = 0;
            //char[] explode = uncompressedLevel.ToCharArray();
            //do
            //{
            //    i++;
            //    string t = explode[i - 1].ToString();
            //    try
            //    {
            //        if (explode[i].ToString() == t)
            //        {
            //            c++;
            //        }
            //        else
            //        {
            //            if ( c != 1)
            //            {
            //                res += t + c;
            //            }
            //            else
            //            {
            //                res += t;
            //            }
            //            c = 1;
            //        }
            //    } 
            //    catch
            //    {
            //        if (c != 1)
            //        {
            //            res += t + c;
            //        }
            //        else
            //        {
            //            res += t;
            //        }
            //    }

            //} while (i < explode.Length);
            //Compressed = res;
        }

        public void Expand(string compressedLevel)
        {

            //string res = "";
            //string a = "";
            //int count = 0;
            ////StringBuilder sb = new StringBuilder();
            //char current = char.MinValue;
            //for (int i = 0; i < compressedLevel.Length; i++)
            //{
            //    current = compressedLevel[i];
            //    if (char.IsDigit(current))
            //        a += current;
            //    else
            //    {
            //        count = int.Parse(a);
            //        a = "";
            //        res += new string(current, count);
            //    }
            //}
            Expanded = Regex.Replace(compressedLevel, @"(\d+)(\D)", delegate (Match m)
            {
                return new string(m.Groups[2].Value[0], int.Parse(m.Groups[1].Value));
            });
        }
    }
}
