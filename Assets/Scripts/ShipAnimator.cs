using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipAnimator : MonoBehaviour
{
    public void AnimationInvoke(int direction)
    {
        StartCoroutine(Rotate(direction));
    }

    public IEnumerator Rotate(int direction)
    {
        for (int i = 0; i < 15; ++i)
        {
            transform.Rotate(0, 0, direction);
            yield return null;
        }
    }
}
