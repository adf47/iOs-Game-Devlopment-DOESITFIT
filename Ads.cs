using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class Ads : MonoBehaviour
{
	public void ShowAd()
	{
		if (Advertisement.IsReady())
		{
			//to continue game with score
			BallBehavior.AdClicked = true;

			//show the advertisement
			Advertisement.Show();
		}

	}
}
