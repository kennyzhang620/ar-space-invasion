using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeBodyText : MonoBehaviour
{

    public CameraAnimator cameraAnimator;
    public Animator fader;
    public float[] cameraY;
    public string[] Herotext;
    public string[] Bodytext;

    public Text Title;
    public Text BodyText;
    public GameObject startBtn;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    int prev = -1;
    void Update()
    {
        if (cameraY.Length != Herotext.Length) return;
        
        for (int i = 0;i < Herotext.Length;i++) {
            print(cameraAnimator.transform.position.y - cameraY[i]);
            if (Mathf.Abs(cameraAnimator.transform.position.y - cameraY[i]) < 0.01f && prev != i) {
                Title.text = Herotext[i];
                BodyText.text = Bodytext[i];
                fader.Play("FadeInCanvas");
                startBtn.SetActive(true);
                prev = i;
                return;
            }
        }
    }
}
