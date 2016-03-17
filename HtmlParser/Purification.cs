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
        public Format format { set; get; }

        public Purification(Format format)
        {
            removeJavaScript(format);
        }
        /// <summary>
        /// 判断是否为无用的标签
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        private int garbageTags(Tag tag)
        {
            string temp = tag.Name.ToLower();
            if (temp == "script")
                return 1;
            if (temp == "style")
                return 2;
            return -1;
        }
        /// <summary>
        /// 删除无用的标签
        /// </summary>
        /// <param name="format"></param>
        private void removeJavaScript(Format format)
        {
            ReadChars tags = format.rc;
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
            this.format = format;
        }

        public override string ToString()
        {
            return format.ToString();
        }
    }
}
