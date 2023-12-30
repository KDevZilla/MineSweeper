using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MineSweeper.Game;

namespace MineSweeper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


       
       

        public enum FaceEnum
        {
            Smile,
            SmilePushed,
            Wonder,
            Depress,
            Happy
        }

        private SharedBitMap sharedBitmap = new SharedBitMap();
        private void RenderBoard(Board pBoard)
        {
            int i;
            int j;
            for (i = 0; i < pBoard.NoofRow; i++)
            {
                for (j = 0; j < pBoard.NoofCol; j++)
                {
                    Label b = DicButon[i][j];
                    int CellValue = pBoard.Matrix[i, j];

                    
                    if (pBoard.IsOpenCell[i, j])
                    {
                        b.Image = sharedBitmap.GetBitmapByCellValue(CellValue);
                    } else
                    {
                        if (this.IsFlagCell[i, j])
                        {
                            b.Image = sharedBitmap.GetBitmapFlg();
                        }
                        else
                        {
                            b.Image = sharedBitmap.GetBitmapByCellValue(ConstCell.HasValue);
                        }
                    }


                }
            }
        }
        Boolean IsBoardUIHasInitial = false;

        private void InitialBoardUI(Board pBoard)
        {
            int i;
            int j;



           // board = new Board(BoardSize, BoardSize);
            int LastColumn = pBoard.NoofRow - 1;
            Label LastButton = null;
            DicButon.Clear();
            
            foreach (Label label in pnlGame.Controls )
            {
               // label.Click -= Cell_Click;
                label.MouseDown -= Cell_MouseDown;
            }
            pnlGame.Controls.Clear();

            for (i = 0; i < pBoard.NoofRow ; i++)
            {
                DicButon.Add(i, new Dictionary<int, Label>());
                for (j = 0; j < pBoard.NoofCol ; j++)
                {
                    //Button b = new Button();
                    Label lable = new Label();
                    lable.Height = labelTemplateCell.Height;
                    lable.Width = labelTemplateCell.Width;
                    lable.Top = (i * lable.Height);
                    lable.Left = (j * lable.Width);
                    lable.Font = labelTemplateCell.Font;
                    lable.Tag = i.ToString("00") + j.ToString("00");
                    lable.BorderStyle = BorderStyle.None;
                    this.pnlGame.Controls.Add(lable);
                    DicButon[i].Add(j, lable);
                   // lable.Click += Cell_Click;
                    lable.MouseDown += Cell_MouseDown;
                }
            }

            LastButton = (Label)pnlGame.Controls[pnlGame.Controls.Count - 1];
            int XoffSet = 10;
            int YOffset = 5;

            //this.pnlGame.Width = LastButton.Left + LastButton.Width;
            this.pnlGame.Height = LastButton.Top + LastButton.Height + 5;
            this.pnlGame.Width = LastButton.Left + LastButton.Width + 5;

            this.pnlScore.Left = XoffSet;
            this.pnlScore.Width = this.pnlGame.Width;

            this.pnlNumberofMine.Left = XoffSet;
            this.pnlNumberofMine.Top = YOffset;

            this.pnlTime.Left = pnlScore.Width - pnlTime.Width - XoffSet;
            this.pnlTime.Top = YOffset;
            this.pnlScore.Height = this.pnlTime.Top + this.pnlTime.Height + (YOffset * 2);

            this.pnlGame.Top = this.pnlScore.Height + this.pnlScore.Top + YOffset;
            this.pnlGame.Left = this.pnlScore.Left;
            this.pnlGame.BorderStyle = BorderStyle.Fixed3D;

            this.pnlMain.Width = this.pnlGame.Width + this.pnlGame.Left * 2;
            this.pnlMain.Height = this.pnlGame.Height + this.pnlGame.Top + 50;
            this.lblFace.Left = (this.pnlScore.Width - this.lblFace.Width) / 2;
            this.lblFace.Top = (this.pnlScore.Height - this.lblFace.Height) / 2;

            IsBoardUIHasInitial = true;


            this.pnlMain.Left = 0;
            this.pnlMain.Top = this.menuStrip1.Height;
            this.Height = this.pnlMain.Top + this.pnlMain.Height + 20;
            this.Width = this.pnlMain.Left + this.pnlMain.Width + 17;

            this.lblFace.MouseDown += LblFace_MouseDown;
            this.lblFace.MouseUp += LblFace_MouseUp;
            //this.RenderNumberofMineShow(0);
            this.RenderNumberofSecond(0);

        }



        private void ShowFaceWon()
        {
            this.lblFace.Image = sharedBitmap.GetBitmapFace(FaceEnum.Happy);
        }
        private async void ShowFaceWonder()
        {
            this.lblFace.Image = sharedBitmap.GetBitmapFace(FaceEnum.Wonder);
            await PutTaskDelay();
            ShowFaceSmile();



        }
        async Task PutTaskDelay()
        {
            await Task.Delay(200);
        }
        private void ShowFaceSmile()
        {
            this.lblFace.Image = sharedBitmap.GetBitmapFace(FaceEnum.Smile);
        }

        private void ShowFaceLost()
        {
            this.lblFace.Image = sharedBitmap.GetBitmapFace(FaceEnum.Depress);
        }
        private void LblFace_MouseUp(object sender, MouseEventArgs e)
        {
            if(!IsClickNewGame )
            {
                return;
            }
            this.lblFace.Image = sharedBitmap.GetBitmapFace(FaceEnum.Smile );
            IsClickNewGame = false;
            NewGame();

        }
        private Boolean IsClickNewGame = false;
        
        private void LblFace_MouseDown(object sender, MouseEventArgs e)
        {
            //throw new NotImplementedException();
            IsClickNewGame = true;
            this.lblFace.Image = sharedBitmap.GetBitmapFace(FaceEnum.SmilePushed);

        }

        private void RenderNumberofMineShow(int NumbeofMineShow)
        {
            if (NumbeofMineShow < -99 ||
                NumbeofMineShow > 999)
            {
                throw new Exception(String.Format("Number of mine is {0} which is not invalid, it must be between {1} and {2}",
                    NumbeofMineShow, -99, 999)
                    );

            }
            String StringNumberofMineShow = "";
            if (NumbeofMineShow >= 0)
            {
                StringNumberofMineShow= NumbeofMineShow.ToString("000");
            }
            else
            {
                if (NumbeofMineShow > -10)
                {
                    StringNumberofMineShow ="0"+ NumbeofMineShow.ToString();
                } else
                {
                    StringNumberofMineShow = NumbeofMineShow.ToString();
                }
            }
            int i;

            Bitmap bit1 =sharedBitmap.GetBitMapDigit(StringNumberofMineShow.Substring(0, 1));
            Bitmap bit2 = sharedBitmap.GetBitMapDigit(StringNumberofMineShow.Substring(1, 1));
            Bitmap bit3 = sharedBitmap.GetBitMapDigit(StringNumberofMineShow.Substring(2, 1));
            this.lblNumberofMine1.Image = bit1;
            this.lblNumberofMine2.Image = bit2;
            this.lblNumberofMine3.Image = bit3;



        }
        private void RenderNumberofSecond(int NumberofSecond)
        {
            if (NumberofSecond < 0 ||
    NumberofSecond > 999)
            {
                throw new Exception(String.Format("Number of Second is {0} which is not invalid, it must be between {1} and {2}",
                    NumberofSecond, 0, 999)
                    );

            }
            String StringNumberofSecondShow = NumberofSecond.ToString("000");
            int i;

            Bitmap bit1 = sharedBitmap.GetBitMapDigit(StringNumberofSecondShow.Substring(0, 1));
            Bitmap bit2 = sharedBitmap.GetBitMapDigit(StringNumberofSecondShow.Substring(1, 1));
            Bitmap bit3 = sharedBitmap.GetBitMapDigit(StringNumberofSecondShow.Substring(2, 1));
            this.lblNumberofSecond1.Image = bit1;
            this.lblNumberofSecond2.Image = bit2;
            this.lblNumberofSecond3.Image = bit3;
            
        }
        private void RenderNumberofSecondShow()
        {

        }

        Dictionary<int, Dictionary<int, Label>> DicButon = new Dictionary<int, Dictionary<int, Label>>();
        Game MineSweep = new Game ();
        private void button7_Click(object sender, EventArgs e)
        {
           

        }
        
        private void Timer1_Tick(object sender, EventArgs e)
        {
            MineSweep.RunningTime();
            this.RenderNumberofSecond(MineSweep.Seconds);

           // throw new NotImplementedException();
        }
        private Boolean[,] _IsFlagCell;
        public Boolean[,] IsFlagCell
        {
            get { return _IsFlagCell; }
        }

        /*
        private void Cell_Click(object sender, EventArgs e)
        {
            // throw new NotImplementedException();
            
            String ID = "";
            Label b = (Label)sender;
            ID = b.Tag.ToString();
            List<Position> listPo = new List<Position>();
         
            int Row = ID.Substring(0, 2).ToInt();
            int Col = ID.Substring(2, 2).ToInt();
            if(IsFlagCell[Row, Col])
            {
                return;
            }

            UserClick(MineSweep , Row, Col);

        }
        */
        private void Cell_MouseDown(object sender, MouseEventArgs e)
        {
            //throw new NotImplementedException();

            String ID = "";
            Label b = (Label)sender;
            ID = b.Tag.ToString();
            int Row = ID.Substring(0, 2).ToInt();
            int Col = ID.Substring(2, 2).ToInt();

            if (e.Button == MouseButtons.Left )
            {
                if (IsFlagCell[Row, Col])
                {
                    return;
                }

                UserClick(MineSweep, Row, Col);

                
            }
            if (e.Button == MouseButtons.Right)
            {
                if (MineSweep.board.IsOpenCell[Row, Col])
                {
                    return;
                }
                if(IsFlagCell[Row, Col])
                {
                    NumberofFlag--;
                    IsFlagCell[Row, Col] = false;
                }
                else
                {
                    NumberofFlag++;
                    IsFlagCell[Row, Col] = true;
                }
               // IsFlagCell[Row, Col] = !IsFlagCell[Row, Col];
                ShowNumberofBome();
            }
            RenderBoard(MineSweep.board);

            
            
        }
        private int NumberofFlag = 0;
        private void ShowNumberofBome()
        {
           // int NumberofFlag = 0;
            int NumberofMindShow = MineSweep.NumberofMines - NumberofFlag;
            RenderNumberofMineShow(NumberofMindShow);
        }
        string[] arrDifficultLevel = {"",
        "Beginner",
        "Intermidate",
        "Expert"};
        private void UserClick(Game pGame, int Row, int Column)
        {
            if(MineSweep.GameState == GameStateEnum.End )
            {
                return;
            }

            bool IsThisCellAlreayOpen = pGame.board.IsOpenCell[Row, Column];
            if (IsThisCellAlreayOpen )
            {
                return;
            }

            pGame.OpenCell(Row, Column);
            if (this.timer1.Enabled == false)
            {
                StartTimer();
            }
            int CellValue = pGame.board.Matrix[Row, Column];
            if (pGame.board.Matrix[Row, Column] == ConstCell.Blank) { 
              pGame.OpenNeighborBlankCell(Row, Column);
            }
            //this.RenderBoard(pGame.board);
            if(pGame.GameState== GameStateEnum.Running )
            {
                ShowFaceWonder();
                return;
            }

            if (pGame.GameState == GameStateEnum.End)
            {
                if (!pGame.HasSuccessfulClickthefirstCellWithoutDie)
                {
                    Position ByPassPositionFortheNewGame = new Position(Row, Column);
                    NewGame(ByPassPositionFortheNewGame);
                    UserClick(MineSweep, Row, Column);
                    return;
                }

                StopTimer();
                if(pGame.GameResult == GameResultEnum.Lost)
                {
                    ShowFaceLost();
                } else
                {
                    ShowFaceWon();
                    if(MineSweep.GameDifficultLevel == 4)
                    {
                        return;
                    }

                    String message = @"You broke a record for " + arrDifficultLevel[MineSweep.GameDifficultLevel];
                    if(MineSweep.Seconds < score.GetSecond (MineSweep.GameDifficultLevel  ))
                    {
                        FormEnterNewTimeRecord f = new FormEnterNewTimeRecord();
                        f.Message = message;
                        f.PreviousRecordName = score.GetName(MineSweep.GameDifficultLevel);
                        f.ShowDialog();
                        if(f.DialogResult != DialogResult.OK)
                        {
                            return;
                        }
                        score.SetSecond(MineSweep.GameDifficultLevel , MineSweep.Seconds);
                        score.SetName(MineSweep.GameDifficultLevel, f.NewName);
                        SaveScore();
                    }
                }
            }
            
          

            

        }
        public static string CurrentPath
        {
            get
            {
                String ExePath = new Uri(System.Reflection.Assembly.GetExecutingAssembly().CodeBase).LocalPath;
                return Path.GetDirectoryName(ExePath);
                //   logFilePath = logFilePath.Replace(".exe", "");
            }
        }
        private String ScoreFileName = CurrentPath + @"\Score.bin";
        private Score _score = null;
        private Score score
        {
            get
            {
                if(_score ==null)
                {
                    if(!System.IO.File.Exists(ScoreFileName))
                    {
                        SerializeUtility.CreateNewScoreFile(ScoreFileName);
                    }
                    _score = SerializeUtility.DeserializeScore(CurrentPath + @"\Score.bin");
                }

                return _score;
            }
        }
        private void SaveScore()
        {
            SerializeUtility.SerializeScore (_score,ScoreFileName );
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //Credit icon designer
            //http://www.rw-designer.com/icon-detail/3084
            this.Icon = Resource1.mine2;

            Color BoardBackColor = Color.FromArgb(192, 192, 192);
            this.pnlMain.BackColor = BoardBackColor;
            this.pnlScore.BackColor = BoardBackColor;
            this.pnlGame.BackColor = BoardBackColor;
            NewGame();
           // this.Scale(0.90f);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGame();
        }
        private void StartTimer()
        {
            timer1.Interval = 1000;
            timer1.Enabled = true;
            timer1.Tick -= Timer1_Tick;
            timer1.Tick += Timer1_Tick;

        }
        private void StopTimer()
        {
            timer1.Enabled = false;
           
        }
        private void NewGame()
        {
            NewGame(Position.Empty);
        }
        private void NewGame(Position PostionThatMineMustNotExist)
        {
            //   MineSweep = new Game();
            NumberofFlag = 0;
            MineSweep.listMinePositionForDebugPurpose = new List<Position>();
         //   MineSweep.listMinePositionForDebugPurpose.Add(new Position(1, 1));
            MineSweep.New(PostionThatMineMustNotExist);

            _IsFlagCell = new Boolean[MineSweep.NoofRow, MineSweep.NoofColumn];

            InitialBoardUI(MineSweep.board);
            RenderBoard(MineSweep.board);
            RenderNumberofMineShow(MineSweep.NumberofMines);
            StopTimer();


        }
        private void UpdateMenuDifficultLevelClick(int DifficultyLevel)
        {
            beginnerToolStripMenuItem.Checked = false;
            intermidiateToolStripMenuItem.Checked = false;
            expertToolStripMenuItem.Checked = false;
            customToolStripMenuItem.Checked = false;
            int i;
            ToolStripMenuItem menuItem = null;
            switch (DifficultyLevel)
            {
                case 1:
                    menuItem = beginnerToolStripMenuItem;
                    break;
                case 2:
                    menuItem = intermidiateToolStripMenuItem;
                    break;
                case 3:
                    menuItem = expertToolStripMenuItem;
                    break;
                case 4:
                    menuItem = customToolStripMenuItem;
                    break;
                default:
                    throw new Exception(DifficultyLevel.ValueRangeIsIncorrectString ("Difficulty Level",1,4));
            }
            menuItem.Checked = true;


        }
       // private int DifficultyLevel = 1;

       // Game MineGame = new Game();
        private void intermidiateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MineSweep.GameDifficultLevel = 2;            
            UpdateMenuDifficultLevelClick(MineSweep.GameDifficultLevel );

        }

        private void beginnerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MineSweep.GameDifficultLevel = 1;
            UpdateMenuDifficultLevelClick(MineSweep.GameDifficultLevel);
        }

        private void expertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MineSweep.GameDifficultLevel = 3;
            UpdateMenuDifficultLevelClick(MineSweep.GameDifficultLevel);
        }
        
        private void customToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCustomField f = new FormCustomField();
            f.NoofRow = MineSweep.CustomHeight;
            f.NoofColumn = MineSweep.CustomWidth;
            f.NoofMines = MineSweep.CustomNumberofMines;
            f.ShowDialog();
            if(f.DialogResult != DialogResult.OK)
            {
                return;
            }
            MineSweep.GameDifficultLevel = 4;
            MineSweep.CustomHeight = f.NoofRow;
            MineSweep.CustomWidth = f.NoofColumn;
            MineSweep.CustomNumberofMines = f.NoofMines;
            UpdateMenuDifficultLevelClick(MineSweep.GameDifficultLevel);

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void openAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MineSweep.OpenAllCell();
            this.RenderBoard(MineSweep.board);

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void hideRunningTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hideRunningTimeToolStripMenuItem.Checked = !hideRunningTimeToolStripMenuItem.Checked;
            this.pnlTime.Visible = !hideRunningTimeToolStripMenuItem.Checked;

        }

        private void bestTimesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormBestTime f = new FormBestTime();
            f.score = this.score;
            f.ShowDialog();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAbout f = new FormAbout();
            f.StartPosition = FormStartPosition.CenterParent;
            f.ShowDialog();
        }
    }
}
