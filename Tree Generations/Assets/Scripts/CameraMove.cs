using UnityEngine;

public class CameraMove : MonoBehaviour {

    public float speed, smoothing;

    Vector3 targetPosition;
    Vector2 targetMovement;

	void Start () {
        targetPosition = transform.position;
        targetMovement = Vector2.zero;
	}
	
	void Update () {
        targetMovement.x = Input.GetAxisRaw("Horizontal");
        targetMovement.y = Input.GetAxisRaw("Vertical");
        targetMovement.Normalize();

        targetPosition.x += targetMovement.x * speed;
        targetPosition.z += targetMovement.y * speed;

        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
	}
}
