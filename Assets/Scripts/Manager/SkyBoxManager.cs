using System;
using UnityEngine;

namespace Manager
{
    public class SkyBoxManager : MonoBehaviour

    {
        [SerializeField] private Material[] _skyBoxMaterials;
        [Range(0.01f, 0.1f)] public float _rotateSpeed;
        private Material _sky;

        private enum DayTime
        {
            EarlyMorning,
            Morning,
            Noon,
            Afternoon,
            Evening,
            Night
        }

        private void Start()
        {
            ChangeSkyBox();
        }

        private void Update()
        {
            if (_sky == null) return;
            var rotationRepeatValue = Mathf.Repeat(_sky.GetFloat("_Rotation") + _rotateSpeed, 360f);
            _sky.SetFloat("_Rotation", rotationRepeatValue);
        }

        public void ChangeSkyBox()
        {
            var index = GetIndex();
            _sky = _skyBoxMaterials[index];
            RenderSettings.skybox = _sky;
        }

        private int GetIndex()
        {
            var nowHour = DateTime.Now.Hour;
            return nowHour switch
            {
                >= 4 and < 7 => (int)DayTime.EarlyMorning,
                >= 7 and < 10 => (int)DayTime.Morning,
                >= 10 and < 13 => (int)DayTime.Noon,
                >= 13 and < 16 => (int)DayTime.Afternoon,
                >= 16 and < 19 => (int)DayTime.Evening,
                >= 19 and < 24 => (int)DayTime.Night,
                >= 0 and < 4 => (int)DayTime.Night,
                _ => 0
            };
        }
    }
}