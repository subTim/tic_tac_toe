using System;
using System.Collections.Generic;
using Infrastructure.Services;
using UnityEngine;

namespace Infrastructure.GameState
{
    public class GlobalStateMachine : IService
    {
        private Dictionary<Type, IState> _states = new();
        private IState _activeState;

        public bool CompareState<TState>()
        {
            return _activeState.GetType() == typeof(TState);
        }

        public void AddState<TState>(TState state) where TState : IState
        {
            _states[typeof(TState)] = state;
        }
        
        public void SetState<TState>() where TState : IState
        {
            if(_activeState != null)
                TryExit(_activeState);
            
            
            Debug.Log(typeof(TState));
            _activeState = _states[typeof(TState)];
            TryEnter(_activeState);
        }

        private void TryExit<TState>(TState state = null) where TState : class
        {
            if (state is IExitableState exitableState)
                exitableState.Exit();
        }

        private void TryEnter<TState>(TState state) where TState : class
        {
            if (state is IEnterableState enterableState)
                enterableState.Enter();
        }
    }
}