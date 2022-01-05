namespace Platformer2D
{
    public class Health
    {
        public int MaxHP { get; private set; }
        public int HP { get; private set; }

        public Health(int maxHP, int currentHP)
        {
            HP = currentHP;
            MaxHP = maxHP;
        }

        public void TakeDamage(int damage)
        {
            HP -= damage;

            if (HP <= 0)
                HP = 0;
        }

        public void ResetHealth()
        {
            HP = MaxHP;
        }

        public float GetFillAmountValue()
        {
            return (float) HP / MaxHP;
        }
    }
}