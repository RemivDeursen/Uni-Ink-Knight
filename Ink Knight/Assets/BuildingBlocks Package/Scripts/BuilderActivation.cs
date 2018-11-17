using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BuilderActivation : MonoBehaviour {
    public Button sideNext;
    public Button sidePrev;
    public Button sideChoose;
    public Button blockChoose;

    public GameObject spawnedBuilder;
    public GameObject spawnedSelector;
    public void getBuilder()
    {
        spawnedBuilder = GameObject.Find("BasicCube");
        spawnedSelector = GameObject.Find("selector");
    }
	
    public void AssignButtonInCanvas()
    {
        sideNext.onClick.AddListener(spawnedSelector.GetComponent<selectorMovement>().moveSelectorNext);
        sidePrev.onClick.AddListener(spawnedSelector.GetComponent<selectorMovement>().moveSelectorBack);
        sideChoose.onClick.AddListener(spawnedBuilder.GetComponent<AddCube>().addCube);
        blockChoose.onClick.AddListener(spawnedSelector.GetComponent<BlockSelectorMovement>().SelectCube);
    }
}
