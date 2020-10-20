using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ExtraBT
{
    public class BehaviourTree : MonoBehaviour
    {
        [SerializeField] private BTNode root;
        [SerializeField] private GameObject body;

        public GameObject Body => body;
        private BTNode Root => root;
        private bool _isRunning = false;
        private Coroutine _behavior;

        public Dictionary<string, object> Blackboard { get; private set; } = new Dictionary<string, object>();

        private void Start()
        {
            Init();
            Run();
        }

        private void Init()
        {
            Blackboard = new Dictionary<string, object>
            {
                {"Bounds", new Rect(0, 0, 5, 5)}
            };

            _isRunning = false;

            // Root = new BTRepeater(this, new BTSequencer(this, new List<BTNode>
            // {
            //     new BTRandomWalk(this), 
            //     new BTWait(this, 1)
            // }));
        }

        public void Run()
        {
            if (_behavior != null)
                StopCoroutine(_behavior);

            _behavior = StartCoroutine(RunBehavior());
        }

        public void Stop()
        {
            if(_behavior != null)
                StopCoroutine(_behavior);

            _isRunning = false;
            _behavior = null;
        }

        private IEnumerator RunBehavior()
        {
            _isRunning = true;
            BTNode.Result result = Root.Execute();
            while (result == BTNode.Result.Running)
            {
                yield return null;
                result = Root.Execute();
            }

            Debug.Log($"Behaviour has finished with {result}");
        }
    }
}