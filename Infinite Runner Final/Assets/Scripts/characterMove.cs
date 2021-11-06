using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterMove : MonoBehaviour
{
  
    private CharacterController controller;
    private Vector3 direction;
    public float speed;
    public float maxSpeed;
    private int desiredLane = 1;
    public float laneDistance = 4;
    public float jumpForce;
    public float gravity=-20;
    public Animator anim;
    private bool isSliding=false;
    private Vector3 controllerCenter;
    private float controllerHeight;
    public float scoreAmount =0f;
    private LivesManager lm;
    public GameObject kinectObject;
    private GestureListener gestureListener;
     public Animator pointlight;

    void Start()
    {
        pointlight.gameObject.SetActive(false);
        controller = GetComponent<CharacterController>();
        lm = FindObjectOfType<LivesManager>();
        controllerHeight = controller.height;
        controllerCenter = controller.center;
        gestureListener = kinectObject.GetComponent<GestureListener>();
    }
    void Update()
    {
        

        if (CountDownTimer.hasCountDownEnded)
        {
            
            ManagerGamer.isGameStarted = true;
            
            
            anim.SetTrigger("isRunning");


            if (speed < maxSpeed)
            {
                speed += 0.1f * Time.deltaTime;
            }

            direction.z = speed;
            ManagerGamer.score = (int)scoreAmount;
            scoreAmount += direction.z * Time.deltaTime;

            if (controller.isGrounded)
            {

                if (Input.GetKeyDown(KeyCode.UpArrow)||gestureListener.isJumpGesture())
                {
                    jump();
                    anim.SetBool("isGrounded", false);
                }
            }
            else
            {
                direction.y += gravity * Time.deltaTime;
                anim.SetBool("isGrounded", true);
            }


            if (Input.GetKeyDown(KeyCode.RightArrow)||gestureListener.IsSwipeRight())
            {
                desiredLane++;
                if (desiredLane == 3)
                {
                    desiredLane = 2;
                }
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow)||gestureListener.IsSwipeLeft())
            {
                desiredLane--;
                if (desiredLane == -1)
                {
                    desiredLane = 0;
                }
            }
            if ((Input.GetKeyDown(KeyCode.DownArrow))||(gestureListener.isSwipeDown()) && !isSliding)
            {
                StartCoroutine(Slide());
            }
            Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
            if (desiredLane == 0)
            {
                targetPosition += Vector3.left * laneDistance;
            }
            else if (desiredLane == 2)
            {
                targetPosition += Vector3.right * laneDistance;
            }

            if (transform.position != targetPosition)
            {
                Vector3 diff = targetPosition - transform.position;
                Vector3 moveDir = diff.normalized * 25 * Time.deltaTime;
                if (moveDir.sqrMagnitude < diff.sqrMagnitude)
                    controller.Move(moveDir);
                else
                    controller.Move(diff);
            }

            controller.Move(direction * Time.deltaTime);

        }

    }
    
    private void jump()
    {
        direction.y = jumpForce;
        FindObjectOfType<AudioManager>().PlaySound("JumpSound");
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag == "Obstacle")
        {
            if (LivesManager.isLastObstacle)
            {

            }
            else
            {
                Destroy(hit.gameObject);
                FindObjectOfType<AudioManager>().PlaySound("Hit");
                StartCoroutine(Flash());
            }
            lm.DestroyLife();
        }
    }
    
      private IEnumerator Flash(){
        
         pointlight.gameObject.SetActive(true);
           yield return new WaitForSeconds(1.5f);
            pointlight.gameObject.SetActive(false);
      
       
    }
    

    private IEnumerator Slide()
    {
        isSliding = true;
        anim.SetBool("isSliding", true);
        FindObjectOfType<AudioManager>().PlaySound("Slide");
        controller.center = new Vector3(0, 0, 0);
        controller.height = 0.5f;
        yield return new WaitForSeconds(1.3f);

        controller.center = controllerCenter;
        controller.height = controllerHeight;
        anim.SetBool("isSliding", false);
        isSliding = false;
    }
}
