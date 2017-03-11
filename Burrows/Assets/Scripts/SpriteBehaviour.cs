using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteBehaviour : MonoBehaviour {
    

    public float speed;

    void Update()
    {
        var move = new Vector3(Input.GetAxis("Horizontal"), 0);
        if (transform.position.x > -60 && transform.position.x < 74.0)
        {
            transform.position += move * speed * Time.deltaTime * 20;
        }
        
    }

}
