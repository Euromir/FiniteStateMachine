
using UnityEngine;
using UnityEngine.AI;
public class FSMAIController : MonoBehaviour
{
    public Animator anim;
    public NavMeshAgent agent;
    public Transform player;
    public AudioSource audioSource;
    public float visionDistance = 10.0f; public float visionAngle = 30.0f; public float attackDistance = 7.0f;
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>(); anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    public bool CanSeePlayer()
    {
        Vector3 direction = player.position
        -
        transform.position;
        float angle = Vector3.Angle(direction, transform.forward);
        if (direction.magnitude < visionDistance && angle < visionAngle)
        {
            return true;
        }
        return false;
    }

    public bool IsPlayerBehind()
    {
        Vector3 direction = transform.position - player.position;
        float angle = Vector3.Angle(direction, transform.forward);
        if (direction.magnitude < 2f && angle < visionAngle)
        {
            return true;
        }
        return false;
    }

    public bool CanAttackPlayer()
    {
        Vector3 direction = player.position - transform.position;
        if (direction.magnitude < attackDistance)
        {
            return true;
        }
        return false;
    }
}
