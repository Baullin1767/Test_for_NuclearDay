using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using System;

public class Unit : MonoBehaviour
{
    [SerializeField]
    protected SkeletonAnimation skeletonAnimation;
    [SerializeField]
    protected AnimationReferenceAsset idle, walking, attack;
    [SerializeField]
    protected HealthBar EnemyHealthBar;
    [SerializeField]
    protected float speed;

    protected float movement;
    protected string currentState, currentAnimatoin, previousState;

    protected Rigidbody2D rb;

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentState = "Idle";
        SetUnitState(currentState);
    }

    protected virtual void Update(){}

    protected void SetAnimation(AnimationReferenceAsset animation, bool loop, float timeScale)
    {
        if (animation.name.Equals(currentAnimatoin))
        {
            return;
        }
        skeletonAnimation.state.SetAnimation(0, animation, loop).TimeScale = timeScale;
        currentAnimatoin = animation.name;
    }

    

    protected void AddAnimation(int index, AnimationReferenceAsset animation, bool loop, float timeScale)
    {
        Spine.TrackEntry AnimationEntry = skeletonAnimation.state.AddAnimation(index, animation, loop, 0);        
        AnimationEntry.TimeScale = timeScale;
        AnimationEntry.Complete += AnimationEntry_Complete;
    }
    private void AnimationEntry_Complete(Spine.TrackEntry trackEntry)
    {
        if (currentState.Equals("Attack"))
        {
            SetUnitState(previousState);
            EnemyHealthBar.Damage();
        }
    }

    protected void SetUnitState(string state)
    {
        if (state.Equals("Walking"))
        {
            SetAnimation(walking, true, 1f);
        }
        else if (state.Equals("Attack"))
        {
            AddAnimation(1, attack, false, 1.2f);
        }
        else
        {
            SetAnimation(idle, true, 1f);
            skeletonAnimation.state.ClearTrack(1);
        }

        currentState = state;
    }

    
    protected virtual void Walk() { }

    protected virtual void Attack() { }

    public virtual void Death() { }

}
