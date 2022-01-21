using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormyManager : MonoBehaviour
{
    Wormy[] wormies;
    public Transform wormyCamera;

    public static WormyManager singleton;

    private int currentWormy;

    public float horizontalInput;
    public bool shouldShoot;
    public bool shouldRotate;

    void Start()
    {
        if (singleton != null)
        {
            Destroy(gameObject);
            return;
        }

        shouldRotate = true;
        singleton = this;

        wormies = GameObject.FindObjectsOfType<Wormy>();
        wormyCamera = Camera.main.transform;

        for (int i = 0; i < wormies.Length; i++)
        {
            wormies[i].wormId = i;
        }
    }

    public void NextWorm()
    {
        StartCoroutine(NextWormCoroutine());
    }

    public IEnumerator NextWormCoroutine()
    {
        var nextWorm = currentWormy + 1;
        currentWormy = -1;

        yield return new WaitForSeconds(2);

        currentWormy = nextWorm;
        if (currentWormy >= wormies.Length)
        {
            currentWormy = 0;
        }

        wormyCamera.SetParent(wormies[currentWormy].transform);
        wormyCamera.localPosition = Vector3.zero + Vector3.back * 10;
        wormyCamera.transform.position = new Vector3(wormyCamera.transform.position.x +4f, wormyCamera.transform.position.y + 2.4f, wormyCamera.transform.position.z);
    }


    public bool IsMyTurn(int i)
    {
        return i == currentWormy;
    }

    public void MoveLeft()
    {
        horizontalInput = -1f;
        Debug.Log(horizontalInput);

    }

    public void MoveRight()
    {
        horizontalInput = 1f;
    }

    public void StopMovement()
    {
        horizontalInput = 0f;

    }

    public void ShootCanoon()
    {
        shouldRotate = false;
        shouldShoot = true;
    }

    public void StopGun()
    {
        shouldRotate = true;
        shouldShoot = false;
    }


}
