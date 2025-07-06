using System;
using UnityEngine;

namespace Blade.FSM
{
    [CreateAssetMenu(fileName = "StateData", menuName = "SO/FSM/StateData", order = 0)]
    public class StateSO : ScriptableObject
    {
        public string stateName;
        public string className;
        public string animParamName;

        //이거는 private으로 하게 되면 빌드할 때 동작하지 않게 된다.
        public int animationHash;

        private void OnValidate()
        {
            animationHash = Animator.StringToHash(animParamName);
        }
    }
}