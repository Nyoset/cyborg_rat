using UnityEngine.Rendering;
using UnityEngine;

public class SortingLayerOrderer : MonoBehaviour
{

    private int sortingOrderBase = 5000;
    [SerializeField]
    private bool runOnlyOnce = true;
    [SerializeField]
    private int offset = 5;

    Renderer myRenderer;
    SortingGroup sortingGroup;


    private void Awake()
    {
        myRenderer = gameObject.GetComponent<Renderer>();
        sortingGroup = gameObject.GetComponent<SortingGroup>();
    }

    private void LateUpdate()
    {
        int newOrder = (int)(sortingOrderBase - 10 * transform.position.y - offset);
        if (myRenderer) myRenderer.sortingOrder = newOrder;
        if (sortingGroup) sortingGroup.sortingOrder = newOrder;

        if (runOnlyOnce)
        {
            Destroy(this);
        }
    }
}
