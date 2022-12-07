using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avatar : MonoBehaviour
{
    private bool _paused;
    public GameObject GameMenu;

    // Start is called before the first frame update
    void Start()
    {
        GameMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!_paused)
            {
                _paused = true;
                GameMenu.SetActive(true);
            }
            else
            {
                _paused = false;
                GameMenu.SetActive(false);
            }
        }

        if (!_paused)
        {
            Movement();
        }
    }

    void Movement()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(inputX, inputY) * Time.deltaTime;

        EncounterManager.Instance.Countdown(movement.magnitude);

        transform.Translate(movement.x, movement.y, 0);
    }
}
