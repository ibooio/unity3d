
using UnityEngine;
using System.Collections.Generic;

public class BuildArea{
    public float x1;
    public float x2;
    public float y1;
    public float y2;

    public BuildArea(float x1, float y1, float x2, float y2){
        this.x1 = x1;
        this.y1 = y1;
        this.x2 = x2;
        this.y2 = y2;
    }



}

public class BuildingGrid
{
    private int width;
    private int height;

    private Material lineMaterial;

    private GameObject build;
    private Transform area;

    private Color original;

    private List<BuildArea> builds;

    public BuildingGrid(int width, int height, Material lineMaterial)
    {
        this.width = width;
        this.height = height;
        this.lineMaterial = lineMaterial;
        this.builds =  new List<BuildArea>();
    }

    public void draw(){

        for(var i=0; i<width; i++){
            drawLine(new Vector3(i,0,0), new Vector3(i,0,height));
        }
        for(var j=0; j<height; j++){
            drawLine(new Vector3(0,0,j), new Vector3(width,0,j));
        }

    }

    private void drawLine(Vector3 start, Vector3 end){
        GameObject line = new GameObject("line");
        line.transform.position = new Vector3(0,0,0);
        line.AddComponent<LineRenderer>();

        LineRenderer lr = line.GetComponent<LineRenderer>();
        lr.material = lineMaterial;
        lr.startColor = Color.white;
        lr.endColor = Color.white;
        lr.startWidth = .1f;
        lr.endWidth = .1f;
        lr.SetPosition(0, start); 
        lr.SetPosition(1, end);
    }

    public void setBuild(GameObject build){
        this.build = build;
        this.area = build.transform.Find("area");
        
        this.area.localScale = new Vector3(this.area.lossyScale.x+2, this.area.lossyScale.y+2, this.area.lossyScale.z);
    }

    public void calculateBuildPosition(RaycastHit hit){
      


        build.transform.position = new Vector3((int)Mathf.Round(hit.point.x), 1.35f, (int)Mathf.Round(hit.point.z));

        Vector3 position = area.position;
        Vector3 scale = area.lossyScale;
        Vector3 v1 = new Vector3( position.x - scale.x/2, position.y - scale.y/2, position.z - scale.y/2 ); 
        Vector3 v4 = new Vector3( position.x + scale.x/2, position.y - scale.y/2, position.z + scale.y/2 );


        bool isValid = true;
        foreach(BuildArea a in builds) {    

            if( (v1.x > a.x1 && v1.x < a.x2) || ((v4.x > a.x1 && v4.x < a.x2)) ){
                if( (v1.z > a.y1 && v1.z < a.y2) || ((v4.z > a.y1 && v4.z < a.y2)) ){
                    isValid = false;
                }
            }
        }
        area.GetComponent<Renderer>().material.color = isValid ? Color.green : Color.red;
    }

    public void saveBuild(){
        this.area.localScale = new Vector3(this.area.lossyScale.x-2, this.area.lossyScale.y-2, this.area.lossyScale.z);
        
        Vector3 position = area.position;
        Vector3 scale = area.lossyScale;
        Vector3 v1 = new Vector3( position.x - scale.x/2, position.y - scale.y/2, position.z - scale.y/2 ); 
        Vector3 v2 = new Vector3( position.x + scale.x/2, position.y - scale.y/2, position.z - scale.y/2 ); 
        Vector3 v3 = new Vector3( position.x - scale.x/2, position.y - scale.y/2, position.z + scale.y/2 ); 
        Vector3 v4 = new Vector3( position.x + scale.x/2, position.y - scale.y/2, position.z + scale.y/2 );

        float minX = v1.x;
        float minZ = v1.z;
        float maxX = v4.x;
        float maxZ = v4.x;
        this.builds.Add(new BuildArea(v1.x,v1.z,v4.x,v4.z));

    }



}
