using UnityEngine;
// Use the Pathfinding namespace to be able to
// use most common classes in the package
using Pathfinding;

public class FollowCursor : MonoBehaviour
{
    FollowerEntity ai;

    // This runs when the game starts
    void OnEnable()
    {
        // Get a reference to our movement script.
        // You can alternatively use the interface IAstarAI,
        // which makes the code work with all movement scripts
        ai = GetComponent<FollowerEntity>();
    }

    void Update()
    {
        // Get the mouse position
        var mousePosition = Input.mousePosition;

        // Create a ray from the camera to the mouse position
        var ray = Camera.main.ScreenPointToRay(mousePosition);

        // Check if the ray hits something
        if (Physics.Raycast(ray, out var hit))
        {
            // Set the destination for the AI to move towards
            ai.destination = hit.point;
        }
    }
}