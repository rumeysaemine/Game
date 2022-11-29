using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge_sc : MonoBehaviour
{
    public bool turn;
    public int turnCount = 1;
    public float bridgeLength;
    public bool control = false;

    [SerializeField]
    private GameObject playerControl;
    
    Player_sc playerScript;
    
    // Start is called before the first frame update
    void Start()
    {
        playerScript = playerControl.GetComponent<Player_sc>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetAxisRaw("Jump") == 1f && turnCount == 1)
        {
            transform.localScale += new Vector3(0f,0.2f,0f);
            
        } 

        else if(Input.GetAxisRaw("Jump") == -1f)
        {
            turn = true;
            if(turn == true && turnCount == 1)
            {
                transform.rotation = transform.rotation * Quaternion.Euler(0,0,-90);
                turn = false;
                turnCount -= 1;             
            }
        } 

        if(turnCount == 0)
        {
            playerControl.transform.Translate(Vector3.right * Time.deltaTime * playerScript.speed);      
        }
           
    }
 
}
