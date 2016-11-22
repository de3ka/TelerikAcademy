using LogsDB.DatabaseContext.Entities;

namespace LogsDB.Importer.Interfaces
{
    public interface ILogsImporter
    {
        void Import(LogsEntities db, int count);
    }
}
