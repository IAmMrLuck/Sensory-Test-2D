using UnityEngine;

public class Movement : MonoBehaviour
{
    private bool isRunning;
    private bool isSneaking;

    public float moveSpeed = 5f; 

    public SensoryBase sensoryBase;

    private float lastFireTime;

    [SerializeField] private float interval = 0.3f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sensoryBase = GetComponent<SensoryBase>();
    }

    void Update()
    {
        // SNEAKING
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            isSneaking = true;
            moveSpeed = 2;
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            isSneaking = false;
            moveSpeed = 5;
        }

        // RUNNING
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isRunning = true;
            moveSpeed = 10;
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            isRunning= false;
            moveSpeed = 5;
        }


        GameObject currentCircle = GameObject.Find("SensoryTest");

        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector2 movement = new Vector2(horizontalInput, verticalInput).normalized;
        rb.velocity = movement * moveSpeed;

        
        // FOOTSTEPS
        if(rb.velocity.magnitude > 0)
        {
            if(isSneaking == true)
            {
                if (Time.time - lastFireTime >= interval)
                {
                    sensoryBase.CreateCircle(5);
                    lastFireTime = Time.time;
                }
            }

            if (isRunning == true)
            {
                if (Time.time - lastFireTime >= interval)
                {
                    sensoryBase.CreateCircle(20);
                    lastFireTime = Time.time;
                }
            }


            if (Time.time - lastFireTime >= interval)
            {
                sensoryBase.CreateCircle(10);
                lastFireTime = Time.time;
            }
        }
    }
}
