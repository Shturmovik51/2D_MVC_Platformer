using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2D
{
    public class HitController : IInitializable, ICleanable, IController
    {
        private Dictionary<Collider2D, IDamagable> _hitObjects;
        private ShootController _shootController;

        public HitController(BarrelsInitialisator barrelsInitialisator, ShootController shootController)
        {
            _hitObjects = new Dictionary<Collider2D, IDamagable>();
            _shootController = shootController;

            foreach (var keyValueParams in barrelsInitialisator.GetBarrels())
                _hitObjects.Add(keyValueParams.Key, keyValueParams.Value);            
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
