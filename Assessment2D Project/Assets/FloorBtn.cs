using System.Collections;
using System.Collections.Generic;
using UnityEditor.Purchasing;
using UnityEngine;
using UnityEngine.Events;

public class FloorBtn : MonoBehaviour
{
    public Sprite buttonPressedSprite;
    public UnityEvent buttonPressed;
    public GameObject light;

    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            buttonPressed.Invoke();
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = buttonPressedSprite;
            light.gameObject.SetActive(false);
        }        
    }
}
