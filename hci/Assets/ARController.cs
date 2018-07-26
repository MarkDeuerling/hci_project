using UnityEngine;
using UnityEngine.Video;

public class ARController : MonoBehaviour
{

	public GameObject VR_1;
	public GameObject VR_2;
	public GameObject VR_3;
	public GameObject VR_4;
	public GameObject UI_Dummy;

	public long VR_1_frame = 73;
	public long VR_2_frame = 200;
	public long VR_3_frame = 380;
	public long VR_4_frame = 420;
	
	VideoPlayer video;
	GameObject curActive;
	bool uiState;
	bool arSate;
	
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
		WaitForArPop(VR_1_frame, VR_1);
		WaitForArPop(VR_2_frame, VR_2);
		WaitForArPop(VR_3_frame, VR_3);
		WaitForArPop(VR_4_frame, VR_4);
		ShowArImage();
		ShowHud();
	}

	void ShowArImage()
	{
		if (Input.GetKeyDown(KeyCode.X))
			curActive.SetActive(arSate = !arSate);
	}

	void WaitForArPop(long frame, GameObject activate)
	{
		if (video.frame == frame)
		{
			video.playbackSpeed = 0;
			curActive = activate;
		}
	}

	void ShowHud()
	{
		if (Input.GetKeyDown(KeyCode.Y))
		{
			UI_Dummy.SetActive(uiState = !uiState);	
		}
	}

	void Continue()
	{
		if (Input.GetKeyDown(KeyCode.A))
		{
			video.frame += 1;
			video.playbackSpeed = 1;
			curActive.SetActive(false);
		}
	}

	void Restart()
	{
		if (Input.GetKeyDown(KeyCode.S))
		{
			video.Stop();
			video.playbackSpeed = 1;
			video.Play();
		}
	}
}
