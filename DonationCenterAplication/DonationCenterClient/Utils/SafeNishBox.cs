using NishBox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.Utils
{
    public class SafeNishBox : MultiLineListBox
    {

        public SafeNishBox() : base()
        {
            InitializeComponent();
        }
        protected override void OnMouseUp(MouseEventArgs e){ return; }
        protected override void OnKeyDown(KeyEventArgs e){ return; }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}

