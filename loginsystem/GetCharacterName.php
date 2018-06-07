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
    
    $selectChars = "SELECT characterName FROM characters WHERE username = '".$username."'";
    $result = mysqli_query($conn,$selectChars);
    
    for($i = 0; $i <= 5; $i++)
    {
        $row = mysql_fetch_assoc($result);
        echo"".$row['characterName']."|";
    }
    if(!$result)echo"Error";
?>