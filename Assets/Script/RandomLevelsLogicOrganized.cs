using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RandomLevelsLogicOrganized : MonoBehaviour {
	System.Random rand = new System.Random();

	public int[,] Map;
	public string[,] sMap={{"#","#",".","#",},{"#","&","~","#"}};

	public int mapWidth	= 40;	
	public int mapHeight=21;
	public int percentAreWalls	=40;
	public int numberOfSteps=1;
    public Dictionary<string, GameObject> objectDictionary;
	public GameObject wall;
	public GameObject finish;
	public GameObject player;
	public GameObject fan;
	public GameObject magnetp;
	public GameObject magnetm;
    public GameObject pendulum;
    public GameObject block;
    public GameObject water;
    public float spaceBetweenObject=2.9536f;
	private float timer=0; 
	public int maxtimer=1;
	private string destroyany="killer";
	public bool haveMap=false;
    public int maxMagnetp=5;

	public void MakeCaverns()
	{
		// By initilizing column in the outter loop, its only created ONCE
		for(int column=0, row=0; row <= mapHeight-1; row++)
		{
			for(column = 0; column <= mapWidth-1; column++)
			{
				Map[column,row] = PlaceWallLogic(column,row);
			}
		}


	}

	public int PlaceWallLogic(int x,int y)
	{
		int numWalls = GetAdjacentWalls(x,y,1,1);
		if(Map[x,y]==1)
		{
			if( numWalls >= 4 )
			{
				return 1;
			}
			if(numWalls<2)
			{
				return 0;
			}
		}
		else
		{
			if(numWalls>=5)
			{
				return 1;
			}
		}
		return 0;
	}

	public int GetAdjacentWalls(int x,int y,int scopeX,int scopeY)
	{
		int startX = x - scopeX;
		int startY = y - scopeY;
		int endX = x + scopeX;
		int endY = y + scopeY;

		int iX = startX;
		int iY = startY;

		int wallCounter = 0;

		for(iY = startY; iY <= endY; iY++) {
			for(iX = startX; iX <= endX; iX++)
			{
				if(!(iX==x && iY==y))
				{
					if(IsWall(iX,iY))
					{
						wallCounter += 1;
					}
				}
			}
		}
		return wallCounter;
	}

	bool IsWall(int x,int y)
	{
		// Consider out-of-bound a wall
		if( IsOutOfBounds(x,y) )
		{
			return true;
		}

		if( Map[x,y]==1	 )
		{
			return true;
		}

		if( Map[x,y]==0	 )
		{
			return false;
		}
		return false;
	}

	bool IsOutOfBounds(int x, int y)
	{
		if( x<0 || y<0 )
		{
			return true;
		}
		else if( x>mapWidth-1 || y>mapHeight-1 )
		{
			return true;
		}
		return false;
	}


	string MapToString()
	{
		List<string> mapSymbols = new List<string>();
		mapSymbols.Add(".");
		mapSymbols.Add("#");
		mapSymbols.Add("+");
		mapSymbols.Add("&");
		mapSymbols.Add("~");
		mapSymbols.Add("{");
		mapSymbols.Add("}");
        mapSymbols.Add("*");
        mapSymbols.Add("H");
        mapSymbols.Add("W");
        string returnString = "";
		if (haveMap == false) {
			mapHeight = Map.GetLength (1);
			mapWidth = Map.GetLength (0);
		} else {
			mapHeight = sMap.GetLength (1);
			mapWidth = sMap.GetLength (0);
		}
		for(int column=0,row=0; row < mapHeight; row++ ) {
			for( column = 0; column < mapWidth; column++ )
			{string s = "";
				if (haveMap == false) {
					s = mapSymbols [Map [column, row]];
				} else {
					s = sMap [column, row];
				}
				returnString += mapSymbols[Map[column,row]];
			
				if (s == "#") {
					UnityEngine.Object go =Instantiate (wall, new Vector3 (column * spaceBetweenObject, row * spaceBetweenObject, 0), Quaternion.Euler (0, 0, 0));
					go.name = destroyany;
					((GameObject)go).tag = destroyany;
				}
				else if (s == "+") {
					
					finish.transform.position = new Vector3 (column * spaceBetweenObject, row * spaceBetweenObject, 0);
				
				}
				else if (s == "&") {

					player.transform.position = new Vector3 (column * spaceBetweenObject, row * spaceBetweenObject, 0);

				}
				else if (s == "~") {

					UnityEngine.Object go =Instantiate (fan, new Vector3 (column * spaceBetweenObject, row * spaceBetweenObject, 0), Quaternion.Euler (60, 0, 0));
					go.name = destroyany;
					((GameObject)go).tag = destroyany;

				}
				else if (s == "{") {

					UnityEngine.Object go =Instantiate (magnetp, new Vector3 (column * spaceBetweenObject, row * spaceBetweenObject, 0), Quaternion.Euler (0, 0, 0));
					go.name = destroyany;
					((GameObject)go).tag = destroyany;

				}
				else if (s == "}") {

					UnityEngine.Object go =Instantiate (magnetm, new Vector3 (column * spaceBetweenObject, row * spaceBetweenObject, 0), Quaternion.Euler(0, 0, 0));
					go.name = destroyany;
					((GameObject)go).tag = destroyany;

				}
                else if (s == "*")
                {
                    UnityEngine.GameObject go = Instantiate(pendulum, new Vector3(column * spaceBetweenObject, row * spaceBetweenObject, 0), Quaternion.Euler(0, 0, 0));
                    go.gameObject.transform.GetComponent<SpringJoint2D>().connectedAnchor = new Vector2(column * spaceBetweenObject - 5,60);
                        go.name = destroyany;
                    ((GameObject)go).tag = destroyany;
                }
                else if (s == "H")
                {
                    UnityEngine.GameObject go = Instantiate(block, new Vector3(column * spaceBetweenObject, row * spaceBetweenObject, 0), Quaternion.Euler(0, 0, 0));

                    go.name = destroyany;
                    ((GameObject)go).tag = destroyany;

                }
                else if (s == "W")
                {
                    UnityEngine.GameObject go = Instantiate(water, new Vector3(column * spaceBetweenObject, row * spaceBetweenObject, 0), Quaternion.Euler(0, 0, 0));
                    go.name = destroyany;
                    ((GameObject)go).tag = destroyany;

                }
            }
		
			//returnString += Environment.NewLine;
			returnString="";
		}
		return returnString;
	}

	public void BlankMap()
	{
		for(int column=0,row=0; row < mapHeight; row++) {
			for(column = 0; column < mapWidth; column++) {
				Map[column,row] = 0;
			}
		}
	}

	public void RandomFillMap()
	{
		// New, empty map
		Map = new int[mapWidth,mapHeight];

		int mapMiddle = 0; // Temp variable
		for(int column=0,row=0; row < mapHeight; row++) {
			for(column = 0; column < mapWidth; column++)
			{
				// If coordinants lie on the the edge of the map (creates a border)
				if(column == 0)
				{
					Map[column,row] = 1;
				}
				else if (row == 0)
				{
					Map[column,row] = 1;
				}
				else if (column == mapWidth-1)
				{
					Map[column,row] = 1;
				}
				else if (row == mapHeight-1)
				{
					Map[column,row] = 1;
				}
				// Else, fill with a wall a random percent of the time
				else
				{
					mapMiddle = (mapHeight / 2);

					if(row == mapMiddle)
					{
						Map[column,row] = 0;
					}
					else
					{
						Map[column,row] = RandomPercent(percentAreWalls);
					}
				}
			}
		}
	}

	int RandomPercent(int percent)
	{
		if(percent>=rand.Next(1,101))
		{
			return 1;
		}
		return 0;
	}
	public void fillmore(){
		//RandomFillMap();
		MakeCaverns();
		MapToString ();
	}
	private void addtreasure(){
		for(int row=0,column=mapWidth-1; column>= 0; column--)
		{
			for(row=0; row<= mapHeight -1; row++)
			{
				if (Map [column, row]==0) {
					Map [column, row] = 2;
					return;
				}
			}
		}
	}
	private void addfan(){
        bool random = true;
		for(int row=0,column=mapWidth-1; column>= 0; column--)
		{
			for(row=0; row<= mapHeight -1; row++)
			{
				if (Map [column, row]==0) {
					if (column < mapWidth - 3) {
						if (countblock(column, row) >= 3&&Map[column, row-1]==1&&row<mapHeight-5) {
                            if (/*random&&*/ Map[column, row + 1] == 0 && Map[column, row +2] == 0 && Map[column, row + 3] == 0 && Map[column, row + 4] == 0)
                                Map[column, row] = 4;
                            else
                                Map[column, row] = 6;
                            random ^= true;

                        } else {
							//column--;
						}
					}
				}
			}
		}
	}
    private void addmagnet()
    {
        int sum = 0;
        int space1 = 2;
        for (int row = 0, column = 0; row <= mapHeight - 1 ; row++)
        {
            for (column = mapWidth - 1; column >= 0; column--)
            {
                if (Map[column, row] == 0 && row > 5)
                {

                    if (checkearth(column - space1, row - space1, space1*2, space1*2) == 0)
                    {
                        Map[column, row] = 5;
                        sum++;
                    }
                    if (sum >= maxMagnetp)
                        return;

                }
            }
        }
    }
    private void addwater()
    {
        int sum = 0;
        int space1 = 2;
        for (int row = 0, column = 0; row <= mapHeight - 1; row++)
        {
            for (column=0; column <= mapWidth - 1; column++)
            {
                if (/*Map[column, row] == 0 && */row < 5&&row>1&&column>2&&column < mapWidth - 2)
                {

                    if ((checkearth(column - space1, 1, space1 * 2, 0) == 0 && (checkearth(column - space1, 0, space1 * 2, 0) > 0) && Map[column, row + 1] == 0 && Map[column, row - 1] == 1) || Map[column - 1, row] == 9 || Map[column + 1, row] == 9)
                    {
                        if (Map[column, row + 1] == 1 || Map[column, row + 1] == 0) {
                            Map[column, row + 1] = 0;
                            Map[column, row - 1] = 1;
                            Map[column, row] = 9;
                        sum++;
                    }
                    }
                    if (sum >= maxMagnetp + 5)
                        return;

                }
            }
        }
    }
    private void addpendulum()
    {
        int sum = 0;
        int space1=2;
        for (int row = 0, column = 0; row <= mapHeight - 1; row++)
        {
            for (column = mapWidth - 1; column >= 0; column--)
            {
                if (Map[column, row] == 0 && row > 5)
                {

                    if (checkearth(column - space1, row - space1, space1*2, space1*2) == 0)
                    {
                        
                        Map[column, row] = 7;
                        sum++;
                    }
                    if (sum >= maxMagnetp)
                        return;

                }
            }
        }
    }
    private int checkearth(int column, int row,int rows,int cols) {
        int sum = 0;
        int addr = 0;
        int addc=0;
        // if (rows != 0)
        {
            addr= 1;
        }
     //   if (cols != 0)
        {
            addc =1;
        }
        int col = column;
        int ro = row;
        int sumcol = column + cols;
        int sumrow = rows + row;
        if (ro < 0)
            ro = 0;
        if (col < 0)
           col = 0;
        for (row=ro, column=col; row <= mapHeight - 1 && row <= sumrow; row += addr)
        {
            for (column = col; column <= mapWidth - 1&& column <= sumcol; column+= addc)
            {
              //  Debug.Log(column + ";" + row);
                //Debug.Log(">" + Map[column, row]);
                if (Map[column, row] != 0)
                {
                    sum ++;
                }
            }
        }
        return sum;
    }
        private int countblock(int column,int row){
		column++;
		int i = 0;
		for ( i = 0; Map [column, row+i] != 0&&row+i<mapHeight-1; i++) {
		
		}
		return i;
				
	}
	private void addplayer(){
     
        for (int column=0, row=0; column <= mapWidth-1; column++)
		{
			for(row = 0; row<=mapHeight -1; row++)
			{
				if (Map [column, row]==0) {
					Map [column, row] = 3;
					return;
				}
			}
		}

	}
    private void addblock()
    {
        int sum = 0;
        int row = mapHeight - 2, column;
        if (checkearth(0, row, mapWidth - 1, 0) == 0) {
            row = mapHeight - 3;
        }
        for (column = mapWidth-1, row = mapHeight-2; column >=0; column--)
        {
            
                if (Map[column, row] == 0)
                {
                    Map[column, row] = 8;
                sum++;
                
                }
            if (sum >= maxMagnetp + 15)
                return;
        }

    }
    // Use this for initialization
    void Start () {
		RandomFillMap();
		for(int i=0; i<2; i++){
			MakeCaverns();
		}
        addblock();

        addtreasure ();
		addplayer();
		addfan ();
        addmagnet();
        addpendulum();
        addwater();
        MapToString ();
        AstarPath.active.Scan();

    }
	public void restart () {
        StartCoroutine(Example());
    }
    IEnumerator Example()
    {
      //  AstarPath.active.Scan();
       // yield return new WaitForSeconds(0.5f);

        foreach (GameObject laserSplit in GameObject.FindGameObjectsWithTag(destroyany))
            Destroy(laserSplit);
        RandomFillMap();
        for (int i = 0; i < 2; i++)
        {
            MakeCaverns();
        }
        addblock();
        addtreasure();
        addplayer();
        addfan();
        addmagnet();
        addpendulum();
        addwater();
        MapToString();

        AstarPath.active.Scan();
        yield return new WaitForSeconds(0.5f);
    }

    // Update is called once per frame
    void Update () {
		timer += Time.deltaTime;
		if (timer >= maxtimer) {
			timer = 0;
			if (finish.activeInHierarchy == false) {
				finish.SetActive (true);
				restart ();
                
               // AstarPath.active.Scan();
            }
			//	return;
		}
	}
}
