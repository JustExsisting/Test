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
        if (Input.touchCount == 1) SetTarget(); //Для сеснора

        if (Input.GetMouseButtonDown(0)) SetTarget();//Для мыши
        if (target) transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        
        rb.velocity = new Vector3(joystick.Horizontal * speed,//Для джойстика
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
            if (hit.collider == null) return; //если ничего ничего не задели -> выход

            if (target) Destroy(target.gameObject); //уделение точки, если кликнули 2ой раз

            GameObject newTarget = Instantiate(Resources.Load("Point"), hit.point, Quaternion.identity) as GameObject; //создание новой точки для движения

            target = newTarget.transform;
        }
    }
}
