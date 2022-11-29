using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star_sc : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation *= Quaternion.Euler(new Vector3(0,0,45 * 0.05f));
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);  
    }
   
}
