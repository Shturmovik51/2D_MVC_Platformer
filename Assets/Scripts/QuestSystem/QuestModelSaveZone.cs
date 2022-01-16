using UnityEngine;

namespace Platformer2D
{
    public class QuestModelSaveZone : IQuestModel
    {
        private const string Tag = "Player";

        public bool TryComplete(GameObject thisGameObject)
        {
            return thisGameObject.CompareTag(Tag);
        }
    }
}