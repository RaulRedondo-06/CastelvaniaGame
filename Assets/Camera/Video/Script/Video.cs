using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Video : MonoBehaviour
{
    [SerializeField]
    VideoPlayer myVideoPlayer;
    public string sceneToLoad = "nivel_1"; 
    void Start()
    {
        myVideoPlayer.loopPointReached += EndVideo;
    }

    void EndVideo(VideoPlayer vp) 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
