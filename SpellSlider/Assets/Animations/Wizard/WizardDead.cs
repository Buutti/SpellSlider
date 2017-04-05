using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardDead : StateMachineBehaviour {

    public GameObject deathPuff;

    private GameObject deathPuffInstance;
    private ParticleSystem deathPuffParticles;
    private float originalSpeed;
    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        originalSpeed = animator.speed;
        deathPuffInstance = Instantiate(deathPuff, animator.transform.GetChild(0).transform.position, Quaternion.identity);
        deathPuffParticles = deathPuffInstance.GetComponent<ParticleSystem>();
        // Delay animation until puff is done
        animator.speed = 0;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // If puff done puffing play animation
        if(animator.speed == 0 && !deathPuffParticles.isEmitting) {
            animator.speed = originalSpeed;
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Lose level after animation has finished playing
        Destroy(deathPuffInstance);
        AdventureView.Instance.LoseLevel();
    }

    // OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}
}
