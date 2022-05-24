using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickTouched : MonoBehaviour
{
    protected Joystick joystick;

    void Start()
    {
        
    }
    private void Awake()
    {
        joystick = GameObject.FindObjectOfType<Joystick>().GetComponent<FixedJoystick>();
    }
    // Update is called once per frame
    void Update()
    {
        if (joystick.Horizontal != 0 || joystick.Vertical !=0)
        {
            Destroy(GameObject.FindGameObjectWithTag("Triger"));
        }
    }
}
