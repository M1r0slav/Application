using System.Collections.Generic;

namespace Common
{
    public static class Global
    {
        public static string ApplicationName { get; } = "Jica";

        public static string AdminRoleName { get; } = "Admin";

        public static AppTitles Titles = new AppTitles { Home = "Jica", Privacy = "Privacy", Concerts = "Concerts", ConcertsDetails = "Details of Concerts" };

        public static string SQLString => sqlConnectionStrings[connectionStringToUse];

        //Choose your connection that should be used upon running the app
        private static string connectionStringToUse = "MiroHomePc";
        //Register here all connections to remoteDB to your DB to all kinds of DB-s
        private static IDictionary<string, string> sqlConnectionStrings = new Dictionary<string, string>()
        {
            ["MiroHomePc"] = "Server=DESKTOP-K8JTLLP\\SQLEXPRESS;Database=JicaDB;Trusted_Connection=True;MultipleActiveResultSets=true",
            ["Pc2"] = "Server=.;Database=JicaDB;Trusted_Connection=True;MultipleActiveResultSets=true",
            ["Pc3"] = "Server=localhost\\SQLEXPRESS;Database=JicaDB2;Trusted_Connection=True;MultipleActiveResultSets=true",
            ["Somee"] = "workstation id=JicaDatabase.mssql.somee.com;packet size=4096;user id=Miro347_SQLLogin_2;pwd=1ap79rqyz2;data source=JicaDatabase.mssql.somee.com;persist security info=False;initial catalog=JicaDatabase",
            
        };
        public static string TicketsCurrency = "лв.";
        public static string BudgetCurrency = "USD";
    }


    public class AppTitles
    {
        public string Home { get; set; }
        public string Privacy { get; set; }
        public string Concerts { get; set; }
        public string ConcertsDetails { get; set; }
    }
}
