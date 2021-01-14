using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Collections.ObjectModel;

namespace CoronaApp
{
    class OldDataRepository
    {
        public string KommuneID { get; set; }
        public string AntalTestede { get; set; }
        public string AntalBekræftedeCOVID19 { get; set; }
        public string Befolkningstal { get; set; }
        public string KumulativIncidens { get; set; }
        public string Dato { get; set; }
    }
}
