using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 100f;
    bool dragging = false;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnMouseDrag()
    {
        dragging = true;
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            dragging = false;
        }
    }

    private void FixedUpdate()
    {



        if (dragging)
        {
            float x = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;

            rb.AddTorque(Vector3.down * x);
        }
    }
}
