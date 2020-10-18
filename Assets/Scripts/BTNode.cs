namespace ExtraBT
{
    public class BTNode
    {
        public enum Result { Running, Success, Failure }
        
        public BehaviourTree Tree { get; private set; }

        public BTNode(in BehaviourTree tree)
        {
            Tree = tree;
        }

        public virtual Result Execute()
        {
            return Result.Failure;
        }
    }
}