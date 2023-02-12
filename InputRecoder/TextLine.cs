using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InputRecoder
{
    internal class TextLine
    {
        private Label parent;
        private List<string> data;
        public int index = 0;
        private int textCount;
        private bool isAutoScroll = true;
        public void AddLine(string text,string endl = "\n")
        {
            data.Add(text + endl);
            if(isAutoScroll) SetShowIndex(data.Count - textCount > 0? data.Count - textCount : 0 );
        }
        public TextLine(int Count, Label parent)
        {
            this.parent = parent;
            data = new List<string>();
            textCount = Count;
        }
        public void Show()
        {
             parent.Text = string.Join("", data.GetRange(index, index + textCount > data.Count  ? data.Count - index  : textCount));
        }
        public void SetShowIndexDelta(int deltaIndex)
        {
            SetShowIndex(index + deltaIndex);
        }
        public void SetShowIndex(int index)
        {
            if(index > data.Count - textCount || index < 0)
            {
                
                return;
            }
            isAutoScroll = (index == data.Count - textCount);
            this.index = index;
        }
        public void Clear()
        {
            data = new List<string>();
            parent.Text = "";
            index = 0;
        }

    }

}
