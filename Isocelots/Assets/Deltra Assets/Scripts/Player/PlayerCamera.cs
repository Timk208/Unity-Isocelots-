using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerCamera : MonoBehaviour
{
    public static PlayerCamera Instance { get; private set; }

    private CinemachineVirtualCamera vCam;

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
        var body = vCam.GetCinemachineComponent<CinemachineTransposer>();

        body.m_XDamping = amount;
        body.m_YDamping = amount;
        body.m_ZDamping = amount;
    }
}
