HOW TO USE:

1. Add these tags to your scene;
			'AlkaliMetals'
			'AlkalineEarthMetals'
			'Metalloids'
			'NobleGases'
			'PostTransitionMetals'
			'ReactiveNonMetals'
			'SwitchView'
			'GroupContainer'
2. Place a 'Spawner' and 'Board' prefab in your scene. (Found in the Prefabs folder)
3. Attach a 'ButtonReader' script to the main camera. (Found in the Scripts folder)
4. Import TMP essentials (This is also prompted if you run the program without having imported them)
____________________________________________________________________________________________________________________
HOW TO ADD/REMOVE USEABLE CATEGORIES:

1. Access the 'Filters' folder and create a new 'FilterConfig' object inside of it. (Right Click > Create > Filter Config)
	2a. Category Name - The text written on the spawned filter block (e.g: Alkali Metals)
	2b. Block Colour - Hex code to be used to colour the material (e.g: #aaaaaa)
	2c. Xpos - The x position of the filter box
	2d. Ypos - The y position of the filter box
	2e. Tag Name - What the element will be tagged as (Make sure a matching tag exists in the project to be able to assign it, Make sure the category for the element in the JSON file matches this exactly!)
	2f. Elements List - This will hold the index of all the elements in the category | Manually enter each element's number in this list
	2g. Filtered X Pos - The X position of the filtered element in the groups only view
	2h. Filtered Y Pos - The Y position of the filtered element in the groups only view

	NB: The size of 2f, 2g and 2h must be the same, the values entered in 2g and 2h will be the ones used by the corresponding element in 2f!

3. Select the 'FullViewContainer' prefab from the Prefabs folder.
4. Under the 'FullViewSpawner' script component find the 'Categories' variable and change its size to the amount of desired categories.
5. Type the names of the desired categories.
REMINDER: If adding a category, type it as it is in the json file. (Found in Resources > Json > PeriodicTableJSON) THIS MEANS THAT THE TAG NAME (2e) SHOULD MATCH WHAT IS WRITTEN HERE

6. Select the 'FilterContainer' prefab from the Prefabs folder.
7. From the 'FilterButtonSpawner' component, set the size of the AllFilters list to the same amount of categories you want to be accessible.
8. In no particular order, make sure that all the desired FilterConfig objects are assigned to 'AllFilters'.
