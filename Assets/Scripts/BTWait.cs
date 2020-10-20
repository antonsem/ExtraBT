using UnityEngine;

namespace ExtraBT
{
    public class BTWait : BTNode
    {
        [SerializeField] private float waitTime = 0;
        private float _lastTime = 0;
        private bool _isRunning = false;
        
        public override Result Execute()
        {
            if (!_isRunning)
            {
                _lastTime = Time.time;
                _isRunning = true;
                return Result.Running;
            }
            
            if (Time.time - _lastTime < waitTime)
                return Result.Running;

            _lastTime = Time.time;
            _isRunning = false;
            return Result.Success;
        }
    }
}