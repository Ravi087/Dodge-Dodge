using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DifficultyGame {

    public static float secToMaxDifficulty = 60f;

    public static float DifficultyPercentage()
    {
        return Mathf.Clamp01(Time.time / secToMaxDifficulty);
    }
	
}
