namespace HorizonREST.Classes
{
    internal class Endpoints
    {
        public static readonly Dictionary<string, string> Api = new()
        {
            {"Login", "/rest/login" },
            {"Machines", "/rest/inventory/v1/machines"},
            {"Pools", "/rest/inventory/v1/desktop-pools" },
            {"Refresh", "/rest/refresh" },
            {"Disconnect", "/rest/logout" }
        };
    }
}
