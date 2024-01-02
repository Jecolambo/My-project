using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{
    [System.Serializable]
    public struct AIVariants
    {
        public TextMeshProUGUI textMeshPro;
        public Transform targetAI;
        public Vector3 offset;
    }

    public AIVariants[] aiVariants;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var pair in aiVariants)
        {
            if(pair.textMeshPro != null && pair.targetAI != null)
            {
                Vector3 targetpos = pair.targetAI.position + pair.offset;
                pair.textMeshPro.transform.position = Camera.main.WorldToScreenPoint(targetpos);
                float targetAvoidanceQuality = pair.targetAI.GetComponent<NavMeshAgent>().avoidancePriority;
                pair.textMeshPro.text = targetAvoidanceQuality.ToString();
            }
        }
    }
}
