using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed;
    protected Joystick joystick;
    private Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {

    }

    private void Awake() 
    {
        rb = GetComponent<Rigidbody>();
        joystick = GameObject.FindObjectOfType<Joystick>().GetComponent<FixedJoystick>();


    }
    // Update is called once per frame 
    void Update()
    {
        rb.velocity = new Vector3(joystick.Horizontal * speed,
                                  rb.velocity.y,
                                  joystick.Vertical * speed);
    }
}

