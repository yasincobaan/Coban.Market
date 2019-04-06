using System.Data.Entity;

namespace Coban.Market.DAL
{
    public class MyInitializer : DropCreateDatabaseIfModelChanges<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
        }
    }
}
