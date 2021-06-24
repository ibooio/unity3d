using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    /*[SerializeField] float x = 0.5f;
    [SerializeField] float y = 0.5f;
    float rotacion = 5f;*/
    float velocidad =5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(x*Time.deltaTime,y*Time.deltaTime,0);
        //transform.Rotate(0,rotacion*Time.deltaTime,0);
        float aceleracion = Input.GetAxis("Vertical")*Time.deltaTime*velocidad;
        transform.Translate(aceleracion,0,0);

        if(Input.GetKey(KeyCode.LeftArrow)){
            transform.Rotate(Vector3.down*Time.deltaTime*300, Space.Self);
        }
        else if(Input.GetKey(KeyCode.RightArrow)){
            transform.Rotate(Vector3.up*Time.deltaTime*300, Space.Self);
        }
    }
}
