using System;

namespace Platformer2D
{
    public class QuestController : IQuest
    {
        public event EventHandler<IQuest> Completed;

        public bool IsCompleted { get; private set; }


        private QuestObjectView _view;
        private bool _active;
        private IQuestModel _model;
        private QuestsData _questsData;

        public QuestController(QuestsData questsData, IQuestModel model)
        {
            _view = questsData.QuestObjectView;
            _model = model;
            _questsData = questsData;
        }

        private void OnContact(PlayerView arg)
        {
            bool complete = _model.TryComplete(arg.gameObject);

            if (complete)
            {
                Complete();
            }
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
            _view.OnLevelObjectContact -= OnContact;
            _view.ProcessComplete();
            OnCompleted();
        }

        public void Reset()
        {
            if (_active)
            {
                return;
            }

            _active = true;
            _view.OnLevelObjectContact += OnContact;
            _view.ProcessActivate(_questsData);
        }

        public void Dispose()
        {
            _view.OnLevelObjectContact -= OnContact;
        }
    }
}
