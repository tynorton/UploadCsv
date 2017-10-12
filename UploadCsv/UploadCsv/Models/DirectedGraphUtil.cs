using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UploadCsv.Models
{
    public class DirectedGraphUtil
    {
        public static bool DirectedGraphHasCycle(string csvContent)
        {
            DirectedGraph graph = new DirectedGraph();

            string[] lines = csvContent.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in lines)
            {
                if (line.IndexOf("Parent", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    continue;
                }
                string[] elements = line.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                if (elements.Length == 3)
                {
                    graph.AddEdge(elements[0], elements[1]);
                }
            }

            bool b = graph.IsCyclic();
            return b;
        }
    }
}