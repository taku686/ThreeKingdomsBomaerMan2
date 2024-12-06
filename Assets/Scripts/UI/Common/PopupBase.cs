using TMPro;
using UnityEngine;

public abstract class PopupBase : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI titleText;

    public virtual void Open()
    {
    }

    public virtual void Close()
    {
    }
}