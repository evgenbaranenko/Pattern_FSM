// скрипт состояние передвижения в общем виде 
// базовый класс

using UnityEngine;

namespace Pattern_FSM.Scripts
{
    public class FsmStateMovement : FsmState
    {
        protected readonly Transform Transform;
        protected readonly float Speed;

        public FsmStateMovement(Fsm fsm, Transform transform, float speed) : base(fsm)
        {
            Transform = transform;
            Speed = speed;
        }

        public override void Enter()
        {
            Debug.Log($"Movement ({this.GetType().Name}) state [ENTER] ");
        }

        public override void Exit()
        {
            Debug.Log($"Movement ({this.GetType().Name}) state [EXIT] ");
        }

        public override void Update()
        {
            Debug.Log($"Movement ({this.GetType().Name}) state [UPDATE] with speed:{Speed} ");

            var inputDirection = ReadInput();

            if (inputDirection.sqrMagnitude == 0f) // если магнитуда равна нулю, то переходим в состояние покоя
                Fsm.SetState<FsmStateIdle>();

            Move(inputDirection); // если не равна то двигаемся 
        }

        protected Vector2 ReadInput()
        {
            var inputHorizontal = Input.GetAxis("Horizontal");
            var inputVertical = Input.GetAxis("Vertical");
            var inputDirection = new Vector2(inputHorizontal, inputVertical);

            return inputDirection;
        }

        protected virtual void Move(Vector2 inputDirection)
        {
            Transform.position += new Vector3(inputDirection.x, 0f, inputDirection.y) *
                                  (Speed * Time.deltaTime);
        }
    }
}