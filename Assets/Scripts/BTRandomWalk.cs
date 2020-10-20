using UnityEngine;
using Random = UnityEngine.Random;

namespace ExtraBT
{
    public class BTRandomWalk : BTNode
    {
        [SerializeField] private float speed = 1;
        private float Speed => speed;
        private Vector3 NextDestination { get; set; }

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

            Tree.Body.gameObject.transform.position =
                Vector3.MoveTowards(Tree.gameObject.transform.position, NextDestination, Time.deltaTime * Speed);

            return Result.Running;
        }
    }
}