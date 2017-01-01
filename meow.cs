using UnityEngine;
using System.Collections;

public class meow : MonoBehaviour {

	// Use this for initialization

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
            playSound.playTheSoundForCamera(playSound.Meow, playSound.soundVol);
    }
}
