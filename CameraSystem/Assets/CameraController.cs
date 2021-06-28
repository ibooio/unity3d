using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform cameraTransform;

    public float movementSpeed;
    public float movementTime;

    public float rotationAmount;

    public Vector3 zoomAmount;

    public Vector3 newPosition;
    public Quaternion newRotation;

    public Vector3 newZoom;

    public Vector3 dragStartPosition;
    public Vector3 dragCurrentPosition;




    // Start is called before the first frame update
    void Start()
    {
        newPosition = transform.position;
        newRotation = transform.rotation;
        newZoom = cameraTransform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        HandleMouseInput();
        HandleMovementInput();
    }


    void HandleMouseInput(){

        if(Input.mouseScrollDelta.y != 0){

            newZoom += Input.mouseScrollDelta.y *  zoomAmount;
    
        }

        if(Input.GetMouseButtonDown(0)){
            Plane plane =  new Plane(Vector3.up, Vector3.zero);
            Ray ray =  Camera.main.ScreenPointToRay(Input.mousePosition);


            float entry;

            
            if( plane.Raycast(ray, out entry) ){
                dragStartPosition = ray.GetPoint(entry);            
            }

        }

        if(Input.GetMouseButton(0)){
            Plane plane =  new Plane(Vector3.up, Vector3.zero);
            Ray ray =  Camera.main.ScreenPointToRay(Input.mousePosition);


            float entry;

            
            if( plane.Raycast(ray, out entry) ){
                dragCurrentPosition = ray.GetPoint(entry);           

                newPosition	= transform.position + dragStartPosition - dragCurrentPosition; 
            }

        }


    }

    void HandleMovementInput(){

        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)){
            newPosition += (transform.forward * movementSpeed);
        }
        if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)){
            newPosition += (transform.forward * -movementSpeed);
        }
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)){
            newPosition += (transform.right * -movementSpeed) ;
        }
        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)){
            newPosition += (transform.right * movementSpeed) ;
        }

        if(Input.GetKey(KeyCode.Q)){
            newRotation *= Quaternion.Euler(Vector3.up * rotationAmount);
        }
        if(Input.GetKey(KeyCode.E)){
            newRotation *= Quaternion.Euler(Vector3.up * -rotationAmount);
        }


        transform.position = Vector3.Lerp(transform.position,newPosition, Time.deltaTime * movementTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * movementTime);
                cameraTransform.localPosition = Vector3.Lerp(cameraTransform.localPosition, newZoom, Time.deltaTime * movementTime);

    }
}
