// Description: This script is used to store the information of the planet.
// Author: Palin Wiseman
// Last Updated: 19/09/2023
// Last Updated By: Chase Bennett-Hill
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetInfo : MonoBehaviour
{
    //The count of each animal type on the planet with the range it can spawn in
    [HideInInspector]
    public int hostileCount;
    private const int HOSTILEMIN = 1;
    private const int HOSTILEMAX = 2;

    [HideInInspector]
    public int scaredCount;
    private const int SCAREDMIN = 1;
    private const int SCAREDMAX = 4;

    [HideInInspector]
    public int neutralCount;
    private const int NEUTRALMIN = 3;
    private const int NEUTRALMAX = 12;

    [HideInInspector]
    public int treeCount;
    private const int TREEMIN = 0;
    private const int TREEMAX = 20;

    [HideInInspector]
    public int totalAnimals;

    public List<GameObject> hostilePrefabs; //List of prefabs that can be used for the hostile animal

    [HideInInspector]
    public int selectedHostile;

    public List<GameObject> neutralPrefabs; //List of prefabs that can be used for the neutral animal

    [HideInInspector]
    public int selectedNeutral;

    public List<GameObject> scaredPrefabs; //List of prefabs that can be used for the Scared animal

    [HideInInspector]
    public int selectedScared;

    public List<GameObject> foliagePrefabs; //List of prefabs that can be used for the foliage

    [HideInInspector]
    public int selectedFoliage;

    void Awake()
    {
        hostileCount = Random.Range(HOSTILEMIN, HOSTILEMAX);
        scaredCount = Random.Range(SCAREDMIN, SCAREDMAX);
        neutralCount = Random.Range(NEUTRALMIN, NEUTRALMAX);
        treeCount = Random.Range(TREEMIN, TREEMAX);

        totalAnimals = hostileCount + scaredCount + neutralCount;

        //Selects an index from each list of prefabs
        selectedFoliage = Random.Range(0, foliagePrefabs.Count);
        selectedHostile = Random.Range(0, hostilePrefabs.Count);
        selectedNeutral = Random.Range(0, neutralPrefabs.Count);
        selectedScared = Random.Range(0, scaredPrefabs.Count);
    }
}
