// паттерн FSM  - Машина Конечных Состояний 

using System;
using System.Collections.Generic;

namespace Pattern_FSM.Scripts
{
    public class Fsm
    {
        private FsmState StateCurrent { get; set; }

        private Dictionary<Type, FsmState> _states = new Dictionary<Type, FsmState>(); // список всех состояний

        public void AddState(FsmState state) // добавляем в словарь состояние 
        {
            _states.Add(state.GetType(), state);
        }

        // назначаем состояние 
        public void SetState<T>() where T : FsmState
        {
            var type = typeof(T); // определяем тип 

            // проверям на null 
            // и проверяем не тогоже ли типа текущее состояние (не включено ли это же состояние) 
            if (StateCurrent != null && StateCurrent.GetType() == type) return; // если то то просто возвращаем 

            // если есть состояние типа T то будем присваивать 
            // если в списке (_states) есть значение, то по ключу (type) возвращаем в newState 
            // если нету то вернем false (проверяем и сразу же вытаскиваем)

            if (_states.TryGetValue(type, out var newState))
            {
                StateCurrent?.Exit(); // если не null то мы выходим из этого состояния 

                StateCurrent = newState; // присваиваем новое состояние 

                StateCurrent.Enter(); // входим в состоние 
            }
        }

        public void Update() => StateCurrent?.Update();
    }
}