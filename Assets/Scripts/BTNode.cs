using UnityEngine;

namespace ExtraBT
{
    public class BTNode : MonoBehaviour
    {
        public enum Result { Running, Success, Failure }

        [SerializeField] private BehaviourTree tree;
        
        protected BehaviourTree Tree => tree;

        public virtual Result Execute()
        {
            return Result.Failure;
        }
    }
}