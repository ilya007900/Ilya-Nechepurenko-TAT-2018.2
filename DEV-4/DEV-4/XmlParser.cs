using System;
using System.Collections.Generic;
using System.Text;

namespace DEV_4
{
    class XmlParser
    {
        public int NTag { get; set; }

        public List<string> Parse(string xmlString)
        {
            List<string> retres = new List<string>();
            List<string> result = new List<string>();
            StringBuilder tag = new StringBuilder();
            bool flag = false;
            for (int i = 0; i < xmlString.Length; i++)
            {
                if (xmlString[i] == '<' && xmlString[i + 1] != '/')
                {
                    flag = true;
                    NTag++;
                    i++;
                    while (xmlString[i] != '>')
                    {
                        tag.Append(xmlString[i]);
                        i++;
                    }
                    if (!"\n\t\r <>".Contains(xmlString[i + 1]))
                    {
                        tag.Append("->");
                        while (!"\n\t\r <>".Contains(xmlString[i + 1]))
                        {
                            i++;
                            tag.Append(xmlString[i]);
                        }
                    }
                    result.Add(tag.ToString() + "->");
                }

                if (xmlString[i] == '<' && xmlString[i + 1] == '/')
                {
                    if (flag)
                    {
                        StringBuilder big = new StringBuilder();
                        foreach (string s in result)
                        {
                            big.Append(s);
                        }
                        retres.Add(big.ToString());
                        NTag--;
                        result.RemoveAt(NTag);
                        flag = false;
                    }
                    else
                    {
                        NTag--;
                        result.RemoveAt(NTag);
                    }
                }
                tag.Clear();
            }

            return retres;
        }
    }
}
