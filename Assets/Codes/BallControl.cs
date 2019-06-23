using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallControl : MonoBehaviour {

    Rigidbody ball;
    public int speed;
    public int ObjectsToBeCollected;
    int score = 0;
    public Text scoreBoard;
    public Text gameOverText;

	void Start () {
        ball = GetComponent<Rigidbody>();
	}
	
	void FixedUpdate () {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 vec = new Vector3(horizontal,0,vertical);
        ball.AddForce(vec * speed);


	}

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "goal")
        {
            other.gameObject.SetActive(false);
            score++;
            scoreBoard.text = "Score = "+score;

            if(score == ObjectsToBeCollected)
            {
                gameOverText.text = "Game Over!";
            }

        }
    }
}
