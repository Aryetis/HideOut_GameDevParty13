using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private int punchReceived;

    public int getPunchReceived() {
        return punchReceived;
    }

    public void addPunchReceived() {
        punchReceived ++;
    }

    public void initPunch() {
        punchReceived = 0;
    }
    
}
