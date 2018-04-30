<?php


$servername = "localhost";
	$server_username = "root";
	$server_password = "";
	$dbName = "loginsystem";

	$email = $_POST["email_Post"];
	$password = $_POST["password_Post"];
	$resetcode = $_POST["resetcode_Post"];
	
	//Make Connection
	$conn = new mysqli($servername, $server_username,$server_password,$dbName);
	//Check Connection
	if(!$conn)
	{
		die("Connection Failed.". mysql_connect_error());
	}
	
	$sqlUpdatePassword = "UPDATE users SET password = '".$password."', resetcode = '' WHERE email = '".$email."'";
    $resultChangePassword = mysqli_query($conn, $sqlUpdatePassword);
    if(!$resultChangePassword)
    {
        echo "error";
    }
    else
    {
        echo "Password Changed";
    }
	/*$checkaccount = "SELECT resetcode FROM users WHERE email = '".$email."'";
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
					$sql3 = "UPDATE users SET password='".$password."' WHERE email='".$email."'";
					$result3 = mysqli_query($conn, $sql3);
					if(!$result3) 
					{					
						print "Error 1";
					break 1;
					}
					else 
					{
					print "Password Set!";
						break 1;
					}
				}					
				else
				{
					print "Error 2";
					break 1;
				}
			}
		}
	}
	else
	{
		echo "Error 3";
	}*/
	
?>