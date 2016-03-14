using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlParser
{
    /// <summary>
    /// 标签类，起始标签拥有标签名和属性列表，结束标签拥有标签名。
    /// </summary>
    class Tag
    {
        private string name;        //标签名
        private Dictionary<string, string> attributes;      //属性列表
        private string content;     //文本内容
        private Tag parent;         //父标签
        private int type = -1;           //标签类型， 0：起始标签 1：结束标签 2：完整标签 3：文本内容

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public Dictionary<string, string> Attributes
        {
            get
            {
                return attributes;
            }

            set
            {
                attributes = value;
            }
        }

        public string Content
        {
            get
            {
                return content;
            }

            set
            {
                content = value;
            }
        }

        public int Type
        {
            get
            {
                return type;
            }

            set
            {
                type = value;
            }
        }
       
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (name != null)
            {
                sb.Append(name);
                sb.Append(": ");
            }
            if (attributes != null)
            {
                sb.Append("[");
                foreach(var dir in attributes)
                {
                    sb.Append(dir.Key);
                    sb.Append(": ");
                    sb.Append(dir.Value);
                }
                sb.Append("]\t");
            }
            if (content != null)
            {
                sb.Append(content);
                sb.Append("\t");
            }
            if (type != -1)
                sb.Append(type);

            return sb.ToString();
        }

    }
}
