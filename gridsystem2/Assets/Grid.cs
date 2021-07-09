using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public int width;
    public int heigth;

    public int[,] cells;

    public Material material;

    public GameObject test;

    // Start is called before the first frame update
    void Start()
    {
        var count = 0;
        foreach (Transform child in test.transform)
        {
            count++;
            if( child.name !="Cube")
                child.GetComponent<Renderer>().material.color = Color.red;
            if( count == 3 )
                child.GetComponent<Renderer>().material.color = Color.green;
        }
        drawLines();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void drawLines(){

        for(var i=0; i<width; i++){
            drawLine(new Vector3(i,0,0), new Vector3(i,0,heigth));
        }
        for(var j=0; j<heigth; j++){
            drawLine(new Vector3(0,0,j), new Vector3(width,0,j));
        }

    }

    private void drawLine(Vector3 start, Vector3 end){
        GameObject line = new GameObject("line");
        line.transform.parent = gameObject.transform;
        line.transform.position = new Vector3(0,0,0);

        line.AddComponent<LineRenderer>();

        LineRenderer lr = line.GetComponent<LineRenderer>();
        lr.material = material;
        lr.startColor = Color.white;
        lr.endColor = Color.white;
        lr.startWidth = .1f;
        lr.endWidth = .1f;
        lr.SetPosition(0, start); 
        lr.SetPosition(1, end);
    }
}
