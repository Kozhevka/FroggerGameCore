using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class PickRoadType : MonoBehaviour
    {
    //int previousRoadType = 0;


        public int GetRoadType(int previousRoadType)
        {
        //Debug.Log($"previous type road = {previousRoadType}");
            int random = Random.Range(0, 100);


            // If was road (25/75 - tree/road)
            // If was tree (25/25/50 - road/tree/river
            // If
            if (previousRoadType == 0)
            {
                if (random < 75)
                    return 0;
                if (random > 75)
                    return 1;
            }
            else if (previousRoadType == 1)
            {
                if (random < 25)
                    return 0;
                if (random > 50)
                    return 2;
                else // between 25 and 50;
                    return 1;
            }
            else // if 2 or mistake and other
            {
                if (random < 75)
                    return 1;
                if (random > 75)
                    return 0;
            }
            return 0;
        }
    }

