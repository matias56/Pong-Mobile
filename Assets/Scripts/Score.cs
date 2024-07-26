using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private GameObject goScreen;

    private int score;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.GetComponent<BallController>()!=null)
        {
         score++;
         scoreText.text = score.ToString();
         other.gameObject.GetComponent<BallController>().ResetBall();
        }

        if(score >= 7)
        {
            other.gameObject.SetActive(false);
            goScreen.gameObject.SetActive(true);
        }
        
    }
}
