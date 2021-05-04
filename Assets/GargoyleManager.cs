using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GargoyleManager : MonoBehaviour
{
    public static GargoyleManager instance;
    public bool didTalkToDoyle = false;
    public bool didTalkToMerriam = false;
    public bool didTalkToKoyle = false;

    public Gargoyle_Interactor merriamInteractor;
    public Gargoyle_Interactor koyleInteractor;
    public BoxCollider merriamCollider;
    public BoxCollider koyleCollider; 

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        merriamInteractor.enabled = false;
        merriamCollider.enabled = false;
        koyleInteractor.enabled = false;
        koyleCollider.enabled = false;
    }

    public void ActivateMerriam()
    {
        merriamInteractor.enabled = true;
        merriamCollider.enabled = true;
    }

    public void ActivateKoyle()
    {
        koyleInteractor.enabled = true;
        koyleCollider.enabled = true;
    }

}
