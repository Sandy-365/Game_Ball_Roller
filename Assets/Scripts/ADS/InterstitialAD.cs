using UnityEngine;
using GoogleMobileAds.Api;
using System;
using System.Collections;

public class InterstitialAD : MonoBehaviour
{
    private InterstitialAd interstitialAd;
    private string adUnitId = "ca-app-pub-7636626627734979/4393672002";

    private Action onAdClosedCallback;

    void Start()
    {
        // Initialize the Mobile Ads SDK.
        MobileAds.Initialize(initStatus => LoadInterstitialAd());
    }

    // Load a new interstitial ad
    public void LoadInterstitialAd()
    {
        if (interstitialAd != null)
        {
            interstitialAd.Destroy();
            interstitialAd = null;
        }

        AdRequest request = new AdRequest();

        InterstitialAd.Load(adUnitId, request, (InterstitialAd ad, LoadAdError error) =>
        {
            if (error != null || ad == null)
            {
                Debug.LogError("Interstitial ad failed to load: " + error);
                return;
            }

            interstitialAd = ad;
            RegisterAdEvents(interstitialAd);
            Debug.Log("Interstitial ad loaded successfully.");
        });
    }

    // Show the interstitial ad
    public void ShowInterstitialAd(Action onAdClosed = null)
    {
        if (interstitialAd != null && interstitialAd.CanShowAd())
        {
            onAdClosedCallback = onAdClosed;
            interstitialAd.Show();
        }
        else
        {
            Debug.LogWarning("Ad not ready, loading new ad...");
            onAdClosed?.Invoke(); // Proceed even if the ad is not ready
            LoadInterstitialAd();  // Start loading for the next time
        }
    }

    // Register ad event handlers
    private void RegisterAdEvents(InterstitialAd ad)
    {
        ad.OnAdFullScreenContentClosed += () =>
        {
            Debug.Log("Ad closed by user.");
            onAdClosedCallback?.Invoke();

            // Delay loading next ad to prevent conflicts during scene changes
            StartCoroutine(LoadAdWithDelay());
        };

        ad.OnAdFullScreenContentFailed += (AdError error) =>
        {
            Debug.LogError("Ad failed to show: " + error);
            onAdClosedCallback?.Invoke();
            StartCoroutine(LoadAdWithDelay());
        };

        ad.OnAdImpressionRecorded += () => Debug.Log("Ad impression recorded.");
        ad.OnAdClicked += () => Debug.Log("Ad clicked.");
    }

    // Coroutine to delay loading the next ad
    private IEnumerator LoadAdWithDelay()
    {
        yield return new WaitForSeconds(0.5f);
        LoadInterstitialAd();
    }

    private void OnDestroy()
    {
        if (interstitialAd != null)
        {
            interstitialAd.Destroy();
        }
    }
}
