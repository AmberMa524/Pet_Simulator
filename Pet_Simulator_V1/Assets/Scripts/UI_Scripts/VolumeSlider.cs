using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    /** Changes the position of the slider based on the volume value.*/

    private Slider thisSlider;
    
    /** The slider is set to the slider the script is attached to.*/
    void Start()
    {
        thisSlider = gameObject.GetComponent<Slider>();
        thisSlider.value = (float) MusicController.volume;
    }

    /** If any changes occur on the slider, the volume will change accordingly.*/

    public void changeVolume() {
        MusicController.volume = (int)thisSlider.value;
    }

}
