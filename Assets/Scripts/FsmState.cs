// паттерн FSM  - Машина Конечных Состояний 

namespace Pattern_FSM.Scripts
{
    public abstract class FsmState
    {
        protected readonly Fsm Fsm;

        public FsmState(Fsm fsm)
        {
            Fsm = fsm;
        }

        // cостояние 1
        public virtual void Enter()
        {
        }

        // cостояние 2
        public virtual void Exit()
        {
        }

        // cостояние 3
        public virtual void Update()
        {
        }
    }
}