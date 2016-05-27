using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AOPSampleWinForm
{

    public static class Extensions
    {
        public static void AppendTextLine(this RichTextBox rtb, string value)
        {
            rtb.AppendText(String.Format("{0}\n", value));
        }
    }
}
