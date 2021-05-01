using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroTrigger : MonoBehaviour
{
    public Gargoyle_Interactor goyleInteractor;


    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && goyleInteractor.goyleState == Gargoyle_Interactor.GargoyleState.Introduction)
        {
            goyleInteractor.Introduction();
        }
    }
}
