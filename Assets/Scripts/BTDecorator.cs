using UnityEngine;

namespace ExtraBT
{
    public class BTDecorator : BTNode
    {
        [SerializeField] private BTNode child;

        protected BTNode Child => child;
    }
}