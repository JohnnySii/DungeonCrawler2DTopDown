using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Animator))]
public class AgentAnimation : MonoBehaviour
{
    protected Animator agentAnimator;

    private void Awake()
    {
        agentAnimator = GetComponent<Animator>();

    }

    public void SetWalkAnimation(bool val)
    {

        agentAnimator.SetBool("IsWalking", val);
    }

    public void AnimatePlayer(float velocity)
    {

        SetWalkAnimation(velocity > 0);

    }


}
