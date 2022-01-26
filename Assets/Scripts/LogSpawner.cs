using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2D
{
    public class LogSpawner : MonoBehaviour, IUpdatable, IController, IInitializable
    {
        [SerializeField] private Transform _startPoint;
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private Transform _triggerPoint;
        [SerializeField] private GameObject _logPrototype;
        [SerializeField] private List<GameObject> _logs;
        private Transform _currentLogTransform;
        private int _logsCounter;

        public void Initialization()
        {
            _logsCounter = 0;
            var log = Object.Instantiate(_logPrototype, _startPoint.position, _logPrototype.transform.rotation);
            _currentLogTransform = log.transform;
            _logs.Add(log);
            _logsCounter++;
        }

        public void LocalUpdate(float deltaTime)
        {
            if(_currentLogTransform.position.x > _triggerPoint.position.x)
            {
                var log = Object.Instantiate(_logPrototype, _spawnPoint.position, _logPrototype.transform.rotation);
                _currentLogTransform = log.transform;
                _logs.Add(log);
                _logsCounter++;

                if(_logsCounter == 4)
                {
                    var logToDelete = _logs[0];
                    _logs.Remove(logToDelete);
                    Object.Destroy(logToDelete);
                    _logsCounter--;
                }
            } 
        }
    }
}