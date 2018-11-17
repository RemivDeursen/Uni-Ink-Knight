using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseCubeToAdd : MonoBehaviour {

    public List<GameObject> differentCubes;
    public int counter;
    public GameObject selector;
	void Update ()
    {
		if(selector.GetComponent<BlockSelectorMovement>().currentState == BlockSelectorMovement.state.cubes)
        {
           
            if (Input.GetKeyDown(KeyCode.Space))
            {
                goToNextCube();
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                changeCubeToAdd();
                gameObject.GetComponent<AddCube>().selector.GetComponent<BlockSelectorMovement>().currentState = BlockSelectorMovement.state.sides;
            }
        }


	}

    public void changeCubeToAdd()
    {

        gameObject.GetComponent<AddCube>().cubeToAdd = differentCubes[counter];
    }
    public void goToNextCube()
    {
        //hard-coded showing all available cubes.
        // displaying on the screen the diffrent types of cubes we have.
        if(counter == 0)
        {
            Debug.Log(differentCubes[counter].name);
        }
        if(counter== 1)
        {
            Debug.Log(differentCubes[counter].name);
        }
        if(counter == differentCubes.Count-1)
        {
            counter = 0;
            return;
        }
        counter++;
    }
}
