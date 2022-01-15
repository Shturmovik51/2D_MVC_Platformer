using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2D
{
    public class ShootEffectsPoolController
    {
        private List<GameObject> _hitEffects;
        private List<GameObject> _bulletShells;
        private GameStarter _gameStarter;
        private float _bulletShellLifeTime;
        private float _hitEffectLifeTime;

        public ShootEffectsPoolController(GameData gameData, StarterGameData starterGameData, GameStarter gameStarter)
        {
            var shootEffectsFactory = new ShootEffectsFactory(gameData, starterGameData);            

            _gameStarter = gameStarter;
            _hitEffects = shootEffectsFactory.GetHitEffects();
            _bulletShells = shootEffectsFactory.GetBulletShells();
            _bulletShellLifeTime = starterGameData.BulletShellLifeTime;
            _hitEffectLifeTime = starterGameData.HitEffectLifeTime;
        }

        public GameObject ProvideHitEffect()
        {
            var hitEffect = _hitEffects[0];
            _hitEffects.Remove(hitEffect);
            _gameStarter.StartCoroutine(EffectLifeTime(_hitEffectLifeTime, hitEffect, _hitEffects));

            return hitEffect;
        }

        public GameObject ProvideBulletShell()
        {
            var bulletShell = _bulletShells[0];
            _bulletShells.Remove(bulletShell);
            _gameStarter.StartCoroutine(EffectLifeTime(_bulletShellLifeTime, bulletShell, _bulletShells));

            return bulletShell;
        }

        private IEnumerator EffectLifeTime(float time, GameObject effect, List<GameObject> effectPool)
        {
            yield return new WaitForSeconds(time);
            effect.SetActive(false);
            effectPool.Add(effect);
            yield break;
        }


    }
}
