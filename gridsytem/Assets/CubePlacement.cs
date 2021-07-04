using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePlacement : MonoBehaviour
{

    public GameObject objToMove;
    public GameObject objToPlace;
    public LayerMask mask;
    public float LastPosY;
    public Vector3 mousePos;
    public Renderer rend;
    public Material matGrid, matDefault;


    // Start is called before the first frame update
    void Start()
    {
        rend = GameObject.Find("Ground").GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(mousePos);
        RaycastHit hit;

        if( Physics.Raycast(ray, out hit, Mathf.Infinity, mask) ){
            int posX = (int)Mathf.Round(hit.point.x); 
            int posZ = (int)Mathf.Round(hit.point.z);
            //Debug.Log(posX +','+ posZ);
            objToMove.transform.position = new Vector3(posX, LastPosY, posZ);
            //rend.material = matGrid;
        }


        if (  Input.GetMouseButtonDown(0) ){
            
            Instantiate(objToPlace, objToMove.transform.position, Quaternion.identity);
            //Destroy(gameObject);
            //rend.material = matDefault;
        }

    }
}
