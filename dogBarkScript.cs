using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;

public class dogBarkScript : MonoBehaviour {

    float barkTime = 0;
    float dist;
    bool dogHasBarked = false;
    public AudioClip bark, growl;
    float barkDelay = 5;
    float barkDist = 6;
    float growlDist = 2;


    void closeWarning()
    {
        GameObject.Find("closerWarning").GetComponent<Text>().DOFade(0, 1f);
    }
    void Update()
    {

        dist = Vector3.Distance(GameManager.Player.transform.position, transform.position);
        if (dist <= barkDist)
        {
            if (GameManager.MainCamera.GetComponent<CameraController>().currentRoom.Equals("Front Yard") || GameManager.MainCamera.GetComponent<CameraController>().currentRoom.Equals("Living Room"))
            {
                AudioClip oldClip = gameObject.GetComponent<AudioSource>().clip;
                if (dist >= growlDist)
                    gameObject.GetComponent<AudioSource>().clip = bark;
                else
                    gameObject.GetComponent<AudioSource>().clip = growl;

                AudioClip newClip = gameObject.GetComponent<AudioSource>().clip;

                if (oldClip == newClip)
                    barkDelay = 10f;
                else
                {
                    gameObject.GetComponent<AudioSource>().Stop();
                    barkDelay = 0f;
                }

                if (!dogHasBarked)
                {
                    gameObject.GetComponent<AudioSource>().Play();
                    dogHasBarked = true;
                    barkTime = Time.time;
                }
                else if (dogHasBarked && Time.time - barkTime >= barkDelay && !gameObject.GetComponent<AudioSource>().isPlaying)
                {
                    gameObject.GetComponent<AudioSource>().Play();
                    barkTime = Time.time;
                }
            }
        }
        else if (dist > barkDist || GameManager.MainCamera.GetComponent<CameraController>().currentRoom.Equals("Front Yard"))
        {
            if (gameObject.GetComponent<AudioSource>().isPlaying) gameObject.GetComponent<AudioSource>().Stop();
        }
    }
}
