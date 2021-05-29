using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PeliAlkaaButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("Menumusic");
    }

    // Update is called once per frame
    void Update()
    {
        SceneManager.LoadScene("SkaleScene");
    }
}
