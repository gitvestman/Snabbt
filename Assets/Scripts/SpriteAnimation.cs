using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimation : MonoBehaviour {

    [SerializeField] SpriteRenderer sprite;
    [SerializeField] Sprite[] sprites;
    [SerializeField] float speed;

    int index;
    float timer;

	// Use this for initialization
	void Start () {
        index = 0;
        timer = speed;
	}
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            timer = speed;
            index++;

            if (index >= sprites.Length)
                index = 0;

            sprite.sprite = sprites[index];
        }
	}
}
