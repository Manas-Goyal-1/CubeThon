using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public Transform player;

    // Update is called once per frame
    void Update()
    {
        scoreText.text = player.position.z.ToString("0");
    }
}
