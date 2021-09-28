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
    protected float hp, damage, speed;
    protected string currentState, currentAnimatoin, previousState;
    protected float movement;

    protected Rigidbody2D rb;

    protected void Start()
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
        Spine.TrackEntry animationEntry = skeletonAnimation.state.SetAnimation(0, animation, loop);
        animationEntry.TimeScale = timeScale;
        animationEntry.Complete += AnimationEntry_Complete;
        currentAnimatoin = animation.name;
    }

    private void AnimationEntry_Complete(Spine.TrackEntry trackEntry)
    {
        if (currentState.Equals("Attack"))
        {
            SetUnitState(previousState);
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
            SetAnimation(attack, false, 1.3f);
        }
        else
        {
            SetAnimation(idle, true, 1f);
        }

        currentState = state;
    }

    
    protected virtual void Walk() { }

    protected virtual void Attack() { }

    protected virtual void Death() { }

}
