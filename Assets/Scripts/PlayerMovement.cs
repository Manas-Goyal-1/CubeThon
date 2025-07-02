using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
	public Rigidbody rb;

	public float forwardForce = 675f;
	public float sideForce = 6f;
	public float jumpForce = 100f;

	public int numJumps = 10;
	bool onGround = true;

	// FixedUpdate because we are changing physics.
	void FixedUpdate()
	{

		rb.AddForce(0, 0, forwardForce * Time.deltaTime);

		if (Keyboard.current.dKey.isPressed)
			rb.AddForce(sideForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);

		if (Keyboard.current.aKey.isPressed)
			rb.AddForce(-sideForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);

		if (Keyboard.current.spaceKey.isPressed)
		{
			if (numJumps > 0 && onGround)
			{
				onGround = false;
				numJumps--;
				rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
				Debug.Log("Jumps: " + numJumps);
			}
			else
			{
				Debug.Log("onGround: " + onGround);
			}
		}

		if (rb.linearVelocity.y < 0)    // If falling down, fall slower
		{
			rb.linearVelocity -= Vector3.up * rb.linearVelocity.y * 0.025f;	// Dampens down yVelocity to 0.8 times itself when falling.
		}

		if (rb.position.y <= -3)	// If falling under the ground, die.
			FindAnyObjectByType<GameManager>().EndGame();

		//Debug.Log(rb.linearVelocity);
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.CompareTag("Ground"))
			onGround = true;
		Debug.Log(collision.collider.tag + " " + collision.collider.tag + " " + onGround);
	}
}


