using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ExtraBT
{
    public class BehaviourTree : MonoBehaviour
    {
        private BTNode _root;
        public BTNode Root { get; private set; }
        private bool _isRunning = false;
        private Coroutine _behavior;

        public Dictionary<string, object> Blackboard { get; set; } = new Dictionary<string, object>();

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

            Root = new BTRepeater(this, new BTSequencer(this, new[]
            {
                new BTRandomWalk(this)
            }));
        }

        public void Run()
        {
            if (_behavior != null)
                StopCoroutine(_behavior);

            _behavior = StartCoroutine(RunBehavior());
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