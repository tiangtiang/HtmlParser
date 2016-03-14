using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;

namespace HtmlParser
{
    class Html
    {
        private string url;     //网址
        public Html(string url)
        {
            this.url = url;
        }
        /// <summary>
        /// 获取目标网页的信息
        /// </summary>
        /// <returns>流</returns>
        public Stream getResponse()
        {
            WebRequest request;
            WebResponse response;
            Stream stream = null;
            try
            {
                request = WebRequest.Create(url);
                response = request.GetResponse();
                stream = response.GetResponseStream();
            }catch(Exception)
            {
                //Console.Write(ex.Message);
                throw new Exception("访问网页出错！");
            }
            return stream;
        }
        /// <summary>
        /// 保存网页到本地
        /// </summary>
        /// <param name="path">文件路径</param>
        public void writeToFile(string path)
        {
            FileStream file = null;
            Stream stream = null;
            try
            {
                file= new FileStream(path, FileMode.OpenOrCreate);
                stream = getResponse();
                int length = 1024, i = 0;
                byte[] bytes = new byte[1025];
                while ((i = stream.Read(bytes, 0, length)) > 0)
                    file.Write(bytes, 0, i);
            }catch(Exception)
            {
                //Console.WriteLine(ex.Message);
                throw new Exception("写入文件出错！");
            }
            finally
            {
                if (file != null)
                    file.Close();
                if (stream != null)
                    stream.Close();
            }
            
        }
    }
}
