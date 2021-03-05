using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreController : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    private int Score = 0;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void increaseScore(int increment)
    {
        Score += increment;
        scoreText.text = "Score: " + Score.ToString();
    }

}
