using UnityEngine;

namespace ExtraBT
{
    public class BTRepeater : BTDecorator
    {
        public BTRepeater(BehaviourTree tree, BTNode child) : base(tree, child)
        {
        }

        public override Result Execute()
        {
            Debug.Log($"Child returned {Child.Execute()}");
            return Result.Running;
        }
    }
}