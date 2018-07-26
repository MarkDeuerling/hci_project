using UnityEngine;
using UnityEngine.Experimental.UIElements;
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

    public AudioSource audioSourceDinoDokuSound;
    public AudioClip audioDinoDokuSound;

    [SerializeField]
    public Button stopButton;

	VideoPlayer video;
	GameObject curActive;
	bool uiState;
	bool arState;
	bool showAr;
	
	void Start ()
	{
		video = GetComponent<VideoPlayer>();
		UI_Dummy.SetActive(uiState);
        stopButton = GetComponent<Button>();
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
        if (Input.GetKeyDown(KeyCode.X) && showAr)
        {
            curActive.SetActive(arState = !arState);
            audioSourceDinoDokuSound.mute = false;
            audioSourceDinoDokuSound.Play();
        }
	}

	void WaitForArPop(long frame, GameObject activate)
	{
		if (video.frame == frame)
		{
			video.playbackSpeed = 0;
			curActive = activate;
			showAr = true;
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
			video.Stop();
			video.playbackSpeed = 1;
			video.Play();
		}
	}

	public void OnStartVideo()
	{
		
	}

	public void OnExitVideo()
	{
		
	}
	
	
}
