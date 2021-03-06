﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace HtmlParser
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = new ReadHtml(@"D:\project\htmlparser\test.txt").read(Encoding.UTF8);
            ReadChars rc = new ReadChars(str);
            rc.readTags();
            Format format = new Format(rc);
            Purification purify = new Purification(format);
            MakeTree make = new MakeTree(purify);
            Tree tree = make.tree;
            tree.changeToList();
            List<TreeNode> list = tree.getTagsByName("iframe");
            for(int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i].parent.node);
                Console.WriteLine(list[i].node.Attributes["src"]);
            }
            Console.ReadKey();
            //File.WriteAllText(@"D:\project\htmlparser\out.txt", make.tree.ToString());

            //Html html = new Html("http://www.chenjian.cc/1534.html");
            //html.writeToFile(@"D:\project\htmlparser\test.txt");
        }
    }
}
