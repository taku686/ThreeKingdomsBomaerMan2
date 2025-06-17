using UnityEngine;

namespace Manager
{
    public class DataAcrossStates : MonoBehaviour
    {
        public bool _changingScene;
        private bool _canEditTeam;
        
        public bool GetCanEditTeam()
        {
            return _canEditTeam;
        }
        
        public void SetCanEditTeam(bool canEditTeam)
        {
            _canEditTeam = canEditTeam;
        }
    }
}