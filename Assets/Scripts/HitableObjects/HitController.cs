using System.Collections.Generic;
using UnityEngine;

namespace Platformer2D
{
    public class HitController : IInitializable, ICleanable, IController
    {
        private Dictionary<Collider2D, IDamagableObjectController> _hitObjects;
        private ShootController _shootController;

        public HitController(ShootController shootController)
        {
            _hitObjects = new Dictionary<Collider2D, IDamagableObjectController>();
            _shootController = shootController;         
        }

        public void AddHitableObject(Collider2D collider, IDamagableObjectController objectController)
        {
            _hitObjects.Add(collider, objectController);
        }
            
        
        public void Initialization()
        {
            _shootController.OnHitSomeThing += CheckHitedObject;
        }
        
        public void CleanUp()
        {
            _shootController.OnHitSomeThing -= CheckHitedObject;
        }

        private void CheckHitedObject(Collider2D collider, int value)
        {
            if (_hitObjects.ContainsKey(collider))
                _hitObjects[collider].GetDamage(collider, value);
        }
    }
}
