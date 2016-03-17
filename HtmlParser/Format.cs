using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlParser
{
    /// <summary>
    /// 将字符串变成标签的内容
    /// </summary>
    class Format
    {
        public ReadChars rc { set; get; }

        public Format(ReadChars tags)
        {
            integration(tags);
        }

        private void integration(ReadChars tags)
        {
            Stack<Tag> stack = new Stack<Tag>();
            for(int i = 0; i < tags.length(); i++)
            {
                Tag temp = tags.get(i);
                if (temp.Type == 0)
                    stack.Push(temp);
                else if (tags.get(i).Type == 3)
                {
                    //将字符串赋值给栈顶元素的文本
                    if (stack.Count > 0)
                    {
                        stack.Peek().Content += tags.get(i).Content;
                    }
                    tags.set(i, null);
                }
                else if (tags.get(i).Type == 1)
                {
                    //将该元素对应的元素弹出栈
                    //while (stack.Peek().Name != tags.get(i).Name)
                    //    stack.Pop();
                    stack.Pop();
                }
            }
            DeleteTag.DELETENULL(tags);

            rc = tags;
        }

        public override string ToString()
        {
            return rc.ToString();
        }

    }
}
