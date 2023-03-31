using UnityEngine;

public class CommonView : MonoBehaviour
{
    public GameObject waitPopup;

    public void Initialize()
    {
        waitPopup.SetActive(false);
    }
}