using System.Collections.Generic;
using UnityEngine;

namespace Platformer2D
{
    public class HitController : IInitializable, ICleanable, IController
    {
        private Dictionary<Collider2D, IDamagableObjectController> _hitObjects;
        private ShootController _shootController;
        private ShootEffectsPoolController _shootEffectsPoolController;

        public HitController(ShootController shootController, ShootEffectsPoolController shootEffectsPoolController)
        {
            _hitObjects = new Dictionary<Collider2D, IDamagableObjectController>();
            _shootController = shootController;
            _shootEffectsPoolController = shootEffectsPoolController;
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

        private void CheckHitedObject(RaycastHit2D hit, int value, Transform shootDirection)
        {
            var collider = hit.collider;

            if (_hitObjects.ContainsKey(collider))
            {
                _hitObjects[collider].GetDamage(collider, value);

                if(collider.TryGetComponent(out EnemyView enemy))
                {
                    var effect = _shootEffectsPoolController.ProvideHitEffect();

                    effect.transform.position = hit.point;                    
                    effect.transform.up = shootDirection.transform.right;

                    effect.SetActive(true);
                }
            }
        }
    }
}
