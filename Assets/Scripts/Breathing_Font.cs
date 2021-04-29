using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class Breathing_Font : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler
{
    public TMP_Text text; 
        [Range(.5f, 30f)]
    public float rate = 1f;
    [Range(0f, 30f)]
    public float scale = 1f;

    bool isHovering = false;

    public void OnPointerEnter(PointerEventData eventData){
        isHovering = true; 
    }
    public void OnPointerExit(PointerEventData eventData){
        isHovering = false;
        text.characterSpacing = 0;
    }
    public void OnSelect(BaseEventData eventData){
        isHovering = true;
    }


    public void OnDeselect(BaseEventData eventData){
        isHovering = false;
    }
    void Update(){
        if (!isHovering) return;
        
        text.characterSpacing = Mathf.PingPong(Time.time * rate, scale);

    }
}
