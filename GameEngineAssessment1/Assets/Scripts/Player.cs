using InputNamespace;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Player : Collidable
{
    [SerializeField]
    GameObject crosshair;
    //Move to base class for similar objects
    Rigidbody2D rb;
    Collider2D col;
    Vector3 velocity = Vector3.zero;
    bool CanRotate = true;
    [SerializeField]
    Projectile projectile;
    // Use this for initialization
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        col = gameObject.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        InputManager.currentControls.Update();
        if (Input.GetKeyDown(KeyCode.Tab))
            CanRotate = !CanRotate;
        crosshair.transform.position = new Vector3(FindObjectOfType<Camera>().ScreenToWorldPoint(Input.mousePosition).x, FindObjectOfType<Camera>().ScreenToWorldPoint(Input.mousePosition).y);
    }

    private void FixedUpdate()
    {
        if (InputManager.currentControls.moveFoward.IsPressed())
            velocity.y += 1 * Time.deltaTime;
        if (InputManager.currentControls.moveBack.IsPressed())
            velocity.y -= 1 * Time.deltaTime;
        if (CanRotate)
        {
            if (InputManager.currentControls.turnLeft.IsPressed())
                gameObject.transform.Rotate(new Vector3(0, 0, 5));
            if (InputManager.currentControls.turnRight.IsPressed())
                gameObject.transform.Rotate(new Vector3(0, 0, -5));
        }
        else
        {
            if (InputManager.currentControls.moveLeft.IsPressed())
                velocity.x -= 1 * Time.deltaTime;
            if (InputManager.currentControls.moveRight.IsPressed())
                velocity.x += 1 * Time.deltaTime;
        }
        if(InputManager.currentControls.shoot.IsDown())
        {
            Vector3 mousePos = FindObjectOfType<Camera>().ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            print(mousePos);
            Vector2 trajectory = new Vector2(mousePos.x - gameObject.transform.position.x, mousePos.y - gameObject.transform.position.y);
            trajectory.Normalize();
            double angle = Math.Atan2(trajectory.y, trajectory.x);
            Projectile p = Instantiate(projectile, transform.position, Quaternion.Euler(new Vector3(0, 0, -90 + (float)angle * Mathf.Rad2Deg)));
        }
        velocity *= 0.8f;
        gameObject.transform.position += CanRotate? gameObject.transform.rotation * velocity : velocity;
    }
}
