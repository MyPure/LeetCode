using System;
using System.Collections.Generic;
using System.Text;

namespace JZOffer
{
    class JZ2
    {
        public string replaceSpace(string s)
        {
            StringBuilder sb = new StringBuilder();
            for(int i = 0; i < s.Length; i++)
            {
                if(s[i] == ' ')
                {
                    sb.Append("%20");
                }
                else
                {
                    sb.Append(s[i]);
                }
            }
            return sb.ToString();
        }
    }
}
