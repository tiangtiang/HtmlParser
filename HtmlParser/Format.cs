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
        public void integration(ReadChars tags)
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
                    stack.Peek().Content += tags.get(i).Content;
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
            delete(tags);
        }

        public void delete(ReadChars tags)
        {
            List<Tag> list = tags.List;
            for(int i = list.Count - 1; i >= 0; i--)
            {
                if (list[i] == null)
                    list.RemoveAt(i);
            }
        }
    }
}
