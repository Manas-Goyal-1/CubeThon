using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

	bool gameOver;
	public float restartDelay = 1f;

	public GameObject completeLevelUI;

	public void CompleteLevel()
	{
		completeLevelUI.SetActive(true);
	}

	public void EndGame()
	{
		if (!gameOver)
		{
			gameOver = true;
			//Debug.Log("Game over");
			Invoke("Restart", restartDelay);
		}
	}


	void Restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}


