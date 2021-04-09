using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class PickRoadType : MonoBehaviour
    {
    //int previousRoadType = 0;
    float wasCarWillForest = 65;

    float wasTreeWillRoad = 25f;
    float wasTreeWillTree = 60f;

    float wasRiverWillTree = 50f;

        public int GetRoadType(int previousRoadType)
        {
        //Debug.Log($"previous type road = {previousRoadType}");
            int random = Random.Range(0, 100);


            // If was road (25/75 - tree/road)
            // If was tree (25/25/50 - road/tree/river
            // If
            if (previousRoadType == 0) //if road
            {
                if (random <= wasCarWillForest)
                    return 0;
                if (random > wasCarWillForest)
                    return 1;
            }
            else if (previousRoadType == 1) //if tree
            {
                if (random <= wasTreeWillRoad)
                    return 0;
                if (random > wasTreeWillTree)
                    return 2;
                else // between 25 and 50;
                    return 1;
            }
            else // if river or mistake and other
            {
                if (random <= wasRiverWillTree)
                    return 1;
                if (random > wasRiverWillTree)
                    return 0;
            }
            return 0;
        }
    }

