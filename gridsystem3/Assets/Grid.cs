using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{

    private int width;
    private int height; 

    private float cellSize;
    private int[,] gridArray;

    public Grid(int width, int height, float cellSize){
        CreateWorldText("0", null, new Vector3(0,0,0));
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        gridArray = new int[width, height];
        Debug.Log(width +","+ height);

        for(int x=0;x<gridArray.GetLength(0);x++){
            for(int y=0;y<gridArray.GetLength(1);y++){
                Debug.Log(x+ " " + y );
                CreateWorldText(gridArray[x,y].ToString(), null, GetWorldPosition(x, y));
            }
        }

    }


    private Vector3 GetWorldPosition(int x, int y){
        return new Vector3(x,0,y);
    }

    private TextMesh CreateWorldText(string text, Transform parent = null, Vector3 localPosition = default(Vector3)){
        GameObject go = new GameObject("World_text", typeof(TextMesh));
        Transform transform = go.transform;
        transform.SetParent(parent, false);
        transform.localPosition = localPosition;
        TextMesh textMesh = go.GetComponent<TextMesh>();
        textMesh.anchor = TextAnchor.MiddleCenter;
        textMesh.alignment = TextAlignment.Center;
        textMesh.text = text;
        textMesh.fontSize = 12;
        textMesh.color = Color.white;
        textMesh.GetComponent<MeshRenderer>().sortingOrder = 1;
        return textMesh;
    }
}
