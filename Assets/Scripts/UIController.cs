using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    public Image heart1, heart2, heart3, heart4, heart5;
    public Sprite heartFULL, heartHALF, heartEMPTY;

    public Text timer;
    public float timeNumber, timeNumberLength;

    private void Awake() { instance = this; }
    
    // Start is called before the first frame update
    void Start()
    {
        timeNumberLength = timeNumber;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeNumberLength > 0) {
            timeNumberLength -= Time.deltaTime;
        } else if (timeNumberLength <= 0) {
            timeNumberLength = 0;
        }
        
        timer.text = timeNumberLength.ToString("F0");

        switch (PlayerController.instance.health)
        {
            case 10:
                heart1.sprite = heartFULL;
                heart2.sprite = heartFULL;
                heart3.sprite = heartFULL;
                heart4.sprite = heartFULL;
                heart5.sprite = heartFULL;
                break;
            
            case 9:
                heart1.sprite = heartFULL;
                heart2.sprite = heartFULL;
                heart3.sprite = heartFULL;
                heart4.sprite = heartFULL;
                heart5.sprite = heartHALF;
                break;
            
            case 8:
                heart1.sprite = heartFULL;
                heart2.sprite = heartFULL;
                heart3.sprite = heartFULL;
                heart4.sprite = heartFULL;
                heart5.sprite = heartEMPTY;
                break;
            
            case 7:
                heart1.sprite = heartFULL;
                heart2.sprite = heartFULL;
                heart3.sprite = heartFULL;
                heart4.sprite = heartHALF;
                heart5.sprite = heartEMPTY;
                break;
            
            case 6:
                heart1.sprite = heartFULL;
                heart2.sprite = heartFULL;
                heart3.sprite = heartFULL;
                heart4.sprite = heartEMPTY;
                heart5.sprite = heartEMPTY;
                break;
            
            case 5:
                heart1.sprite = heartFULL;
                heart2.sprite = heartFULL;
                heart3.sprite = heartHALF;
                heart4.sprite = heartEMPTY;
                heart5.sprite = heartEMPTY;
                break;
            
            case 4:
                heart1.sprite = heartFULL;
                heart2.sprite = heartFULL;
                heart3.sprite = heartEMPTY;
                heart4.sprite = heartEMPTY;
                heart5.sprite = heartEMPTY;
                break;
            
            case 3:
                heart1.sprite = heartFULL;
                heart2.sprite = heartHALF;
                heart3.sprite = heartEMPTY;
                heart4.sprite = heartEMPTY;
                heart5.sprite = heartEMPTY;
                break;
            
            case 2:
                heart1.sprite = heartFULL;
                heart2.sprite = heartEMPTY;
                heart3.sprite = heartEMPTY;
                heart4.sprite = heartEMPTY;
                heart5.sprite = heartEMPTY;
                break;
            
            case 1:
                heart1.sprite = heartHALF;
                heart2.sprite = heartEMPTY;
                heart3.sprite = heartEMPTY;
                heart4.sprite = heartEMPTY;
                heart5.sprite = heartEMPTY;
                break;
            
            case 0:
                heart1.sprite = heartEMPTY;
                heart2.sprite = heartEMPTY;
                heart3.sprite = heartEMPTY;
                heart4.sprite = heartEMPTY;
                heart5.sprite = heartEMPTY;
                break;
            
            default:
                heart1.sprite = heartEMPTY;
                heart2.sprite = heartEMPTY;
                heart3.sprite = heartEMPTY;
                heart4.sprite = heartEMPTY;
                heart5.sprite = heartEMPTY;
                break;
        } // End Switch (PlayerController.instance.health)
    } // function - Update()
}
