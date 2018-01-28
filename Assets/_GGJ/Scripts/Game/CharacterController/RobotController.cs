using UnityEngine;

[RequireComponent(typeof(GravityBody))]
public class RobotController : MonoBehaviour
{
    public float walkSpeed = 6;
    public float rotateSpeed = 45f;
    //public float jumpForce = 220;
    public LayerMask groundedMask;
    public bool canMove = true;
    public Animator animator;
    public GameObject map;

    public AudioClip walk;

    // System vars
    private bool grounded;
    private Vector3 moveAmount;
    private Vector3 smoothMoveVelocity;
    private float verticalLookRotation;
    private Transform cameraTransform;
    private Rigidbody rigidBody;
    private AudioSource aSource;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
        aSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (!canMove)
            return;

        // Calculate movement:
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");

        Vector3 moveDir = Vector3.forward * inputY;
        Vector3 targetMoveAmount = moveDir * walkSpeed;
        moveAmount = Vector3.SmoothDamp(moveAmount, targetMoveAmount, ref smoothMoveVelocity, .15f);

        if (animator)
            animator.SetFloat("Speed", Mathf.Abs(inputY));

        if (Mathf.Abs(inputY) > 0.1f)
        {
            aSource.volume = 1;
        }
        else
        {
            aSource.volume = 0;
        }

        transform.Rotate(0.0f, inputX * rotateSpeed * Time.deltaTime, 0.0f);

        // Grounded check
        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1 + .1f, groundedMask))
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            if (!GameManager.Instance.canShowMap)
                return;

            if (map.activeSelf)
                map.SetActive(false);
            else
                map.SetActive(true);
        }

    }

    void FixedUpdate()
    {
        if (!canMove)
            return;

        // Apply movement to rigidBody
        Vector3 localMove = transform.TransformDirection(moveAmount) * Time.fixedDeltaTime;
        rigidBody.MovePosition(rigidBody.position + localMove);
    }
}
