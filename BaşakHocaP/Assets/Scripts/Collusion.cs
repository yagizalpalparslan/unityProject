using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collusion : MonoBehaviour
{
    [SerializeField] float loaddelay = 1f;
    [SerializeField] GameObject crashVfx;
    public GameObject ecder;
    public GameObject ecder2;
    [SerializeField] Transform parent;
    [SerializeField] AudioClip olme;
    new AudioSource audio;


    void Start()
    {
        audio = GetComponent<AudioSource>();
    }


    private void OnTriggerEnter(Collider collision)

    {
        Debug.Log("asd");
        GameObject vfx = Instantiate(crashVfx, transform.position, Quaternion.identity);
        vfx.transform.parent = parent;
        audio.PlayOneShot(olme);
        ecder2.GetComponent<SkinnedMeshRenderer>().enabled = false;
       GetComponent<Movement>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        Invoke("Reloadlevel", loaddelay);
    }




    void Reloadlevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}