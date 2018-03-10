using UnityEngine;
using VRStandardAssets.Utils;

public class GazeInput : MonoBehaviour
{
	private VRInput vrInput;

	// modify suzuki
	public GazeInput()
	{
		// 熱対策
		OVRManager.cpuLevel = 0;
		OVRManager.gpuLevel = 0;
	}

	void Init() 
	{
		var vrObjects = FindObjectsOfType<VRInteractiveItem>(); //シーン中のVRInteractiveItemをすべて見つける。

		foreach (var vrObject in vrObjects)
		{
			vrObject.OnOver += OnOver; //GazeInputのOnOver()をサブスクライブ
			vrObject.OnOut += OnOut; //GazeInputのOnOut()をサブスクライブ
		}

		vrInput = FindObjectsOfType<VRInput>()[0];//シーン中のVRInputを見つける。一つのはずだが、複数なら最初のを。
	}

	void Start()
	{
		UnityEngine.VR.InputTracking.Recenter(); // modify suzuki
		Init ();
	}

	void Update()
	{
	}

	void OnOver()
	{
		vrInput.DoOnDown();
	}

	void OnOut()
	{
		vrInput.DoOnUp();
	}
}