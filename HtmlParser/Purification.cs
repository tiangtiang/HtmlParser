using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlParser
{
    /// <summary>
    /// 去掉网页中的js和css
    /// </summary>
    class Purification
    {
        private bool garbageTags(Tag tag)
        {
            string temp = tag.Name.ToLower();
            if (temp == "script")
                return true;
            if (temp == "style")
                return true;
            return false;
        }
        public void removeJavaScript(ReadChars tags)
        {
            
        }
    }
}
