using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MineSweeper.Form1;
using static MineSweeper.Game;

namespace MineSweeper
{
    public class SharedBitMap
    {
        public static string CurrentPath
        {
            get
            {
                String ExePath = new Uri(System.Reflection.Assembly.GetExecutingAssembly().CodeBase).LocalPath;
                return Path.GetDirectoryName(ExePath);
                //   logFilePath = logFilePath.Replace(".exe", "");
            }
        }
        public static string ImageFolder
        {
            get
            {
                return CurrentPath + @"\Images\";
            }
        }
        Dictionary<FaceEnum, Bitmap> DicBitMapFace = null;
        public Bitmap GetBitmapFace(FaceEnum Face)
        {
            //  Bitmap B = new Bitmap(@"D:\Temp\2022_04_17\stone2.png");
            if (DicBitMapFace == null)
            {
                DicBitMapFace = new Dictionary<FaceEnum, Bitmap>();

            }
            if (!DicBitMapFace.ContainsKey(Face))
            {
                String fileName = "";

                switch (Face)
                {
                    case FaceEnum.Smile:
                        fileName = "SmileFace.png";
                        break;
                    case FaceEnum.SmilePushed:
                        fileName = "SmileFace_Down.png";
                        break;
                    case FaceEnum.Wonder:
                        fileName = "Wonder_Face.png";
                        break;
                    case FaceEnum.Depress:
                        fileName = "Depress_Face.png";
                        break;
                    case FaceEnum.Happy:
                        fileName = "Happy_Face.png";
                        break;
                }

                fileName = ImageFolder + fileName;
                DicBitMapFace.Add(Face, new Bitmap(fileName));
            }
            return DicBitMapFace[Face];
        }
        Dictionary<int, Bitmap> DicBitMapDigit = null;
        private Bitmap BitMapMinus = null;
        public Bitmap GetBitMapDigit(String str)
        {
            //return GetBitMapDigit(str.ToInt());
            if (str == "-")
            {
                if(BitMapMinus ==null)
                {
                    BitMapMinus = new Bitmap(ImageFolder + "Score_-.png");
                }
                return BitMapMinus;
            }

            int Digit = str.ToInt ();
           // if(str!= " " str.ToInt();
            if (!Digit.IsBetween(0, 9))
            {
                throw new Exception(String.Format("The Digit is {0} which is incorrect, it must be between {1} and {2}", Digit, 0, 9));
            }
            if (DicBitMapDigit == null)
            {
                DicBitMapDigit = new Dictionary<int, Bitmap>();
            }
            if (!DicBitMapDigit.ContainsKey(Digit))
            {
                String fileName = "";

                fileName = "Score_" + Digit + ".png";

                fileName = ImageFolder + fileName;
                DicBitMapDigit.Add(Digit, new Bitmap(fileName));
            }
            return DicBitMapDigit[Digit];
        }
        

        private Bitmap GetBitMapDigit(int Digit)
        {
            if (!Digit.IsBetween(0, 9))
            {
                throw new Exception(String.Format("The Digit is {0} which is incorrect, it must be between {1} and {2}", Digit, 0, 9));
            }
            if (DicBitMapDigit == null)
            {
                DicBitMapDigit = new Dictionary<int, Bitmap>();
            }
            if (!DicBitMapDigit.ContainsKey(Digit))
            {
                String fileName = "";

                fileName = "Score_" + Digit + ".png";

                fileName = ImageFolder + fileName;
                DicBitMapDigit.Add(Digit, new Bitmap(fileName));
            }
            return DicBitMapDigit[Digit];
        }
        Dictionary<int, Bitmap> DicValue = null;

        private Bitmap BitmapFlag = null;
        public Bitmap GetBitmapFlg()
        {
            if (BitmapFlag == null)
            {
                String fileName = ImageFolder + @"CloseFlag.png";
                BitmapFlag = new Bitmap(fileName);

            }
            return BitmapFlag;
        }
        public Bitmap GetBitmapByCellValue(int iValue)
        {
            if (DicValue == null)
            {
                DicValue = new Dictionary<int, Bitmap>();
            }
            if (!DicValue.ContainsKey(iValue))
            {
                String fileName = "";


                if (iValue < 1)
                {
                    switch (iValue)
                    {
                        case ConstCell.Bomb:
                            fileName = "Mine.png";
                            break;
                        case ConstCell.Blank:
                            fileName = "BlankCell.png";
                            break;
                        case ConstCell.HasValue:
                            fileName = "CloseCell.png";
                            break;

                    }
                }
                else
                {
                    fileName = iValue + ".png";
                }
                fileName = ImageFolder + fileName;
                DicValue.Add(iValue, new Bitmap(fileName));
            }
            return DicValue[iValue];
        }

    }
}
