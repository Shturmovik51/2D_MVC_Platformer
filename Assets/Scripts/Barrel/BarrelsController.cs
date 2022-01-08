using System.Collections.Generic;
using UnityEngine;

namespace Platformer2D
{
    public class BarrelsController : IDamagableObjectController
    {
        private List<BarrelModel> _barrelModels;
        private List<BarrelView> _barrelViews;

        public BarrelsController(BarrelsInitialisator barrelsInitialisator)
        {
            _barrelModels = barrelsInitialisator.GetBarrels().models;
            _barrelViews = barrelsInitialisator.GetBarrels().views;
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
