using System.Configuration;

namespace Reposytories.Factory
{
    public static class Factories
    {
        public static IFactory GetFactory()
        {
            string type = ConfigurationManager.AppSettings["factoryType"].ToString();
            switch (type)
            {
                case "ef":
                    return new EFFactory();
                case "ado":
                    return new ADOFactory();
                default:
                    return new ADOFactory();
            }
        }
    }
}
