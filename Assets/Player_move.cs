using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Player_move : MonoBehaviour
{
    private int m_energy; 
    public float m_speed = 1500f;
    public float m_score;
    public GameObject m_bonus;
    private float posZOffset = 15f;
    private float maxZ = 20f;
    private float minZ = -20f;





    void Awake()
    {
        m_energy = 10;
        m_score = 0;

    }
    public int GetEnergy()
    {
        return m_energy;
    }

    public float GetSpeed()
    {
        return m_speed;
    }

    public float GetScore()
    {
        return m_score;
    }

    public void SetEnergy(int energyValue)
    {
        m_energy = energyValue;
    }

    public void SetSpeed(float speedValue)
    {
        m_speed = speedValue;
    }

    public void SetScore(float scoreValue)
    {
        m_score = scoreValue;
    }

    public void Move(float dt)
    {
        float currentRotationZ = gameObject.transform.rotation.eulerAngles.z;

        if (Input.GetKey(KeyCode.LeftArrow) && gameObject.transform.position.x > -3500)
        {
            gameObject.transform.position= new Vector3(gameObject.transform.position.x -m_speed * Time.deltaTime, gameObject.transform.position.y, gameObject.transform.position.z);
            if (currentRotationZ < maxZ)
            {
                gameObject.transform.Rotate(new Vector3(0, 0, +posZOffset) * Time.deltaTime);
            }

        }
        else if (Input.GetKey(KeyCode.RightArrow) && gameObject.transform.position.x < 3500)
        {
            gameObject.transform.position= new Vector3(gameObject.transform.position.x +m_speed * Time.deltaTime, gameObject.transform.position.y, gameObject.transform.position.z);

            if (currentRotationZ > minZ)
            {
                gameObject.transform.Rotate(new Vector3(0, 0, -posZOffset) * Time.deltaTime);
            }
        }
        else {
          
            gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
        }
     
    }

    void DestroyGameObject()
    {
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D other)

    {
        if (other.gameObject.tag == "Enemy")
        {
            SetEnergy(m_energy -= 10);

            Image_script.Blur();


        }

        if (other.gameObject.tag == "Coin")
        {
              SetScore(m_score += 10f);
            Destroy(other.gameObject);

        }

        if (m_energy <= 0) {
            SceneManager.LoadScene("Gameover");




}
    }
   

    void Update()
    {
        Move(Time.deltaTime);
        m_score += Time.deltaTime * 6;

       
   
    }
}









