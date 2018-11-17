using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AddCube : MonoBehaviour
{

    public GameObject cubeToAdd;
    public GameObject selector;
    public List<GameObject> robotCubes;
    public Button action;
    public GameObject sidePhaseButtons;
    public GameObject blockPhaseButtons;
    private void Start()
    {
        robotCubes = new List<GameObject>();
        robotCubes.Add(gameObject);
        sidePhaseButtons = GameObject.Find("SidePhase");
        blockPhaseButtons = GameObject.Find("BlocksPhase");
        blockPhaseButtons.SetActive(false);
    }
    public void addCube()
    {
        GameObject newCube = Instantiate(cubeToAdd, selector.transform.position, transform.rotation);
        newCube.transform.parent = GameObject.Find("BasicCube").transform;
        robotCubes.Add(newCube);
        selector.GetComponent<SpriteRenderer>().enabled = false;
        sidePhaseButtons.SetActive(false);
        blockPhaseButtons.SetActive(true);
        selector.GetComponent<BlockSelectorMovement>().currentState = BlockSelectorMovement.state.blocks;
    }
}
