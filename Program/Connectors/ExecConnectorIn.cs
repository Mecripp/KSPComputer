﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KSPFlightPlanner.Program.Connectors
{
    [Serializable]
    public class ExecConnectorIn : ConnectorIn
    {
        public ExecConnectorIn()
            : base(null, false)
        {
        }
    }
}