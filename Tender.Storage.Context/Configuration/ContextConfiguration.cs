using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace Tender.Storage.Context
{
    /// <summary>
    /// Configuration Singleton object
    /// </summary>
    public sealed class ContextConfiguration
    {
        /// Properties for singleton
        private static ContextConfiguration _configurationInstance = null;
        private static readonly object _lockObj = new object();

        /// Properties for class object
        public string ConnectionString { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        private ContextConfiguration()
        {
            this._getConnectionString();
        }

        /// <summary>
        /// Get Configuration Instance
        /// </summary>
        public static ContextConfiguration GetInstance
        {
            get {
                lock (_lockObj) {
                    if (_configurationInstance == null) {
                        _configurationInstance = new ContextConfiguration();
                    }
                    return _configurationInstance;
                }
            }
        }

        private void _getConnectionString()
        {
            // Create Builder
            var builder = new Microsoft.Extensions.Configuration.ConfigurationBuilder()
                //.SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables();
            var config = builder.Build();

            // Get Connection string from the build
            var connectionString = config.GetConnectionString("(default)");
        }
    }
}
