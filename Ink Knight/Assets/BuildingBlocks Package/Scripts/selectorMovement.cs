using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class selectorMovement : MonoBehaviour {

    public GameObject selector;
    public GameObject selectedCube;
    public Vector3 positionOfSelector;
    private Vector3 top = new Vector3(0f, 1f/2f, 0f); //original is 1f.
    private Vector3 right  =  new Vector3(1f/2f, 0f, 0f);
    private Vector3 left =  new Vector3(-1f/2f, 0f, 0f);
    private Vector3 bottom  = new Vector3(0f, -1f/2f, 0f);
    private bool input = false; //if false = previous <> if true = next
    private void Update()
    {
        if (selector.GetComponent<BlockSelectorMovement>().currentState == BlockSelectorMovement.state.sides)
        {
            foreach (GameObject item in gameObject.GetComponent<BlockSelectorMovement>().mainCube.GetComponent<AddCube>().robotCubes)
            {
                if (selector.gameObject.transform.position == item.transform.position)
                {
                    if(input == false)
                    {
                        moveSelectorBack();
                    }
                    if (input == true)
                    {
                        moveSelectorNext();
                    }
                }
            }

        }
    }
    public void moveSelectorNext()
    {
        input = true;
            selectedCube.GetComponent<Cube>().changeSide();
            changePosition();
    }
    public void moveSelectorBack()
    {
        input = false;
        selectedCube.GetComponent<Cube>().changeSideBack();
        changePosition();
    }
    public void changePosition()
    {
        if (selectedCube.GetComponent<Cube>().currentSide == Cube.sides.top)
        {
            selector.transform.position = selectedCube.GetComponent<Cube>().position + top;
        }
        if (selectedCube.GetComponent<Cube>().currentSide == Cube.sides.right)
        {
            selector.transform.position = selectedCube.GetComponent<Cube>().position + right;
        }
        if (selectedCube.GetComponent<Cube>().currentSide == Cube.sides.left)
        {
            selector.transform.position = selectedCube.GetComponent<Cube>().position + left;
        }
        if (selectedCube.GetComponent<Cube>().currentSide == Cube.sides.bottom)
        {
            selector.transform.position = selectedCube.GetComponent<Cube>().position + bottom;
        }
    }


}
