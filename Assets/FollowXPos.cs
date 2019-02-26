using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowXPos : MonoBehaviour {
    public GameObject m_objectToFollow;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(m_objectToFollow.transform.position.x, transform.position.y, transform.position.z);
	}
}
