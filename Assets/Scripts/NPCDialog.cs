
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;

public class NPCDialog : MonoBehaviour
{
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private GameObject ToActivate;
    [SerializeField] private Transform standingPoint;
    Transform avatar;

    private async void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            avatar = other.transform;

            // disable player input 
            avatar.GetComponent<PlayerInput>().enabled = false;

            await Task.Delay(2000);


            //teleport the avatar to standing point
            avatar.position = standingPoint.position;
            avatar.rotation = standingPoint.rotation;

            mainCamera.SetActive(false);
            ToActivate.SetActive(true);

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void Recover()
    {
        avatar.GetComponent<PlayerInput>().enabled = true;


        mainCamera.SetActive(true);
        ToActivate.SetActive(false);

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }
}
