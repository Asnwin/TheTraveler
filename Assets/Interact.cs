using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public GameObject Panel;
    bool near;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            near = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            near = false;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (near)
        {
            if (Input.GetKeyDown(KeyCode.E))    
                {
                Panel.SetActive(true);
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                Panel.SetActive(false);
            }
        }

        if (near == false)
        {
            Panel.SetActive(false);
        }
    }
}
