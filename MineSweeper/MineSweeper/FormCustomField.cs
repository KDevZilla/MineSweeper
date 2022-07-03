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
    public partial class FormCustomField : Form
    {
        public FormCustomField()
        {
            InitializeComponent();
        }
        private Boolean IsInt(String CheckValue)
        {
            try
            {
                int.Parse(CheckValue);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public int NoofRow = 9;
        public int NoofColumn = 9;
        public int NoofMines = 9;

        private Boolean AcceptTheData()
        {
            if (!IsInt(this.txtHeight.Text) ||
                !IsInt (this.txtWidth.Text) ||
                !IsInt(this.txtMines.Text)){
                MessageBox.Show("Please enter the value as numbers");
                return false;
            }

            NoofRow = int.Parse(this.txtHeight.Text);
            NoofColumn = int.Parse(this.txtWidth.Text);
            NoofMines = int.Parse(this.txtMines.Text);


            NoofColumn = NoofColumn.AdjustToBound(9, 24);
            NoofRow = NoofRow.AdjustToBound(9, 30);

            int MaxMines = (NoofRow - 1) * (NoofColumn - 1);
            int MinMines = 10;
            NoofMines = NoofMines.AdjustToBound(MinMines, MaxMines);

            return true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(!AcceptTheData())
            {
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCustomField_Load(object sender, EventArgs e)
        {
            this.txtHeight.Text = this.NoofRow.ToString();
            this.txtWidth.Text = this.NoofColumn.ToString();
            this.txtMines.Text = this.NoofMines.ToString();

        }
    }
}
