namespace CrudUsingADONet
{
    public static class ConnectionString
    {
        private static string cs = "Server=DESKTOP-06ADKEA; Database=CRUD; Trusted_Connection=True; TrustServerCertificate=Yes;";
        public static string dbcs { get => cs; }
    }
}
