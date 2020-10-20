using System.Collections.Generic;

namespace ExtraBT
{
    public class BTSelector : BTComposite
    {
        private int _currentNode = 0;

        public override Result Execute()
        {
            if (_currentNode >= Children.Count)
                return Result.Success;
           
            switch (Children[_currentNode].Execute())
            {
                case Result.Running:
                    return Result.Running;
                case Result.Failure:
                    if (++_currentNode < Children.Count)
                        return Result.Running;
                    _currentNode = 0;
                    return Result.Failure;
                default:
                    _currentNode = 0;
                    return Result.Success;
            }
        }
    }
}