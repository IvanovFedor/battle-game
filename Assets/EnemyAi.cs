using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAi : MonoBehaviour
{
    public GameObject sword;
    public bool UpDown;
    public NavMeshAgent agent;
    public Transform player;
    // Start is called before the first frame update
    public LayerMask whatIsGround, whatIsPlayer , Enemy;
    public Vector3 walkPoint;
    public float walkPointRange;
    bool walkPointSet;
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public float sightRange, attackRange;
    public bool PlayerInSightRange, playerInAttackRange;
    public float RotSword;
    public float RotSwordLerp;
    void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }
    private void Patroling()
    {
        agent.isStopped = false;
        if (!walkPointSet) SearchWalkPoint();
        if (walkPointSet)
            agent.SetDestination(walkPoint);
        Vector3 distanceToWalkPoint = transform.position - walkPoint;
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }
    private void SearchWalkPoint()
    {
        
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        var heading = walkPoint - transform.position;
        var distance = heading.magnitude;
        var direction = heading / distance; // This is now the normalized direction.

       /// if (Physics.Raycast(walkPoint, direction, 10f, Enemy))
        //{
            if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
                walkPointSet = true;
       // }
        

        

    }
    private void Chase()
    {
        agent.isStopped = false;
        Vector3 distanceToWalkPoint = transform.position - player.transform.position;
        if (distanceToWalkPoint.magnitude > 2f)
            agent.SetDestination(player.position);
        

    }
    private void Attack()
    {
       // agent.SetDestination(transform.position);
        agent.isStopped = true;

        if (!alreadyAttacked)
        {
            UpDown = true;
            RotSword = Random.Range(-66, 66);
            alreadyAttacked = true;

            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
    // Update is called once per frame
    void Update()
    {
        PlayerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        if (!PlayerInSightRange && !playerInAttackRange) Patroling();
        if (PlayerInSightRange && !playerInAttackRange) Chase();
        if (PlayerInSightRange && playerInAttackRange) 
        {
            
            Vector3 direction = new Vector3(player.transform.position.x, player.transform.position.y+1, player.transform.position.z) - transform.position;
            Quaternion rotation = Quaternion.LookRotation(direction);

            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, 10 * Time.deltaTime);
            Attack();
        }
        if (UpDown == true)
        {
            if (sword.transform.localRotation.eulerAngles.z < 89)
            {
                sword.transform.localRotation = Quaternion.Euler(sword.transform.localRotation.eulerAngles.x, sword.transform.localRotation.eulerAngles.y, Mathf.Lerp(sword.transform.localRotation.eulerAngles.z, 90, 25f * Time.deltaTime));
            }
            else
            {
                UpDown = false;
            }
        }
        else
        {
            if (sword.transform.localRotation.eulerAngles.z > 0)
            {


                sword.transform.localRotation = Quaternion.Euler(sword.transform.localRotation.eulerAngles.x, sword.transform.localRotation.eulerAngles.y, Mathf.Lerp(sword.transform.localRotation.eulerAngles.z, 0, 20f * Time.deltaTime));
            }

        }
        if (alreadyAttacked == true)
        {
            RotSwordLerp = Mathf.Lerp(RotSwordLerp, RotSword, 1f*Time.deltaTime);
            sword.transform.localRotation = Quaternion.Euler(RotSwordLerp, sword.transform.localRotation.eulerAngles.y, sword.transform.localRotation.eulerAngles.z);
        }
    }
    private void FixedUpdate()
    {
        if (GetComponent<Rigidbody>().velocity.magnitude > 1)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(Mathf.Lerp(GetComponent<Rigidbody>().velocity.x, 0, 0.1f), Mathf.Lerp(GetComponent<Rigidbody>().velocity.y, 0, 0.1f), Mathf.Lerp(GetComponent<Rigidbody>().velocity.z, 0, 0.1f));
        }
        if (GetComponent<Rigidbody>().angularVelocity.magnitude > 1)
        {
            GetComponent<Rigidbody>().angularVelocity = new Vector3(Mathf.Lerp(GetComponent<Rigidbody>().angularVelocity.x, 0, 0.1f), Mathf.Lerp(GetComponent<Rigidbody>().angularVelocity.y, 0, 0.1f), Mathf.Lerp(GetComponent<Rigidbody>().angularVelocity.z, 0, 0.1f));
        }
    }
}
