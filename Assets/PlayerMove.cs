using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Transform target;
    public float speed;

    protected Joystick joystick;
    private Rigidbody rb;
    void Update()
    {
        if (Input.touchCount == 1)
            SetTarget();

        if (Input.GetMouseButtonDown(0)) SetTarget();
        if (target) transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        rb.velocity = new Vector3(joystick.Horizontal * speed,
                          rb.velocity.y,
                          joystick.Vertical * speed);
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        joystick = GameObject.FindObjectOfType<Joystick>().GetComponent<FixedJoystick>();
    }

    void SetTarget()
    {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
        {
            if (hit.collider == null) return;

            if (target) Destroy(target.gameObject);

            GameObject newTarget = Instantiate(Resources.Load("Point"), hit.point, Quaternion.identity) as GameObject;

            target = newTarget.transform;
        }
    }
}
