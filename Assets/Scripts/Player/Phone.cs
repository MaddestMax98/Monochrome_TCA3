using Cinemachine;
using ScripatbleObj;
using ScriptedCamera;
using Unity.VisualScripting;
using UnityEngine;

namespace PlayerCharacter 
{
    public class Phone : MonoBehaviour
    {
        [SerializeField]
        private GameObject phone;
        [SerializeField]
        private CinemachineVirtualCamera fpsCamera;
        private bool isturnedOn = false;

        [SerializeField]
        private TaskData currentTask;

        [SerializeField]
        private PhoneUI phoneUI;
        private int signal = 0;
        public int Signal { get => signal; set => signal = value; }

        public void UpdateSignal()
        {
            phoneUI.UpdateSignal(Signal);
        }

        private void OnEnable()
        {
            phone.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.E) && !isturnedOn)
            {
                TurnOnPhone();
            }
            else if (Input.GetKeyDown(KeyCode.E) && isturnedOn)
            {
                TurnOffPhone();
            }
        }

        private void TurnOnPhone()
        {
            GetComponent<Player>().CanMove = false;
            isturnedOn = true;
            phone.SetActive(true);
            Manager.CameraManager.PreviousCamera = Manager.CameraManager.ActiveCamera;
            CameraSwitcher.SwitchCamera(fpsCamera);
        }

        private void TurnOffPhone()
        {
            GetComponent<Player>().CanMove = true;
            isturnedOn = false;
            phone.SetActive(false);
            CameraSwitcher.SwitchCamera(Manager.CameraManager.PreviousCamera);
        }
    }
}