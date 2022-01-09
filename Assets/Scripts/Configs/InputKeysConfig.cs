using UnityEngine;

namespace Platformer2D
{
    [CreateAssetMenu(menuName = "Configs/InputKeysConfig", fileName = nameof(InputKeysConfig))]
    public sealed class InputKeysConfig : ScriptableObject
    {
        [SerializeField] private KeyCode _shoot;
        [SerializeField] private KeyCode _aim;
        [SerializeField] private KeyCode _save;
        [SerializeField] private KeyCode _load;
        [SerializeField] private KeyCode _jump;
        [SerializeField] private KeyCode _down;
 
        public KeyCode Shoot => _shoot;
        public KeyCode Aim => _aim;
        public KeyCode Save => _save;
        public KeyCode Load => _load;
        public KeyCode Jump => _jump;
        public KeyCode Down => _down;
    }
}