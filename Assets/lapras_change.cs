using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement; // Add this line

public class ClickObject : MonoBehaviour
{
    public GameObject cube;
    public string sceneToLoad; // Add this to specify which scene to load

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("lapras");
        }
    }

    // Get clicked object
    GameObject getClickedObject(out RaycastHit hit)
    {
        GameObject target = null;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray.origin, ray.direction, out hit, 10))
        {
            if (!isPointerOverUIObject())
            {
                target = hit.collider.gameObject;
            }
        }

        return target;
    }

    private bool isPointerOverUIObject()
    {
        PointerEventData ped = new PointerEventData(EventSystem.current)
        {
            position = new Vector2(Input.mousePosition.x, Input.mousePosition.y)
        };

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(ped, results);

        return results.Count > 0;
    }
}
