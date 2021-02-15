using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorJob.Nodes
{
    public struct Node_InPalette
    {
        public string Name;
        public string Label;
        public Color Color;
        public string Icon;
        public string Category;
        public bool HaveInput;
        public int OutputCount;

    }

    public abstract class Node : INode
    {
        public abstract Node_InPalette Define { get; }

        protected FlowContext context;

        // public Node(FlowContext context)
        // {
        //     this.context = context;
        // }

        public string Name => this.GetType().Name;
        public string Category { get; set; }
        public List<string> Tags { get; set; }
        public Color Color { get; set; }
        //public Guid Id { get; set; }
        public string Icon { get; set; }
        public string Label { get; set; }
        public bool HaveInput { get; set; }
        public int OutputCount { get; set; }
        public NodeConfig Config { get; set; }

        protected void Done()
        {
            
            throw new NotImplementedException();
        }

        protected void Error(string msg)
        {
            this.Log(msg, LogLevel.Error);
        }

        protected void Log(string msg, LogLevel level)
        {
            this.context.logger.Log(level, msg);
        }

        public abstract void OnInput(NodeMessage msg);

        protected void Send(NodeMessage msg, int output = 1)
        {
            throw new NotImplementedException();
        }

        protected void StatusChange(string text, Color fill, string shape)
        {
            throw new NotImplementedException();
        }
    }
    
}

