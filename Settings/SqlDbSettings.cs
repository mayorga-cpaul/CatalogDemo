namespace CatalogDemo.Settings
{
    public class SqlDbSettings
    {
        public string Server { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string Database { get; set; }
        public string GetConnectionString => $"Data source={Server}; Initial Catalog={Database}; User Id={User}; Password={Password}; TrustServerCertificate=True";
    }
}