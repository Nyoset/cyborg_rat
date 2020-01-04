using UnityEngine;
using UnityEngine.Tilemaps;

namespace UnityEditor
{
    [CreateAssetMenu]
    [CustomGridBrush(false, false, false, "Fences Brush")]
    public class FencesBrush : GridBrushBase
    {
        public TileBase horizontalFence;
        public TileBase verticalFence;

        bool startedLine;
        Vector3Int startPosition;

        public override void Paint(GridLayout gridLayout, GameObject brushTarget, Vector3Int position)
        {
            if (startedLine)
            {
                Tilemap tilemap = brushTarget.GetComponent<Tilemap>();

                if (startPosition.x == position.x)
                {
                    for (int i = Mathf.Min(startPosition.y, position.y); i <= Mathf.Max(startPosition.y, position.y); ++i)
                    {
                        Vector3Int drawPosition = new Vector3Int(position.x, i, position.z);
                        tilemap.SetTile(drawPosition, verticalFence);
                    }
                }
                else if (startPosition.y == position.y)
                {
                    for (int i = Mathf.Min(startPosition.x, position.x); i <= Mathf.Max(startPosition.x, position.x); ++i)
                    {
                        Vector3Int drawPosition = new Vector3Int(i, position.y, position.z);
                        tilemap.SetTile(drawPosition, horizontalFence);
                    }
                }
                startedLine = false;
            }
            startPosition = position;
            startedLine = true;
        }

        public override void Erase(GridLayout gridLayout, GameObject brushTarget, Vector3Int position)
        {
            Tilemap tilemap = brushTarget.GetComponent<Tilemap>();
            tilemap.SetTile(position, null);
        }
    }
}
