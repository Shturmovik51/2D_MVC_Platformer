using UnityEngine;

namespace Platformer2D
{
    public class QuestModelKills : IQuestModel
    {
        public bool TryComplete<T>(T parameter)
        {
            if(parameter is int killsCount)
            {                
                return killsCount == 0;
            }
            else
            {
                throw new System.Exception("что-то пошло не так =)");
            }
        }
    }
}
