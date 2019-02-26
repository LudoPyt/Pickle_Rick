using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Object_poping : MonoBehaviour
{
    public Player_move m_playerScript;
    public GameObject m_cafard;
    public GameObject m_rat;
    public GameObject m_bonus;
    public GameObject m_hole;
    private float m_previousx;
    private float m_previousy;
    public float m_max_xpos = 3375;
    public float m_min_xpos = -3375;
    public float m_max_ypos = 2500;
    public float m_min_ypos = 2000;
    public float m_timeToPop = 1f;
    private float m_chrono = 0.75f;


    // Use this for initialization
    void Awake()
    {

    }


    // Update is called once per frame
    void Update()
    {
        m_chrono += Time.deltaTime;
        if (m_chrono > m_timeToPop)
        {
            int pos_obj = Random.Range(0, 5);
            float random_x = Random.Range(m_min_xpos, m_max_xpos);
            float random_y = Random.Range(m_min_ypos, m_max_ypos);
            if (Mathf.Abs(random_x - m_previousx) > 750)
            {
                if (Mathf.Abs(random_y - m_previousy) > 500)
                {
                    if (pos_obj == 0)
                    {
                        GameObject cafard = Instantiate(m_cafard);
                        Enemy_move currentCM = cafard.GetComponent<Enemy_move>();
                        currentCM.m_speed = 1000f + m_playerScript.GetScore()*10;
                        cafard.transform.position = new Vector3(random_x, 2500, 0);
                       
                    }
                    if (pos_obj == 1)
                    {
                        GameObject rat = Instantiate(m_rat);
                        Enemy_move currentRM = rat.GetComponent<Enemy_move>();
                        currentRM.m_speed = 1500f + m_playerScript.GetScore()*10; 
                        rat.transform.position = new Vector3(random_x, 2500, 0);

                    }
                    if (pos_obj == 2)
                    {
                        GameObject coin = Instantiate(m_bonus);
                        Enemy_move currentCoM = coin.GetComponent<Enemy_move>();
                        currentCoM.m_speed = 1200f + m_playerScript.GetScore()*10; 
                        coin.transform.position = new Vector3(random_x, 2500, 0);


                    }

                    m_chrono = 0f;
                    m_previousx = random_x;
                    m_previousy = random_y;
                }
            }

        }
       
    }
}
