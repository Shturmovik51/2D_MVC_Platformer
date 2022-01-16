using UnityEngine;

namespace Platformer2D
{
    public class QuestModelSaveZone : IQuestModel
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
                throw new System.Exception("���-�� ����� �� ��� =)");
            }            
        }
    }
}