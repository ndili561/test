using System;

namespace Incomm.Allocations.BLL.Common
{
    public class DateDifference
    {
        private int[] monthDay = new int[12] { 31, -1, 31, 30, 31, 30, 31, 31, 30, 31, 30,31 };
        private readonly DateTime fromDate;
        private DateTime toDate;
        private int year;
        private int month;
        private int day;
        public DateDifference(DateTime dateFrom, DateTime dateTo)
        {
            if (dateFrom > dateTo)
            {
                this.fromDate = dateTo;
                this.toDate = dateFrom;
            }
            else
            {
                this.fromDate = dateFrom;
                this.toDate = dateTo;
            }
           int increment = 0;
            if (this.fromDate.Day > this.toDate.Day)
            {
                increment = this.monthDay[this.fromDate.Month - 1];
            }
            if (increment == -1)
            {
                if (DateTime.IsLeapYear(this.fromDate.Year))
                {
                    increment = 29;
                }
                else
                {
                    increment = 28;
                }
            }
            if (increment != 0)
            {
                day = (this.toDate.Day + increment) - this.fromDate.Day;
                increment = 1;
            }
            else
            {
                day = this.toDate.Day - this.fromDate.Day;
            }
            //Month Calculation
            if ((this.fromDate.Month + increment) > this.toDate.Month)
            {
                this.month = (this.toDate.Month + 12) - (this.fromDate.Month + increment);
                increment = 1;
            }
            else
            {
                this.month = (this.toDate.Month) - (this.fromDate.Month + increment);
                increment = 0;
            }
            //Year Calculation
            this.year = this.toDate.Year - (this.fromDate.Year + increment);
        }
        public override string ToString()
        {
            return this.year + "Year(s), " + this.month + " month(s), and " + this.day + " day(s)";
        }
    }
}
