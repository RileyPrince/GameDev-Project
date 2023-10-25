using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    /// <summary>
    /// Usage:
    /// <code>
    /// void StartWave(int wave, int count) { // Whatever you want to do on activation }
    /// void Awake() { GameObject.Find("GameManager").GetComponent<WaveManager>().startWave += StartWave; }
    /// </code>
    /// </summary>
    public Action<int, int> startWave;
    public Action finishWave;

    public int wave { get; private set; } = 1;

    void Start() => StartCoroutine(StartWaveCoroutine(1));
    public void FinishWave(bool playerDied) => StartCoroutine(FinishWaveCoroutine(playerDied));

    private IEnumerator StartWaveCoroutine(int wave)
    {
        Debug.Log("Pls");
        
        startWave?.Invoke(wave, (int) Math.Round(((wave * 1.5) + 2) * 1.75));

        yield return null;
    }
    private IEnumerator FinishWaveCoroutine(bool playerDied)
    {
        finishWave?.Invoke();

        if (!playerDied)
            yield return StartCoroutine(StartWaveCoroutine(wave++));
        yield return EndGame();
    }

    private IEnumerator EndGame()
    {
        yield return null;
    }
}