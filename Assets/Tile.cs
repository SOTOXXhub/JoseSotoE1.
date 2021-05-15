using System.Collections;
using System.Collections.Generic;
using Trabajo;
using UnityEngine;

namespace Trabajo
{
    public struct FTileData
    {
        public int tileIndex;
        public Vector2Int boardPosition;
    }

    public class Tile : MonoBehaviour
    {
        BoardManager boardManager;
        FTileData tileData;
        public Sprite[] sprites = new Sprite[5];

        void Start()
        {
        
        }

        private void OnMouseDown()
        {
            boardManager.DestroyTile(tileData);
        }
        public void DestroyTile()
        {
            Destroy(gameObject);
        }
        public void Initialize(BoardManager BoardManagerReference,Vector2Int NewBoardPosition)
        {
            tileData.tileIndex = Random.Range(0, 5);
            GetComponent<SpriteRenderer>().sprite=sprites[tileData.tileIndex];
            boardManager = BoardManagerReference;
            tileData.boardPosition = NewBoardPosition;
        }
    }
}