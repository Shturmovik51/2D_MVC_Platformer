using System;
using System.Collections.Generic;

namespace Platformer2D
{
    public class QuestController : IQuest, IInitializable, IController
    {
        public event EventHandler<IQuest> Completed;

        public bool IsCompleted { get; private set; }

        private List<IQuestModel> _questModels;


        private QuestObjectView _saveZoneQuestView;
        private KillsQuestView _killsQuestView;
        private bool _active;
        private QuestsData _questsData;
        private KillsMonitorController _killsMonitorController;

        public QuestController(QuestsData questsData, QuestModelsFactory questModelsFactory, StarterGameData starterGameData, 
                                    KillsMonitorController killsMonitorController)
        {
            _saveZoneQuestView = questsData.QuestObjectView;
            _questsData = questsData;
            _questModels = questModelsFactory.GetQuestModels();
            _killsQuestView = new KillsQuestView(starterGameData);
            _killsMonitorController = killsMonitorController;
        }

        public void Initialization()
        {
            _killsMonitorController.OnKillsCountChange += OnKill;

            Reset();
        }

        private void OnKill(object sender, int count)
        {
            var killsQuestModel = _questModels.Find(model => model is KillsQuestModel);
            bool complete = killsQuestModel.TryComplete(count);

            if (complete)
            {
                _killsQuestView.ProcessComplete(_questsData);
            }
        }

        private void OnContact(PlayerView arg)
        {
            var SaveZoneQuestModel = _questModels.Find(model => model is SaveZoneQuestModel);
            bool complete = SaveZoneQuestModel.TryComplete(arg.gameObject);

            if (complete)
            {
                _saveZoneQuestView.ProcessComplete(_questsData);
            }


            //foreach (var model in _questModels)
            //{
            //    bool complete = model.TryComplete(arg.gameObject);

            //    if (complete)
            //    {
            //        Complete();
            //    }
            //}
        }

        private void OnCompleted()
        {
            Completed?.Invoke(this, this);
        }

        private void Complete()
        {
            if (!_active)
            {
                return;
            }

            _active = false;
            _saveZoneQuestView.OnLevelObjectContact -= OnContact;
            _saveZoneQuestView.ProcessComplete(_questsData);
            OnCompleted();
        }

        public void Reset()
        {
            if (_active)
            {
                return;
            }

            _active = true;
            _saveZoneQuestView.OnLevelObjectContact += OnContact;
            _saveZoneQuestView.ProcessActivate(_questsData);

            _killsQuestView.ProcessActivate(_questsData);
        }

        public void Dispose()
        {
            _saveZoneQuestView.OnLevelObjectContact -= OnContact;
        }
    }
}
