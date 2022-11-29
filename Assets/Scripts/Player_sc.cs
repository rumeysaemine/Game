using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_sc : MonoBehaviour
{
    public float speed = 1f;
    Canvas ana_kanvas;
    public bool pause = false;
    private bool x = false;

    [SerializeField]
    Bridge_sc bridgeScript;
    // Start is called before the first frame update
    void Start()
    {
        ana_kanvas = GameObject.FindObjectOfType<Canvas>();
        ana_kanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxisRaw("Cancel") != 0)
        {   
            if(x == false)
            {
                ana_kanvas.enabled = !ana_kanvas.enabled;
                if (pause)
                {
                    Time.timeScale = 1;
                    pause = false;
                }
                else
                {
                    Time.timeScale = 0;
                    pause = true;
                }
                x = true;
            }      
        }
        
        if(Input.GetAxisRaw("Cancel") == 0)
        {
            x = false;
        } 
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Target"){
            speed = 0f;
        }   
    }

    public void ResumeGame()
    {
        if (pause)
        {
            Time.timeScale = 1;
            pause = false;
        }
        else
        {
            Time.timeScale = 0;
            pause = true;
        }
        ana_kanvas.enabled = false;
    }
    
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        ResumeGame();

    }
      
}
