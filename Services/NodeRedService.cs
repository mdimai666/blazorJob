using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorJob.Models;
using BlazorJob.Nodes;
using BlazorJob.Nodes.Palette;

namespace BlazorJob.Services
{
    public class NodeRedService
    {

        public List<Node_InPalette> nodes = new List<Node_InPalette>();

        public NodeRedService(IServiceProvider serviceProvider)
        {

            IEnumerable<Node> exporters = typeof(Node)
                .Assembly.GetTypes()
                .Where(t => t.IsSubclassOf(typeof(Node)) && !t.IsAbstract)
                .Select(t => (Node)Activator.CreateInstance(t));

            nodes = exporters.Select(s=>s.Define).ToList();

            // nodes.Add(new ConsoleWrite().Define);
            // nodes.Add(new ConcatString().Define);
        }

        public List<Node_InPalette> PaletteList()
        {
            return this.nodes;
        }
    }
}
