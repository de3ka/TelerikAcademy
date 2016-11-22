using LogsDB.DatabaseContext.Entities;
using LogsDB.Importer.Models;

namespace LogsDB.ConsoleClient
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            using (var db = new LogsEntities())
            {
                var logsImporter = new LogsImporter();
                logsImporter.Import(db, 10000000);
            }
        }
    }
}