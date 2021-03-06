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

        public Vector2Int boardPosition;
        FTileData tileData;

        public Tile[,] board;

        void Start()
        {
            InitializeBoard();
            lujo();
        }
       
        
        public IEnumerator Webito()
        {
            yield return new WaitForSeconds(1f);
            Refill();
            lujo();
        }
       public void lujo()
        {
            board[tileData.boardPosition.x = 0, tileData.boardPosition.y = 8].DestroyTile();
            board[tileData.boardPosition.x = 0, tileData.boardPosition.y = 9].DestroyTile();
            board[tileData.boardPosition.x = 1, tileData.boardPosition.y = 9].DestroyTile();
            board[tileData.boardPosition.x = 0, tileData.boardPosition.y = 1].DestroyTile();
            board[tileData.boardPosition.x = 0, tileData.boardPosition.y = 0].DestroyTile();
            board[tileData.boardPosition.x = 1, tileData.boardPosition.y = 0].DestroyTile();
            board[tileData.boardPosition.x = 6, tileData.boardPosition.y = 9].DestroyTile();
            board[tileData.boardPosition.x = 7, tileData.boardPosition.y = 9].DestroyTile();
            board[tileData.boardPosition.x = 7, tileData.boardPosition.y = 8].DestroyTile();
            board[tileData.boardPosition.x = 6, tileData.boardPosition.y = 0].DestroyTile();
            board[tileData.boardPosition.x = 7, tileData.boardPosition.y = 0].DestroyTile();
            board[tileData.boardPosition.x = 7, tileData.boardPosition.y = 1].DestroyTile();
        }
        public void Refill()
        {
            
            Vector3 SpawnPosition = Vector3.zero;
            Vector2Int boardPosition = Vector2Int.zero;
            for (int x = 0; x < boardSize.x; x++)
            {
                for (int y = 0; y < boardSize.y; y++)
                {
                    if (board[x, y] == null)
                    {
                        SpawnPosition.x = x * tileOffset;
                        SpawnPosition.y = y * tileOffset;
                        boardPosition.x = x;
                        boardPosition.y = y;
                        GameObject tile = Instantiate(tilePrefab, SpawnPosition, Quaternion.identity);
                        tile.GetComponent<Tile>().Initialize(this, boardPosition);

                        board[x, y] = tile.GetComponent<Tile>();

                        

                    }
                }
            }
        }
        public void DestroyTile1(FTileData tileData)
        {
            Debug.Log(tileData.boardPosition);
            //derecha----------------------------------------------------------
            for (int x = tileData.boardPosition.x; x < boardSize.x; x++)
            {
                if (board[x,tileData.boardPosition.y] == null) break;
                if (board[x,tileData.boardPosition.y].tileIndex != tileData.tileIndex) break;

                if (board[x,tileData.boardPosition.y].tileIndex == tileData.tileIndex)
                {
                    Webito();
                    board[x, tileData.boardPosition.y].DestroyTile();
                }

            }
            //izquierda-------------------------------------------------------
            for (int x = tileData.boardPosition.x; x >=0;  x--)
            {
                if (board[x,tileData.boardPosition.y] == null) break;
                if (board[x,tileData.boardPosition.y].tileIndex != tileData.tileIndex) break;

                if (board[x, tileData.boardPosition.y].tileIndex == tileData.tileIndex)
                {
                    Webito();
                    board[x, tileData.boardPosition.y].DestroyTile();
                }
            }
            //arriba----------------------------------------------------------
            for (int y = tileData.boardPosition.y; y < boardSize.y; y++)
            {
                if (board[tileData.boardPosition.x, y] == null) break;
                if (board[tileData.boardPosition.x, y].tileIndex != tileData.tileIndex) break;

                if (board[tileData.boardPosition.x,y].tileIndex == tileData.tileIndex)
                {
                    Webito();
                    board[tileData.boardPosition.x,y].DestroyTile();
                }
            }
            //abajo-----------------------------------------------------------
            for (int y = tileData.boardPosition.y; y >=0; y--)
            {
                if (board[tileData.boardPosition.x, y] == null) break;
                if (board[tileData.boardPosition.x, y].tileIndex != tileData.tileIndex) break;
              
                if (board[tileData.boardPosition.x, y].tileIndex == tileData.tileIndex)
                {
                    Webito();
                    board[tileData.boardPosition.x, y].DestroyTile();
                }
            }
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
                    board[x, y]  =  tile.GetComponent<Tile>();
                    
                }
                
                    
            }
        }
    }

} 
