using LogsDB.Data.Models;
using System.Data.Entity;

namespace LogsDB.DatabaseContext.Entities
{
    public class LogsEntities : DbContext
    {
        public LogsEntities() : base("LogsDB")
        {
        }

        public virtual IDbSet<Log> Logs { get; set; }
    }
}