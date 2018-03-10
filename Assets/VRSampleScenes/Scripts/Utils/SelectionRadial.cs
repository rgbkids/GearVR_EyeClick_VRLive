using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

namespace VRStandardAssets.Utils
{
    // This class is used to control a radial bar that fills
    // up as the user holds down the Fire1 button.  When it has
    // finished filling it triggers an event.  It also has a
    // coroutine which returns once the bar is filled.
    public class SelectionRadial : MonoBehaviour
    {
        public event Action OnSelectionComplete;                                                // This event is triggered when the bar has filled.


//		[SerializeField] private float m_SelectionDuration = 2f;                                // How long it takes for the bar to fill.
		[SerializeField] private float m_SelectionDuration = 6.0f; // modify suzuki             // How long it takes for the bar to fill.

		[SerializeField] private bool m_HideOnStart = true;                                     // Whether or not the bar should be visible at the start.
		[SerializeField] private Image m_Selection;                                             // Reference to the image who's fill amount is adjusted to display the bar.
//		[SerializeField] private static Image m_Selection; // modify suzuki static              // Reference to the image who's fill amount is adjusted to display the bar.
        [SerializeField] private VRInput m_VRInput;                                             // Reference to the VRInput so that input events can be subscribed to.
        

        private Coroutine m_SelectionFillRoutine;                                               // Used to start and stop the filling coroutine based on input.
        private bool m_IsSelectionRadialActive;                                                    // Whether or not the bar is currently useable.
        private bool m_RadialFilled;                                                               // Used to allow the coroutine to wait for the bar to fill.

		private GameObject[] reticleImages; // modify suzuki
		private long fillAmountEndOverCnt; // modify suzuki
		private int countNum; // modify suzuki

        public float SelectionDuration { get { return m_SelectionDuration; } }

		// modify suzuki
//		public static void ClearSelectionFillAmount()
//		{
//			m_Selection.fillAmount = 0f;
//		}

        private void OnEnable()
        {
            m_VRInput.OnDown += HandleDown;
            m_VRInput.OnUp += HandleUp;
        }


        private void OnDisable()
        {
            m_VRInput.OnDown -= HandleDown;
            m_VRInput.OnUp -= HandleUp;
        }


        private void Start()
        {
            // Setup the radial to have no fill at the start and hide if necessary.
            m_Selection.fillAmount = 0f;

            if(m_HideOnStart)
                Hide();

			// modify suzuki
			/*
			reticleImages = new GameObject[5];
			reticleImages[0] = GameObject.Find("ReticleImage0");
			reticleImages[1] = GameObject.Find("ReticleImage1");
			reticleImages[2] = GameObject.Find("ReticleImage2");
			reticleImages[3] = GameObject.Find("ReticleImage3");
			reticleImages[4] = GameObject.Find("ReticleImageGO");
			*/
			reticleImages = new GameObject[10];
			reticleImages[0] = GameObject.Find("ReticleImage3");
			reticleImages[1] = GameObject.Find("ReticleImage3");
			reticleImages[2] = GameObject.Find("ReticleImage2");
			reticleImages[3] = GameObject.Find("ReticleImage2");
			reticleImages[4] = GameObject.Find("ReticleImage2");
			reticleImages[5] = GameObject.Find("ReticleImage1");
			reticleImages[6] = GameObject.Find("ReticleImage1");
			reticleImages[7] = GameObject.Find("ReticleImage1");
			reticleImages[8] = GameObject.Find("ReticleImage0");
			reticleImages[9] = GameObject.Find("ReticleImageGO");
			for (int i = 0; i < reticleImages.Length; i++) 
			{
				reticleImages [i].SetActive (false);
			}

			// modify suzuki
			countNum = (int)m_SelectionDuration;
//			countNum = (int)(m_SelectionDuration / reticleImages.Length);
//			countNum = reticleImages.Length - 0;
        }

