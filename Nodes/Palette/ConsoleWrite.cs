using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorJob.Nodes.Palette
{
    public class ConsoleWrite : Node
    {

        public ConsoleWrite() //: base(context)
        {
            this.Category = "System";
            this.Color = Color.Red;
            //this.Config = new Object();
            this.HaveInput = true;
            this.OutputCount = 0;
            this.Tags = new List<string> { "Console" };
            this.Icon = "Console";
        }

        public override Node_InPalette Define => new Node_InPalette
        {
            Name = "Console",
            Category = "System",
            Color = Color.Red,
            Icon = "bug",
            HaveInput = true,
            Label = "Console.WritreLine",
            OutputCount = 0
        };

        public override void OnInput(NodeMessage msg)
        {
            Console.WriteLine("OK", msg.Payload.ToString());

            Done();
        }

    }

    public class ConcatString : Node
    {
        public ConcatString()// : base(context)
        {
        }

        public override Node_InPalette Define => new Node_InPalette
        {
            Name = "ConcatString",
            Category = "String",
            Color = Color.Red,
            Icon = "text",
            HaveInput = true,
            Label = "ConcatString",
            OutputCount = 1
        };

        public override void OnInput(NodeMessage msg)
        {
            msg.Payload = "Concat";

            Send(msg);
            Done();
        }
    }
}
