namespace StateManagement
{
    public abstract class StateBase<T>
    {
        public virtual void Enter(StateMachine<T> sm) { }
        public virtual void Update(StateMachine<T> sm) { }
        public virtual void FixedUpdate(StateMachine<T> sm) { }
        public virtual void LateUpdate(StateMachine<T> sm) { }
        public virtual void Exit(StateMachine<T> sm) { }
    }
}