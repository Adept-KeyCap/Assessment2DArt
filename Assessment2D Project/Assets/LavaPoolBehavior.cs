using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.Rendering;

public class LavaPoolBehavior : MonoBehaviour
{
    public GameObject lavalight;

    public void DrainLava()
    {
        StartCoroutine(DrainLavaCorutine());
    }

    private IEnumerator DrainLavaCorutine()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Dynamic;
        yield return new WaitForSeconds(1);
        lavalight.SetActive(true);
        Destroy(rb.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            
            StartCoroutine(ResetPlayer(collision.gameObject));
        }
    }

    private IEnumerator ResetPlayer(GameObject player)
    {
        
        player.SetActive(false);
        player.transform.position = new Vector3(-10, 2.85f, 0);

        yield return new WaitForSeconds(2);

        player.SetActive(true);
    }
}
