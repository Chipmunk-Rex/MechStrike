using Blade.Entities;

namespace Blade.FSM
{
    public abstract class EntityState
    {
        protected Entity _entity;
        protected int _animationHash;
        protected EntityAnimator _animator;
        protected EntityAnimatorTrigger _animatorTrigger;
        protected bool _isTriggerCall;

        public EntityState(Entity entity, int animationHash)
        {
            _entity = entity;
            _animationHash = animationHash;
            _animator = entity.GetCompo<EntityAnimator>();
            _animatorTrigger = entity.GetCompo<EntityAnimatorTrigger>();
        }

        public virtual void Enter()
        {
            _animator.SetParam(_animationHash, true);
            _isTriggerCall = false;
            _animatorTrigger.OnAnimationEndTrigger += AnimationEndTrigger;
        }
        
        public virtual void Update(){}

        public virtual void Exit()
        {
            _animator.SetParam(_animationHash, false);
            _animatorTrigger.OnAnimationEndTrigger -= AnimationEndTrigger;
        }

        public virtual void AnimationEndTrigger() => _isTriggerCall = true;
    }
}