using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineSweeper
{
    public partial class FormEnterNewTimeRecord : Form
    {
        public FormEnterNewTimeRecord()
        {
            InitializeComponent();
        }
        public string Message = "";
        public string PreviousRecordName = "";
        public string NewName = "";
        private void FormEnterNewTimeRecord_Load(object sender, EventArgs e)
        {
            this.lblMessage.Text = Message;
            this.txtName.Text = PreviousRecordName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(this.txtName.Text.Trim ()=="")
            {
                MessageBox.Show("Please enter your name");
                return;
            }
            NewName = this.txtName.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();


        }
    }
}
