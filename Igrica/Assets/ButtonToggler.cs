using System;
using UnityEngine;
using UnityEngine.UI;

namespace UnityStandardAssets.CrossPlatformInput
{
    public class ButtonToggler : MonoBehaviour
    {
        
        public string Name;
        private static bool isRunning = false;

        void OnEnable()
        {

        }

        public void ToggleState()
        {
            Debug.Log("HOLLA!!!");
            isRunning = !isRunning;
            if (isRunning)
            {
                CrossPlatformInputManager.SetAxisPositive(Name);
                GetComponent<Image>().color = Color.magenta;
            }
            else
            {
                CrossPlatformInputManager.SetAxisZero(Name);
                GetComponent<Image>().color = Color.white;
            }
        }

        public void SetDownState()
        {
            CrossPlatformInputManager.SetButtonDown(Name);
        }


        public void SetUpState()
        {
            CrossPlatformInputManager.SetButtonUp(Name);
        }


        public void SetAxisPositiveState()
        {
            CrossPlatformInputManager.SetAxisPositive(Name);
        }


        public void SetAxisNeutralState()
        {
            CrossPlatformInputManager.SetAxisZero(Name);
        }


        public void SetAxisNegativeState()
        {
            CrossPlatformInputManager.SetAxisNegative(Name);
        }

        public void Update()
        {

        }
    }
}
