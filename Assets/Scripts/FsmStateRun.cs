﻿// состояние бега

using UnityEngine;

namespace Pattern_FSM.Scripts
{
    public class FsmStateRun : FsmStateMovement
    {
        public FsmStateRun(Fsm fsm, Transform transform, float speed) : base(fsm, transform, speed)
        {
        }

        public override void Update()
        {
            Debug.Log($"Run state [UPDATE] with speed: {Speed}");

            var inputDirection = ReadInput();

            if (inputDirection.sqrMagnitude == 0f)
            {
                Fsm.SetState<FsmStateIdle>();
            }

            // когда нажимаем Shift если игрок идет то включается бег 
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                Fsm.SetState<FsmStateWalk>();
            }

            Move(inputDirection);
        }
    }
}