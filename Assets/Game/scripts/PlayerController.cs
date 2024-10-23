using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
     public Camera mainCamera;
      public NavMeshAgent navMeshAgent;
      public Animator playerAnimator;
      public GameObject targetDestination;
  
      // Update is called once per frame
      void Update()
      {
          // If the player clicks, set the destination
          if (Input.GetMouseButtonDown(0))
          {
              Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
              RaycastHit hitPoint;
  
              if (Physics.Raycast(ray, out hitPoint))
              {
                  // Set the target's position and the NavMeshAgent's destination
                  targetDestination.transform.position = hitPoint.point;
                  navMeshAgent.SetDestination(hitPoint.point);
              }
          }
  
          // Calculate the player's speed
          float speed = navMeshAgent.velocity.magnitude;
  
          // Update the animator parameters based on the speed
          if (speed > 0f)
          {
              playerAnimator.SetBool("isWalking", true);
              playerAnimator.SetFloat("Speed", speed);
          }
          else
          {
              playerAnimator.SetBool("isWalking", false);
              playerAnimator.SetFloat("Speed", speed);
          }
  
          // Set the speed in the animator as a float parameter for blending
         
      }
}
