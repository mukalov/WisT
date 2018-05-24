using System.Data.Entity.Migrations;

namespace WisT.DemoWeb.Persistence.DataEntities.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<WisTEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "WisTAPI";
        }

        protected override void Seed(WisTEntities context)
        {
            //  This method will be called after migrating to the latest version.
        }
    }
}
