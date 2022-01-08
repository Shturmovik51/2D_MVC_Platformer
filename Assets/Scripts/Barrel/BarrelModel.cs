namespace Platformer2D
{
    public class BarrelModel
    {
        public Health _health { get; } 

        public BarrelModel(int health)
        {
            _health = new Health(health, health);
        }
    }
}
