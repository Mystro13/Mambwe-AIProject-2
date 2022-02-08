using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{

   private Camera cam;
   private NavMeshAgent agent;
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
    private Rigidbody rigidbody;
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword
    public bool grounded = true;

    void Start()
   {
      cam = Camera.main;
      agent = GetComponent<NavMeshAgent>();
      rigidbody = GetComponent<Rigidbody>();
   }

    void Update()
   {
      // clicking on the nav mesh, sets the destination of the agent and off he goes
      if (Input.GetMouseButtonDown(0) && (!agent.isStopped))
      {
         Ray ray = cam.ScreenPointToRay(Input.mousePosition);
         if (Physics.Raycast(ray, out RaycastHit hit))
         {
            agent.SetDestination(hit.point);
         }
      }

      // when you want to jump
   //   if (Input.GetKeyDown(KeyCode.Space) && grounded)
   //   {
   //      grounded = false;
   //      if (agent.enabled)
   //      {
   //         // set the agents target to where you are before the jump
   //         // this stops her before she jumps. Alternatively, you could
   //         // cache this value, and set it again once the jump is complete
   //         // to continue the original move
   //         agent.SetDestination(transform.position);
   //         // disable the agent
   //         agent.updatePosition = false;
   //         agent.updateRotation = false;
   //         agent.isStopped = true;
   //      }
   //      // make the jump
   //      rigidbody.isKinematic = false;
   //      rigidbody.useGravity = true;
   //      rigidbody.AddRelativeForce(new Vector3(0, 5f, 0), ForceMode.Impulse);
   //   }
   }

   /// <summary>
   /// Check for collision back to the ground, and re-enable the NavMeshAgent
   /// </summary>
   private void OnCollisionEnter(Collision collision)
   {
      if (collision.collider != null && collision.collider.tag == "Ground")
      {
         if (!grounded)
         {
            if (agent.enabled)
            {
               agent.updatePosition = true;
               agent.updateRotation = true;
               agent.isStopped = false;
            }
            rigidbody.isKinematic = true;
            rigidbody.useGravity = false;
            grounded = true;
         }
      }
   }
}