using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper
{

    public static class Extensions
    {
        public static IEnumerable<int> To(this int Num1, int Num2)
        {
            return Enumerable.Range(Num1, Num2 - Num1);

        }
        public static String Format(this String s, params object[] objects) 
        {
            return String.Format(s, objects);
        }
        public static int AdjustToBound(this int s,int Min, int Max)
        {
            s = Math.Min(s, Max);
            s = Math.Max(s, Min);
            return s;
        }
        public static bool In<T>(this T item, params T[] items)
        {
            if (items == null)
                throw new ArgumentNullException("items");

            return items.Contains(item);

        }
        /*
        public static bool IsBetween<T>(this T item, T start, T end)
        {
            return Comparer<T>.Default.Compare(item, start) >= 0
                && Comparer<T>.Default.Compare(item, end) <= 0;
        }
       */
        
        public static String ValueRangeIsIncorrectString(this int item, String valueName, int start, int end)
        {
            return String.Format("{0} is {1} which is invalid, it is supposed to be between {2} and {3}.",
                valueName,
                item,
                start,
                end);

        }
        public static bool IsBetween(this int item, int start, int end)
        {
            if(item < start)
            {
                return false;
            }
            if(item > end)
            {
                return false;
            }
            return true;

        }
        public static int ToInt(this String item)
        {
            return int.Parse(item);
        }
        public static double ToDouble(this String item)
        {
            return double.Parse(item);
        }
    }
}
