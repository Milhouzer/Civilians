using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Individual individual;

    private void Awake() {
        individual = GetComponent<Individual>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // Handle raycast hit here
                GameObject hitObject = hit.collider.gameObject;
                
                Individual hitIndividual = hitObject.GetComponent<Individual>();
                if(hitIndividual)
                {
                    individual.CommitAction(hitIndividual, ActionImpact.VeryMinor, ActionMorality.Wrong);
                }
            }
        }
    }
}
