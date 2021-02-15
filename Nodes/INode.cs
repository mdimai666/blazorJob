using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorJob.Nodes
{

    public enum ENodeState : int
    {
        Idle = 0,
        Run,
        Error
    }

    public interface INode
    {
        // HEADER
        //-------------------------
        string Name { get; }
        string Category { get; }
        List<string> Tags { get; }
        Color Color { get; }
        string Icon { get; }
        string Label { get; }

        // Config
        //-------------------------
        //bool Enabled { get; set; }
        bool HaveInput { get; set; }
        int OutputCount { get; set; }

        // Methods
        //-------------------------
        abstract void OnInput(NodeMessage msg);
        //protected void StatusChange(string text, Color fill, string shape);
        //protected void Send(NodeMessage msg, int output = 1);
        //protected void Done();
        //protected void Log(string msg, LogLevel level);
        //protected void Error(string msg);

        //List<object> Outputs { get; set; }
        NodeConfig Config { get; set; }

        //Designer


    }

    public interface INodeRuntime : INode
    {
        Guid Id { get; set; }
        ENodeState State { get; set; }
        bool DirtyChanges { get; set; }

    }

    public interface INodeEditable
    {

        void OnEditPrepare();
        void OnEditSave();
        void OnEditCancel();
        void OnEditDelete();
        void OnEditResize();
        void OnPaletteAdd();
        void OnPaletteRemove();

    }

    public abstract class NodeConfig
    {
        public abstract class Input
        {
            public string name;
            public string label;
            public string value;
        };

        public List<Input> Inputs;
    }

    public abstract class NodeMessage
    {
        public Guid MsgId;
        public object Payload;
        public DateTime Date;
        public string Topic;
    }

    public class FlowContext
    {
        object FlowData;
        object Nodes;
        public ILogger logger;
    }

    public class NodeMetric
    {
        int runCount;
        object lastInput;
        object lastOutput;
        DateTime lastRunDate;
    }

    // public class NodeRedService
    // {
    //     public List<NodeRedFlow> Flows;
    //     //public List<NodeRedFlow> SubFlows;
    //     public object GlobalContext;
    //     public List<object> Palette;
    //     public List<object> configNodes;

    //     public void Start() { }
    //     public void Stop() { }
    //     public void Update() { }
    // }

    public class NodeRedFlow
    {
        public List<Node> Nodes;
        public FlowContext Context;

        public bool Enabled;
        public string Name;
        public string Description;

        public void Start() { }
        public void Stop() { }
        public void Update() { }
    }
}

