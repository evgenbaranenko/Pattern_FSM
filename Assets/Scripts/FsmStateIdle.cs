// состояние по умолчанию (Idle)

using UnityEngine;

namespace Pattern_FSM.Scripts
{
    public class FsmStateIdle : FsmState
    {
        public FsmStateIdle(Fsm fsm) : base(fsm)
        {
        }

        public override void Enter()
        {
            Debug.Log("Idle state [ENTER]");
        }

        public override void Exit()
        {
            Debug.Log("Idle state [EXIT]");
        }

        public override void Update()
        {
            Debug.Log("Idle state [UPDATE]");

            // проверка импута чтобы можно было менять состояние (перейти в другое)
            // написано для примера 

            if (Input.GetAxis("Horizontal") != 0f || Input.GetAxis("Vertical") != 0f)
            {
                Fsm.SetState<FsmStateWalk>();
            }
        }
    }
}