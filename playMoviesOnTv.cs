using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class playMoviesOnTv : MonoBehaviour {

    int playNumber;
    int oldNumber = -1;
    int minRandomNumber = 0;
    int maxRandomNumber;
    bool soundOn;



#if UNITY_WEBGL
    WebGLMovieTexture GL_currentMovie;
#else
    public MovieTexture currentMovie;
#endif


    AudioClip currentSound;
    public AudioSource tvSoundSource;
    void Start()
    {
        soundOn = SceneManager.GetActiveScene().name == "environmental" && gameObject.layer == LayerMask.NameToLayer("livingRoom"); //only environmental livingroom tv has sound;


#if UNITY_WEBGL
        if (Application.platform.Equals(RuntimePlatform.WebGLPlayer))
        {
            gameObject.transform.localScale = new Vector3(1, -1, 1);
            maxRandomNumber = GameObject.Find("Movies").GetComponent<playMovies>().GL_movies.Length;
            playNumber = Random.Range(minRandomNumber, maxRandomNumber);
            GL_currentMovie = GameObject.Find("Movies").GetComponent<playMovies>().GL_movies[playNumber];
            GetComponent<Renderer>().material.mainTexture = GL_currentMovie;

            GL_currentMovie.Play();
            GL_currentMovie.loop = true;
            
            currentSound = GameObject.Find("Movies").GetComponent<playMovies>().movieAudios[playNumber];
            tvSoundSource.clip = currentSound;
            if(soundOn) tvSoundSource.Play();
            
            Invoke("drawNumber", GL_currentMovie.duration);

        }

#else
        maxRandomNumber = GameObject.Find("Movies").GetComponent<playMovies>().movies.Length;
        playNumber = Random.Range(minRandomNumber, maxRandomNumber);
        currentMovie = GameObject.Find("Movies").GetComponent<playMovies>().movies[playNumber];
        GetComponent<Renderer>().material.mainTexture = currentMovie;
        currentMovie.Play();
        currentMovie.loop = true;

        currentSound = GameObject.Find("Movies").GetComponent<playMovies>().movieAudios[playNumber];
        
        tvSoundSource.clip = currentSound;
        if(soundOn) tvSoundSource.Play();
        Invoke("drawNumber", currentSound.length);
#endif

    }
    void Update()
    {
#if UNITY_WEBGL
        if (Application.platform.Equals(RuntimePlatform.WebGLPlayer))
        {
            GL_currentMovie.Update();
        }
#endif
    }

    public void drawNumber()
    {
        tvSoundSource.Stop();
        playNumber = Random.Range(minRandomNumber, maxRandomNumber);
        while (playNumber.Equals(oldNumber)) playNumber = Random.Range(minRandomNumber, maxRandomNumber);

        #if UNITY_WEBGL
            GL_currentMovie.Seek(0f);
            GL_currentMovie = GameObject.Find("Movies").GetComponent<playMovies>().GL_movies[playNumber];
            GetComponent<Renderer>().material.mainTexture = GL_currentMovie;
           
            GL_currentMovie.Play();
            GL_currentMovie.loop = true;
            
            
            currentSound = GameObject.Find("Movies").GetComponent<playMovies>().movieAudios[playNumber];

            tvSoundSource.clip = currentSound;
            if(soundOn) tvSoundSource.Play();
             
            Invoke("drawNumber", GL_currentMovie.duration);
        #else
            currentMovie.Stop();
            currentMovie = GameObject.Find("Movies").GetComponent<playMovies>().movies[playNumber];
            GetComponent<Renderer>().material.mainTexture = currentMovie;
            currentMovie.Play();
            currentMovie.loop = true;

            currentSound = GameObject.Find("Movies").GetComponent<playMovies>().movieAudios[playNumber];
            tvSoundSource.clip = currentSound;
            if (soundOn) tvSoundSource.Play(); ;
            Invoke("drawNumber", currentSound.length);
        #endif

    }

   
}