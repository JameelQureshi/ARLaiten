using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternManager : MonoBehaviour
{
    public bool move = false ;
    float x=0;
    float z=0;
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
        x = Random.Range(-0.01f,0.01f);
        z = Random.Range(-0.01f,0.01f);

    }
}
