using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
public class ExportBuildedCube : MonoBehaviour {

    public GameObject readyGameObject;
    public Canvas mainGameCanvas;
    public Canvas buildingCanvas;
    public GameObject spawningPoint;
   public GameObject prefabLoaded;
    public GameObject buildingBlock;
    public GameObject builderScript;
    //Creates a new menu (Examples) with a menu item (Create Prefab)
    [MenuItem("Examples/Create Prefab")]
    public void ExportAsPrefab()
    {
        readyGameObject = GameObject.Find("BasicCube");
        string localPath = "Assets/BuildingBlocks Package/Resources/" + readyGameObject.name + ".prefab";
        Object prefab = PrefabUtility.CreateEmptyPrefab(localPath);
        readyGameObject = PrefabUtility.CreatePrefab(localPath, readyGameObject, ReplacePrefabOptions.ReplaceNameBased);
        mainGameCanvas.gameObject.SetActive(true);
        buildingCanvas.gameObject.SetActive(false);
        if (Resources.Load<GameObject>("BasicCube") == null)
        {
            Debug.Log("nullllllllllll");
        }
        prefabLoaded = Resources.Load<GameObject>("BasicCube");
        prefabLoaded.GetComponent<Cube>().enabled = false;
        prefabLoaded.GetComponent<AddCube>().enabled = false;
        prefabLoaded.GetComponent<ChooseCubeToAdd>().enabled = false;
        Instantiate(prefabLoaded, spawningPoint.transform.position, Quaternion.identity);
    }

    public void startBuilding()
    {
        mainGameCanvas.gameObject.SetActive(false);
        buildingCanvas.gameObject.SetActive(true);
        buildingBlock = Resources.Load<GameObject>("Builder");
        Instantiate(buildingBlock, spawningPoint.transform.position, Quaternion.identity);
        builderScript.GetComponent<BuilderActivation>().getBuilder();
        builderScript.GetComponent<BuilderActivation>().AssignButtonInCanvas();
    }
}
