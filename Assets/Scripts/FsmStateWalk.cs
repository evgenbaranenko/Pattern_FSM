// состояние ходьбы

using UnityEngine;

namespace Pattern_FSM.Scripts
{
    public class FsmStateWalk : FsmStateMovement
    {
        public FsmStateWalk(Fsm fsm, Transform transform, float speed) : base(fsm, transform, speed)
        {
        }

        public override void Update()
        {
            Debug.Log($"Walk state [UPDATE] with speed: {Speed}");

            var inputDirection = ReadInput();

            if (inputDirection.sqrMagnitude == 0f)
            {
                Fsm.SetState<FsmStateIdle>();
            }

            // когда нажимаем Shift если игрок идет то включается бег 
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                Fsm.SetState<FsmStateRun>();
            }

            Move(inputDirection);
        }
    }
}