using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace UI.Common
{
    public class InputView : MonoBehaviour
    {
        public Button bombButton;
        [FormerlySerializedAs("skillOneButton")] public Button normalSkillButton;
        [FormerlySerializedAs("specialSkillTwoButton")] [FormerlySerializedAs("skillTwoButton")] public Button specialSkillButton;
        public Image normalSkillIntervalImage;
        public Image specialSkillIntervalImage;
        public Image normalSkillImage;
        public Image specialSkillImage;
    }
}