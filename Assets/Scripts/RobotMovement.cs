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

    private Vector3 direction;
    private Vector3 lookDirection;
    Plane plane = new Plane(Vector3.up, Vector3.zero);
    float distance;


    //[SerializeField]
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }
    private void Update()
    {
        direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;

        if(Input.GetKey(KeyCode.LeftShift))
            direction.z = direction.z > 0 ? direction.z * forwardMultiplier : direction.z;

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
        rb.AddRelativeForce(direction * speed * Time.fixedDeltaTime, ForceMode.Acceleration);

    }
}
