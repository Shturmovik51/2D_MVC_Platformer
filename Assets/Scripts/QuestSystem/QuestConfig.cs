using UnityEngine;

namespace Platformer2D
{

    [CreateAssetMenu(fileName = "QuestCfg", menuName = "Configs / Quest Cfg", order = 1)]
    public class QuestConfig : ScriptableObject
    {
        public int id;
        public QuestType questType;
    }

    public enum QuestType
    {
        SaveZones
    }
}
