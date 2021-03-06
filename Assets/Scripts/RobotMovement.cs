using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float forwardMultiplier = 1.5f;

    [SerializeField]
    Animator animator;

    Vector3 direction;
    [HideInInspector]public bool isSprinting;       //if true, energy is spent -added by King
    private Vector3 lookDirection;
    Plane plane = new Plane(Vector3.up, Vector3.zero);
    float distance;

    //singletons -added by King
    public static RobotMovement instance;
    GameManager gm;
    Player player;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
    }


    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = Player.instance; 
        gm = GameManager.instance;
    }
    private void Update()
    {
        direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;

        if(Input.GetKey(KeyCode.LeftShift) && player.energy > 0)
        {           
            direction.z = direction.z > 0 ? direction.z * forwardMultiplier : direction.z;

            //sprint check -added by King
            if (direction.z > 0)
            {
                isSprinting = true;
            }
            /*else
            {
                isSprinting = false;
            }*/
        }

        //added by King
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            isSprinting = false;
        }

        animator.SetFloat("FrontMovement", direction.z);
        animator.SetFloat("SideMovement", direction.x);

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (plane.Raycast(ray, out distance))
        {
            Vector3 target = ray.GetPoint(distance);
            Vector3 direction = target-transform.position;
            float rotation = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, rotation, 0);
        }

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (!gm.gamePaused)
        {
            rb.AddRelativeForce(direction * speed * Time.fixedDeltaTime, ForceMode.Acceleration);
        }

    }
}
