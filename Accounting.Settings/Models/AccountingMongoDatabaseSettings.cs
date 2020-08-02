using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.Settings.Models
{
    public class AccountingMongoDatabaseSettings : IAccountingDatabaseSettings
    {
        public string EmployeesCollectionName { get; set; }

        public string PositionsCollectionName { get; set; }

        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }
    }

    public interface IAccountingDatabaseSettings
    {
        string EmployeesCollectionName { get; set; }

        string PositionsCollectionName { set; get; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
