﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyDotnetCoreWebApp.DataTables
{
    public class DataTablesRequest
    {
        public int Draw { get; set; }

        public IEnumerable<Column> Columns { get; set; }

        public IEnumerable<Order> Order { get; set; }

        public int Start { get; set; }

        public int Length { get; set; }

        public Search Search { get; set; }
    }
}
