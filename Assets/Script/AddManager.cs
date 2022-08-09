using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AddManager : MonoBehaviour, IUnityAdsListener
{
	private string gameId = "4294268";
	private string placementId = "Reward";
	public static AddManager instance;

	private void Awake()
	{
		instance = this;
	}


	public void PlayAdd()
	{
		Advertisement.Show(placementId);
	}
	public void OnUnityAdsDidError(string message)
	{
		
	}
	public void OnUnityAdsDidFinish(string placementId, ShowResult result)
	{
		if(result == ShowResult.Finished)
		{
			
		}
	}
	public void OnUnityAdsDidStart(string placementId)
	{
		
	}
	public void OnUnityAdsReady(string placementId)
	{
		//Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
		//Advertisement.Banner.Show("Banner");
	}
    // Start is called before the first frame update
    void Start()
    {
		Advertisement.AddListener(this);
		Advertisement.Initialize (gameId, false);
    }
	public void OnShowAddButton()
	{
		AddManager.instance.PlayAdd();
	}
		
}
