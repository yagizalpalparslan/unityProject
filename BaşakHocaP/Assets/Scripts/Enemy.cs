using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    [SerializeField] int ScorePerHit = 15;
    [SerializeField] int hitPoints = 4;
    Score score;
    [SerializeField] GameObject deathVfx;
    [SerializeField] GameObject hitVfx;
    [SerializeField] Transform parent;
    [SerializeField] GameObject parentV2;
    [SerializeField] AudioClip olme;
    new AudioSource audio;
    public GameObject yoket1;



    void Start()
    {
        audio = GetComponent<AudioSource>();
        score = FindObjectOfType<Score>();
    }

    void OnParticleCollision()
    {

        HitProcess();
        if (hitPoints < 1)
        {
            KillProcess();
        }
    }

    void HitProcess()
        {
            GameObject vfx = Instantiate(hitVfx, transform.position, Quaternion.identity);
            hitPoints--;
            score.IncreaseScore(ScorePerHit);
        }

        void KillProcess()
    {
        audio.PlayOneShot(olme);
        GameObject vfx = Instantiate(deathVfx, transform.position, Quaternion.identity);
        vfx.transform.parent = parent;
        GetComponent<MeshRenderer>().enabled = false;

        GetComponent<MeshCollider>().enabled = false;
        // Destroy(gameObject);
        // Destroy(parentV2);
    }
}