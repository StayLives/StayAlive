using UnityEngine;

public class PlayerMoveJoystick : MonoBehaviour 
{
    public float moveSpeed = 8f;
    public Joystick joystick;
    private Animator animator;
    private float movementSpeed = 100.0f;
    private void Update()
    {
        Vector3 moveVector = (Vector3.right * joystick.Horizontal + Vector3.up * joystick.Vertical);

        if (moveVector != Vector3.zero)
        { 
            //transform.rotation = Quaternion.LookRotation(Vector3.forward, moveVector);
            transform.Translate(moveVector * moveSpeed * Time.deltaTime, Space.World);
        }
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        if (horizontal > 0)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(movementSpeed * Time.deltaTime, 0);
            animator.SetInteger("Direction", 1);
            animator.speed = 0.5f;
        }
        else if (horizontal < 0)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-movementSpeed * Time.deltaTime, 0);
            animator.SetInteger("Direction", 3);
            animator.speed = 0.5f;
        }

        // vertical movement, up or down, set animation type and speed 
        if (vertical > 0)
        {
            //transform.Translate(0, movementSpeed * 0.9f * Time.deltaTime, 0);
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, movementSpeed * Time.deltaTime);
            animator.SetInteger("Direction", 0);
            animator.speed = 0.35f;
        }
        else if (vertical < 0)
        {
            //transform.Translate(0, -movementSpeed *  0.9f * Time.deltaTime, 0);
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, -movementSpeed * Time.deltaTime);
            animator.SetInteger("Direction", 2);
            animator.speed = 0.35f;
        }
    }
}
