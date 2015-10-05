using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/**
* ClickToLoadAsync controls loading bar on the loading image to 
* synchronize with the progress of loading an scene.
*/
public class ClickToLoadAsync : MonoBehaviour {

    public Slider loadingBar;
    public GameObject loadingImage;


    private AsyncOperation async;

    /**
    * ClickAsync shows loading image and loading the progress bar.
    */
    public void ClickAsync(int level)
    {
        loadingImage.SetActive(true);
        StartCoroutine(LoadLevelWithBar(level));
    }


    /**
    * LoadLevelWithBar loads a specific level
    */
    IEnumerator LoadLevelWithBar(int level)
    {
        async = Application.LoadLevelAsync(level);
        while (!async.isDone)
        {
            loadingBar.value = async.progress;
            yield return null;
        }
    }
}
