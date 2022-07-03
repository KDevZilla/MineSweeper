using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper
{
    [Serializable]
    public class Score
    {
        public int BeginerSeconds = 999;
        public int IntermidiateSeconds = 999;
        public int ExpertSeconds = 999;
        public String BeginnerName = "Anonymous";
        public String IntermidateName = "Anonymous";
        public String ExpertName = "Anonymous";

        public int GetSecond(int DifficultLevel)
        {
            if(!DifficultLevel.IsBetween(1, 3))
            {
                throw new Exception(DifficultLevel.ValueRangeIsIncorrectString("Difficult Level", 1, 3));
            }
            switch (DifficultLevel)
            {
                case 1:
                    return BeginerSeconds;
                    break;
                case 2:
                    return IntermidiateSeconds;
                    break;
                case 3:
                    return ExpertSeconds;
                    break;
                        
            }
            return -1;
        }
        public void SetSecond(int DifficultLevel, int Seconds)
        {
            if (!DifficultLevel.IsBetween(1, 3))
            {
                throw new Exception(DifficultLevel.ValueRangeIsIncorrectString("Difficult Level", 1, 3));
            }
            switch (DifficultLevel)
            {
                case 1:
                    BeginerSeconds =Seconds;
                    break;
                case 2:
                    IntermidiateSeconds  = Seconds ;
                    break;
                case 3:
                    ExpertSeconds = Seconds ;
                    break;

            }

        }
        public String GetName(int DifficultLevel)
        {
            if (!DifficultLevel.IsBetween(1, 3))
            {
                throw new Exception(DifficultLevel.ValueRangeIsIncorrectString("Difficult Level", 1, 3));
            }
            switch (DifficultLevel)
            {
                case 1:
                    return BeginnerName;
                    break;
                case 2:
                    return IntermidateName;
                    break;
                case 3:
                    return ExpertName;
                    break;

            }
            return "";
        }

        public void SetName(int DifficultLevel, String Name)
        {
            if (!DifficultLevel.IsBetween(1, 3))
            {
                throw new Exception(DifficultLevel.ValueRangeIsIncorrectString("Difficult Level", 1, 3));
            }
            switch (DifficultLevel)
            {
                case 1:
                    BeginnerName = Name;
                    break;
                case 2:
                    IntermidateName = Name;
                    break;
                case 3:
                    ExpertName = Name;
                    break;

            }

        }
    }
}
