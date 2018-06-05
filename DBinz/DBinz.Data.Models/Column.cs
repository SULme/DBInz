using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBinz.Data.Models
{
    public class Column
    {
        public string Name { get; set; }
        public SqlDbType Type { get; set; }
    }
}
