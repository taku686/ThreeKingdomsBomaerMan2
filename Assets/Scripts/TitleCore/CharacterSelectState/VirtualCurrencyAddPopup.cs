using UnityEngine;
using UnityEngine.UI;

public class VirtualCurrencyAddPopup : MonoBehaviour
{
    [SerializeField] private Button cancelButton;
    [SerializeField] private Button addButton;
    [SerializeField] private Button closeButton;

    public Button CancelButton => cancelButton;

    public Button AddButton => addButton;

    public Button CloseButton => closeButton;
}