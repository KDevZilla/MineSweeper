using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper
{
    public class Game
    {
        public enum GameStateEnum
        {
            NotRunningYet,
            Running,
            End
        }
        public enum GameResultEnum
        {
            NotDicidedYet,
            Won,
            Lost
        }
        public Position PostionThatMineMustNotExist = Position.Empty;

        private Boolean _HasSuccessfulClickthefirstCellWithoutDie = false;
        public Boolean HasSuccessfulClickthefirstCellWithoutDie
        {
            get { return _HasSuccessfulClickthefirstCellWithoutDie; }
        }
        public GameResultEnum GameResult { get; private set; }
        private GameStateEnum _GameState = GameStateEnum.NotRunningYet;
        public GameStateEnum GameState
        {
            get{
                return _GameState;
            }
        }
        int[] arrNoofRow = { -1, 9, 16, 16, 24 };
        int[] arrNoofColumn = { -1, 9, 16, 30, 30 };
        int[] arrMines = { -1, 10, 40, 99, 688 };
        public int NoofRow
        {
            get { return arrNoofRow[this._GameDifficultLevel]; }
        }
        public int NoofColumn {
            get { return arrNoofColumn[this._GameDifficultLevel]; }
        }
        public int NumberofMines
        {
            get { return arrMines[this._GameDifficultLevel]; }
        }

        public int CustomHeight
        {
            get
            {
                return arrNoofRow[4];
            }
            set
            {
                arrNoofRow[4] = value;
            }
        }
        public int CustomWidth
        {
            get
            {
                return arrNoofColumn[4];
            }
            set
            {
                arrNoofColumn[4] = value;
            }
        }
        public int CustomNumberofMines
        {
            get
            {
                return arrMines[4];
            }
            set
            {
                arrMines[4] = value;
            }
        }
        private int _GameDifficultLevel = 1;
        public int GameDifficultLevel
        {
            get { return _GameDifficultLevel; }
            set
            {
                if(!_GameDifficultLevel.IsBetween(1, 4))
                {
                    throw new Exception(_GameDifficultLevel.ValueRangeIsIncorrectString("Game Difficulty", 1, 4));
                }
                _GameDifficultLevel = value;
            }
        }
        public void OpenCell(int Row, int Col)
        {
           this.board.IsOpenCell[Row, Col] = true;
            
            UpdateGameState(Row, Col);
        }
        public void OpenAllCell()
        {
            int i;
            int j;
            for (i = 0; i < this.NoofRow; i++)
            {
                for (j = 0; j < this.NoofColumn; j++)
                {
                    OpenCell(i, j);
                }
            }
        }
        private Boolean IsWon()
        {
            int i;
            int j;
            for (i = 0; i < this.NoofRow; i++)
            {
                for(j=0;j<this.NoofColumn;j++)
                {
                    if(this.board.Matrix [i,j] == ConstCell.Bomb)
                    {
                        continue;
                    }
                    if(!this.board.IsOpenCell[i,j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private void UpdateGameState(int LatestRow, int LatestCol)
        {
            if (this.board.Matrix[LatestRow, LatestCol] == ConstCell.Bomb)
            {
                _GameState = GameStateEnum.End;
                GameResult = GameResultEnum.Lost;
            }
            else
            {
                _HasSuccessfulClickthefirstCellWithoutDie = true;
            }
            if (IsWon())
            {
                _GameState = GameStateEnum.End;
                GameResult = GameResultEnum.Won;
            }
         
        }
        public void OpenCell(Position pos)
        {
            OpenCell(pos.Row, pos.Col);
        }

        public void CloseCell(int Row, int Col)
        {
            this.board.IsOpenCell[Row, Col] = false;
        }
        public void CloseCell(Position pos)
        {
            CloseCell(pos.Row, pos.Col);
        }
        public void CloseAllCell()
        {
            int i;
            int j;
            for (i = 0; i < this.NoofRow ; i++)
            {
                for (j = 0; j < this.NoofColumn ; j++)
                {
                    CloseCell(i, j);
                }
            }
        }
        public void GenerateMine(Board pBoard)
        {
            int i;

            int j;

            InitialBoard(pBoard);
            
            SetBomb(pBoard,this.NumberofMines, this.PostionThatMineMustNotExist);
            if (PostionThatMineMustNotExist.Row == -1)
            {
                this.board.Matrix[0, 0] = ConstCell.Bomb;
            }

            SetHasValueCell(pBoard);






            for (i = 0; i < pBoard.NoofRow; i++)
            {
                for (j = 0; j < pBoard.NoofCol; j++)
                {
                    if (pBoard.Matrix[i, j].In(ConstCell.Bomb, ConstCell.Blank))
                    {
                        continue;
                    }

                    List<Position> listNeighbour = GetNeighbourCell(i, j, pBoard.NoofRow, pBoard.NoofCol);
                    int NumberBomb = 0;
                    foreach (Position p in listNeighbour)
                    {
                        if (pBoard.Matrix[p.Row, p.Col] == ConstCell.Blank)
                        {
                            continue;
                        }

                        if (pBoard.Matrix[p.Row, p.Col] == ConstCell.Bomb)
                        {
                            NumberBomb++;
                        }
                    }
                    pBoard.Matrix[i, j] = NumberBomb;
                }
            }


        }

        private static Random rnd = new Random();


        public static int Random(int Min, int Max)
        {
            return rnd.Next(Min, Max);
        }
        //positionDoesnotAllow
        public static List<Position> GetUniqueRandomPosition(int MaxRow, int MaxCol, int NumberofRandom, Position positionDoesnotAllow)
        {
            List<Position> lst = new List<Position>();
            HashSet<int> hsh = new HashSet<int>();

            hsh.Add((positionDoesnotAllow.Row * MaxRow) + positionDoesnotAllow.Col);

            while (lst.Count < NumberofRandom)
            {
                int Row = Random(0, MaxRow );
                int Col = Random(0, MaxCol );
                int hshValue = (Row * MaxRow) + Col;
                if (hsh.Contains(hshValue))
                {
                    continue;
                }
                hsh.Add(hshValue);
                lst.Add(new Position(Row, Col));
            }
            return lst;
        }
        public static List<Position> GetUniqueRandomPosition(int Min, int Max, int NumberofRandom)
        {
            return GetUniqueRandomPosition(Min, Max, NumberofRandom, Position.Empty);
        }

        // int[,] Matrix = new int[9, 9];
        private Board _board = null;
        public Board board
        {
            get { return _board; }
        }
       // Dictionary<int, Dictionary<int, Label>> DicButon = new Dictionary<int, Dictionary<int, Label>>();
        //int BoardSize = 9;

        private List<Position> GetNeighbourCell(int Row, int Col, int NoofRow, int NoofCol)
        {
            int i;
            int j;
            List<Position> listNeighbour = new List<Position>();
            for (i = -1; i <= 1; i++)
            {
                int RowNeighbour = Row + i;
                Boolean IsRowvalid = RowNeighbour.IsBetween(0, NoofRow - 1);
                if (!IsRowvalid)
                {
                    continue;
                }

                for (j = -1; j <= 1; j++)
                {

                    int ColNeighbour = Col + j;
                    Boolean IsColNeightborValid = ColNeighbour.IsBetween(0, NoofCol - 1);
                    if (!IsColNeightborValid)
                    {
                        continue;
                    }
                    if (RowNeighbour == Row && ColNeighbour == Col)
                    {
                        continue;
                    }
                    listNeighbour.Add(new Position(RowNeighbour, ColNeighbour));
                }
            }
            return listNeighbour;
        }
        public static class ConstCell
        {
            public const int Bomb = -1;
            public const int Blank = -2;
            public const int HasValue = 0;
           
        }
        private int[,] CopyArray(int[,] Original)
        {

            int[,] NewArray = new int[Original.GetLength(0),
                                      Original.GetLength(1)];

            Array.Copy(Original, 0, NewArray, 0, Original.Length);
            return NewArray;
        }
        private Boolean IsValidGame(int[,] pMatrxi)
        {
            int i;
            int j;
            int LastRow = pMatrxi.GetLength(0);
            int LastCol = pMatrxi.GetLength(1);
            for (i = 0; i < LastCol; i++)
            {
                for (j = 0; j < LastCol; j++)
                {
                    int Cellvalue = pMatrxi[i, j];
                    if (!Cellvalue.IsBetween(-1, 8))
                    {
                        return false;
                    }
                }
            }
            var NewArray = CopyArray(pMatrxi);

            return true;
        }
        private void InitialBoard(Board pBoard)
        {
            int i;
            int j;

            for (i = 0; i < pBoard.NoofRow; i++)
            {
                for (j = 0; j < pBoard.NoofCol; j++)
                {
                    pBoard.Matrix[i, j] = ConstCell.Blank;
                }
            }
            CloseAllCell();
        }
        private void SetBomb(Board pBoard, int NumberofBomb, Position positionDoesnotAllow)
        {
            int i;
            int j;

            List<Position> listPositionBomb = GetUniqueRandomPosition(pBoard.NoofRow ,pBoard.NoofCol , NumberofBomb, positionDoesnotAllow);
            int CellValue = 0;
            for (i = 0; i < NumberofBomb; i++)
            {
                pBoard.Matrix[listPositionBomb[i].Row, listPositionBomb[i].Col] = ConstCell.Bomb;
            }
            if (System.Diagnostics.Debugger.IsAttached)
            {
                if (listMinePositionForDebugPurpose?.Count > 0)
                {
                    foreach (Position pos in listMinePositionForDebugPurpose)
                    {
                        if (pos.Col == positionDoesnotAllow.Col && pos.Row ==positionDoesnotAllow.Row )
                        {
                            continue;
                        }
                        pBoard.Matrix[pos.Row, pos.Col] = ConstCell.Bomb;
                    }
                }
            }

        }
        private int _Seconds = 0;
        public int Seconds
        {
            get { return _Seconds; }
        }
        public void RunningTime()
        {
            _Seconds++;
        }
        //public Board board = null;
        public List<Position> listMinePositionForDebugPurpose = new List<Position>();
       // public void SetMinePositionForDebugPurpose()
        public void ExplicitConstructor(Position PostionThatMineMustNotExist)
        {
            this.PostionThatMineMustNotExist = PostionThatMineMustNotExist;
            _board = new Board(this.NoofRow, this.NoofColumn);
            _Seconds = 0;
            _HasSuccessfulClickthefirstCellWithoutDie = false;
            //InitialBoard(_board);
            this.GenerateMine(_board);
            GameResult = GameResultEnum.NotDicidedYet;
            _GameState = GameStateEnum.Running;
        }
        public void New(Position PostionThatMineMustNotExist)
        {
            ExplicitConstructor(PostionThatMineMustNotExist);
        }

        public void New()
        {
            ExplicitConstructor(Position.Empty);
            
           // SetBomb(_board, this.NumberofMines, new Position(0, 0));
           // SetHasValueCell(_board);

        }
        private void SetHasValueCell(Board pBoard)
        {
            int i;
            int j;

            //List<Position> listPositionHasValue = GetUniqueRandomPosition(0, 9, NumberofHasValueCell);
            for (i = 0; i < pBoard.NoofRow; i++)
            {
                for (j = 0; j < pBoard.NoofCol; j++)
                {
                    if (pBoard.Matrix[i, j] != ConstCell.Bomb)
                    {
                        continue;
                    }
                    List<Position> listPositionhasValue = GetNeighbourCell(i, j, pBoard.NoofRow, pBoard.NoofCol);
                    foreach (Position posi in listPositionhasValue)
                    {
                        int NieghbourCellValue = pBoard.Matrix[posi.Row, posi.Col];
                        if (NieghbourCellValue.In(ConstCell.Bomb, ConstCell.HasValue))
                        {
                            continue;
                        }
                        int RandomValue = Random(1, 9);
                        if (RandomValue > 3)
                        {
                            pBoard.Matrix[posi.Row, posi.Col] = ConstCell.HasValue;
                        }

                    }

                }



            }
        }

        private List<Position> GetNeighbourCellRecursive(List<Position> lisNeighborAll, HashSet<int> HshNeighborAll, int Row, int Column, int NoofRow, int NoofCol, int CellValueCriteria)
        {
            List<Position> listNeighbor = GetNeighbourCell(Row, Column, board.NoofRow, board.NoofCol);
            foreach (Position pos in listNeighbor)
            {

                if (board.Matrix[pos.Row, pos.Col] != CellValueCriteria)
                {
                    continue;
                }
                int HashValue = pos.Row * NoofRow + pos.Col;
                if (HshNeighborAll.Contains(HashValue))
                {
                    continue;
                }
                //listNeighbor.Add(pos.Clone());
                HshNeighborAll.Add(HashValue);
                lisNeighborAll.Add(pos.Clone());
                List<Position> listNeighborChild = GetNeighbourCellRecursive(lisNeighborAll,
                                                                            HshNeighborAll,
                                                                            pos.Row,
                                                                            pos.Col,
                                                                            NoofRow,
                                                                            NoofCol,
                                                                            CellValueCriteria);

            }
            return listNeighbor;

        }
        public void OpenNeighborBlankCell(int Row, int Column)
        {
            List<Position> listNeighborRecursive = new List<Position>();
            HashSet<int> hshNeighborRecursive = new HashSet<int>();
            GetNeighbourCellRecursive(listNeighborRecursive,
                hshNeighborRecursive,
                Row,
                Column,
               board.NoofRow,
               board.NoofCol,
                ConstCell.Blank);

            listNeighborRecursive.ForEach(x => OpenCell(x.Row, x.Col));
            int i;
            foreach (Position po in listNeighborRecursive)
            {
                List<Position> listNeighbourNotBlank = GetNeighbourCell(po.Row, po.Col, board.NoofRow, board.NoofCol);
                foreach (Position poNotBlank in listNeighbourNotBlank)
                {
                    if (!board.Matrix[poNotBlank.Row, poNotBlank.Col].IsBetween(1, 8))
                    {
                        continue;
                    }
                    OpenCell(poNotBlank);
                }
            }
        }
    }
}
