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
                new SaveZoneQuestModel(),
                new KillsQuestModel(),
            };            
        }

        public List<IQuestModel> GetQuestModels()
        {
            return _questModels;
        }
    }
}
