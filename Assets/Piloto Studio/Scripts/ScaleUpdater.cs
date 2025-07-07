using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleUpdater : MonoBehaviour
{
    private Vector2 currentScreenResolution;
    public float scalingAdjustment = 10.0f;

    void Start()
    {
        currentScreenResolution = new Vector2(Screen.width, Screen.height);
        AdjustScaleToFitScreen();
    }

    void Update()
    {
        // Check if the screen resolution has changed, and if so, adjust the object scale
        if (currentScreenResolution.x != Screen.width || currentScreenResolution.y != Screen.height)
        {
            AdjustScaleToFitScreen();
            currentScreenResolution.x = Screen.width;
            currentScreenResolution.y = Screen.height;
            //Debug.Log(currentScreenResolution);
        }
    }

    // Adjusts the object's scale to match the current screen size
    // REMEMBER THAT YOUR CAMERA MUST BE TAGGED WITH "MainCamera"
    private void AdjustScaleToFitScreen()
    {

         if (Camera.main == null)
    {
        Debug.LogError("Main Camera not found! Ensure there is a camera tagged as 'MainCamera' in the scene.");
        return;
    }


        float distanceToCamera = Vector3.Distance(transform.position, Camera.main.transform.position);
        float heightBasedOnScreen = (2.0f * Mathf.Tan(0.5f * Camera.main.fieldOfView * Mathf.Deg2Rad) * distanceToCamera) * scalingAdjustment;
        float widthBasedOnAspect = heightBasedOnScreen * Camera.main.aspect;
        transform.localScale = new Vector3(widthBasedOnAspect, heightBasedOnScreen, 1);
    }
}
