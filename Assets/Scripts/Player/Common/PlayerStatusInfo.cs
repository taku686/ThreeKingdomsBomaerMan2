using UnityEngine;

public class PlayerStatusInfo : MonoBehaviour
{
    private int _playerIndex;

    public void SetPlayerIndex(int userId)
    {
        _playerIndex = userId;
    }

    public int GetPlayerIndex()
    {
        return _playerIndex;
    }
}