using UnityEngine;
using UnityEngine.AI;

public class DancingBehaviour : StateMachineBehaviour
{
    private NavMeshAgent agent;
    private FSMAIController controller;
    private Animator anim;
    private AudioSource gangnamStyle;

    private float rotationSpeed = 5.0f;
    private float transitionDelay = 5.0f;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        controller = animator.GetComponentInParent<FSMAIController>();
        agent = controller.agent;
        anim = controller.anim;
        gangnamStyle = controller.musicSource;
        agent.isStopped = true;

        gangnamStyle.Play();
        anim.SetTrigger("isDancing");
        animator.SetBool("IsGrooving", true);
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector3 direction = controller.player.position - controller.gameObject.transform.position;
        direction.y = 0;
        controller.gameObject.transform.rotation = Quaternion.Slerp(controller.gameObject.transform.rotation,
            Quaternion.LookRotation(direction), Time.deltaTime * rotationSpeed);

        if (transitionDelay > 0)
        {
            transitionDelay -= Time.deltaTime;
            return;
        }
        else
        {
            animator.SetBool("IsGrooving", false);
        }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        anim.ResetTrigger("isDancing");
        transitionDelay = 3.0f;
        animator.SetBool("IsGrooving", false);
        gangnamStyle.Stop();
    }
}
