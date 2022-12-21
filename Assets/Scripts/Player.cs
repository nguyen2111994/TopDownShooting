using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))] // Tu add them playerController scripts vao. 
public class Player : MonoBehaviour
{
    PlayerController controller;
    public float moveSpeed = 5f;

    Camera viewCamera;

    private void Start()
    {
        controller = GetComponent<PlayerController>();
        viewCamera = Camera.main;
    }

    private void Update()
    {
        Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        Vector3 moveVelocity = moveInput.normalized * moveSpeed;
        controller.Move(moveVelocity);

        Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition); // Ve ra mot Duong Thang tu Camera den con cho chuot;
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero); // Ve ra mot Mat Phang ;
        float rayDistance;

        if(groundPlane.Raycast(ray, out rayDistance))
        {
            Vector3 point = ray.GetPoint(rayDistance);
            Debug.DrawLine(ray.origin, point, Color.red);
            controller.LookAt(point);
        }
    }

}
