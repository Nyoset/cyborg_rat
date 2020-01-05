using UnityEngine;
using UnityEngine.Tilemaps;

namespace UnityEditor
{
    [CreateAssetMenu]
    [CustomGridBrush(false, false, false, "Fences Brush")]
    public class FencesBrush : GridBrushBase
    {
        TileBase horizontalFence;
        TileBase verticalFence;

        bool startedLine;
        Vector3Int startPosition;

        private void Awake()
        {
            horizontalFence = (TileBase)Instantiate(Resources.Load("Tiles/Fences/g6747"));
            verticalFence = (TileBase)Instantiate(Resources.Load("Tiles/Fences/g6702"));
        }

        public override void Paint(GridLayout gridLayout, GameObject brushTarget, Vector3Int position)
        {
            Debug.Log(startedLine);
            if (startedLine)
            {
                Tilemap tilemap = brushTarget.GetComponent<Tilemap>();

                if (startPosition.x == position.x)
                {
                    for (int i = Mathf.Min(startPosition.y, position.y); i <= Mathf.Max(startPosition.y, position.y); ++i)
                    {
                        Vector3Int drawPosition = new Vector3Int(position.x, i, position.z);
                        if (IsTileHorizontal(tilemap, drawPosition))
                        {
                            tilemap.SetTile(drawPosition, verticalFence);
                        }
                        else
                        {
                            tilemap.SetTile(drawPosition, verticalFence);
                        }
                    }
                }
                else if (startPosition.y == position.y)
                {
                    for (int i = Mathf.Min(startPosition.x, position.x); i <= Mathf.Max(startPosition.x, position.x); ++i)
                    {
                        Vector3Int drawPosition = new Vector3Int(i, position.y, position.z);

                        if (IsTileVeritcal(tilemap, drawPosition))
                        {
                            tilemap.SetTile(drawPosition, horizontalFence);
                        }
                        else
                        {
                            tilemap.SetTile(drawPosition, horizontalFence);
                        }
                    }
                }
            }

            startPosition = position;
            startedLine = !startedLine;
        }

        public override void Erase(GridLayout gridLayout, GameObject brushTarget, Vector3Int position)
        {
            Tilemap tilemap = brushTarget.GetComponent<Tilemap>();
            tilemap.SetTile(position, null);
        }

        bool IsTileHorizontal(Tilemap tilemap, Vector3Int position)
        {
            if (!tilemap.HasTile(position))
            {
                return false;
            }
            TileBase tile = tilemap.GetTile(position);
            Debug.Log(tile == horizontalFence);
            
            return tile == horizontalFence;
        }

        bool IsTileVeritcal(Tilemap tilemap, Vector3Int position)
        {
            if (!tilemap.HasTile(position))
            {
                return false;
            }
            TileBase tile = tilemap.GetTile(position);
            Debug.Log(tile == horizontalFence);

            return tile == verticalFence;
        }
    }
}
