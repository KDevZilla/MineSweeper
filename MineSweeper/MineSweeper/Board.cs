using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper
{
    public struct Position
    {
        public int Row;
        public int Col;
        public Position(int Row, int Col)
        {
            this.Row = Row;
            this.Col = Col;
        }
        public static Position Empty
        {
            get
            {
                return new Position(-1, -1);
            }
        }
        public Position Clone()
        {
            return new Position(this.Row, this.Col);
        }
    }

    public class Board
    {
       
        private int[,] _Matrix;
        public int[,] Matrix
        {
            get { return _Matrix; }
        }


        private Boolean[,] _IsOpenCell;
        public Boolean[,] IsOpenCell
        {
            get { return _IsOpenCell; }
        }
        public Board(int NoofRow, int NoofCol)
        {
            _Matrix = new int[NoofRow, NoofCol];
            _IsOpenCell = new Boolean[NoofRow, NoofCol];
            this.NoofRow = NoofRow;
            this.NoofCol = NoofCol;
        }
       


        public int NoofRow { get; private set; }
        public int NoofCol { get; private set; }
    }
}
