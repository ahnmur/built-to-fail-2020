using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{

    public bool buildingIsHighlighted = false;

    private void Update()
    {

    }

    public void SetBuildingYPos(float yPos)
    {
        Vector3 buildingPos = this.transform.position;
        this.transform.position = new Vector3(buildingPos.x, yPos, buildingPos.z);

    }

}
