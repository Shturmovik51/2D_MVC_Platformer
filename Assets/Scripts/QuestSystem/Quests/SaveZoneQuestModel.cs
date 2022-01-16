using UnityEngine;

namespace Platformer2D
{
    public class SaveZoneQuestModel : IQuestModel
    {
        private const string Tag = "Player";

        public bool TryComplete<T>(T parameter)
        {
            if (parameter is GameObject playerView)
            {
                return playerView.CompareTag(Tag);
            }
            else
            {
                throw new System.Exception("что-то пошло не так =)");
            }            
        }
    }
}