using UnityEngine;

public class EndTrigger : MonoBehaviour
{
	private void OnTriggerEnter()
	{
		//Debug.Log("End");
		FindAnyObjectByType<GameManager>().CompleteLevel();
	}
}
