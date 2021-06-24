using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
	public GameObject Player;
	public Vector2 followOffset;
	private Vector2 ThereShold;
	private Rigidbody2D rb;
	public float speed;

	// Use this for initialization
	void Start () {
		ThereShold = calculateThereShold ();
		rb = Player.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector2 Follow = Player.transform.position;
		float xDifference = Vector2.Distance (Vector2.right * transform.position.x, Vector2.right * Follow.x);
		float yDifference = Vector2.Distance (Vector2.up * transform.position.y, Vector2.up * Follow.y);

		Vector3 newPosition = transform.position;
		if (Mathf.Abs (xDifference) >= ThereShold.x) {
			newPosition.x = Follow.x;
		}
		if (Mathf.Abs (yDifference) >= ThereShold.y) {
			newPosition.y = Follow.y;
		}
		float movementSpeed = rb.velocity.magnitude > speed ? rb.velocity.magnitude : speed;
		transform.position = Vector3.MoveTowards (transform.position, newPosition, movementSpeed * Time.deltaTime);
	}

	private Vector3 calculateThereShold(){
		Rect aspect = Camera.main.pixelRect;
		Vector2 t = new Vector2 (Camera.main.orthographicSize * aspect.width / aspect.height, Camera.main.orthographicSize);
		t.x -= followOffset.x;
		t.y -= followOffset.y;
		return t;
	}

	private void OnDrawGizmos (){
		Gizmos.color = Color.blue;
		Vector2 border = calculateThereShold ();
		Gizmos.DrawWireCube (transform.position, new Vector3 (border.x * 2, border.y * 2, 1));
	}
}
