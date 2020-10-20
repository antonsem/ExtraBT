using System.Collections.Generic;
using UnityEngine;

namespace ExtraBT
{
    public class BTComposite : BTNode
    {
        [SerializeField] private List<BTNode> children = new List<BTNode>();
        protected List<BTNode> Children => children;
    }
}