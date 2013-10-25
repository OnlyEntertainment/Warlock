using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;

class UnitMove
{

    enum ACTIONS {idle,walk};

    private GameObject currentUnit;
    private RaycastHit hit_MouseCursor;
    private Camera camera;


    private ACTIONS onAction = ACTIONS.idle;
    private float walkSpeed = 10;
    private Vector2 targetPoint;    



    private float selectionAreaRadius = 10;
    public GameObject selectionProjectorPrefab;
    private GameObject selectionProjector;


    void Awake()
    {
        camera = Camera.mainCamera;        
        //currentUnit = GameObject;
    }


    void Start()
    {
        //selectionProjector = Instantiate(selectionProjectorPrefab, currentUnit.transform.position + new Vector3(0f, 1f, 0f)/*Abhängig von falloff-Textur*/, Quaternion.Euler(90, 0, 0)) as GameObject;
        selectionProjector.transform.parent = currentUnit.transform;
        selectionProjector.GetComponent<Projector>().orthographicSize = selectionAreaRadius;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition), out hit_MouseCursor, Mathf.Infinity, 512/*9: Weg collider*/))
            {
                GoToPoint(hit_MouseCursor.point);
            }
        }

        switch (onAction)
        {
            case ACTIONS.walk:
                //Debug.Log("Gehe in Walk");
                //höchstens eine Frame-Bewegung vom Ziel
                if ((targetPoint - new Vector2(currentUnit.transform.position.x, currentUnit.transform.position.z)).magnitude >= walkSpeed * Time.deltaTime)
                {
                    currentUnit.transform.LookAt(new Vector3(targetPoint.x, currentUnit.transform.position.y, targetPoint.y));
                    currentUnit.transform.Translate(Vector3.forward * walkSpeed * Time.deltaTime);
                    currentUnit.transform.position = new Vector3(currentUnit.transform.position.x, Terrain.activeTerrain.SampleHeight(currentUnit.transform.position), currentUnit.transform.position.z);
                }
                else
                {
                    onAction = ACTIONS.idle; //nach Ankommen auf "idle"-Aktion
                }
                break;
        }

    }



    public void GoToPoint(Vector3 newTargetPoint) //in Bewegung setzen, falls keine vorrangige Aktion läuft
    {
        //Debug.Log("Erhalte Befehle (" + ownUnit_OnAction + ") --> Fahre zu " + newTargetPoint);
        onAction = ACTIONS.walk;
        targetPoint = new Vector2(newTargetPoint.x, newTargetPoint.z);        
    }
}
