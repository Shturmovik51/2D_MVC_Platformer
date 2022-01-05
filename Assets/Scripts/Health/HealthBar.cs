using UnityEngine;
using UnityEngine.UI;

namespace Platformer2D
{
    public class HealthBar
    {
        public Image BarImage { get; }
        public Transform HealhBarObject { get; }

        public HealthBar(Transform healhBarObject, Image barImage)
        {
            BarImage = barImage;
            HealhBarObject = healhBarObject;
        }        
    }
}
