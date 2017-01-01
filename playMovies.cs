using UnityEngine;
using System.Collections;

public class playMovies : MonoBehaviour {

#if UNITY_WEBGL
    public WebGLMovieTexture[] GL_movies;
#else
    public MovieTexture[] movies;
#endif

    public AudioClip[] movieAudios;
    void Awake() {
        #if UNITY_WEBGL
        GL_movies = new WebGLMovieTexture[7];
        GL_movies[0] = new WebGLMovieTexture("StreamingAssets/OldPublicDomainCommercials0.mp4");
        GL_movies[1] = new WebGLMovieTexture("StreamingAssets/OldPublicDomainCommercials3.mp4");
        GL_movies[2] = new WebGLMovieTexture("StreamingAssets/OldPublicDomainCommercials4.mp4");
        GL_movies[3] = new WebGLMovieTexture("StreamingAssets/OldPublicDomainCommercials5.mp4");
        GL_movies[4] = new WebGLMovieTexture("StreamingAssets/OldPublicDomainCommercials6.mp4");
        GL_movies[5] = new WebGLMovieTexture("StreamingAssets/OldPublicDomainCommercials7.mp4");
        GL_movies[6] = new WebGLMovieTexture("StreamingAssets/OldPublicDomainCommercials8.mp4");
        #endif
    }
}
