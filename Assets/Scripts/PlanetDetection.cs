using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetDetection : MonoBehaviour
{

    public bool PlayerInsideRadius;
    public bool PlanetRescued;
    //Temp Materials
    public Material Complete; //Color of rescued planet
    public Material WithinRadius; //Color of planet when within the radius
    public Material Normal; //Color of normal planet 

    public GameObject Planet;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) //The user needs to press the enter key to rescue the planet.
        {
            

            print($"P:{GameSettings.RescueCount}");

            if (PlayerInsideRadius && !PlanetRescued) //Test whether the Player is within range of the Planet and if the planet is not been rescued
            {

                //Does the Task
                PlanetRescued = true;
                Planet.GetComponent<MeshRenderer> ().material = Complete; //Temp Indicator 
                GameSettings.RescueCount++;

            }
        }

    }
    
    private void OnTriggerEnter(Collider other)  //When the Player enters the Planet Radius the bool will be set to true and the material will be changed
                                                 //This is indicated by colour change   
    {

        if (other.CompareTag("Player")) 
        {
            
            PlayerInsideRadius = true;
            Planet.GetComponent<MeshRenderer> ().material = WithinRadius; //Temp Indicator 

        }
        

    }

    private void OnTriggerExit(Collider other)
    //When the player leaves the radius the Planet is no longer active.
    {
        if (other.CompareTag("Player")) 
        {
            if(!PlanetRescued) //If the player has not complete the planet it will return to default other wise it will remain Completed.
            {
                PlayerInsideRadius = false;
                Planet.GetComponent<MeshRenderer> ().material = Normal; //Temp Indicator 
            }
            

        }
    }
}
