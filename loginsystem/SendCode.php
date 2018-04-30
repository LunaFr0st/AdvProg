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
		$sql2 = "SELECT email FROM users";
		$result2 = mysqli_query($conn, $sql2);
		if(mysqli_num_rows($result2) > 0)
		{
			while($row = mysqli_fetch_assoc($result2))
			{
				if($row['email'] == $email)
					{
						$sql3 = "UPDATE users SET resetcode='".$resetcode."' WHERE email='".$email."'";
						$result3 = mysqli_query($conn, $sql3);
						if(!$result3) 
						{					
							print "Error";
						}
						else 
						{
							print "Created User";
						}
					}					
					else
					{
						print "Error";
					}
			}
		}
	}
	else
	{
		echo "Reset Code Incorrect";
	}
	
?>