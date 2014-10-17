﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KSPFlightPlanner.Program.Nodes;
namespace KSPFlightPlanner.Program.Connectors
{
    [Serializable]
    public abstract class ConnectorIn : Connector
    {
        internal bool FreshData { get; set; }
        private Object buffer;
        public ConnectorIn(Type dataType, bool allowMultipleConnections = false)
            : base(dataType, allowMultipleConnections)
        {

        }
        public void RequestData()
        {
            //Should always be one !
            //never called on execution nodes
            foreach (var i in connections)
            {
                if (!(i.Node is ExecutableNode || i.Node is RootNode))
                    i.Node.UpdateOutputData();
            }
        }
        public void SetData(Object data)
        {
            buffer = data;
            FreshData = true;
        }
        public string GetBufferAsString()
        {
            if (buffer == null)
                return "";
            return buffer.ToString();
        }
        public double GetBufferAsDouble()
        {
            if (buffer is double)
                return (double)buffer;
            double val;
            if (double.TryParse(buffer as string, out val))
                return val;
            float valf;
            if (float.TryParse(buffer as string, out valf))
                return (double)valf;
            return 0.0;
        }
        public float GetBufferAsFloat()
        {
            if (buffer is float)
                return (float)buffer;
            float val;
            if (float.TryParse(buffer as string, out val))
                return val;
            double vald;
            if (double.TryParse(buffer as string, out vald))
                return (float)vald;
            return 0.0f;
        }
        public bool GetBufferAsBool()
        {
            if (buffer is bool)
                return (bool)buffer;
            bool val;
            if (bool.TryParse(buffer as string, out val))
                return val;
            return false;
        }
        public SVector3 GetBufferAsVector3()
        {
            if (buffer is SVector3)
                return (SVector3)buffer;
            return new SVector3();
        }
        public SQuaternion GetBufferAsQuaternion()
        {
            if (buffer is SQuaternion)
                return (SQuaternion)buffer;
            return new SQuaternion();
        }
    }
}