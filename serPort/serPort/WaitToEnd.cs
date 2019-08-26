using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace serPort
{
    public partial class WaitToEnd : Form
    {
        public WaitToEnd()
        {
            InitializeComponent();
        }

        public void endMessage()
        {
            message_lbl.Text = "Finished!";
        }

        public void closeWindow()
        {
            if (IsFormOpen(typeof(WaitToEnd)))
            {
                this.Hide();
            }                        
        }

        public bool IsFormOpen(Type formType)
        {
            foreach (Form form in Application.OpenForms)
                if (form.GetType().Name == form.Name)
                    return true;
            return false;
        }
    }
}
