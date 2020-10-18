using System.Collections.Generic;

namespace ExtraBT
{
    public class BTComposite : BTNode
    {
        protected List<BTNode> Children { get; private set; }
        
        public BTComposite(BehaviourTree tree, IEnumerable<BTNode> children) : base(tree)
        {
            Children = new List<BTNode>(children);
        }
    }
}