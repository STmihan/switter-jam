namespace StateManagement
{
    public class StateMachine<T>
    {
        public StateBase<T> CurrentState { get; private set; }
        public T Data { get; }
        
        public StateMachine(T data, StateBase<T> initialState)
        {
            Data = data;
            CurrentState = initialState;
            CurrentState.Enter(this);
        }

        public void ChangeState(StateBase<T> newState)
        {
            if (CurrentState != null)
            {
                CurrentState.Exit(this);
            }
            CurrentState = newState;
            CurrentState.Enter(this);
        }
        
        public void Update()
        {
            CurrentState.Update(this);
        }
        
        public void FixedUpdate()
        {
            CurrentState.FixedUpdate(this);
        }
        
        public void LateUpdate()
        {
            CurrentState.LateUpdate(this);
        }
        
        public void OnDestroy()
        {
            CurrentState.Exit(this);
        }
    }
}