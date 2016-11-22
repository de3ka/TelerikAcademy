using School.Data;
using School.DatabaseContext.Migrations;
using System.Data.Entity;

namespace School.DatabaseContext
{
    public class SchoolDatabaseContext : DbContext
    {
        public SchoolDatabaseContext() : base("name=SchoolDB")
        {
            var migrationStrategy = new MigrateDatabaseToLatestVersion<SchoolDatabaseContext, Configuration>();
            Database.SetInitializer(migrationStrategy);
        }

        public virtual IDbSet<Student> Students { get; set; }

        public virtual IDbSet<Course> Courses { get; set; }

        public virtual IDbSet<Homework> Homeworks { get; set; }
    }
}