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
        if( build != null )
            Destroy(build);
        build = Instantiate(house, new Vector3(0, 0, 0), Quaternion.identity);
    }

    public void addBigHouse(){
        if( build != null )
            Destroy(build);
        build = Instantiate(bigHouse, new Vector3(0, 0, 0), Quaternion.identity);
    }

    void Update()
    {
        if( build != null ){
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if( Physics.Raycast(ray, out hit, Mathf.Infinity) ){
                build.transform.position = new Vector3((int)Mathf.Round(hit.point.x), posY, (int)Mathf.Round(hit.point.z));
            }

            if (  Input.GetMouseButtonDown(0)  && !EventSystem.current.IsPointerOverGameObject() ){
                Instantiate(build, build.transform.position, Quaternion.identity);
                Destroy(build);
            }
        }
    }

}
