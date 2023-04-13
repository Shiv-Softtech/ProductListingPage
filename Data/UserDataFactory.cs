using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Web;

namespace ProductListingPage.Data
{
    public class UserDataFactory : IUserDataFactory
    {
        // static MappingSource _mappingSource = new AttributeMappingSource();
        static MappingSource _sharedMappingSource = new AttributeMappingSource();
        string _connectionString;
        public UserDataContext GetUserDataContext()
        {
                _connectionString = ConfigurationManager.ConnectionStrings["velaDBConnectionString"].ConnectionString;
                return new UserDataContext(_connectionString, _sharedMappingSource);
            
        }
    }
}