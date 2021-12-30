using UnityEngine;

namespace Platformer2D
{
    public class EnemyModel : IEnemyModel
    {
        public Health ZombieHealth { get; }
        public float MoveSpeed { get; }
        public Transform LeftPatrolBorder { get; private set; }
        public Transform RightPatrolBorder { get; private set; }
        public bool IsOnChasing { get; private set; }

        public EnemyModel(GameData gameData)
        {
            ZombieHealth = new Health(gameData.EnemyConfig.EnemyMaxHealth, gameData.EnemyConfig.EnemyMaxHealth);
            MoveSpeed = Random.Range(40f, 50f);
        }

        public void SetPatrolZone(Transform left, Transform right)
        {
            LeftPatrolBorder = left;
            RightPatrolBorder = right;
        }

        public void SetChasingStatus(bool chasingStatus)
        {
            IsOnChasing = chasingStatus;
        }
    }
}
