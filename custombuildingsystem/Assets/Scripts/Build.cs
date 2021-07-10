using UnityEngine;
using Unity​Engine.EventSystems;

public class Build : MonoBehaviour
{

    public int gridWidth;
    public int gridHeight;
    public Material gridLineMaterial;

    public BuildingGrid grid;

    public float posY = 1.35f;
    public GameObject house;
    public GameObject bigHouse;

    #nullable enable
    public GameObject? build;
    #nullable disable

    void Start()
    {
        grid = new BuildingGrid(gridWidth, gridHeight, gridLineMaterial);
        grid.draw();

    }

    public void addHouse(){
        if( build != null )
            Destroy(build);
        build = Instantiate(house, new Vector3(0, 0, 0), Quaternion.identity);
        grid.setBuild(build);
    }

    public void addBigHouse(){
        if( build != null )
            Destroy(build);
        build = Instantiate(bigHouse, new Vector3(0, 0, 0), Quaternion.identity);
        grid.setBuild(build);
    }

    void Update()
    {
        if( build != null ){
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if( Physics.Raycast(ray, out hit, Mathf.Infinity) ){
                grid.calculateBuildPosition(hit);
            }

            if (  Input.GetMouseButtonDown(0)  && !EventSystem.current.IsPointerOverGameObject() ){
                Instantiate(build, build.transform.position, Quaternion.identity);
                grid.saveBuild();
                Destroy(build);
            }
        }
    }

}
