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
        public int tileIndex { get { return tileData.tileIndex; } }
        void Start()
        {
        
        }

        private void OnMouseDown()
        {
            boardManager.DestroyTile1(tileData);
            boardManager.Refill();
            boardManager.board[tileData.boardPosition.x = 0, tileData.boardPosition.y = 8].DestroyTile();
            boardManager.board[tileData.boardPosition.x = 0, tileData.boardPosition.y = 9].DestroyTile();
            boardManager.board[tileData.boardPosition.x = 1, tileData.boardPosition.y = 9].DestroyTile();
            boardManager.board[tileData.boardPosition.x = 0, tileData.boardPosition.y = 1].DestroyTile();
            boardManager.board[tileData.boardPosition.x = 0, tileData.boardPosition.y = 0].DestroyTile();
            boardManager.board[tileData.boardPosition.x = 1, tileData.boardPosition.y = 0].DestroyTile();
            boardManager.board[tileData.boardPosition.x = 6, tileData.boardPosition.y = 9].DestroyTile();
            boardManager.board[tileData.boardPosition.x = 7, tileData.boardPosition.y = 9].DestroyTile();
            boardManager.board[tileData.boardPosition.x = 7, tileData.boardPosition.y = 8].DestroyTile();
            boardManager.board[tileData.boardPosition.x = 6, tileData.boardPosition.y = 0].DestroyTile();
            boardManager.board[tileData.boardPosition.x = 7, tileData.boardPosition.y = 0].DestroyTile();
            boardManager.board[tileData.boardPosition.x = 7, tileData.boardPosition.y = 1].DestroyTile();
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