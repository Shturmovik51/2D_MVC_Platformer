using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2D
{
    public class HitableObjectsInitialisator
    {
        private HitController _hitController;

        public HitableObjectsInitialisator(BarrelsInitialisator barrelsInitialisator, BarrelsController barrelsController,
                                            EnemiesInitialisator enemiesInitialisator, EnemiesController enemiesController,
                                                HitController hitController)
        {
            _hitController = hitController;

            var barrelsObjects = barrelsInitialisator.GetBarrels().views;
            var enemiesViews = enemiesInitialisator.GetEnemies().views;

            for (int i = 0; i < barrelsObjects.Count; i++)
            {
                var view = barrelsObjects[i] as IHitable;
                hitController.AddHitableObject(view.Collider, barrelsController);
            }

            for (int i = 0; i < enemiesViews.Count; i++)
            {
                var view = enemiesViews[i] as IHitable;
                hitController.AddHitableObject(view.Collider, enemiesController);
            }
        }
    }

}
