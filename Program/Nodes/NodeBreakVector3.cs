﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KSPFlightPlanner.Program.Connectors;
namespace KSPFlightPlanner.Program.Nodes
{
    [Serializable]
    public class NodeBreakVector3 : Node
    {
        public new static string Name = "Break Vector3";
        public new static string Description = "Returns the float components of a Vector3";
        public new static SVector3 Color = new SVector3(0.2f, 1f, 1f);
        public new static SVector2 Size = new SVector2(190, 150);
        protected override void OnCreate()
        {
            AddConnectorIn("Vector3", new Vector3ConnectorIn());
            AddConnectorOut("X", new FloatConnectorOut());
            AddConnectorOut("Y", new FloatConnectorOut());
            AddConnectorOut("Z", new FloatConnectorOut());
        }
        protected override void OnUpdateOutputData()
        {
            var v = GetConnectorIn("Vector3").GetBufferAsVector3();
            var x = GetConnectorOut("X");
            if(x != null)
                x.SendData(v.x);
            var y = GetConnectorOut("Y");
            if(y != null)
                y.SendData(v.y);
            var z = GetConnectorOut("Z");
            if(z != null)
                z.SendData(v.z);
         
        }
    }
}
