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
    public partial class FormBestTime : Form
    {
        public FormBestTime()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();

        }
        public Score score;
        private void FormBestTime_Load(object sender, EventArgs e)
        {
            if(score == null)
            {
                throw new Exception("Please set a score property");
            }
            this.lblNameBeginner.Text = score.BeginnerName;
            this.lblNameIntermidate.Text = score.IntermidateName;
            this.lblNameExpert.Text = score.ExpertName;

            this.lblSecondBeginner.Text = score.BeginerSeconds.ToString ();
            this.lblSecondIntermidate.Text = score.IntermidiateSeconds.ToString ();
            this.lblSecondExpert.Text = score.ExpertSeconds.ToString();

        }
    }
}
