using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookRentalProj.Extensions
{
    // sets custom date range to be used elsewhere
    public class DateRangeAttribute : RangeAttribute
    {
        // function to set the to type of DateTime and also must be between minimum value and current datetime e.g., birthdates
        public DateRangeAttribute(string minVal) : base(typeof(DateTime), minVal, DateTime.Now.ToString())
        {

        }
    }
}