using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerCamera : MonoBehaviour
{
    public static PlayerCamera Instance { get; private set; }

    private CinemachineVirtualCamera vCam;
    private CinemachineTransposer vCamBody;
    private CinemachineBasicMultiChannelPerlin vCamNoise;
    private CinemachineConfiner vCamConfiner;

    private Coroutine currentShake;

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        vCam = GetComponent<CinemachineVirtualCamera>();
        vCamBody = vCam.GetCinemachineComponent<CinemachineTransposer>();
        vCamNoise = vCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        vCamConfiner = vCam.GetComponent<CinemachineConfiner>();

        // FOR NOW, THE CONFINER USES AN OBJECT ON THE SCENE CALLED "CameraConfiner", LATER ON THIS SHOULD BE IN THE LEVEL MANAGER.
        vCamConfiner.m_BoundingShape2D = GameObject.Find("CameraConfiner").GetComponent<PolygonCollider2D>();
    }



    // Changes the Follow Object of the camera to whatever you put in.
    public void ChangeFollowObject(GameObject followObject)
    {
        vCam.Follow = followObject.transform;
    }



    // Resets the Follow Object back to the player.
    public void ResetFollowObject()
    {
        vCam.Follow = PlayerState.Instance.gameObject.transform;
    }



    // Sets the damping on the camera to the amount.
    public void Damping(float amount)
    {
        vCamBody.m_XDamping = amount;
        vCamBody.m_YDamping = amount;
        vCamBody.m_ZDamping = amount;
    }



    // Shake camera function. - FUTURE ADDITIONS AS NEEDED: TOGGLE FADE IN/FADE OUT, OPTION FOR INFINITE DURATION 
    public void ShakeCamera(float amplitude, float frequency, float duration, bool fadeOut)
    {
        // If a shake is already happening, stop it.
        if (currentShake != null)
        {
            StopCoroutine(currentShake);
        }

        currentShake = StartCoroutine(Shake(amplitude, frequency, duration, fadeOut));
    }



    // Coroutine that the shake function uses.
    private IEnumerator Shake(float amplitude, float frequency, float duration, bool fadeOut)
    {
        bool finished = false;

        float t = 0;
        float time = 0;

        if (fadeOut)
        {
            // If fadeOut is true, linear fade the shake out over the duration.

            time = duration;

            while (!finished)
            {
                t = time / duration;

                vCamNoise.m_AmplitudeGain = Mathf.Lerp(0, amplitude, t);
                vCamNoise.m_FrequencyGain = Mathf.Lerp(0, frequency, t);

                if (t < 0)
                {
                    finished = true;
                }

                time -= Time.deltaTime;

                yield return new WaitForEndOfFrame();
            }
        }
        else
        {
            // If fadeOut is false, just set the shake and turn it off after the duration is over.

            while (!finished)
            {
                vCamNoise.m_AmplitudeGain = amplitude;
                vCamNoise.m_FrequencyGain = frequency;

                if (time > duration)
                {
                    finished = true;
                }

                time += Time.deltaTime;

                yield return new WaitForEndOfFrame();
            }

            vCamNoise.m_AmplitudeGain = 0;
            vCamNoise.m_FrequencyGain = 0;
        }
        
        currentShake = null;
    }
}
