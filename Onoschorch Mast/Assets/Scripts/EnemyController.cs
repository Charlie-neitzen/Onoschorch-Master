using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    public float lookRadius = 1000f;
    public Animator animator;
    public float maxHealth = 100f;
    private float currentHealth;

    Transform target;
    NavMeshAgent agent;

    public void Start()
    {
        target = PlayerManager.instance.player.transform;
        currentHealth = maxHealth;
        agent = GetComponent<NavMeshAgent>();
    }

    public void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);    

        if (distance <= lookRadius)
        {
            animator.SetBool("seesPlayer", true);
            agent.SetDestination(target.position);

        }

        if (distance <= agent.stoppingDistance)
        {
            Attack();
            FaceTarget();

        }

        if (currentHealth <= 0)
        {
            KillPlayer();
        }


    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    public void KillPlayer()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Attack()
    {
        currentHealth -= 10;
    }

}
