using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scroll_script : MonoBehaviour
{
    public GameObject scrollCanvas;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            scrollCanvas.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            scrollCanvas.SetActive(false);
        }
    }
}
