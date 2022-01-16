using System.Collections.Generic;

namespace Platformer2D
{
    public class QuestModelsFactory
    {
        private List<IQuestModel> _questModels;
        public QuestModelsFactory()
        {
            _questModels = new List<IQuestModel>()
            {
                new QuestModelSaveZone(),
                new QuestModelKills(),
            };            
        }

        public List<IQuestModel> GetQuestModels()
        {
            return _questModels;
        }
    }
}
