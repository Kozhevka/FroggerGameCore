using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRoadManager : MonoBehaviour
{
    [SerializeField] GameObject roadTypeObject;  // 0 Int
    [SerializeField] GameObject riverTypeObject; // 1 Int
    [SerializeField] GameObject treeTypeObject;  // 2 Int

    RoadPool roadPoolScript;
    RoadPool riverPoolScript;
    RoadPool treePoolScript;

    PickRoadType pickRoadTypeScript;

    [Range(0, 2)]
    int typeOfRoadInt = 0;

    bool rotateForDirectionQueue = false;

    // Start is called before the first frame update
    void Start()
    {
        roadPoolScript = roadTypeObject.GetComponent<RoadPool>();
        riverPoolScript = riverTypeObject.GetComponent<RoadPool>();
        treePoolScript = treeTypeObject.GetComponent<RoadPool>();
        pickRoadTypeScript = this.gameObject.GetComponent<PickRoadType>();
        
    }
    

    public void SpawnOneRoad(float spawnZPosition)
    {
        Debug.Log($"Try to spawn road at: {spawnZPosition}");

        Vector3 spawnPos = new Vector3(0f, 0f, spawnZPosition);
        //Debug.Log($"Spawn one road *spawnPos* = {spawnPos}");


        
        //Debug.Log($"Next type of road = {typeOfRoadInt}");

        if(typeOfRoadInt == 0)
        {
          GameObject road = roadPoolScript.GetPooledRoadObject();
            if (road != null)
            {
                PositionRotationActivate(road, spawnPos);
            }
            else if (road == null)
                Debug.Log("road = null");

        }
        else if (typeOfRoadInt == 2)
        {
            GameObject river = riverPoolScript.GetPooledRoadObject();
            if (river != null)
            {
                PositionRotationActivate(river, spawnPos);
            }
            else if (river == null)
                Debug.Log("river = null");
        }
        else if (typeOfRoadInt == 1) 
        {
            GameObject tree = treePoolScript.GetPooledRoadObject();
            if (tree != null)
            {
                PositionRotationActivate(tree, spawnPos);
            }
            else if (tree == null)
                Debug.Log("tree = null");
        }
        int currentTypeOfRoad = typeOfRoadInt;
        //Debug.Log($"Spawn one road *currentTypeOfRoad* = {currentTypeOfRoad}");


        typeOfRoadInt = pickRoadTypeScript.GetRoadType(currentTypeOfRoad); //get next type of road

    }

    void PositionRotationActivate(GameObject takenGameObj, Vector3 spawnPos)
    {
        takenGameObj.transform.position = spawnPos;
        if (!rotateForDirectionQueue)
        {
            takenGameObj.transform.rotation = Quaternion.identity;
            rotateForDirectionQueue = true;
        }
        else if (rotateForDirectionQueue)
        {
            takenGameObj.transform.rotation = Quaternion.Euler(0, 180, 0);
            rotateForDirectionQueue = false;
        }

        takenGameObj.SetActive(true);
        takenGameObj.GetComponent<MovingObjectsSpawn>().OnEnableSpawn();

        
    }


    
    
    
}
