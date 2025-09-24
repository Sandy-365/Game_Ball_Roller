using UnityEngine;
using GoogleMobileAds.Api;

public class BannerADTop : MonoBehaviour
{
    private BannerView _bannerView;
    private string _adUnitId = "ca-app-pub-7636626627734979/6119184193"; // Test Ad Unit ID

    void Start()
    {
        // Initialize Google Mobile Ads
        MobileAds.Initialize(initStatus => { });

        // Create and load the banner ad
        CreateBannerView();
        LoadAd();
    }

    void CreateBannerView()
    {
        if (_bannerView != null)
        {
            _bannerView.Destroy();
        }

        // Set the position to Top
        _bannerView = new BannerView(_adUnitId, AdSize.Banner, AdPosition.Top);
    }

    void LoadAd()
    {
        if (_bannerView == null) return;

        AdRequest adRequest = new AdRequest();
        _bannerView.LoadAd(adRequest);
    }

    void OnDestroy()
    {
        if (_bannerView != null)
        {
            _bannerView.Destroy();
        }
    }
}
