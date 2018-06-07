<?php
	$servername = "localhost";
	$server_username = "root";
	$server_password = "";
	$dbName = "loginsystem";

	//Make Connection
	$conn = new mysqli($servername, $server_username,$server_password,$dbName);
	//Check Connection
	if(!$conn)
	{
		die("Connection Failed.". mysql_connect_error());
	}
	//Get all the data from our Weapon database
	$getItem = "SELECT id, name, clipSize, damage, fireRate, weaponRange, ammoType, iconName, meshName FROM weapon_DB";
	//connect and search
	$result = mysqli_query($conn, $getItem);
	//if we have something in that search result
	if(mysqli_num_rows($result)>0)
	{
		//while we have rows Echo info
		while($row = mysqli_fetch_assoc($result))
		{
			//we are going to pull a string of all the items
			//items are split by #
			//item data is split by |
			echo $row['id']."|"
				.$row['name']."|"
				.$row['clipSize']."|"
				.$row['damage']."|"
				.$row['fireRate']."|"
				.$row['weaponRange']."|"
				.$row['ammoType']."|"
				.$row['iconName']."|"
				.$row['meshName']."#";
		}
	}
?>