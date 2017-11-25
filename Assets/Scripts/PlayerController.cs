using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private int punchReceived = 0;

    public int GetPunchReceived() {
        return punchReceived;
    }

    public void AddPunchReceived() {
        punchReceived ++;
    }

    public void InitPunch() {
        punchReceived = 0;
    }

}
