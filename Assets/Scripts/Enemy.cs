using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IFollowable
{

    GameObject Follower;
    GameObject Following;
    [SerializeField] Rigidbody2D body;
    [SerializeField] float speed;

    Main Main;

    // Use this for initialization
    void Start () {
        Follower = null;
        Following = null;
        GameObject MainObject = GameObject.FindWithTag("Main");
        Main = MainObject.GetComponent<Main>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Following != null)
        {
            Vector3 target = Following.transform.position;
            Vector3 diff = target - transform.position;
            diff.Normalize();
            body.AddForce(diff);
        }
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (Following == null)
        {
            Debug.Log("Collision " + col.gameObject.name);
            IFollowable FollowingComponent = col.gameObject.GetComponent<Enemy>();
            if (FollowingComponent == null)
            {
                FollowingComponent = col.gameObject.GetComponent<Player>();
                Main.UpdateScore(1);
            }
            if (FollowingComponent != null)
                Following = FollowingComponent.AddFollower(gameObject);
        }
    }

    GameObject IFollowable.AddFollower(GameObject Follower)
    {
        Debug.Log("Enemy AddFollower " + Follower.name);
        if (this.Follower != null)
        {
            IFollowable FollowerComponent = this.Follower.GetComponent<Enemy>();
            if (FollowerComponent == null)
            {
                FollowerComponent = this.Follower.GetComponent<Player>();
            }
            return FollowerComponent.AddFollower(Follower);
        }
        else
        {
            this.Follower = Follower;
            return gameObject;
        }
    }
}
