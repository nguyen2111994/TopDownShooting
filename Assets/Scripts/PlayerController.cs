using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]   // Tu dong them Rigidbody vao Object;  
public class PlayerController : MonoBehaviour
{
    Rigidbody playerRigidbody;
    Vector3 velocity;

    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 _velocity)
    {
        velocity = _velocity;
    }

    public void LookAt(Vector3 lookPoint)
    {
        Vector3 heightCorrectedPoint = new Vector3(lookPoint.x, transform.position.y, lookPoint.z);
        transform.LookAt(heightCorrectedPoint);
    }

    public void FixedUpdate()
    {
        playerRigidbody.MovePosition(playerRigidbody.position + velocity * Time.fixedDeltaTime);
    }
}
