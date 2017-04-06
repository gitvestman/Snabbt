using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IFollowable
{
    [SerializeField] Rigidbody2D body;
    [SerializeField] float speed;
    GameObject Follower;

    GameObject IFollowable.AddFollower(GameObject Follower)
    {
        Debug.Log("Player AddFollower " + Follower.name);
        if (this.Follower != null)
        {
            IFollowable FollowerComponent = this.Follower.GetComponent<Enemy>();
            return FollowerComponent.AddFollower(Follower);
        }
        else
        {
            this.Follower = Follower;
            return gameObject;
        }
    }

    void Start ()
    {

	}
	
	void Update ()
    {
        var direction = Vector2.zero;
	    if (Input.GetKey(KeyCode.A))
        {
            direction.x -= 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction.x += 1;
        }
        if (Input.GetKey(KeyCode.W))
        {
            direction.y += 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction.y -= 1;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            body.AddForce(new Vector2(0, 200));
        }
        body.AddForce(direction * speed);
    }
}
