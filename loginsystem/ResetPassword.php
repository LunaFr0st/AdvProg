<?php


$servername = "localhost";
	$server_username = "root";
	$server_password = "";
	$dbName = "loginsystem";
	
	$username = $_POST["username_Post"];
	$password = $_POST["password_Post"];
	$email = $_POST["email_Post"];
	
	//Make Connection
	$conn = new mysqli($servername, $server_username,$server_password,$dbName);
	//Check Connection
	if(!$conn)
	{
		die("Connection Failed.". mysql_connect_error());
	}
	
	$checkaccount = "SELECT username FROM users WHERE email = '".$email."'";
	$result = mysqli_query($conn, $checkaccount);
	
	if(mysqli_num_rows($result) > 0)
	{
		while($row = mysqli_fetch_assoc($result))
		{
			
		}
	}
	else
	{
		echo "Username Incorrect";
	}
	
?>