using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VelocityCoders.LotteryPractice.Models
{ 
    public class BrokenRule
    {
        public string PropertyName { get; set; }
        public string Message { get; set; }

        public BrokenRule(string propertyName, string message)
        {
            PropertyName = propertyName;
            Message = message;
        }

    }
}
