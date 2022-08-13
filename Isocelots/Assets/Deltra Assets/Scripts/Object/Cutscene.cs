using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cutscenes;

public class Cutscene : MonoBehaviour
{
    public List<CutsceneMovement> movements;

    public bool start = false;
    private bool moving = false;

    private Vector3 velocity = Vector3.zero;
    private Vector3 startVector3;

    private float time;



    // Moves the cutscene object with the first movement in the list.
    private void MoveObject()
    {
        if (transform.position != movements[0].move)
        {
            // Movement is still running.

            PlayerCamera.Instance.Damping(0);

            moving = true;

            time += Time.deltaTime;

            float t = Smoothing(time / movements[0].duration);

            transform.position = Vector3.Lerp(startVector3, movements[0].move, t);
        }
        else
        {
            // Movement is complete.

            movements.RemoveAt(0);

            moving = false;
        }
    }



    // Grabs the correct smoothing formula.
    private float Smoothing(float t)
    {
        switch (movements[0].smoothing)
        {
            case 0:

                // Linear
                return t;

            case 1:

                // Smoothstep
                return t * t * t * (t * (6f * t - 15f) + 10f);

            case 2:

                // Ease In
                return 1f - Mathf.Cos(t * Mathf.PI * 0.5f);

            case 3:

                // Ease Out
                return Mathf.Sin(t * Mathf.PI * 0.5f);
        }

        return 0;
    }



    void Update()
    {
        if (movements.Count != 0 && start)
        {
            //Sets startVector3 and resets time on start of movement.
            if (!moving)
            {
                startVector3 = transform.position;

                time = 0;
            }

            PlayerState.Instance.busy = true;

            PlayerCamera.Instance.ChangeFollowObject(gameObject);

            MoveObject();
        }
        else
        {
            if (start)
            {
                PlayerState.Instance.busy = false;
            }

            start = false;

            PlayerCamera.Instance.ResetFollowObject();

            PlayerCamera.Instance.Damping(1);
        }
    }
}
