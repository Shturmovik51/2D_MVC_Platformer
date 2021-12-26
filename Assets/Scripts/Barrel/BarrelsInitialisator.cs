using System.Collections.Generic;
using UnityEngine;

namespace Platformer2D
{
    public class BarrelsInitialisator
    {
        private GameObject[] _barrelsObjects;
        private Dictionary<Collider2D, IDamagable> _barrels;
        private List<BarrelModel> _barrelModels;
        private List<BarrelView> _barrelViews;

        public BarrelsInitialisator(GameObject[] barrels)
        {
            _barrelsObjects = barrels;
            _barrels = new Dictionary<Collider2D, IDamagable>(_barrelsObjects.Length);
            _barrelModels = new List<BarrelModel>(_barrelsObjects.Length);
            _barrelViews = new List<BarrelView>(_barrelsObjects.Length);

            for (int i = 0; i < _barrelsObjects.Length; i++)
            {
                var barrelModel = new BarrelModel();
                var barrelView = new BarrelView();

                _barrelModels.Add(barrelModel);
                _barrelViews.Add(barrelView);
            }

            var barrelsController = new BarrelsController(/*_barrelModels, _barrelViews*/);

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
