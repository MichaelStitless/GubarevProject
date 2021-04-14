using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class DeathsAnalyzer : MonoBehaviour
{
    public void OnButtonPressed()
    {
        Analytics.CustomEvent("DeathsDataAnalyzed");
    }
}
