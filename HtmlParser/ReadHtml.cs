using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HtmlParser
{
    class ReadHtml
    {
        private string path;
        public ReadHtml(string path)
        {
            this.path = path;
        }

        public string read(Encoding code)
        {
            StreamReader reader = null;
            try
            {
                reader = new StreamReader(path, code);
                return reader.ReadToEnd();
            }
            catch (Exception)
            {
                throw new Exception("读取文件出错！");
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }
    }
}
