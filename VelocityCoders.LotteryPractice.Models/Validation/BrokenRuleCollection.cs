using System;
using System.Collections.ObjectModel;
using System.Linq;


namespace VelocityCoders.LotteryPractice.Models
{
    public class BrokenRuleCollection : Collection<BrokenRule>
    {
        #region ||===  CREATES A NEW BROKEN-RULE AND ADDS IT TO THE INNER LIST  ===||

        public void Add(string message)
        {
            Add(new BrokenRule(string.Empty, message));
        }
        #endregion


        #region ||===  CREATES A NEW BROKEN-RULE AND ADDS IT TO THE INNER LIST  ===||

        public void Add(string propertyName, string message)
        {
            Add(new BrokenRule(propertyName, message));
        }
        #endregion
    }
}
