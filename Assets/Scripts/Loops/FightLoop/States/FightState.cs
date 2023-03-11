using System.Collections.Generic;
using Data.Enemies;
using StateManagement;

namespace Loops.FightLoop.States
{
    public class FightState : StateBase<FightData>
    {
        private StateMachine<FightData> _stateMachine;

        public override void Enter(StateMachine<FightData> sm)
        {
            _stateMachine = sm;
            Queue<EnemyWave> wavesQueue = sm.Data.WavesQueue;
            EnemyWave enemyWave = wavesQueue.Peek();
            sm.Data.EnemyController.StartWave(enemyWave);
            sm.Data.EnemyController.OnWaveEnded += OnWaveEnded;
        }

        private void OnWaveEnded(EnemyWave obj)
        {
            _stateMachine.ChangeState(new SetupState());


            _stateMachine.Data.EnemyController.OnWaveEnded -= OnWaveEnded;
        }
    }
}