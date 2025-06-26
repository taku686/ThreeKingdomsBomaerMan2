using UnityEngine;

public class StartPointsRepository : MonoBehaviour
{
    [SerializeField] private Transform[] _startPoints;

    public Transform GetSpawnPoint(int index)
    {
        index--;
        if (index >= 0 && index < _startPoints.Length) return _startPoints[index];
        Debug.LogError($"Invalid start point index: {index}. Returning first start point.");
        return _startPoints[0];

    }
}