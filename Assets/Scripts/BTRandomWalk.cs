using UnityEngine;

namespace ExtraBT
{
    public class BTRandomWalk : BTNode
    {
        protected Vector3 NextDestination { get; set; }
        public float Speed { get; set; } = 1;

        public BTRandomWalk(in BehaviourTree tree) : base(in tree)
        {
            NextDestination = Vector3.zero;
            FindNextDestination();
        }

        private bool FindNextDestination()
        {
            if (!Tree.Blackboard.TryGetValue("Bounds", out object r))
                return false;

            Rect rect = (Rect) r;
            float x = (Random.value - 0.5f) * 2 * rect.width;
            float y = (Random.value - 0.5f) * 2 * rect.height;
            NextDestination = new Vector3(x, y, 0);

            return true;
        }

        public override Result Execute()
        {
            if (Tree.gameObject.transform.position == NextDestination)
                return FindNextDestination() ? Result.Success : Result.Failure;

            Tree.gameObject.transform.position =
                Vector3.MoveTowards(Tree.gameObject.transform.position, NextDestination, Time.deltaTime * Speed);

            return Result.Running;
        }
    }
}