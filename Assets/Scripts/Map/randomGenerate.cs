using UnityEngine;

public class randomGenerate : MonoBehaviour
{

    [Header("Basic Stuff")]
    [SerializeField] private GameObject spawnTile;
    public Vector2 mapDimensions;

    [Space]
    private GameObject map;

    [Space]

    public GameObject[] possibleTiles; //a table that holds all the possible tiles that can be spawned, instead of starting at 1, it will start at 0, it will make sense later on
    private int randomTileChooser;


    public void generateMap()
    {
        int currentTileX = 0;
        int currentTileY = 0;

        for (int i = 0; i < mapDimensions.x * mapDimensions.y; i++)
        {
            randomTileChooser = Random.Range(0, possibleTiles.Length); //chooses a random number between 0, and the max number of possible tiles, we have to start at 0 because to count, unity starts at 0 instead of 1
            GameObject chosenTile = possibleTiles[randomTileChooser].gameObject;
            Vector3 newTilePos = new Vector3(spawnTile.transform.position.x + spawnTile.transform.localScale.x * currentTileX, spawnTile.transform.position.y, spawnTile.transform.position.z + spawnTile.transform.localScale.z * currentTileY); //gets a position that equals to the same y position as the spawn tile, but the x is the spawn tile's x position + the spawn tile's x scale multiplied but the current tile its on, and the z, the same thing (basically)
            GameObject clonedTile = Instantiate(chosenTile, newTilePos, Quaternion.identity, map.transform); //instantiate basically just spawns a prefab, and quaternian is its rotation if you didnt know. Quaternians can be very complicated unfortunatly
            currentTileX++;

            if(currentTileX >= mapDimensions.x) //if it has reached the max x distanced
            {
                currentTileX = 0;
                currentTileY++; //makes sure the tiles will start adding up
            }
        }
        
   
       
        
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        map = gameObject;
        generateMap();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
