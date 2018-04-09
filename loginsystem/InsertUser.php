<?php
	$servername = "localhost";
	$server_username = "root";
	$server_password = "";
	$dbName = "loginsystem";
	
	$username = $_POST["username_Post"];//"JyJayRay me";
	$email = $_POST["email_Post"];//"testEmail@gmail.com";
	$password = $_POST["password_Post"];//"123456";
	
	//Make Connection
	$conn = new mysqli($servername, $server_username,$server_password,$dbName);
	//Check Connection
	if(!$conn)
	{
		die("Connection Failed.". mysql_connect_error());
	}
	
	$sql = "SELECT username FROM users";
	$result = mysqli_query($conn, $sql);
	$canmakeacount = "";
	
	if(mysqli_num_rows($result) > 0)
	{
		while($row = mysqli_fetch_assoc($result))
		{
			if($row['username'] == $username)
				{
					$canmakeacount = "cant_user";
					print "User Already Exists";

				}					
				else
				{
					$canmakeacount = "email_check";
					//print "email_check";
				}
		}
	}
	
	else if(mysqli_num_rows($result) <= 0)
	{
		$canmakeacount = "creating_account";
		$sql3 = "INSERT INTO  users (username, email, password) VALUES('".$username."','".$email."','".$password."')";
		$result3 = mysqli_query($conn, $sql3);
		if(!$result3) 
		{					
			//print "Error";
		}
		else 
		{
			print "Create First User";
		}
	}
	if($canmakeacount == "email_check" && mysqli_num_rows($result) > 0)
	{
		$sql2 = "SELECT email FROM users";
		$result2 = mysqli_query($conn, $sql2);
		if(mysqli_num_rows($result2) > 0)
		{
			while($row = mysqli_fetch_assoc($result2))
			{
				if($row['email'] == $email)
					{
						$canmakeacount = "cant_email";
						print "Email Already Exists";

					}					
					else
					{
						$canmakeacount = "creating_account";
						$sql3 = "INSERT INTO  users (username, email, password) VALUES('".$username."','".$email."','".$password."')";
						$result3 = mysqli_query($conn, $sql3);
						if(!$result3) 
						{					
							//print "Error";
						}
						else 
						{
							print "Created User";
						}
					}
			}
		}
	}
	$canmakeacount = "";


?>