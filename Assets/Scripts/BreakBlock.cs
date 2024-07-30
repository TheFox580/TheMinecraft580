using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BreakBlock : MonoBehaviour
{

    [SerializeField] private float distance = 3f;
    [SerializeField] private Camera cam;
    //void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawRay(transform.position, cam.transform.forward * distance);
    //}

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray _raycast = new Ray(transform.position, cam.transform.forward * distance);

            RaycastHit hit;

            if (Physics.Raycast(_raycast, out hit, distance))
            {
                Destroy(hit.transform.gameObject);
            }
        }

        
    }
}
