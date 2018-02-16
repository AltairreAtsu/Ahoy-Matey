using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField]
    [Tooltip ("The Speed at which the ship travels.")]
    private float maxSpeed = 1;
    [SerializeField]
    [Tooltip ("The Speed at which the ship accelerates.")]
    private float acceleration = 0.5f;
    [SerializeField]
    [Tooltip ("The speed at which the ship rotates.")]
    private float rotationSpeed = 5f;

    private float travelSpeed = 0f;
    private Rigidbody rb = null;

	void Start ()
    {
        rb = GetComponent<Rigidbody>();
	}
	
	private void FixedUpdate ()
    {
        MoveRotation();
        MoveShip();
    }

    private void MoveShip()
    {
        float newTravelSpeed = travelSpeed + (Input.GetAxis("Vertical") * acceleration) * Time.deltaTime;
        travelSpeed = Mathf.Clamp(newTravelSpeed, 0f, maxSpeed);

        Vector3 dirrection = transform.right * newTravelSpeed;

        rb.MovePosition(transform.position + dirrection);
    }

    private void MoveRotation()
    {
        float yRotation = (Input.GetAxis("Horizontal") * rotationSpeed) * Time.deltaTime;

        Vector3 eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + yRotation, transform.eulerAngles.z);
        Quaternion rotation = Quaternion.Euler(eulerAngles);

        rb.MoveRotation(rotation);
    }
}
