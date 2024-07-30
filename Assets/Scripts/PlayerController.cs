using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float _speed = 6;
    [SerializeField] private float _jumpForce = 250;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float distance = 1.5f;
    [SerializeField] private Camera cam;
    private bool survival = true;

    /*
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, Vector3.down*distance);
    }
    */

    // Update is called once per frame
    private void FixedUpdate()
    {
        var vel = (cam.transform.forward * Input.GetAxis("Vertical") + cam.transform.right * Input.GetAxis("Horizontal")) * _speed;
        if (survival)
        {
            vel.y = _rb.velocity.y;
        }
        _rb.velocity = vel;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            Ray _raycast = new Ray(transform.position, Vector3.down * distance);

            if (Physics.Raycast(_raycast, 1f))
            {
                _rb.AddForce(Vector3.up * _jumpForce);
            }
        }

        if (Input.GetKeyDown(KeyCode.G))
        {

            survival = !survival;
            _rb.useGravity = survival;

        }
    }

}
