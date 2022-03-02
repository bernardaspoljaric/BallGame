using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggers : MonoBehaviour
{
    public GameManager gm;
    [Header("True = Player | False = Walls")]
    public bool isPlayer;

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            if (isPlayer)
            {
                gm.TakeLife();
                Destroy(other.gameObject);
            }
            else if (!isPlayer)
            {
              gm.AddScore();
              Destroy(other.gameObject);
            }
        }

    }
}
