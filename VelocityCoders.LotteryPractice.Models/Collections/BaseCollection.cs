using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VelocityCoders.LotteryPractice.Models
{
    public abstract class BaseCollection<T> : Collection<T>, IList<T>
    {

        protected BaseCollection() : base(new List<T>()) { }

    }
}
