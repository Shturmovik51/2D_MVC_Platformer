using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2D
{
    public class BarrelsController : IDamagable
    {
        private List<BarrelModel> _barrelModels;
        private List<BarrelView> _barrelViews;

        public BarrelsController(List<BarrelModel> barrelModels, List<BarrelView> barrelViews)
        {
            _barrelModels = barrelModels;
            _barrelViews = barrelViews;
        }

        public void GetDamage(Collider2D collider, int value)
        {
            for (int i = 0; i < _barrelViews.Count; i++)
            {
                if (_barrelViews[i].Collider == collider)
                {
                    _barrelViews[i].Explosion();
                    Object.Destroy(_barrelViews[i].Collider.gameObject);
                }
            }
        }
    }
}
