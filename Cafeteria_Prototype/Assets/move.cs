using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
    {
        public CharacterController player;
        public Transform rotation;
        RaycastHit objects;
        GameObject interacting;
        public bool interacted = false;
        Vector3 movement;
        Vector3 front;
        Vector3 left;
        // Start is called before the first frame update
        void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        // Update is called once per frame
        void Update()
        {
        front = transform.forward * Input.GetAxis("Vertical");
        left = transform.right * Input.GetAxis("Horizontal");
        movement = front + left;
        movement.y = 0;
        player.Move(movement / 100);
        transform.eulerAngles += new Vector3(Input.GetAxis("Mouse Y") * -10, Input.GetAxis("Mouse X") * 10, 0);





        if (Input.GetButtonDown("Fire1"))
            {
                    Physics.BoxCast(transform.position, Vector3.one / 10, transform.forward, out objects);
                    if (objects.collider.tag == "interactable")
                    {
                        interacting = objects.collider.gameObject;
                        interacted = true;
                    }
            }
            if (Input.GetButtonDown("Fire2"))
            {
                interacting = null;
                interacted = false;
            }
                if (interacted)
            {
                interacting.transform.position = this.transform.position + transform.forward;
                interacting.transform.rotation = this.transform.rotation;
            }
        }
    }
