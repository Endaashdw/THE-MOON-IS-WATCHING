using UnityEngine;
using System.Collections;
using TMPro;

public class Timeout : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Timer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Timer() {
        yield return new WaitForSeconds(5f);
        text.gameObject.SetActive(false);
    }
}
