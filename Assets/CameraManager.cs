using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private InventoryManager inventoryManager;
    
    public Camera mainCamera;
    public Camera GunCamera;  // This camera is fixed on the barrel of the gun and is used for better aiming

    // Start is called before the first frame update
    void Start()
    {
        // Render the main camera on screen and put a small gun camera view in the top left side
        mainCamera.rect = new Rect(0, 0, 1, 1);
        GunCamera.rect = new Rect(0, 0, 0.2f, 0.2f);

        inventoryManager = FindObjectOfType<InventoryManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // Gun camera must follow the mouse
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Vector3 target = hit.point;
            target.y = transform.position.y;
            Quaternion rotation = Quaternion.LookRotation(target - transform.position);
            transform.rotation = Quaternion.Slerp(GunCamera.transform.rotation, rotation, Time.deltaTime * 10);
        }

        // Add bobbing to the gun camera when moving
        /*if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            transform.localPosition = new Vector3(0, 0.1f * Mathf.Sin(Time.time * 10) + 1, 0);
        }
        else
        {
            // default pos is at 0,1,0
            transform.localPosition = Vector3.Lerp(GunCamera.transform.localPosition, new Vector3(0, 1, 0), Time.deltaTime * 5);
        }*/
    }
}
