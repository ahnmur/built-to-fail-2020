using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{

    [SerializeField] Material defaultMat;
    [SerializeField] Material isSelectedMat;
    Renderer rend;
    public bool buildingIsHighlighted = false;

    private void Start() 
    {
        rend = GetComponent<Renderer> ();
    }
    private void Update()
    {

    }

    public void SetBuildingYPos(float yPos)
    {
        Vector3 buildingPos = this.transform.position;
        this.transform.position = new Vector3(buildingPos.x, yPos, buildingPos.z);

                if (buildingIsHighlighted ==  true)
        {
            if (rend.material == defaultMat)
            {
                rend.material = isSelectedMat;
            } else
            {
            rend.material = defaultMat;
            }
        }
    }

}
