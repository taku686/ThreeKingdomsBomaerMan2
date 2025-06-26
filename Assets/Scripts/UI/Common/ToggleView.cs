using UI.Title;
using UnityEngine;

namespace UI.Common
{
    public class ToggleView : MonoBehaviour
    {
        [SerializeField] private ToggleElement[] toggleElements;

        public ToggleElement[] _ToggleElements => toggleElements;

        public void ApplyView(TemporaryCharacterRepository.OrderType orderType)
        {
            foreach (var element in toggleElements)
            {
                element.SetActive(element.OrderType == orderType);
            }
        }
    }
}