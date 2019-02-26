using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_move : MonoBehaviour
{

    public float m_speed = 0f;

    
  

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
        if (transform.position.y < -4500){
            Destroy(gameObject);
        }
    }

}