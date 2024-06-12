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
    public GameObject Skinn;
    new AudioSource audio;
    



    void Start()
    {
        audio = GetComponent<AudioSource>();
        score = FindObjectOfType<Score>();
    }

    void OnParticleCollision()
    {
        Debug.Log("asdasd");

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
        if (Skinn.GetComponent<MeshRenderer>() == null) 
        {
           Skinn.GetComponent<SkinnedMeshRenderer>().enabled = false;        
        }
        else { Skinn.GetComponent<MeshRenderer>().enabled = false; }
        
       
        if (Skinn.GetComponent<MeshCollider>() == null)
        {
            Skinn.GetComponent<BoxCollider>().enabled = false;
        }
        else { Skinn.GetComponent<MeshCollider>().enabled = false; }
        
        // Destroy(gameObject);
        // Destroy(parentV2);
    }
}