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
        private int garbageTags(Tag tag)
        {
            string temp = tag.Name.ToLower();
            if (temp == "script")
                return 1;
            if (temp == "style")
                return 2;
            return -1;
        }
        public void removeJavaScript(ReadChars tags)
        {
            for(int i= 0; i < tags.length(); i++)
            {
                Tag tag = tags.get(i);
                int temp = garbageTags(tag);
                if (temp != -1 && tag.Type == 0)
                {
                    tags.set(i++, null);
                    tag = tags.get(i);
                    while(garbageTags(tag)!=temp && tag.Type == 1)
                    {
                        tags.set(i++, null);
                        tag = tags.get(i);
                    }
                    tags.set(i, null);
                }
            }
            DeleteTag.DELETENULL(tags);
        }
    }
}
