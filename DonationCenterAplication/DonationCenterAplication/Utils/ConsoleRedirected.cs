using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DonationCenterServer.Utils
{
    public class ControlWriter : TextWriter
    {

        List<string> buffer;

        private ListBox listBox;
        public ControlWriter(ListBox listBox)
        {
            this.listBox = listBox;
            buffer = new List<string>();
        }

       
        public override Encoding Encoding
        {
            get { return Encoding.ASCII; }
        }

        public override void WriteLine(string value)
        {


            buffer.Add(value);

            ListBox.CheckForIllegalCrossThreadCalls = false;

            if (buffer.Count == 10)
            {
                new Thread(x =>
                {
                    listBox.Items.Add(value);
                    listBox.SelectedIndex = listBox.Items.Count - 1;
                    listBox.ScrollAlwaysVisible = false;
                    listBox.ClearSelected();
                    buffer.Clear();
                }).Start();
            }


        }

    }
}
