using Common.Data;
using UnityEngine;

public class StatusSpriteManager : MonoBehaviour
{
    [SerializeField] private Sprite[] _statusSprites;
    [SerializeField] private Color[] _statusColors;
    
    public (Sprite, Color) GetStatusSprite(StatusType statusType)
    {
        var index = (int)statusType;
        if (index < 0 || index >= _statusSprites.Length)
        {
            Debug.LogError($"Index {index} is out of range for status sprites.");
            return (null, Color.white);
        }
        return (_statusSprites[index], _statusColors[index]);
    }
}