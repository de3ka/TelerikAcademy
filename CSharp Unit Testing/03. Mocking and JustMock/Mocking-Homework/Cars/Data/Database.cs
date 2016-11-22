using Cars.Contracts;
using Cars.Models;
using System.Collections.Generic;

namespace Cars.Data
{
    public class Database : IDatabase
    {
        public IList<Car> Cars { get; set; }
    }
}
