using System;
using UnityEngine;

namespace Manager
{
    public class SkyBoxManager : MonoBehaviour

    {
        private static readonly int Rotation = Shader.PropertyToID("_Rotation");
        [SerializeField] private Material[] _skyBoxMaterials;
        [Range(0.01f, 0.1f)] public float _rotateSpeed;
        private Material _sky;
        private const　int EarlyMorning = 0;
        private const　int Morning = 10;
        private const　int Noon = 20;
        private const　int Afternoon = 30;
        private const　int Evening = 40;
        private const　int Night = 50;

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
            var rotationRepeatValue = Mathf.Repeat(_sky.GetFloat(Rotation) + _rotateSpeed, 360f);
            _sky.SetFloat(Rotation, rotationRepeatValue);
        }

        public void ChangeSkyBox()
        {
            var index = GetIndex();
            _sky = _skyBoxMaterials[index];
            RenderSettings.skybox = _sky;
        }

        private static int GetIndex()
        {
            var minute = DateTime.Now.Minute;
            return minute switch
            {
                >= EarlyMorning and < Morning => (int)DayTime.EarlyMorning,
                >= Morning and < Noon => (int)DayTime.Morning,
                >= Noon and < Afternoon => (int)DayTime.Noon,
                >= Afternoon and < Evening => (int)DayTime.Afternoon,
                >= Evening and < Night => (int)DayTime.Evening,
                >= Night => (int)DayTime.Night,
                _ => 0
            };
        }
    }
}