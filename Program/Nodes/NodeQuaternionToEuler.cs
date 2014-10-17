﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using KSPFlightPlanner.Program.Connectors;
namespace KSPFlightPlanner.Program.Nodes
{
    [Serializable]
    public class NodeQuaternionToEuler : Node
    {
        public new static string Name = "Quaternion to euler";
        public new static string Description = "Returns the euler-angles for a quaternion";
        public new static SVector3 Color = new SVector3(0.2f, 1f, 1f);
        public new static SVector2 Size = new SVector2(190, 200);
        protected override void OnCreate()
        {
            AddConnectorIn("Quaternion", new QuaternionConnectorIn());
            AddConnectorOut("X", new FloatConnectorOut());
            AddConnectorOut("Y", new FloatConnectorOut());
            AddConnectorOut("Z", new FloatConnectorOut());
            
        }
        protected override void OnUpdateOutputData()
        {
            var v = GetConnectorIn("Quaternion").GetBufferAsQuaternion().GetQuaternion().eulerAngles;
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