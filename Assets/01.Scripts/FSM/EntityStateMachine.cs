using System;
using System.Collections.Generic;
using Blade.Entities;
using UnityEngine;

namespace Blade.FSM
{
    public class EntityStateMachine
    {
        public EntityState CurrentState { get; set; }
        private Dictionary<string, EntityState> _states;

        public EntityStateMachine(Entity entity, StateSO[] stateList)
        {
            _states = new Dictionary<string, EntityState>();
            foreach (StateSO state in stateList)
            {
                Type type = Type.GetType(state.className);
                Debug.Assert(type != null, $"Finding type is null : {state.className}");
                EntityState entityState = Activator.CreateInstance(type, entity, state.animationHash) as EntityState;
                _states.Add(state.stateName, entityState);
            }
        }

        public void ChangeState(string newStateName, bool forced = false)
        {
            EntityState newState = _states.GetValueOrDefault(newStateName);
            Debug.Assert(newState != null, $"Finding state is null : {newStateName}");

            if(forced == false && CurrentState == newState)
                return; //강제전환이 활성화되어 있지 않은 상태에서 현재 상태와 동일한 상태로 전환은 막는다.
            
            CurrentState?.Exit(); //이걸 아래로.
            CurrentState = newState;
            CurrentState?.Enter();
        }

        public void UpdateStateMachine()
        {
            CurrentState?.Update();
        }
    }
}