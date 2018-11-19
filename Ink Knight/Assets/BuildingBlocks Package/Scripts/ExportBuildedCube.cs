using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class ExportBuildedCube : MonoBehaviour {
     
    //public GameObject readyGameObject;   legacy
    public Canvas mainGameCanvas;
    public Canvas buildingCanvas;
    public GameObject spawningPoint;
   // public GameObject prefabLoaded;   legacy
    public GameObject buildingBlock;
    public GameObject builderScript;
    public List<GameObject> activators;
    public string builderActivatorName;
    public GameObject blockPhase;
    public GameObject sidePhase;
    [MenuItem("Examples/Create Prefab")] // legacy, used to make a prefab of the builded thing.




    //public void ExportAsPrefab()
    //{
    //    readyGameObject = GameObject.Find("BasicCube");
    //    string localPath = "Assets/BuildingBlocks Package/Resources/" + readyGameObject.name + ".prefab";
    //    Object prefab = PrefabUtility.CreateEmptyPrefab(localPath);
    //    readyGameObject = PrefabUtility.CreatePrefab(localPath, readyGameObject, ReplacePrefabOptions.ReplaceNameBased);
    //    mainGameCanvas.gameObject.SetActive(true);
    //    buildingCanvas.gameObject.SetActive(false);
    //    if (Resources.Load<GameObject>("BasicCube") == null)
    //    {
    //        Debug.Log("nullllllllllll");
    //    }
    //    prefabLoaded = Resources.Load<GameObject>("BasicCube");
    //    prefabLoaded.GetComponent<Cube>().enabled = false;
    //    prefabLoaded.GetComponent<AddCube>().enabled = false;
    //    prefabLoaded.GetComponent<ChooseCubeToAdd>().enabled = false;
    //    Instantiate(prefabLoaded, spawningPoint.transform.position, Quaternion.identity);
    //}
    public void BridgeReady()
    {
        mainGameCanvas.gameObject.SetActive(true);
        buildingCanvas.gameObject.SetActive(false);
        Destroy( GameObject.Find("BasicCube").GetComponent<Cube>());
        Destroy(GameObject.Find("BasicCube").GetComponent<AddCube>());
        Destroy( GameObject.Find("BasicCube").GetComponent<ChooseCubeToAdd> ());
        blockPhase.gameObject.SetActive(true);
        sidePhase.gameObject.SetActive(true);
        GameObject.Find("BasicCube").AddComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        GameObject.Find("BasicCube").name = "bridge_" + builderActivatorName.ToString();
        Destroy(GameObject.Find("selector"));
    }
    public void assignSpawner()
    {
       spawningPoint = GameObject.Find("BuilderSpawningPoint_" + builderActivatorName);
        Debug.Log(spawningPoint.name);
    }
    public void startBuilding()
    {
        mainGameCanvas.gameObject.SetActive(false);
        buildingCanvas.gameObject.SetActive(true);
        string name = EventSystem.current.currentSelectedGameObject.name;
        buildingBlock = Resources.Load<GameObject>("Builder");
        Instantiate(buildingBlock, spawningPoint.transform.position, Quaternion.identity);
      
        builderScript.GetComponent<BuilderActivation>().getBuilder();
        builderScript.GetComponent<BuilderActivation>().AssignButtonInCanvas();
    }

}
