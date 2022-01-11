using System.Collections.Generic;
using UnityEngine;

namespace Platformer2D
{
    public class ShootEffectsFactory
    {
        private List<GameObject> _hitEffects;
        private List<GameObject> _bulletShells;

        public ShootEffectsFactory(GameData gameData, StarterGameData starterGameData)
        {
            _hitEffects = new List<GameObject>(starterGameData.HitEffectsCountInPool);
            _bulletShells = new List<GameObject>(starterGameData.BulletShellsCountInPool);

            var hitEffectsContainer = new GameObject("HitEffectsContainer").transform;
            var bulletShellsContainer = new GameObject("BulletShellsContainer").transform;

            hitEffectsContainer.parent = starterGameData.Pools;
            bulletShellsContainer.parent = starterGameData.Pools;


            for (int i = 0; i < starterGameData.HitEffectsCountInPool; i++)
            {
                var hitEffect = Object.Instantiate(gameData.PrefabsData.HitEffectprefab, hitEffectsContainer);
                hitEffect.SetActive(false);
                _hitEffects.Add(hitEffect);
            }

            for (int i = 0; i < starterGameData.BulletShellsCountInPool; i++)
            {
                var bulletShell = Object.Instantiate(gameData.PrefabsData.BulletShellPrefab, bulletShellsContainer);
                bulletShell.SetActive(false);
                _bulletShells.Add(bulletShell);
            }
        }

        public List<GameObject> GetHitEffects()
        {
            return _hitEffects;
        }

        public List<GameObject> GetBulletShells()
        {
            return _bulletShells;
        }
    }
}
