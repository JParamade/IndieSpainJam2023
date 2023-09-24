using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class RadarBehaviour : MonoBehaviour
{
    Chest[] chests = null;
    GameObject closestChest = null;

    public RectTransform selfAnchor;
    Vector3 arrowDirection = Vector3.zero;

    public TextMeshProUGUI distanceText;

    private void Start()
    {
        distanceText.text = "0 m";
    }

    private void Update()
    {
        chests = FindObjectsOfType<Chest>();

        foreach (Chest chest in chests)
        {
            if (closestChest == null)
            {
                closestChest = chest.gameObject;
            }

            if ((chest.transform.position - transform.position).magnitude < (closestChest.transform.position - transform.position).magnitude)
            {
                closestChest = chest.gameObject;
            }
        }

        arrowDirection = closestChest.transform.position - transform.position;
        distanceText.text = ((int) arrowDirection.magnitude / 100).ToString() + " m";

        if (closestChest.transform.position.x < transform.position.x)
        {
            selfAnchor.rotation = Quaternion.Euler(0, 0, Vector3.Angle(arrowDirection, transform.forward));
        }
        else
        {
            selfAnchor.rotation = Quaternion.Euler(0, 0, -Vector3.Angle(arrowDirection, transform.forward));
        }
    }
}
