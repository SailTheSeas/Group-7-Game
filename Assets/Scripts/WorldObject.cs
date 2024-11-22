using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class WorldObject : MonoBehaviour
{
    [SerializeField] private Vector3 swapPosition;
    [SerializeField] private Vector3 swapRotation;
    [SerializeField] private int maxProgress;
    [SerializeField] private int score;
    [SerializeField] private bool MoveCamera;
    [SerializeField] private int dir;
    [SerializeField] private AudioClip drag;

    private AudioSource source;


    private Texture2D open, close;
    private Vector2 cursorHotspot;
    private ScoreCounter SC;
    private MouseStateManager MSM;
    private Vector3 startPosition, startRotation;
    private bool isMoved, isPressed;
    private Progressbar progressBar;
    private float progress;
    private Rooms RMS;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        SC = FindObjectOfType<ScoreCounter>();
        MSM = FindObjectOfType<MouseStateManager>();
        progressBar = GameObject.FindGameObjectWithTag("ProgressBar").GetComponent<Progressbar>();
        isMoved = false;
        startPosition = this.transform.localPosition;  
        startRotation = this.transform.rotation.eulerAngles;
        open = MSM.GetOpenHand();
        close = MSM.GetCloseHand();
        if (MoveCamera)
            RMS = FindObjectOfType<Rooms>();
    }

    private void OnMouseEnter()
    {
        if (MSM.GetMouseState() == MouseState.drag)
        {
            progress = 0;
            progressBar.SetState(true);
            progressBar.SetProgress(0, maxProgress);
        }
    }

    private void OnMouseExit()
    {
        if (MSM.GetMouseState() == MouseState.drag)
        {
            progressBar.SetState(false);

        }
    }

    private void OnMouseDown()
    {
        if (MSM.GetMouseState() == MouseState.drag)
        {
            isPressed = true;
            cursorHotspot = new Vector2(close.width / 2, close.height / 2);
            Cursor.SetCursor(close, cursorHotspot, CursorMode.Auto);
        }
    }

    private void OnMouseUp()
    {
        if (MSM.GetMouseState() == MouseState.drag)
        {
            isPressed = false;
            source.Stop();
            progress = 0;
            progressBar.SetProgress(0, maxProgress);
            cursorHotspot = new Vector2(open.width / 2, open.height / 2);
            Cursor.SetCursor(open, cursorHotspot, CursorMode.Auto);
        }
    }

    private void OnMouseOver()
    {
        if (isPressed)
        {
            if (MSM.GetMouseState() == MouseState.drag)
            {
                if (progress <= maxProgress)
                {
                    if (!source.isPlaying)
                        source.PlayOneShot(drag);
                    progress += 200 * Time.deltaTime;
                    progressBar.SetProgress(progress, maxProgress);
                }
                else
                {
                    source.Stop();
                    if (!isMoved)
                    {
                        this.transform.localPosition = swapPosition;
                        this.transform.localRotation = Quaternion.Euler(swapRotation);
                        isMoved = true;
                        if (MoveCamera)
                        {
                            RMS.ChangeRoom(dir);
                            dir *= -1;
                        }
                        SC.UpdateScore(score);
                    }
                    else
                    {
                        this.transform.localPosition = startPosition;
                        this.transform.rotation = Quaternion.Euler(startRotation);
                        isMoved = false;
                        if (MoveCamera)
                        {
                            RMS.ChangeRoom(dir);
                            dir *= -1;
                        }
                        SC.UpdateScore(-1 * score);
                    }
                    //progressBar.SetState(false);
                    progress = 0;
                }

            }
        }
    }

}
