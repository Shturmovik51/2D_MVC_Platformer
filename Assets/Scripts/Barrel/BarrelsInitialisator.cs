using System.Collections.Generic;
using UnityEngine;

namespace Platformer2D
{
    public class BarrelsInitialisator
    {
        private SpriteRenderer[] _barrelsObjects;
        private List<BarrelModel> _barrelModels;
        private List<BarrelView> _barrelViews;
        private int _barrelHealth = 5;

        public BarrelsInitialisator(StarterGameData starterGameData, HitController hitController)
        {
            _barrelsObjects = starterGameData.BarrelsContainer.GetComponentsInChildren<SpriteRenderer>();
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
            
            
        }

        public (List<BarrelModel> models, List<BarrelView> views) GetBarrels()
        {
            return (_barrelModels, _barrelViews);
        }
    }
}
