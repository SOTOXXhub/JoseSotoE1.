using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Trabajo
{
    public class BoardManager : MonoBehaviour
    {
        public Vector2Int boardSize = new Vector2Int(8, 10);

        public GameObject tilePrefab;

        public float tileOffset =1.5f;

        Tile[,] board;
        void Start()
        {
            InitializeBoard();
        }
        public void DestroyTile(FTileData tileData)
        {
            Debug.Log(tileData.boardPosition);

            board[tileData.boardPosition.x, tileData.boardPosition.y].DestroyTile();
        }
        void InitializeBoard()
        {
            Vector3 SpawnPosition = Vector3.zero;
            Vector2Int boardPosition = Vector2Int.zero;
            board = new Tile[boardSize.x, boardSize.y];
            for (int x = 0; x < boardSize.x; x++)
            {
                for (int y = 0; y < boardSize.y; y++)
                {
                    SpawnPosition.x = x*tileOffset;
                    SpawnPosition.y = y*tileOffset;
                    boardPosition.x = x;
                    boardPosition.y = y;
                   GameObject tile= Instantiate(tilePrefab,SpawnPosition, Quaternion.identity);
                    tile.GetComponent<Tile>().Initialize(this,boardPosition);

                    board[x, y] = tile.GetComponent<Tile>();
                }
            }
        }
    }

} 
