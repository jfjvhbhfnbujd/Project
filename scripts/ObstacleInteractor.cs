using System.Collections;
using System.Collections.Generic;
using UnityEngine;














public class ObstacleInteractor : MonoBehaviour
{
    public float speed;
    //This Script is meant to go on obstacles
    //
    //
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);
    }
    
}
