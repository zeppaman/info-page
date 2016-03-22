﻿using InfoPage.Classes;
using InfoPage.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoPage.Model
{
    public class InfoPageModel
    {
        public string ChangeLogs { get; set; }
        public string License { get; set; }
        public string Info { get; set; }
        public AssemblyMetadata MainAssembly { get; set; }
        public List<AssemblyMetadata> LoadedAssemblies { get; set; }
        public InfoPageConfiguration Conf { get; set; }
    }
}

