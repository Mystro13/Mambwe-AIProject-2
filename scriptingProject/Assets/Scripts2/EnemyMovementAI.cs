using System;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovementAI : MonoBehaviour
{
    private MovementCategoryOptions movementCategory = MovementCategoryOptions.StayIdle;
    //wandering 
    public float wanderRadius;
    public float wanderTimer;

    private Transform target;
    private NavMeshAgent navigationAgent;
    private float movementTimer;

    //
    public Transform[] Patrolpoints;
    public int curPatrolpoint = 0;
    bool ReversePath = false;
    Vector3 AIDestination;
    float distanceToDestination;
    //staying idle
    public float stayingIdleTimer= 20;

    void Awake()
    {
        navigationAgent = GetComponent<NavMeshAgent>();
        movementCategory = MovementCategoryOptions.SearchingForAPlayer;
    }

    void Update()
    {
        switch (movementCategory)
        {
            case MovementCategoryOptions.StayIdle:
                {
                    StayIdelAI();
                    break;
                }
            case MovementCategoryOptions.MoveTowardsTarget:
                {
                    MoveTowardsTargetAI();
                    break;
                }
            case MovementCategoryOptions.RotateTowardsTarget:
                {
                    RotateTowardsTargetAI();
                    break;
                }
            case MovementCategoryOptions.SeekTarget:
                {
                    SeekTargetAI();
                    break;
                }
            case MovementCategoryOptions.FleeingFromAPlayer:
                {
                    FleeingFromDangerAI();
                    break;
                }
            case MovementCategoryOptions.AttackingAPlayer:
                {
                    AttackingTargetAI();
                    break;
                }
            case MovementCategoryOptions.PursueingAPlayer:
                {
                    PursueTargetAI();
                    break;
                }
            case MovementCategoryOptions.FollowTarget:
                {
                    FollowTargetAI();
                    break;
                }
            case MovementCategoryOptions.PatrollingAnAreaPath:
                {
                    PatrolAnAreaAI();
                    break;
                }
            case MovementCategoryOptions.FindingCover:
                {
                    FindingCoverAI();
                    break;
                }
            case MovementCategoryOptions.WanderRandomly:
                {
                    WanderRandomlyAI();
                    break;
                }
            case MovementCategoryOptions.SearchingForAPlayer:
                {
                    SearchTargetAI();
                    break;
                }
            case MovementCategoryOptions.WithinDistance:
                {
                    WithinDistanceAI();
                    break;
                }
            case MovementCategoryOptions.CanSeeObject:
                {
                    CanSeeObjectAI();
                    break;
                }
            case MovementCategoryOptions.CanHearTarget:
                {
                    CanHearTargetAI();
                    break;
                }
            case MovementCategoryOptions.FlockTogether:
                {
                    FlockTogetherAI();
                    break;
                }
            case MovementCategoryOptions.FollowALeader:
                {
                    FollowLeaderAI();
                    break;
                }
            case MovementCategoryOptions.TakePlaceInQueue:
                {
                    TakePlaceInQueueAI();
                    break;
                }
        }
    }

    private void MoveTowardsTargetAI()
    {
        throw new NotImplementedException();
    }

    private void RotateTowardsTargetAI()
    {
        throw new NotImplementedException();
    }

    private void SeekTargetAI()
    {
        throw new NotImplementedException();
    }

    private void FleeingFromDangerAI()
    {
        for (int fleePoint = 0; fleePoint < Patrolpoints.Length; fleePoint++)
        {
            distanceToDestination = Vector3.Distance(gameObject.transform.position, Patrolpoints[fleePoint].position);
            if (distanceToDestination > 10.00f)
            {
                AIDestination = Patrolpoints[curPatrolpoint].position;
                navigationAgent.SetDestination(AIDestination);
                break;
            }
            else if (distanceToDestination < 2.00f)
            {
                ChangeMovementCategoryOption(MovementCategoryOptions.StayIdle);
            }
        }
    }

    private void PursueTargetAI()
    {
        throw new NotImplementedException();
    }

    private void AttackingTargetAI()
    {
        throw new NotImplementedException();
    }

    private void FollowTargetAI()
    {
        throw new NotImplementedException();
    }

    private void PatrolAnAreaAI()
    {
        distanceToDestination = Vector3.Distance(gameObject.transform.position, Patrolpoints[curPatrolpoint].position);
        if (distanceToDestination > 2.00f)
        {
            AIDestination = Patrolpoints[curPatrolpoint].position;
            navigationAgent.SetDestination(AIDestination);
        }
        else
        {
            if (ReversePath)
            {
                if (curPatrolpoint <= 0)
                {
                    ReversePath = false;
                }
                else
                {
                    curPatrolpoint--;
                    AIDestination = Patrolpoints[curPatrolpoint].position;
                }
            }
            else
            {
                if (curPatrolpoint >= Patrolpoints.Length - 1)
                {
                    ReversePath = true;
                }
                else
                {
                    curPatrolpoint++;
                    AIDestination = Patrolpoints[curPatrolpoint].position;
                }
            }
        }
    }

    private void FindingCoverAI()
    {
        throw new NotImplementedException();
    }

    private void SearchTargetAI()
    {
        AIDestination = GameObject.FindGameObjectWithTag("Player").transform.position;
        navigationAgent.SetDestination(AIDestination);
        distanceToDestination = Vector3.Distance(gameObject.transform.position, AIDestination);
        if (distanceToDestination < 10)
        {
            //change the mode into interaction or combat
            movementCategory = MovementCategoryOptions.FleeingFromAPlayer;
            movementTimer = 0;
        }
    }

    private void WanderRandomlyAI()
    {
        movementTimer += Time.deltaTime;

        if (movementTimer >= wanderTimer)
        {
            Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
            navigationAgent.SetDestination(newPos);
            movementTimer = 0;
        }
    }

    private void WithinDistanceAI()
    {
        throw new NotImplementedException();
    }

    private void CanSeeObjectAI()
    {
        throw new NotImplementedException();
    }

    private void CanHearTargetAI()
    {
        throw new NotImplementedException();
    }

    private void FlockTogetherAI()
    {
        throw new NotImplementedException();
    }

    private void FollowLeaderAI()
    {
        throw new NotImplementedException();
    }

    private void TakePlaceInQueueAI()
    {
        throw new NotImplementedException();
    }

    private void StayIdelAI()
    {
        movementTimer += Time.deltaTime;

        if (movementTimer >= stayingIdleTimer)
        {
            movementTimer = 0;
            movementCategory = MovementCategoryOptions.PatrollingAnAreaPath;
        }
    }

    private Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = UnityEngine.Random.insideUnitSphere * dist;

        randDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }
    public void ChangeMovementCategoryOption(MovementCategoryOptions changeToMovementCategory)
    {
        switch (changeToMovementCategory)
        {
            case MovementCategoryOptions.StayIdle:
                {
                    movementCategory = changeToMovementCategory;
                    movementTimer = stayingIdleTimer;
                    break;
                }
            case MovementCategoryOptions.MoveTowardsTarget:
                {
                    break;
                }
            case MovementCategoryOptions.RotateTowardsTarget:
                {
                    break;
                }
            case MovementCategoryOptions.SeekTarget:
                {
                    break;
                }
            case MovementCategoryOptions.FleeingFromAPlayer:
                {
                    break;
                }
            case MovementCategoryOptions.AttackingAPlayer:
                {
                    break;
                }
            case MovementCategoryOptions.PursueingAPlayer:
                {
                    break;
                }
            case MovementCategoryOptions.FollowTarget:
                {
                    break;
                }
            case MovementCategoryOptions.PatrollingAnAreaPath:
                {
                    break;
                }
            case MovementCategoryOptions.FindingCover:
                {
                    break;
                }
            case MovementCategoryOptions.WanderRandomly:
                {
                    break;
                }
            case MovementCategoryOptions.SearchingForAPlayer:
                {
                    break;
                }
            case MovementCategoryOptions.WithinDistance:
                {
                    break;
                }
            case MovementCategoryOptions.CanSeeObject:
                {
                    break;
                }
            case MovementCategoryOptions.CanHearTarget:
                {
                    break;
                }
            case MovementCategoryOptions.FlockTogether:
                {
                    break;
                }
            case MovementCategoryOptions.FollowALeader:
                {
                    break;
                }
            case MovementCategoryOptions.TakePlaceInQueue:
                {
                    break;
                }
        }
    }
}
