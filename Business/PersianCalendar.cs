using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
   public class PersianCalendar
    {
        System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
       

        public int GetDayOfMonth(DateTime time)
        {
            return pc.GetDayOfMonth(time);
            
        }
        public  int GetMonth(DateTime time)
        {

            return pc.GetMonth(time);
        }
       public string GetPersianyear(DateTime date)
        {
            return GetYear(date).ToString().Replace('1', '۱').Replace('2', '۲').Replace('3', '۳')
                .Replace('4', '۴').Replace('5', '۵').Replace('6', '۶').Replace('7', '۷').Replace('8', '۸')
                .Replace('۹', '۱');
        }
        public string GetPersianDay(DateTime date)
        {

            return GetDayOfMonth(date).ToString().Replace('1', '۱').Replace('2', '۲').Replace('3', '۳')
                .Replace('4', '۴').Replace('5', '۵').Replace('6', '۶').Replace('7', '۷').Replace('8', '۸')
                .Replace('۹', '۱');
        }
        public string GetMonthName(DateTime date)
        {
            switch (GetMonth(date))
            {
                case 1:
                    return "فروردین";
                case 2:
                    return "اردیبهشت";
                case 3:
                    return "خرداد";
                case 4:
                    return "تیر";
                case 5:
                    return "مرداد";               
                case 6:
                    return "شهریور";
                case 7:
                    return "مهر";
                case 8:
                    return "آبان";
                case 9:
                    return "آذر";
                case 10:
                    return "دی";
                case 11:
                    return "بهمن";

                default:
                    return "اسفند";
            }

        }


        public int GetYear(DateTime time)
        {
            return pc.GetYear(time);
        }
    }
}
