using System;
using UnityEngine;

namespace VRStandardAssets.Utils
{
    // This class should be added to any gameobject in the scene
    // that should react to input based on the user's gaze.
    // It contains events that can be subscribed to by classes that
    // need to know about input specifics to this gameobject.
    public class VRInteractiveItem : MonoBehaviour
    {
        public event Action OnOver;             // Called when the gaze moves over this object
        public event Action OnOut;              // Called when the gaze leaves this object
        public event Action OnClick;            // Called when click input is detected whilst the gaze is over this object.
        public event Action OnDoubleClick;      // Called when double click input is detected whilst the gaze is over this object.
        public event Action OnUp;               // Called when Fire1 is released whilst the gaze is over this object.
        public event Action OnDown;             // Called when Fire1 is pressed whilst the gaze is over this object.


        protected bool m_IsOver;


        public bool IsOver
        {
            get { return m_IsOver; }              // Is the gaze currently over this object?
        }

		void Start()
		{
		}

        // The below functions are called by the VREyeRaycaster when the appropriate input is detected.
        // They in turn call the appropriate events should they have subscribers.
        public void Over()
        {
			// modify suzuki
			long currentMilliTime = DateTime.Now.Hour * 60 * 60 * 1000 + DateTime.Now.Minute * 60 * 1000 + DateTime.Now.Second * 1000 + DateTime.Now.Millisecond;
			Debug.Log ("currentMilliTime - startMilliTime = " + (currentMilliTime - MainMenuGameObject.StartMilliTime));
			if (currentMilliTime - MainMenuGameObject.StartMilliTime < 3 * 1000) 
			{
				m_IsOver = false;
//				SelectionRadial.ClearSelectionFillAmount ();
				Invoke("Over", 1.0f);
				return;
			}

            m_IsOver = true;

            if (OnOver != null)
                OnOver();
        }


        public void Out()
        {
            m_IsOver = false;

            if (OnOut != null)
                OnOut();
        }


        public void Click()
        {
            if (OnClick != null)
                OnClick();
        }


        public void DoubleClick()
        {
            if (OnDoubleClick != null)
                OnDoubleClick();
        }


        public void Up()
        {
            if (OnUp != null)
                OnUp();
        }


        public void Down()
        {
            if (OnDown != null)
                OnDown();
        }
    }
}