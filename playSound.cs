using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class playSound : MonoBehaviour {

	public AudioClip _door;
    public AudioClip _water;
    public AudioClip _closetDoor;
    public AudioClip _curtains;
    public AudioClip _slidingDoor;
    public AudioClip _fridgeDoor;
    public AudioClip _meow;
    public AudioClip _crate;
    public AudioClip _bomb;
    public AudioClip _drop;
	public static AudioClip Door;
    public static AudioClip Water;
    public static AudioClip ClosetDoor;
    public static AudioClip Curtains;
    public static AudioClip SlidingDoor;
    public static AudioClip FridgeDoor;
    public static AudioClip Meow;
    public static AudioClip Crate;
    public static AudioClip bomb;
    public static AudioClip drop;
	public static float soundVol=0.25f;
	float time;

	void Awake()
	{
        Door = _door;
        Water=_water;
        ClosetDoor=_closetDoor;
        Curtains=_curtains;
        SlidingDoor = _slidingDoor;
        FridgeDoor = _fridgeDoor;
        Meow = _meow;
        Crate = _crate;
        bomb = _bomb;
        drop = _drop;
	}


	public static void playTheSoundForCamera(AudioClip aClip, float vol)
	{ 
		AudioSource.PlayClipAtPoint (aClip, GameObject.FindWithTag("MainCamera").transform.position, vol);
	}
}
