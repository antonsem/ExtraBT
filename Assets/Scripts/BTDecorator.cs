namespace ExtraBT
{
    public class BTDecorator : BTNode
    {
        public BTNode Child { get; private set; }
        public BTDecorator(BehaviourTree tree, BTNode child) : base(tree)
        {
            Child = child;
        }
    }
}