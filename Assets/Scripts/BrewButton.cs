/**
* Author: Elysa Hines  
* Date Created: 03/30/25  
* Date Last Updated: 04/24/25
* Summary: Triggers the brewing process through the PrecisionBrewController using press-and-hold input.
*/

using UnityEngine;

public class BrewButton : MonoBehaviour
{
    private PrecisionBrewController brewController;

    void Start()
    {
        brewController = FindAnyObjectByType<PrecisionBrewController>();
        // if (brewController == null)
        //     Debug.LogError("PrecisionBrewController not found in scene!");
    }

    void OnMouseDown()
    {
        brewController?.StartBrewing();
    }

    void OnMouseUp()
    {
        brewController?.StopBrewing();
    }
}
