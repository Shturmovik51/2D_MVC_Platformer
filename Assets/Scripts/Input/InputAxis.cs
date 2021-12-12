using UnityEngine;

namespace Platformer2D
{
    public sealed class InputAxis
    {
        public float GetHorisontalAxis()
        {
           return Input.GetAxis(AxisManager.Horizontal);
        }

        public float GetVerticalAxis()
        {
            return Input.GetAxis(AxisManager.Horizontal);
        }
    }
}