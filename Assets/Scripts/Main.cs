using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {

    [SerializeField] GameObject[] Enemies;
    [SerializeField] GUIText ScoreText;
    float timer;
    float speed = 5f;
    int score;

    void Start () {
        timer = speed;
        score = 0;
	}

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            timer = speed;
            int enemy = Random.Range(0, 2);
            float positionx = Random.Range(-5, 5);
            float positiony = Random.Range(-5, 5);
            GameObject go = Instantiate(Enemies[enemy]) as GameObject;
            go.transform.position = new Vector3(positionx, positiony, 0);
            Debug.Log("Create Enemy " + go.transform.position);
        }
    }

    public void UpdateScore(int scoreDelta)
    {
        Debug.Log("UpdateScore " + scoreDelta);
        score += scoreDelta;
        ScoreText.text = "Score: " + score.ToString();
    }
}
