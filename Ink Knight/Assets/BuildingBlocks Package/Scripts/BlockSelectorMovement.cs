using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockSelectorMovement : MonoBehaviour {

    public enum state
    {
        sides,
        blocks,
        cubes // used for choosing what kind of block to put. Not used for now. 
    }
    public state currentState;
    public GameObject mainCube;
    public GameObject selector;
    public Material selectedCubeMat;
    public Material normalCubeMat;
    public GameObject selectedCube;
    public GameObject prevSelected;
    public GameObject sidePhaseButtons;
    public GameObject blockPhaseButtons;

    private int currentSelected;
    //private bool input = false; //if false = previous <> if true = next
    public void Awake()
    {
        sidePhaseButtons = GameObject.Find("SidePhase");
        blockPhaseButtons = GameObject.Find("BlocksPhase");
        
    }
    private void Update()
    {
        
        if (currentState == state.blocks)
        {
            if (Input.GetMouseButton(0))
            {
                Vector3 mousePositionFar = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.farClipPlane);
                Vector3 mousePositionClose = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane);
                Vector3 mousePosF = Camera.main.ScreenToWorldPoint(mousePositionFar);
                Vector3 mousePosC = Camera.main.ScreenToWorldPoint(mousePositionClose);
                Debug.DrawRay(mousePosC, mousePosF - mousePosC, Color.red);
                RaycastHit2D hit = Physics2D.Raycast(mousePosC, mousePosF - mousePosC);
                if(hit.collider != null && hit.collider.name != "Tiles_Floor_Coll")
                {
                    //Debug.Log(hit.collider.name);
                    if (hit.transform.gameObject.GetComponent<Cube>().AllUsed == true)
                    {
                        Debug.Log("all sides are currently used.") ;
                        return;
                    }
                    foreach (GameObject item in mainCube.GetComponent<AddCube>().robotCubes)
                    {
                        item.GetComponent<SpriteRenderer>().material = normalCubeMat;
                    }
                    Debug.DrawRay(mousePosC, mousePosF - mousePosC, Color.red);
                    //selectedCube.GetComponent<MeshRenderer>().material = normalCubeMat;
                    selectedCube = hit.transform.gameObject;
                    selectedCube.GetComponent<SpriteRenderer>().material = selectedCubeMat;
                }
                else
                {
                    Debug.DrawRay(mousePosC, mousePosF - mousePosC, Color.white);
                }

            }
            
            //if(selectedCube.GetComponent<Cube>().AllUsed == true)
            //{
            //    if (input == false)
            //    {
            //        previousSelected();
            //    }
            //    if (input == true)
            //    {
            //        nextSelected();
            //    }
            //}
           // selectedCube.GetComponent<MeshRenderer>().material = selectedCubeMat;
        }
    }




    //public void nextSelected()
    //{
    //    input = true;
    //    selectedCube.GetComponent<MeshRenderer>().material = normalCubeMat;
    //    if (currentSelected == mainCube.GetComponent<AddCube>().robotCubes.Count - 1)
    //    {
    //        Debug.Log("limit reached");
    //        currentSelected = 0;          
    //        return;
    //    }
    //    Debug.Log("select next cube");
    //    currentSelected++;
    //}
    //public void previousSelected()
    //{
    //    input = false ;
    //    selectedCube.GetComponent<MeshRenderer>().material = normalCubeMat;
    //    if (currentSelected == 0)
    //    {
    //        Debug.Log("limit reached");
    //        currentSelected = mainCube.GetComponent<AddCube>().robotCubes.Count - 1;
    //        return;
    //    }
    //    Debug.Log("select next cube");
    //    currentSelected--;
    //}
    public void SelectCube()
    {
        foreach (GameObject item in mainCube.GetComponent<AddCube>().robotCubes)
        {
            item.GetComponent<SpriteRenderer>().material = normalCubeMat;
        }
        if (selectedCube.GetComponent<Cube>().AllUsed == true)
        {
            Debug.Log("Chose another cube, as this one is already used.");
            return;
        }
        selectedCube.GetComponent<SpriteRenderer>().material = normalCubeMat;
        selector.GetComponent<selectorMovement>().selectedCube = selectedCube;
        selector.GetComponent<selectorMovement>().moveSelectorNext();
        currentState = state.sides;
        blockPhaseButtons.SetActive(false);
        sidePhaseButtons.SetActive(true);
        selector.GetComponent<SpriteRenderer>().enabled = true;
    }
}
