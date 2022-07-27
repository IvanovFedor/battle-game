using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAiCube : MonoBehaviour
{
    private float temp = 9999;
    public int once;
    public GameObject Part;
    public bool UpDown;
    public NavMeshAgent agent;
    public Transform player;
    // Start is called before the first frame update
    public LayerMask whatIsGround, whatIsPlayer , Enemy;
    public Vector3 walkPoint;
    public float walkPointRange;
    bool walkPointSet;
    public float timeBetweenAttacks;
    public bool alreadyAttacked;
    public float sightRange, attackRange;
    public bool PlayerInSightRange, playerInAttackRange;
    public float RotSword;
    public float RotSwordLerp;
    public bool jump;
    public int TudaSyda;
    public GameObject[] enemies;
    public bool killed;
    void Awake()
    {
        TudaSyda = 1;
        GetComponent<RayFire.RayfireRigid>().Initialize();
        
        agent = GetComponent<NavMeshAgent>();
        alreadyAttacked = false;
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
        var direction = heading / distance; 

       /// if (Physics.Raycast(walkPoint, direction, 10f, Enemy))
        //{
            if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
                walkPointSet = true;
       // }
        

        

    }
    private void Chase()
    {
        enemies = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject go in enemies)
        {

            float tmp2 = Vector3.Distance(transform.position, go.transform.position);
            if (tmp2 < temp)
            {
                temp = tmp2;
                player = go.transform;
                killed = false;

            }

        }
        if (killed == true)
        {
            temp = sightRange;
        }
        if (alreadyAttacked == false)
        {
            agent.isStopped = false;
            
            Vector3 distanceToWalkPoint = transform.position - player.transform.position;
            if (distanceToWalkPoint.magnitude > 2f)
                agent.SetDestination(player.position);
        }
        
        

    }
    private void Attack()
    {
        enemies = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject go in enemies)
        {

            float tmp2 = Vector3.Distance(transform.position, go.transform.position);
            if (tmp2 < temp)
            {
                temp = tmp2;
                player = go.transform;
                killed = false;

            }

        }
        if (killed == true)
        {
            temp = sightRange;
        }
        // agent.SetDestination(transform.position);
        agent.isStopped = true;
        if(alreadyAttacked == false)
        {
            GetComponent<RayFire.RayfireRigid>().initialized = false;
            alreadyAttacked = true;
            agent.enabled = false;
            GetComponent<Rigidbody>().AddForce(0f,18, 0f, ForceMode.Impulse);
            once = 0;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
            Invoke(nameof(Jumping), 1f);

        }
        
           
    }
    private void ResetAttack()
    {
        if(Physics.Raycast(transform.position, -transform.up, 2f, whatIsGround))
        {
            alreadyAttacked = false;
            agent.enabled = true;
            GetComponent<RayFire.RayfireRigid>().Initialize();
        }
        else
        {
            Invoke(nameof(ResetAttack), timeBetweenAttacks/10);
        }
       
        
    }
    private void Jumping()
    {
        if(alreadyAttacked == true)
        {
            Invoke(nameof(Jumped), 1f);
            jump = true;
        }
       
    }
    private void Jumped()
    {
        
            
            jump = false;
        

    }
    // Update is called once per frame
    void Update()
    {
        
        if (alreadyAttacked == false)
        {
            PlayerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
            playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
            if (!PlayerInSightRange && !playerInAttackRange) Patroling();
            if (PlayerInSightRange && !playerInAttackRange) Chase();
            if (PlayerInSightRange && playerInAttackRange)
            {

                Vector3 direction = new Vector3(player.transform.position.x, player.transform.position.y + 1, player.transform.position.z) - transform.position;
                Quaternion rotation = Quaternion.LookRotation(direction);

                transform.rotation = Quaternion.Lerp(transform.rotation, rotation, 20 * Time.deltaTime);
                Attack();
            }
            if (transform.localScale.y > 70 && TudaSyda == 1)
            {
                
                transform.localScale = new Vector3(transform.localScale.x, Mathf.Lerp(transform.localScale.y, 69, 8f * Time.deltaTime), transform.localScale.z);
            }
            else if (transform.localScale.y < 99 )
            {
                if( TudaSyda == 1 ||  TudaSyda == 2)
                {
                    TudaSyda = 2;
                    transform.localScale = new Vector3(transform.localScale.x, Mathf.Lerp(transform.localScale.y, 100, 8f * Time.deltaTime), transform.localScale.z);
                }
                
            }
            else
            {
                TudaSyda = 1;
            }
        }
        else
        {
            
            //ротация к игроку, но так чтобы не упал
            Vector3 direction = new Vector3(player.transform.position.x, player.transform.position.y + 1, player.transform.position.z) - transform.position;
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Euler(Mathf.LerpAngle(transform.rotation.eulerAngles.x, 0, 10 * Time.deltaTime), Mathf.LerpAngle(transform.rotation.eulerAngles.y, rotation.eulerAngles.y, 10 * Time.deltaTime), Mathf.LerpAngle(transform.rotation.eulerAngles.z, 0, 10 * Time.deltaTime));
            if (Physics.Raycast(transform.position, -transform.up, 2f, whatIsGround))
            {
                transform.localScale = new Vector3(transform.localScale.x, Mathf.Lerp(transform.localScale.y, 100, 10f * Time.deltaTime), transform.localScale.z);
                if (once != 1)
                {
                    if (jump == true)
                    {
                        if (Vector3.Distance(transform.position, player.transform.position) < 7)
                        {
                            CameraShake.Shake(0.3f, 1 / Vector3.Distance(transform.position, player.transform.position));
                            player.GetComponent<PlayerMove>().speed = player.GetComponent<PlayerMove>().speed / 5;
                        }
                        Instantiate(Part, new Vector3(transform.position.x, transform.position.y - 1.9f, transform.position.z), Quaternion.identity);
                        GetComponent<RayFire.RayfireRigid>().Initialize();
                        agent.enabled = false;
                        once = 1;
                    }

                }


            }
            else
            {

                transform.Translate(0, 0, 2.5f * Time.deltaTime);
                
                
            }
                
        }
       
        
    }
    private void FixedUpdate()
    {
        if(alreadyAttacked == false)
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
}
