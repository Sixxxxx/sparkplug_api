
using SparkPlug.Services.Interfaces;

namespace SparkPlug.Services.Infrastructures
{
    public class DatabaseSettings 
    {
        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }

        public string FormsCollectionName { get; set; }
    }
}
