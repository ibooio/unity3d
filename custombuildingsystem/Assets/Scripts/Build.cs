using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity​Engine.EventSystems;

public class Build : MonoBehaviour
{

    public float posY = 1.35f;
    public GameObject house;
    public GameObject bigHouse;


    #nullable enable
    public GameObject? build;
    #nullable disable

    public void addHouse(){
        Debug.Log("House");
        if( build != null )
            Destroy(build);
        build = Instantiate(house, new Vector3(0, 0, 0), Quaternion.identity);
    }

    public void addBigHouse(){
        Debug.Log("Big House");
        if( build != null )
            Destroy(build);
        build = Instantiate(bigHouse, new Vector3(0, 0, 0), Quaternion.identity);
    }

    void Update()
    {
        if( build != null ){
            //Debug.Log("EXIT!!");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if( Physics.Raycast(ray, out hit, Mathf.Infinity) ){
                int posX = (int)Mathf.Round(hit.point.x); 
                int posZ = (int)Mathf.Round(hit.point.z);
                //Debug.Log(posX +','+ posZ);
                build.transform.position = new Vector3(posX, posY, posZ);
            }


            if (  Input.GetMouseButtonDown(0)  && !EventSystem.current.IsPointerOverGameObject() ){

                    Instantiate(build, build.transform.position, Quaternion.identity);
                    Destroy(build);
                
            }
        }
        else{
            //Debug.Log("NULL");
        }

    }

}
