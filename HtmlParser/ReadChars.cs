using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlParser
{
    /// <summary>
    /// 将html文档转化成对象列表
    /// </summary>
    class ReadChars
    {
        private string content;     //html内容
        private List<Tag> list;     //对象列表

        public ReadChars(string content)
        {
            this.content = content;
            list = new List<Tag>();
        }

        public void readTags()
        {
            int count = 0;
            for(int i = 0; i < content.Count(); i++)
            {
                char x = content[i];
                if (isBlank(x))
                    continue;
                if (x != '<')
                {
                    while (x != '<')
                    {
                        count++;
                        if (i == content.Count() - 1)
                        {
                            i++;
                            break;
                        }
                        x = content[++i];
                        
                    }
                    list.Add(new Tag() { Content = content.Substring(i - count, count), Type = 3 });
                    count = 0;
                    i--;
                    continue;
                }
                while (x != '>')
                {
                    count++;
                    x = content[++i];
                }
                string node = content.Substring(i - count, count + 1);
                count = 0;
                //Console.WriteLine(node);
                Tag tag = readOneTag(node);
                if(tag!=null)
                    list.Add(tag);
            }
        }
        /// <summary>
        /// 将一个标签语句解析成标签对象
        /// </summary>
        /// <param name="node">标签语句</param>
        /// <returns>标签对象</returns>
        private Tag readOneTag(string node)
        {
            Tag tag = new Tag();
            int count = 0, i = 1;
            char c = node[i];
            while (isBlank(c))
                c = node[++i];
            if (!isNormalChar(c))           //非法标签
                return null;
            if(c == '/')                    //结束标签
            {
                c = node[++i];
                while (!(isBlank(c) || c == '>'))
                {
                    count++;
                    c = node[++i];
                }
                tag.Name = node.Substring(i - count, count);
                tag.Type = 1;
            }
            else
            {                               //起始标签
                while (!(isBlank(c) || c == '>'))
                {
                    count++;
                    c = node[++i];
                }
                tag.Name = node.Substring(i - count, count);
                count = 0;
                while (isBlank(c))
                    c = node[++i];
                Dictionary<string, string> dir = new Dictionary<string, string>();
                while (c != '/' && c != '>')
                {
                    while (isBlank(c))
                        c = node[++i];

                    while (c != '='&&!isBlank(c))
                    {
                        count++;
                        c = node[++i];
                        if (c == '/' || c == '>')
                            break;
                    }
                    string key = node.Substring(i - count, count);
                    count = 0;
                    while(isBlank(c))
                        c = node[++i];
                    if (c != '=')
                        continue;
                    int markcount = 0;
                    char temp = '\"';
                    while (isBlank(c) || c == '=' || c == '\"'||c=='\'')
                    {
                        c = node[++i];
                        if (markcount == 0 && (c == '\"' || c == '\''))
                            temp = c;
                        if (c == '\"'||c=='\'')
                        {
                            if (markcount > 0)
                                break;
                            else
                                markcount++;
                        }

                    }
                    if (c == '/')
                        break;
                    //while (c != '\"'&&c!='\'')
                    while(c!=temp)
                    {
                        count++;
                        c = node[++i];
                        if (c == '\"'||c=='\'')
                            if (node[i - 1] == '\\')
                                continue;
                        if (c == '>')
                            break;
                    }
                    string value = node.Substring(i - count, count);
                    count = 0;
                    try {
                        dir.Add(key, value);
                    }catch(ArgumentException)
                    {
                        dir[key] = value;
                    }
                    if(i<node.Count()-1)
                        c = node[++i];
                    while (isBlank(c)&&i<node.Count())
                        c = node[++i];
                }
                if (dir.Count() > 0)
                    tag.Attributes = dir;
                if (c == '/')
                    tag.Type = 2;
                else
                    tag.Type = 0;
            }

            return tag;
        }
        /// <summary>
        /// 判断字符c是否是空字符
        /// </summary>
        /// <param name="c">输入字符</param>
        /// <returns>是否为空</returns>
        private bool isBlank(char c)
        {
            return c == ' ' || c == '\t' || c == '\n' || c == '\r';
        }
        /// <summary>
        /// 判断字符c是否是普通字符
        /// </summary>
        /// <param name="c">输入字符</param>
        /// <returns>是否为普通字符</returns>
        private bool isNormalChar(char c)
        {
            return Char.IsLetter(c) || c == '/';
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for(int i = 0; i < list.Count; i++)
            {
                sb.Append(list[i].ToString());
                sb.Append("\n");
            }
            return sb.ToString();
        }
    }
}
