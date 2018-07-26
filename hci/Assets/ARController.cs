using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class ARController : MonoBehaviour
{

	public GameObject VR_1;
	public GameObject VR_2;
	public GameObject VR_3;
	public GameObject VR_4;
	public GameObject UI_Dummy;
	public GameObject AR_1_UI;

	public long VR_1_frame = 73;
	public long VR_2_frame = 200;
	public long VR_3_frame = 380;
	public long VR_4_frame = 420;

	public float LoadSpeed = 1;
	
	VideoPlayer video;
	GameObject curActive;
	GameObject curUiActive;
	bool uiState;
	bool arState;
	bool showAr;
	
	void Start ()
	{
		video = GetComponent<VideoPlayer>();
		UI_Dummy.SetActive(uiState);
	}
	
	void Update ()
	{
		print(video.frame);
		Restart();
		Continue();
		WaitForArPop(VR_1_frame, VR_1, AR_1_UI);
		WaitForArPop(VR_2_frame, VR_2, null);
		WaitForArPop(VR_3_frame, VR_3, null);
		WaitForArPop(VR_4_frame, VR_4, null);
		ShowArImage();
		ShowHud();
	}

	void ShowArImage()
	{
		if (Input.GetKeyDown(KeyCode.X) && showAr)
		{
			curActive.SetActive(arState = !arState);
			if (curUiActive != null)
				curUiActive.SetActive(arState);
		}
	}

	void WaitForArPop(long frame, GameObject activate, GameObject uiActivate)
	{
		if (video.frame == frame)
		{
			video.playbackSpeed = 0;
			curActive = activate;
			showAr = true;
			curUiActive = uiActivate != null ? uiActivate : null;
		}
	}

	void ShowHud()
	{
		if (Input.GetKeyDown(KeyCode.Y))
			UI_Dummy.SetActive(uiState = !uiState);	
	}

	void Continue()
	{
		if (Input.GetKeyDown(KeyCode.A))
		{
			video.frame += 1;
			video.playbackSpeed = 1;
			curActive.SetActive(false);
			showAr = false;
			if (curUiActive != null)
			{
				curUiActive.SetActive(false);
				AR_1_UI.GetComponentInChildren<AudioSource>().Stop();
			}
		}
	}

	void Restart()
	{
		if (Input.GetKeyDown(KeyCode.S))
		{
			VR_1.SetActive(false);
			VR_2.SetActive(false);
			VR_3.SetActive(false);
			VR_4.SetActive(false);
			AR_1_UI.SetActive(false);
			video.Stop();
			video.playbackSpeed = 1;
			video.Play();
		}
	}

	public void OnStartSound()
	{
		var img = AR_1_UI.GetComponentsInChildren<Image>();
		StartCoroutine(AnimateLoad(img[1]));
	}

	IEnumerator AnimateLoad(Image img)
	{
		while (img.fillAmount < 1)
		{
			var dt = Time.deltaTime;
			img.fillAmount += dt;
			yield return new WaitForSeconds(dt / LoadSpeed);
		}

		var sound = AR_1_UI.GetComponentInChildren<AudioSource>();
		sound.Play();
	}

	public void OnStartVideo()
	{
		
	}

	public void OnExitVideo()
	{
		
	}
	
	
}
