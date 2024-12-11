namespace ReboteqTask.Core.AppMetaData;

public static class Router
{
    public const string SingleRoute = "/{id}";
    public const string Root = "api";
    public const string Version = "v1";
    public const string Rule = Root + "/" + Version + "/";

    public static class ProductRoutes
    {
        public const string Prefix = Rule + "product";
        public const string GetAllProducts = Prefix + "/all";
    }

    public static class OrderRoutes
    {
        public const string Prefix = Rule + "order";
        public const string AddOrder = Prefix + "/create";
        public const string GetAllProducts = Prefix + "/all";
    }
}
