using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawMover : MonoBehaviour
{

    public float speed;
    public float minLimit;
    public float maxLimit;
    public float Ylim;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(speed *  Time.deltaTime , 0 ,0 );
        if(transform.position.x >= maxLimit)
        {
           speed *= -1;
        }
        if (transform.position.x <= minLimit)
        {
            speed *= -1;
        }
        
    }
}
