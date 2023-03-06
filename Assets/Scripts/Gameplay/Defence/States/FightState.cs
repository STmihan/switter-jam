using System.Collections.Generic;
using Gameplay.Defence.Enemies;
using StateManagement;

namespace Gameplay.Defence.States
{
    public class FightState : StateBase<DefenceData>
    {
        private StateMachine<DefenceData> _stateMachine;

        public override void Enter(StateMachine<DefenceData> sm)
        {
            _stateMachine = sm;
            Queue<EnemyWave> wavesQueue = sm.Data.WavesQueue;
            EnemyWave enemyWave = wavesQueue.Dequeue();
            sm.Data.FightController.StartWave(enemyWave);
            sm.Data.FightController.OnWaveEnded += OnWaveEnded;
        }

        private void OnWaveEnded(EnemyWave obj)
        {
            if (_stateMachine.Data.WavesQueue.Count > 0)
            {
                _stateMachine.ChangeState(new SetupState());
            }
            else
            {
                _stateMachine.ChangeState(new EndState());
            }

            _stateMachine.Data.FightController.OnWaveEnded -= OnWaveEnded;
        }
    }
}