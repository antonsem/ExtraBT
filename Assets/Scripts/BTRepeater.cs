using UnityEngine;

namespace ExtraBT
{
    public class BTRepeater : BTDecorator
    {
        public override Result Execute()
        {
            Debug.Log($"Child returned {Child.Execute()}");
            return Result.Running;
        }
    }
}