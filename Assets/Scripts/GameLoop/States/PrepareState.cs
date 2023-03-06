using StateManagement;

namespace GameLoop.States
{
    public class PrepareState : StateBase<GameStateData>
    {
        public const string SceneName = "Prepare";
        public override void Enter(StateMachine<GameStateData> sm)
        {
            GameManager.Instance.GlobalStateMachine.Data.FoodController.Clear();
        }
    }
}