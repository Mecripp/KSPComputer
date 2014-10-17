﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KSPFlightPlanner.Program.Connectors;
namespace KSPFlightPlanner.Program.Nodes
{
    [Serializable]
    public class NodeMakeVector3 : Node
    {
        public new static string Name = "Make Vector3";
        public new static string Description = "Creates a Vector3 from three floats";
        public new static SVector3 Color = new SVector3(0.2f, 1f, 1f);
        public new static SVector2 Size = new SVector2(190, 200);
        protected override void OnCreate()
        {
            AddConnectorOut("Vector3", new Vector3ConnectorOut());
            AddConnectorIn("X", new FloatConnectorIn());
            AddConnectorIn("Y", new FloatConnectorIn());
            AddConnectorIn("Z", new FloatConnectorIn());
        }
        protected override void OnUpdateOutputData()
        {
            var v = GetConnectorOut("Vector3");
            if (v != null)
            {
                var x = GetConnectorIn("X").GetBufferAsFloat();
                var y = GetConnectorIn("Y").GetBufferAsFloat();
                var z = GetConnectorIn("Z").GetBufferAsFloat();
                v.SendData(new SVector3(x,y,z));
            }
        }
    }
}