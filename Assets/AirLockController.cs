using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// import DOMoveX
using DG.Tweening;

public class AirLockController : MonoBehaviour
{
    [SerializeField] private Transform door1_right;
    [SerializeField] private Transform door1_left;
    [SerializeField] private Transform door2_right;
    [SerializeField] private Transform door2_left;

    [SerializeField] private float door_speed = 1f;
    [SerializeField] private float door_open_distance = 10f;

    private bool door_status = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // is Use or E pressed?
        if (Input.GetKeyDown(KeyCode.E))
        {
            // check distance to the Player
            Transform player = GameObject.Find("Player").transform;
            // check distance
            if (Vector3.Distance(player.position, transform.position) < 2f)
            {
                // open/close the door
                door_status = !door_status;

                if (door_status)
                {
                    door1_left.DOMoveX(door1_left.position.x + door_open_distance, 2);
                    door1_right.DOMoveX(door1_right.position.x - door_open_distance, 2);

                    door2_left.DOMoveX(door2_left.position.x - door_open_distance, 2);
                    door2_right.DOMoveX(door2_right.position.x + door_open_distance, 2);
                    //door1_right.DOMoveX(door1_right.position.x - door_open_distance, 2).OnComplete(() => {
                    //    door1_left.DOMoveX(door1_left.position.x - door_open_distance, 2);
                    //    door1_right.DOMoveX(door1_right.position.x + door_open_distance, 2);
                    //});
                }
                else
                {
                    door1_left.DOMoveX(door1_left.position.x - door_open_distance, 2);
                    door1_right.DOMoveX(door1_right.position.x + door_open_distance, 2);

                    door2_left.DOMoveX(door2_left.position.x + door_open_distance, 2);
                    door2_right.DOMoveX(door2_right.position.x - door_open_distance, 2);
                }


            }
        }
    }
}
