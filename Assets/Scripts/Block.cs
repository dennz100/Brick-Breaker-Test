using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    [SerializeField] AudioClip[] breakSounds;

    // cached reference
    Level level;

    private void Start()
    {
        level = FindObjectOfType<Level>();
        level.CountBreakableBlocks();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        DestroyBlock();
    }

    private void DestroyBlock()
    {
        level.BlockDestroyed();
        AudioClip clip = breakSounds[UnityEngine.Random.Range(0, breakSounds.Length - 1)];
        AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);
        Destroy(gameObject);
    }
}
