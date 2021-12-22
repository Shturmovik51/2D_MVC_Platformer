using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2D
{
    public class EnemiesController: IInitializable, ICleanable, IFixedUpdatable, IController
    {
        private List<EnemyView> _enemiesViews;
        private EnemiesSpawner _enemiesSpawner;

        public EnemiesController(EnemiesSpawner enemiesSpawner)
        {
            _enemiesViews = new List<EnemyView>();
            _enemiesSpawner = enemiesSpawner;
        }

        public void Initialization()
        {
            
        }

        public void CleanUp()
        {

        }

        public void LocalFixedUpdate(float fixedDeltatime)
        {
           
        }
    }
}
