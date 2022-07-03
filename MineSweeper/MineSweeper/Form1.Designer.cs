namespace MineSweeper
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlGame = new System.Windows.Forms.Panel();
            this.labelTemplateCell = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlScore = new System.Windows.Forms.Panel();
            this.lblFace = new System.Windows.Forms.Label();
            this.pnlTime = new System.Windows.Forms.Panel();
            this.lblNumberofSecond3 = new System.Windows.Forms.Label();
            this.lblNumberofSecond2 = new System.Windows.Forms.Label();
            this.lblNumberofSecond1 = new System.Windows.Forms.Label();
            this.pnlNumberofMine = new System.Windows.Forms.Panel();
            this.lblNumberofMine3 = new System.Windows.Forms.Label();
            this.lblNumberofMine2 = new System.Windows.Forms.Label();
            this.lblNumberofMine1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.beginnerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.intermidiateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.expertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.hideRunningTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bestTimesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pnlMain.SuspendLayout();
            this.pnlScore.SuspendLayout();
            this.pnlTime.SuspendLayout();
            this.pnlNumberofMine.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlGame
            // 
            this.pnlGame.BackColor = System.Drawing.Color.White;
            this.pnlGame.Location = new System.Drawing.Point(19, 72);
            this.pnlGame.Name = "pnlGame";
            this.pnlGame.Size = new System.Drawing.Size(336, 324);
            this.pnlGame.TabIndex = 0;
            // 
            // labelTemplateCell
            // 
            this.labelTemplateCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.labelTemplateCell.Location = new System.Drawing.Point(340, 30);
            this.labelTemplateCell.Name = "labelTemplateCell";
            this.labelTemplateCell.Size = new System.Drawing.Size(32, 32);
            this.labelTemplateCell.TabIndex = 9;
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.White;
            this.pnlMain.Controls.Add(this.pnlScore);
            this.pnlMain.Controls.Add(this.pnlGame);
            this.pnlMain.Controls.Add(this.labelTemplateCell);
            this.pnlMain.Location = new System.Drawing.Point(0, 26);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(383, 420);
            this.pnlMain.TabIndex = 11;
            // 
            // pnlScore
            // 
            this.pnlScore.BackColor = System.Drawing.Color.White;
            this.pnlScore.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlScore.Controls.Add(this.lblFace);
            this.pnlScore.Controls.Add(this.pnlTime);
            this.pnlScore.Controls.Add(this.pnlNumberofMine);
            this.pnlScore.Location = new System.Drawing.Point(19, 12);
            this.pnlScore.Name = "pnlScore";
            this.pnlScore.Size = new System.Drawing.Size(315, 54);
            this.pnlScore.TabIndex = 1;
            // 
            // lblFace
            // 
            this.lblFace.Image = global::MineSweeper.Properties.Resources.SmileFace;
            this.lblFace.Location = new System.Drawing.Point(207, 2);
            this.lblFace.Name = "lblFace";
            this.lblFace.Size = new System.Drawing.Size(55, 46);
            this.lblFace.TabIndex = 3;
            // 
            // pnlTime
            // 
            this.pnlTime.BackColor = System.Drawing.Color.Black;
            this.pnlTime.Controls.Add(this.lblNumberofSecond3);
            this.pnlTime.Controls.Add(this.lblNumberofSecond2);
            this.pnlTime.Controls.Add(this.lblNumberofSecond1);
            this.pnlTime.Location = new System.Drawing.Point(117, 3);
            this.pnlTime.Name = "pnlTime";
            this.pnlTime.Size = new System.Drawing.Size(81, 48);
            this.pnlTime.TabIndex = 2;
            // 
            // lblNumberofSecond3
            // 
            this.lblNumberofSecond3.Image = global::MineSweeper.Properties.Resources.Score_0;
            this.lblNumberofSecond3.Location = new System.Drawing.Point(52, 0);
            this.lblNumberofSecond3.Name = "lblNumberofSecond3";
            this.lblNumberofSecond3.Size = new System.Drawing.Size(28, 46);
            this.lblNumberofSecond3.TabIndex = 2;
            // 
            // lblNumberofSecond2
            // 
            this.lblNumberofSecond2.Image = global::MineSweeper.Properties.Resources.Score_0;
            this.lblNumberofSecond2.Location = new System.Drawing.Point(26, 0);
            this.lblNumberofSecond2.Name = "lblNumberofSecond2";
            this.lblNumberofSecond2.Size = new System.Drawing.Size(28, 46);
            this.lblNumberofSecond2.TabIndex = 1;
            // 
            // lblNumberofSecond1
            // 
            this.lblNumberofSecond1.Image = global::MineSweeper.Properties.Resources.Score_0;
            this.lblNumberofSecond1.Location = new System.Drawing.Point(0, 0);
            this.lblNumberofSecond1.Name = "lblNumberofSecond1";
            this.lblNumberofSecond1.Size = new System.Drawing.Size(28, 46);
            this.lblNumberofSecond1.TabIndex = 0;
            // 
            // pnlNumberofMine
            // 
            this.pnlNumberofMine.BackColor = System.Drawing.Color.Black;
            this.pnlNumberofMine.Controls.Add(this.lblNumberofMine3);
            this.pnlNumberofMine.Controls.Add(this.lblNumberofMine2);
            this.pnlNumberofMine.Controls.Add(this.lblNumberofMine1);
            this.pnlNumberofMine.Location = new System.Drawing.Point(3, 3);
            this.pnlNumberofMine.Name = "pnlNumberofMine";
            this.pnlNumberofMine.Size = new System.Drawing.Size(81, 48);
            this.pnlNumberofMine.TabIndex = 1;
            // 
            // lblNumberofMine3
            // 
            this.lblNumberofMine3.Image = global::MineSweeper.Properties.Resources.Score_0;
            this.lblNumberofMine3.Location = new System.Drawing.Point(52, 0);
            this.lblNumberofMine3.Name = "lblNumberofMine3";
            this.lblNumberofMine3.Size = new System.Drawing.Size(28, 46);
            this.lblNumberofMine3.TabIndex = 2;
            // 
            // lblNumberofMine2
            // 
            this.lblNumberofMine2.Image = global::MineSweeper.Properties.Resources.Score_0;
            this.lblNumberofMine2.Location = new System.Drawing.Point(26, 0);
            this.lblNumberofMine2.Name = "lblNumberofMine2";
            this.lblNumberofMine2.Size = new System.Drawing.Size(28, 46);
            this.lblNumberofMine2.TabIndex = 1;
            // 
            // lblNumberofMine1
            // 
            this.lblNumberofMine1.Image = global::MineSweeper.Properties.Resources.Score_0;
            this.lblNumberofMine1.Location = new System.Drawing.Point(0, 0);
            this.lblNumberofMine1.Name = "lblNumberofMine1";
            this.lblNumberofMine1.Size = new System.Drawing.Size(28, 46);
            this.lblNumberofMine1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(427, 24);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.toolStripSeparator1,
            this.beginnerToolStripMenuItem,
            this.intermidiateToolStripMenuItem,
            this.expertToolStripMenuItem,
            this.customToolStripMenuItem,
            this.toolStripSeparator2,
            this.hideRunningTimeToolStripMenuItem,
            this.bestTimesToolStripMenuItem,
            this.toolStripSeparator3,
            this.exitToolStripMenuItem});
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.newGameToolStripMenuItem.Text = "Game";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.newToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // beginnerToolStripMenuItem
            // 
            this.beginnerToolStripMenuItem.Checked = true;
            this.beginnerToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.beginnerToolStripMenuItem.Name = "beginnerToolStripMenuItem";
            this.beginnerToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.beginnerToolStripMenuItem.Text = "Beginner";
            this.beginnerToolStripMenuItem.Click += new System.EventHandler(this.beginnerToolStripMenuItem_Click);
            // 
            // intermidiateToolStripMenuItem
            // 
            this.intermidiateToolStripMenuItem.Name = "intermidiateToolStripMenuItem";
            this.intermidiateToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.intermidiateToolStripMenuItem.Text = "Intermidiate";
            this.intermidiateToolStripMenuItem.Click += new System.EventHandler(this.intermidiateToolStripMenuItem_Click);
            // 
            // expertToolStripMenuItem
            // 
            this.expertToolStripMenuItem.Name = "expertToolStripMenuItem";
            this.expertToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.expertToolStripMenuItem.Text = "Expert";
            this.expertToolStripMenuItem.Click += new System.EventHandler(this.expertToolStripMenuItem_Click);
            // 
            // customToolStripMenuItem
            // 
            this.customToolStripMenuItem.Name = "customToolStripMenuItem";
            this.customToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.customToolStripMenuItem.Text = "Custom";
            this.customToolStripMenuItem.Click += new System.EventHandler(this.customToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
            // 
            // hideRunningTimeToolStripMenuItem
            // 
            this.hideRunningTimeToolStripMenuItem.Name = "hideRunningTimeToolStripMenuItem";
            this.hideRunningTimeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.hideRunningTimeToolStripMenuItem.Text = "Hide Running Time";
            this.hideRunningTimeToolStripMenuItem.Click += new System.EventHandler(this.hideRunningTimeToolStripMenuItem_Click);
            // 
            // bestTimesToolStripMenuItem
            // 
            this.bestTimesToolStripMenuItem.Name = "bestTimesToolStripMenuItem";
            this.bestTimesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.bestTimesToolStripMenuItem.Text = "Best Times...";
            this.bestTimesToolStripMenuItem.Click += new System.EventHandler(this.bestTimesToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(177, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openAllToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // openAllToolStripMenuItem
            // 
            this.openAllToolStripMenuItem.Name = "openAllToolStripMenuItem";
            this.openAllToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.openAllToolStripMenuItem.Text = "OpenAll For Debug Purpose";
            this.openAllToolStripMenuItem.Click += new System.EventHandler(this.openAllToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 476);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MineSweepter";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlScore.ResumeLayout(false);
            this.pnlTime.ResumeLayout(false);
            this.pnlNumberofMine.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlGame;
        private System.Windows.Forms.Label labelTemplateCell;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlScore;
        private System.Windows.Forms.Panel pnlTime;
        private System.Windows.Forms.Label lblNumberofSecond3;
        private System.Windows.Forms.Label lblNumberofSecond2;
        private System.Windows.Forms.Label lblNumberofSecond1;
        private System.Windows.Forms.Panel pnlNumberofMine;
        private System.Windows.Forms.Label lblNumberofMine3;
        private System.Windows.Forms.Label lblNumberofMine2;
        private System.Windows.Forms.Label lblNumberofMine1;
        private System.Windows.Forms.Label lblFace;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem beginnerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem intermidiateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem expertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem hideRunningTimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bestTimesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openAllToolStripMenuItem;
    }
}

