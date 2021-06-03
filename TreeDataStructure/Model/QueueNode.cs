using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeDataStructure.Model
{
    internal class QueueNode
    {
        internal TreeNode Data { get; set; }
        internal QueueNode Next { get; set; }

        public QueueNode(TreeNode data)
        {
            Data = data;
            Next = null;
        }
    }
}
