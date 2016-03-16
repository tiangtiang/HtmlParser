using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlParser
{
    class DeleteTag
    {
        public static void DELETENULL(ReadChars tags)
        {
            List<Tag> list = tags.List;
            for (int i = list.Count - 1; i >= 0; i--)
            {
                if (list[i] == null)
                    list.RemoveAt(i);
            }
        }
    }
}
