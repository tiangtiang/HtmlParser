using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlParser
{
    class MakeTree
    {
        public Purification purify { set; get; }
        public Tree<Tag> tree { set; get; }
        public MakeTree(Purification puri)
        {
            this.purify = puri;
            tree = turnToTree();
        }
        /// <summary>
        /// 将标签对象列表转化成树结构
        /// </summary>
        /// <returns></returns>
        private Tree<Tag> turnToTree()
        {
            List<Tag> list = purify.format.rc.List;         //标签序列
            Tree<Tag> tree = new Tree<Tag>();           //树结构
            Stack<TreeNode<Tag>> stack = new Stack<TreeNode<Tag>>();        //存储节点的栈
            for(int i = 0; i < list.Count; i++)
            {
                Tag tag = list[i];
                int type = tag.Type;
                if (type == 0 || type == 2)
                {
                    TreeNode<Tag> node = new TreeNode<Tag>() { node = tag };        //将该标签封装为树节点
                    if (stack.Count > 0)
                    {
                        node.parent = stack.Peek();         //该节点的父节点是栈顶元素

                        TreeNode<Tag> temp = stack.Peek();      //取出栈顶元素
                        if (temp.childern == null)              //判断父节点的子节点序列是否为空
                        {
                            temp.childern = new List<TreeNode<Tag>>();
                        }
                        temp.childern.Add(node);                //将该元素加入栈顶元素的子节点序列
                    }
                    if (type == 0)
                        stack.Push(node);                   //如果是开始标签，将该元素加入栈
                }else if (type == 1)
                {
                    while (stack.Peek().node.Name!=tag.Name)
                    {
                        if (stack.Count == 1)
                            tree.root = stack.Peek();
                        stack.Pop();
                    }
                    if (stack.Count == 1)
                        tree.root = stack.Peek();
                    stack.Pop();
                }
            }
            while (stack.Count > 0)
            {
                if (stack.Count == 1)
                    tree.root = stack.Peek();
                stack.Pop();
            }
            return tree;
        }
    }
}
