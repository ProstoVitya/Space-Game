using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider), typeof(Rigidbody))]
public class Spaceship : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (!DataHandler.GameOver)
        {
            DataHandler.StopGame();
            GetComponent<Rigidbody>().useGravity = true;
            Mover.StopGame();
        }
    }

    public void AnimationInvoke(int direction)
    {
        StartCoroutine(Rotate(direction));
    }

    private IEnumerator Rotate(int direction)
    {
        for (int i = 0; i < 15; ++i)
        {
            transform.Rotate(0, 0, direction);
            yield return null;
        }
    }
}
