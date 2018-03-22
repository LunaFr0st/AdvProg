<?php
//forced vars
//defined by $
//each script is 1 behaviour

//$_POST means get...
//we are waiting for data to be sent to us 
//we are looking for a string name

//SELECT = choose a column (header) or row (value)
//FROM = from a table, column(header)
//"SELECT username FROM users";

//INSERT = put data
//INTO = in table and referenced columns(headers)
//VALUES = this data value by name
//"INSERT INTO  users (username, email, password) VALUES('".$username."','".$email."','".$password."')";

//UPDATE = change pre existing data from table
//SET = column(header) 
//WHERE = if things match or exist
//"UPDATE users SET password = '".$password."' WHERE email = '".$email."';"

$servername = "localhost";
	$server_username = "root";
	$server_password = "";
	$dbName = "loginsystem";
	
	$username = $_POST["username_Post"];
	$password = $_POST["password_Post"];
	
	//Make Connection
	$conn = new mysqli($servername, $server_username,$server_password,$dbName);
	//Check Connection
	if(!$conn)
	{
		die("Connection Failed.". mysql_connect_error());
	}
	
	//select the username and password fields from users and compare the username then password
	$checkaccount = "SELECT password FROM users WHERE username = '".$username."'";
	$result = mysqli_query($conn, $checkaccount);
	
	if(mysqli_num_rows($result) > 0)
	{
		while($row = mysqli_fetch_assoc($result))
		{
			if($row['password'] == $password)
			{
				echo "Success";
				break 1;
			}
			else if (!($row['password'] == $password))
			{
				echo "Password Incorrect";
				break 1;
			}
		}
	}
	else
	{
		echo "Username Incorrect";
	}
	
?>