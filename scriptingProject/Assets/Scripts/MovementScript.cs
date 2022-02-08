//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.AI;

//public class MovementScript : MonoBehaviour
//{
//    //NavMeshAgent agent;

//    public float rotateSpeedMovement = 0.1f;
//    float rotateVelocity;


//    [SerializeField]
//    float moveSpeed = 1;

//    Rigidbody rb;

//    // Start is called before the first frame update
//    void Start()
//    {
//        //agent = gameObject.GetComponent<NavMeshAgent>();



//        rb = GetComponent<Rigidbody>();
//    }

//    // Update is called once per frame
//    void Update()
//    {


//        //if (Input.GetMouseButtonDown(0))
//        //{
//        //    RaycastHit hit;

//        //    if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
//        //    {
//        //        agent.SetDestination(hit.point);

//        //        Quaternion rotationToLookAt = Quaternion.LookRotation(hit.point - transform.position);
//        //        float rotationY = Mathf.SmoothDampAngle(transform.eulerAngles.y,
//        //            rotationToLookAt.eulerAngles.y,
//        //            ref rotateVelocity,
//        //            rotateSpeedMovement * (Time.deltaTime * 5));
//        //        transform.eulerAngles = new Vector3(0, rotationY, 0);
//        //    }



//        float h = Input.GetAxis("Horizontal");
//        float v = Input.GetAxis("Vertical");

//        Vector3 dirForward = transform.forward;
//        Vector3 dirRight = transform.right;

//        dirForward.y = 0;
//        dirRight.y = 0;
//        dirForward.Normalize();
//        dirRight.Normalize();

//        Vector3 moveDirection = (dirForward * v * moveSpeed) + (dirRight * h * moveSpeed);

//        rb.velocity = new Vector3(moveDirection.x, rb.velocity.y, moveDirection.z);

//    }

//    //}
//}