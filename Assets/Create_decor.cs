using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create_decor : MonoBehaviour {

    public float m_speed = 700f;
    public GameObject m_decor;
    public Player_move m_playerScript;







    void Awake()
    {

    }

    public float GetSpeed()
    {
        return m_speed;
    }



    public void SetSpeed(float speedValue)
    {
        m_speed = speedValue;
    }

  
    public void Move(float dt)
    {

        gameObject.transform.Translate(new Vector3(0, -m_speed * dt, 0));


    }




    void Update()
    {
        Move(Time.deltaTime);

            if (transform.position.y < -5900)
            m_decor.transform.Translate(new Vector3(0, 11800, 0));
        m_speed = 1200f + m_playerScript.GetScore() * 10;


        }
    }


