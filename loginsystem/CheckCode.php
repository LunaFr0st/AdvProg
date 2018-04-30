<?php


$servername = "localhost";
	$server_username = "root";
	$server_password = "";
	$dbName = "loginsystem";
	
	$email = $_POST["email_Post"];
	$resetcode = $_POST["resetcode_Post"];
	
	//Make Connection
	$conn = new mysqli($servername, $server_username,$server_password,$dbName);
	//Check Connection
	if(!$conn)
	{
		die("Connection Failed.". mysql_connect_error());
	}
	
	$checkaccount = "SELECT resetcode FROM users WHERE email = '".$email."'";
	$result = mysqli_query($conn, $checkaccount);
	
	if(mysqli_num_rows($result) > 0)
	{
		while($row = mysqli_fetch_assoc($result))
		{
			if($row['resetcode'] == $resetcode)
			{
				echo "Success";
				break 1;
			}
			else if (!($row['resetcode'] == $resetcode))
			{
				echo "Reset Code Incorrect";
				break 1;
			}
		}
	}
	else
	{
		echo "Reset Code Incorrect";
	}
?>