using System;
using TMPro;

namespace Platformer2D
{
    public class KillsMonitorController : IInitializable, ICleanable, IController
    {
        public event EventHandler<int> OnKillsCountChange;

        private EnemiesController _enemiesController;
        private int _killsToWin;
        private TextMeshProUGUI _killsToWinText;
        public KillsMonitorController(EnemiesController enemiesController, StarterGameData starterGameData, QuestsData questsData)
        {
            _enemiesController = enemiesController;
            _killsToWin = starterGameData.KillsToWin;
            _killsToWinText = questsData.KillsCountText;
        }

        public void Initialization()
        {
            _enemiesController.OnEnemyDeath += UpdateCount;
        }

        public void CleanUp()
        {
            _enemiesController.OnEnemyDeath -= UpdateCount;
        }

        public void UpdateCount(EnemyView view, IEnemyModel model)
        {
            _killsToWin--;
            _killsToWinText.text = _killsToWin.ToString();
            OnKillsCountChange?.Invoke(this, _killsToWin);
        }

    }
    
}
