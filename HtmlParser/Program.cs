using System;
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
            File.WriteAllText(@"D:\project\htmlparser\out.txt", rc.ToString());

            //Html html = new Html("http://www.chenjian.cc/1534.html");
            //html.writeToFile(@"D:\project\htmlparser\test.txt");
        }
    }
}
