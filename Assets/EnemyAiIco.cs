using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAiIco : MonoBehaviour
{
    
    
    public NavMeshAgent agent;
    public Transform player;
    // Start is called before the first frame update
    public LayerMask whatIsGround, whatIsPlayer , Enemy;
    public Vector3 walkPoint;
    public float walkPointRange;
    public bool walkPointSet;
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public float sightRange, attackRange;
    public bool PlayerInSightRange, playerInAttackRange;
    public bool GoToPos;
    NavMeshPath nav_mesh_path;
    private bool Rotated;
    private bool onceRot;
    public GameObject bullet;
    public int TudaSyda;
    void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        agent = GetComponent<NavMeshAgent>();
    }
    private void Start()
    {
        nav_mesh_path = new NavMeshPath();
    }
    private void Patroling()
    {
        if (Rotated == false)
        {
            if(onceRot != true)
            {
                Invoke("ResetRotated", 1);
                onceRot = true;
            }
            agent.enabled = true;
            
        }
        else
        {
            if (onceRot != true)
            {
                Invoke("ResetRotated", 1);
                onceRot = true;
            }
        }    
        if (!walkPointSet) SearchWalkPoint();
        if (walkPointSet)
            agent.SetDestination(walkPoint);
        Vector3 distanceToWalkPoint = transform.position - walkPoint;
        if (distanceToWalkPoint.magnitude < 8f)
            walkPointSet = false;
    }
    private void SearchWalkPoint()
    {
        
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y-2, transform.position.z + randomZ);
        agent.CalculatePath(walkPoint, nav_mesh_path);
        if (nav_mesh_path.status == NavMeshPathStatus.PathComplete)
        {
            
            GoToPos = true;
            var heading = walkPoint - transform.position;
            var distance = heading.magnitude;
            var direction = heading / distance; // This is now the normalized direction.

            /// if (Physics.Raycast(walkPoint, direction, 10f, Enemy))
            //{
            if (Physics.Raycast(walkPoint, -transform.up, 5f, whatIsGround))
                walkPointSet = true;
            // }

        }
        else SearchWalkPoint();



    }
    private void Chase()
    {
        if(Rotated == false)
        {
            
            agent.enabled = true;
            
        }
        else
        {
            if (onceRot != true)
            {
                Invoke("ResetRotated", 1);
                onceRot = true;
            }
        }
        
        Vector3 distanceToWalkPoint = transform.position - player.transform.position;
        if (distanceToWalkPoint.magnitude > 2f)
            agent.SetDestination(player.position);
        

    }
    private void Attack()
    {
       // agent.SetDestination(transform.position);
       
        agent.enabled = false;
        if (!alreadyAttacked)
        {
            Instantiate(bullet,transform.position,Quaternion.identity);
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
        else
        {

        }
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
    // Update is called once per frame
    private void ResetRotated()
    {
        onceRot = false;
        Rotated = false;
    }
    void Update()
    {
        PlayerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        if (!PlayerInSightRange && !playerInAttackRange) Patroling();
        if (PlayerInSightRange && !playerInAttackRange) Chase();
        if (PlayerInSightRange && playerInAttackRange) 
        {
            Rotated = true;
            Vector3 direction = new Vector3(player.transform.position.x, player.transform.position.y+1, player.transform.position.z) - transform.position;
            Quaternion rotation = Quaternion.LookRotation(direction);

            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, 20 * Time.deltaTime);
            Attack();
           
        }
        else
        {
            if (transform.localScale.y > 89 && TudaSyda == 1)
            {

                transform.localScale = new Vector3(transform.localScale.x, Mathf.Lerp(transform.localScale.y, 88, 1f * Time.deltaTime), transform.localScale.z);
            }
            else if (transform.localScale.y < 99)
            {
                if (TudaSyda == 1 || TudaSyda == 2)
                {
                    TudaSyda = 2;
                    transform.localScale = new Vector3(transform.localScale.x, Mathf.Lerp(transform.localScale.y, 100, 1f * Time.deltaTime), transform.localScale.z);
                }

            }
            else
            {
                TudaSyda = 1;
            }
        }
       
    }
    private void FixedUpdate()
    {
        if (GetComponent<Rigidbody>().velocity.magnitude > 1)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(Mathf.Lerp(GetComponent<Rigidbody>().velocity.x,0,0.1f), Mathf.Lerp(GetComponent<Rigidbody>().velocity.y, 0, 0.1f), Mathf.Lerp(GetComponent<Rigidbody>().velocity.z, 0, 0.1f));
        }
        if (GetComponent<Rigidbody>().angularVelocity.magnitude > 1)
        {
            GetComponent<Rigidbody>().angularVelocity = new Vector3(Mathf.Lerp(GetComponent<Rigidbody>().angularVelocity.x, 0, 0.1f), Mathf.Lerp(GetComponent<Rigidbody>().angularVelocity.y, 0, 0.1f), Mathf.Lerp(GetComponent<Rigidbody>().angularVelocity.z, 0, 0.1f));
        }

    }
}
