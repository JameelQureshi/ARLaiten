using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternManager : MonoBehaviour
{
    public bool move = false ;
    float x=0.1f;
    float z=0.1f;
    // Update is called once per frame
    void Update()
    {
        if (move)
        {
            transform.position = new Vector3(transform.position.x+x*Time.deltaTime*TapToPlaceManager.speed,transform.position.y+0.1f * Time.deltaTime * TapToPlaceManager.speed, transform.position.z+z * Time.deltaTime * TapToPlaceManager.speed);

        }
    }
    public void Fly()
    {

        move = true;
        if (Random.Range(0,100)%2==0)
        {
            x = -x;
           
        }
        if (Random.Range(0, 100) % 2 == 0)
        {
            z = -z;

        }

    }
}