		private void Update()
		{
			// modify suzuki
			for (int i = 0; i < reticleImages.Length - 1; i++) 
			{
				reticleImages [i].SetActive (false);
			}

			if (m_Selection.fillAmount < 1) 
			{
				if (m_IsSelectionRadialActive) 
				{
//					int cntIdx = (int)((m_Selection.fillAmount * 10) / countNum);
//					int cntIdx = (int)((m_Selection.fillAmount * 100) / (countNum*10));
					int cntIdx = (int)(m_Selection.fillAmount * 10);
					try {

//						Debug.Log("m_Selection.fillAmount="+m_Selection.fillAmount);
						//Debug.Log("cntIdx=" + cntIdx + " countNum=" + countNum + " reticleImages.Length - 1 - cntIdx =" + (reticleImages.Length - 1 - cntIdx));

//						reticleImages [countNum - 1 - cntIdx].SetActive (true);
//						reticleImages [reticleImages.Length - 1 - cntIdx].SetActive (true);
//						reticleImages [cntIdx].SetActive (true);
						reticleImages [cntIdx - 1].SetActive (true);
//						reticleImages [countNum - 0 - cntIdx].SetActive (true);
					} catch (Exception e) {
						Debug.Log (e);
					}

					fillAmountEndOverCnt = 0;
				}
			}
			else 
			{
				if (fillAmountEndOverCnt > 10) 
				{
					reticleImages [reticleImages.Length - 1].SetActive (true);
				}
				fillAmountEndOverCnt++;
			}
		}


        public void Show()
        {
            m_Selection.gameObject.SetActive(true);
            m_IsSelectionRadialActive = true;
        }


        public void Hide()
        {
            m_Selection.gameObject.SetActive(false);
            m_IsSelectionRadialActive = false;

            // This effectively resets the radial for when it's shown again.
            m_Selection.fillAmount = 0f;
        }


        private IEnumerator FillSelectionRadial()
        {
            // At the start of the coroutine, the bar is not filled.
            m_RadialFilled = false;

            // Create a timer and reset the fill amount.
            float timer = 0f;
            m_Selection.fillAmount = 0f;
            
            // This loop is executed once per frame until the timer exceeds the duration.
            while (timer < m_SelectionDuration)
            {
                // The image's fill amount requires a value from 0 to 1 so we normalise the time.
                m_Selection.fillAmount = timer / m_SelectionDuration;

                // Increase the timer by the time between frames and wait for the next frame.
                timer += Time.deltaTime;
                yield return null;
            }

            // When the loop is finished set the fill amount to be full.
            m_Selection.fillAmount = 1f;

            // Turn off the radial so it can only be used once.
            m_IsSelectionRadialActive = false;

            // The radial is now filled so the coroutine waiting for it can continue.
            m_RadialFilled = true;

            // If there is anything subscribed to OnSelectionComplete call it.
            if (OnSelectionComplete != null)
                OnSelectionComplete();
        }


        public IEnumerator WaitForSelectionRadialToFill ()
        {
            // Set the radial to not filled in order to wait for it.
            m_RadialFilled = false;

            // Make sure the radial is visible and usable.
            Show ();

            // Check every frame if the radial is filled.
            while (!m_RadialFilled)
            {
                yield return null;
            }

            // Once it's been used make the radial invisible.
            Hide ();
        }


        private void HandleDown()
        {
            // If the radial is active start filling it.
            if (m_IsSelectionRadialActive)
            {
                m_SelectionFillRoutine = StartCoroutine(FillSelectionRadial());
            }
        }


        private void HandleUp()
        {
            // If the radial is active stop filling it and reset it's amount.
            //if (m_IsSelectionRadialActive) // modify suzuki
            {
                if(m_SelectionFillRoutine != null)
                    StopCoroutine(m_SelectionFillRoutine);

                m_Selection.fillAmount = 0f;
            }
        }
    }
}