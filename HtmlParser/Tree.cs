using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlParser
{
    /// <summary>
    /// 树结构
    /// </summary>
    class Tree<T>
    {
        public TreeNode<T> root { set; get; }

        public override string ToString()
        {
            return root.ToString();
        }

        
    }
    /// <summary>
    /// 树节点
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class TreeNode<T>
    {
        public TreeNode<T> parent { set; get; }
        public List<TreeNode<T>> childern { set; get; }
        public T node { set; get; }

        public override string ToString()
        {
            return getString(0);
        }

        private string getString(int count)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < count; i++)
            {
                sb.Append("\t");
            }
            sb.Append(node.ToString());
            sb.Append("\n");
            if (childern != null)
            {
                for(int i = 0; i < childern.Count; i++)
                {
                    sb.Append(childern[i].getString(count + 1));
                }
            }
            return sb.ToString();
        }
    }
}
