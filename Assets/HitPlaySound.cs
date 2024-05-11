using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPlaySound : MonoBehaviour
{
    public AudioClip sound;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("StonePrefabTag")) 
        {
            AudioSource.PlayClipAtPoint(sound, transform.position);
        }
    }
}
