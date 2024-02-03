using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    private Slider thisSlider;
    // Start is called before the first frame update
    void Start()
    {
        thisSlider = gameObject.GetComponent<Slider>();
        thisSlider.value = (float) MusicController.volume;
    }

    public void changeVolume() {
        MusicController.volume = (int)thisSlider.value;
    }

}
