using UnityEngine;
using UnityEngine.Video;

public class ARController : MonoBehaviour
{

	public GameObject VR_1;
	public GameObject VR_2;
	public GameObject VR_3;
	public GameObject VR_4;

	public long VR_1_frame = 73;
	public long VR_2_frame = 200;
	public long VR_3_frame = 380;
	public long VR_4_frame = 420;
	
	VideoPlayer vp;
	GameObject curActive;
	
	void Start ()
	{
		vp = GetComponent<VideoPlayer>();
	}
	
	void Update ()
	{
		print(vp.frame);
		Restart();
		Continue();
		Stop();
		Play();
		ShowVRImage(VR_1_frame, VR_1);
		ShowVRImage(VR_2_frame, VR_2);
		ShowVRImage(VR_3_frame, VR_3);
		ShowVRImage(VR_4_frame, VR_4);
	}

	void ShowVRImage(long frame, GameObject activate)
	{
		if (vp.frame == frame)
		{
			vp.playbackSpeed = 0;
			activate.SetActive(true);
			curActive = activate;
		}
	}

	void Continue()
	{
		if (Input.GetKeyDown(KeyCode.A))
		{
			vp.frame += 1;
			vp.playbackSpeed = 1;
			curActive.SetActive(false);
		}
	}

	void Restart()
	{
		if (Input.GetKeyDown(KeyCode.S))
		{
			vp.Stop();
			vp.Play();
		}
	}

	void Stop()
	{
		if (Input.GetKeyDown(KeyCode.D) && vp.playbackSpeed >= 1)
			vp.playbackSpeed = 0;
	}

	void Play()
	{
		if (Input.GetKeyDown(KeyCode.D) && vp.playbackSpeed <= 0)
			vp.playbackSpeed = 1;
	}
}
