using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class adManager : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener, IUnityAdsInitializationListener
{
    public static adManager Instance;

    string iosGameID = "5487392"; 
    string androidGameID = "5487393";

    string interstiialAdID;
    string rewardAdID;

    public bool testMode; 

    private float timer = 0f;
    private float waitIntervalForAd = 10000000f;

    AsyncOperation asyncLoad;

    int sceneID;


    public void Awake()
    {
        if (FindObjectsOfType<onGameLoad>().Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

        void Start()
    {
        string gameID;

#if UNITY_IOS
        gameID = iosGameID;
        interstiialAdID = "Interstitial_iOS";
        rewardAdID = "Rewarded_iOS";
#elif UNITY_ANDROID
        gameID = androidGameID;
        interstiialAdID= "Interstitial_Android";
        rewardAdID= "Rewarded_Android";
#elif UNITY_EDITOR
        gameID = iosGameID;//for testing
#endif
        Advertisement.Initialize(gameID, testMode, this);
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if(timer >= waitIntervalForAd)
        {
            Debug.Log("timer equals interval");
        }
    }

    public void ShowInterstitialAdAndChangeScene(int sceneID)
    {

        this.sceneID = sceneID;
        if (timer > waitIntervalForAd)  
        {
            //asyncLoad = SceneManager.LoadSceneAsync(sceneID);
            //asyncLoad.allowSceneActivation = false;
            try
            {
                Advertisement.Load(interstiialAdID, this);
            }
            catch
            {
                SceneManager.LoadScene(sceneID);
            }
        }
        else
        {
            SceneManager.LoadScene(sceneID);
        }
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        if (placementId.Equals(interstiialAdID))
        {
            Advertisement.Show(placementId, this);
        }
        if (placementId.Equals(rewardAdID))
        {
            Advertisement.Show(placementId, this);
        }
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        Debug.Log($"Ad completed on placement: {placementId}, Completion State: {showCompletionState}");
        //if (asyncLoad != null)
        //{
        //    asyncLoad.allowSceneActivation = true;
        //}
        //SceneManager.LoadScene(sceneID);
        if (placementId == interstiialAdID)
        {
            timer = 0f;
            SceneManager.LoadScene(sceneID);
        }
        if(placementId == rewardAdID)
        {
            currentData.seedsLeft += 5;
            SceneManager.LoadScene(4);
        }
    }

    public void showRewardedAd()
    {
        Advertisement.Load(rewardAdID, this);

    }







    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////




    //annoying shit i have to keep:

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.LogError($"Failed to load Ad: {message}");
    }

    public void OnUnityAdsReady(string placementId)
    {
        Debug.Log($"Ad ready on placement: {placementId}");
    }


    public void OnUnityAdsDidError(string message)
    {
        // Log the error message
        Debug.LogError($"Unity Ads Error: {message}");
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        // Log the start of the ad display
        Debug.Log($"Ad started on placement: {placementId}");
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        // Handle the ad finished event based on the result
        switch (showResult)
        {
            case ShowResult.Finished:
                Debug.Log($"Ad shown successfully on placement: {placementId}");
                break;
            case ShowResult.Skipped:
                Debug.LogWarning($"Ad was skipped on placement: {placementId}");
                break;
            case ShowResult.Failed:
                Debug.LogError($"Ad failed to show on placement: {placementId}");
                break;
        }
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        // Log the ad show failure
        Debug.LogError($"Ad failed to show on placement: {placementId}, Error: {error}, Message: {message}");
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        // Log the start of the ad show
        Debug.Log($"Ad is starting on placement: {placementId}");
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        // Log when the ad is clicked
        Debug.Log($"Ad clicked on placement: {placementId}");
    }

    public void OnInitializationComplete()
    {
        Debug.Log("initialization complete");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"initialization error, Error: {error}, Message: {message}");
    }
}


