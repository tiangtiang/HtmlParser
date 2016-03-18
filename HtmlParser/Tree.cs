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
    class Tree
    {
        public TreeNode root { set; get; }
        public List<TreeNode> list { set; get; }

        public override string ToString()
        {
            return root.ToString();
        }

        public void changeToList()
        {
            list = root.changeToList();
        }
        
        public List<TreeNode> getTagsByName(string name)
        {
            List<TreeNode> temp = new List<TreeNode>();
            for(int i = 0; i < list.Count; i++)
            {
                if (list[i].node.Name == name)
                    temp.Add(list[i]);
            }
            return temp;
        }         
    }
    /// <summary>
    /// 树节点
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class TreeNode
    {
        public TreeNode parent { set; get; }
        public List<TreeNode> childern { set; get; }
        public Tag node { set; get; }

        public override string ToString()
        {
            return getString(0);
        }
        /// <summary>
        /// 将树转化成字符串,深度优先遍历
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
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
        /// <summary>
        /// 将树转化成列表
        /// </summary>
        /// <returns></returns>
        public List<TreeNode> changeToList()
        {
            List<TreeNode> list = new List<TreeNode>();

            list.Add(this);
            if (childern != null)
            {
                for(int i = 0; i < childern.Count; i++)
                {
                    union(list, childern[i].changeToList());
                }
            }

            return list;
        }
        /// <summary>
        /// 合并集合
        /// </summary>
        /// <param name="pre"></param>
        /// <param name="aft"></param>
        /// <returns></returns>
        private List<TreeNode> union(List<TreeNode> pre, List<TreeNode> aft)
        {
            for(int i = 0; i < aft.Count; i++)
            {
                pre.Add(aft[i]);
            }
            return pre;
        }
        /// <summary>
        /// 查找子节点
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public TreeNode findChildren(string name)
        {
            if (childern != null)
            {
                for(int i = 0; i < childern.Count; i++)
                {
                    if (childern[i].node.Name == name)
                        return childern[i];
                }
            }
            return null;
        }
    }
}
