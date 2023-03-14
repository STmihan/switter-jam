using System.Collections.Generic;
using Data.Enemies;
using Data.Enemies.Waves;
using StateManagement;

namespace Loops.FightLoop.States
{
    public class FightState : StateBase<FightData>
    {
        private StateMachine<FightData> _stateMachine;

        public override void Enter(StateMachine<FightData> sm)
        {
            _stateMachine = sm;
            EnemyWave enemyWave = sm.Data.DefenceOptions.GenerateWave(sm.Data.EnemyController.CurrentWave);
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