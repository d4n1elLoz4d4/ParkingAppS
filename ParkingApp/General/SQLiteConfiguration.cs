﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common;
using System.Data.Entity;
using System.Data.SQLite.EF6;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingApp.General
{
    public class SQLiteConfiguration : DbConfiguration
    {
        public SQLiteConfiguration()
        {
            SetProviderFactory("System.Data.SQLite", SQLiteFactory.Instance);
            SetProviderFactory("System.Data.SQLite.EF6", SQLiteProviderFactory.Instance);
            SetProviderServices("System.Data.SQLite", (DbProviderServices)SQLiteProviderFactory.Instance.GetService(typeof(DbProviderServices)));
        }
    }
}
