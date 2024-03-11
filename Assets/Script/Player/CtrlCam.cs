using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CtrlCam : MonoBehaviour
{
    public float Senx;
    public float Seny;

    private float xRotation;
    private float yRotation;

    private float MouseX;
    private float MouseY;

    public Transform Orientation;
    public Canvas PauseMenu;

    private bool isPauseMenuOpen = false;

    public LayerMask ItemLayerMask;
    public GameObject Axe;
    private bool CanGetItem;
    private float distanceToAxe = 5f;
    public GameObject OldAxe;
    // Start is called before the first frame update
    void Start()
    {
        PauseMenu.enabled = false;
        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

        MouseX = Input.GetAxisRaw("Mouse X")*Senx*Time.deltaTime;
        MouseY = Input.GetAxisRaw("Mouse Y")*Seny*Time.deltaTime;

        yRotation += MouseX;
        xRotation -= MouseY;

        xRotation = Mathf.Clamp(xRotation,-90f,90f);

        transform.rotation = Quaternion.Euler(xRotation,yRotation,0f);
        Orientation.rotation = Quaternion.Euler(0f,yRotation,0f);

        if(Input.GetKeyDown(KeyCode.P))
        {
            OpenPauseMenu();
        }

        GetItems();
    }

    private void OpenPauseMenu()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        PauseMenu.enabled = true;
        isPauseMenuOpen = true;
        Time.timeScale = 0f;
    }

    void GetItems()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        CanGetItem = Physics.Raycast(ray,distanceToAxe,ItemLayerMask);
        
        if(CanGetItem && Input.GetButtonDown("Fire1"))
        {
            Axe.SetActive(true);
            Destroy(OldAxe);
        }
    }
}
