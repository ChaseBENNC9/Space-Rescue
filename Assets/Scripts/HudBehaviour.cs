using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public static HudBehaviour instance;
    public GameObject planetStatus,planetName,playerPlanetDistance,blackHolePlanetDist,planetLand; //The HUD Text Objects
    private List<GameObject> hudItems; //Holds the list of hudItems to quickly show and hide them
    void Awake()
    {
        instance = this;
        hudItems = new List<GameObject> {planetStatus,planetName,playerPlanetDistance,blackHolePlanetDist,planetLand};
    }


    //Displays the Planet Info Panel with information about the planet
    //PlanetDetection status: the Planet Detection script attached to the planet has info about whether the planet has been rescued and if the player is close enough to land
    //dist: the distance between the player and the planet distBlackHole: distance between planet and blackhole, name: name of the planet

    public void ShowPlanetInfo(PlanetDetection status,float dist,float distBlackHole, string name)
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = true; //shows the panel sprite

        foreach(GameObject hudItem in hudItems) //loops through the list of hudItems and shows each one
        {
            hudItem.GetComponent<Text>().enabled = true;
        }
        planetStatus.GetComponent<Text>().color = (status.planetRescued ? Color.green : Color.red);
        planetStatus.GetComponent<Text>().text = "Status: " + (status.planetRescued ? "Rescued" : "Not Rescued");
        playerPlanetDistance.GetComponent<Text>().text = "Distance: " + dist.ToString();
        blackHolePlanetDist.GetComponent<Text>().text = "Black Hole: " + distBlackHole.ToString();
        if(status.inDanger) //If the planet is inside the warning area of the black hole
        {
            if(distBlackHole < 150f) //When the distance is under 150 the text turns red as a severe warning
            {
                blackHolePlanetDist.GetComponent<Text>().color = Color.red;

            }
            else
            {
            blackHolePlanetDist.GetComponent<Text>().color = new Color(1.0f, 0.64f, 0.0f); //otherwise it is orange

            }

        }
        else
        {
            blackHolePlanetDist.GetComponent<Text>().color =  planetName.GetComponent<Text>().color; //If the planet is out of danger the distance returns to the standard color
        }
        
        planetName.GetComponent<Text>().text = name;
        
        planetLand.GetComponent<Text>().text = (status.playerInsideRadius ? "Ready to Land" : "Fly Closer to Land"); //Tooltip about when the player can land 
        planetLand.GetComponent<Text>().color = (status.playerInsideRadius ? Color.green : planetName.GetComponent<Text>().color); //sets color to green or standard blue



    }


    public void HidePlanetInfo()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;

        foreach(GameObject hudItem in hudItems)
        {
            hudItem.GetComponent<Text>().enabled = false;
        }


    }
}
