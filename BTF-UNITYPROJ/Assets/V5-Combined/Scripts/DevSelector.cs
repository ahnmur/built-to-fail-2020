using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevSelector : MonoBehaviour
{

    [SerializeField] private BuildingV5 selectedBuilding;
    public bool isPinching;

    //Devmode
    public GameObject parentHand;

    void Update()
    {
        // Check for hit building by sending out a raycast
        RaycastHit hit;
        Ray selectorRay = new Ray(this.transform.position, this.transform.forward);
        Debug.DrawRay(selectorRay.origin, selectorRay.direction * 30.0f, Color.red);

        //we don't want to select a building if we're pinching
        if (isPinching == false)
        {


            // If we've hit a building with our raycast and we are not pinching
            if (Physics.Raycast(selectorRay, out hit))
            {
                // check if the thing we've hit has a building script, if so, set it as the selected building
                BuildingV5 hitBuilding = hit.collider.GetComponent<BuildingV5>();

                if (hitBuilding != null)
                {
                    this.selectedBuilding = hitBuilding;
                    selectedBuilding.buildingIsHighlighted = true;
                }
            }
            else
            {
                //Set the selected building to null if we're not pointing at anything

                if (this.selectedBuilding != null)
                {
                    selectedBuilding.buildingIsHighlighted = false;
                    this.selectedBuilding = null;
                }

            }

        }
        else if (selectedBuilding != null)
        {
            // If I have a building selected and I'm pinching, do something with it
            selectedBuilding.TriggerAnimation();
        }
    }
}
