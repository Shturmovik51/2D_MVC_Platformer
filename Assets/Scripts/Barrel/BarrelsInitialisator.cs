using System.Collections.Generic;
using UnityEngine;

namespace Platformer2D
{
    public class BarrelsInitialisator
    {
        private SpriteRenderer[] _barrelsObjects;
        private Dictionary<Collider2D, IDamagable> _barrels;
        private List<BarrelModel> _barrelModels;
        private List<BarrelView> _barrelViews;
        private int _barrelHealth = 5;

        public BarrelsInitialisator(SpriteRenderer[] barrelObjects)
        {
            _barrelsObjects = barrelObjects;
            _barrels = new Dictionary<Collider2D, IDamagable>(_barrelsObjects.Length);
            _barrelModels = new List<BarrelModel>(_barrelsObjects.Length);
            _barrelViews = new List<BarrelView>(_barrelsObjects.Length);

            for (int i = 0; i < _barrelsObjects.Length; i++)
            {
                var barrelModel = new BarrelModel(_barrelHealth);
                var collider = _barrelsObjects[i].GetComponent<Collider2D>();
                var rigidbody = _barrelsObjects[i].GetComponent<Rigidbody2D>();
                var transform = _barrelsObjects[i].transform;

                var barrelView = new BarrelView(collider, transform, rigidbody);

                _barrelModels.Add(barrelModel);
                _barrelViews.Add(barrelView);
            }

            var barrelsController = new BarrelsController(_barrelModels, _barrelViews);

            for (int i = 0; i < _barrelsObjects.Length; i++)
            {
                _barrels.Add(_barrelsObjects[i].GetComponent<Collider2D>(), barrelsController);
            }
        }

        public Dictionary<Collider2D, IDamagable> GetBarrels()
        {
            return _barrels;
        }
    }
}
