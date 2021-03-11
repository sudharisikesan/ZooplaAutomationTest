using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooplaAutomationTest.Extensions
{
    public static class StringExtensions
    {
        //takes substring between two anchor strings
        public static string Substring(this string s, string leftAnchor, string rightAnchor = "")
        {
            string result = s;
            if (leftAnchor.Length > 0)
            {
                if (result.Split(new string[] { leftAnchor }, StringSplitOptions.None).Length > 1)
                    result = result.Split(new string[] { leftAnchor }, StringSplitOptions.None)[1].Trim();
            }
            if (rightAnchor.Length > 0)
                result = result.Split(new string[] { rightAnchor }, StringSplitOptions.None)[0].Trim();

            return result;
        }
    }
}
