<?php
    // Send variables for the MySQL database class.
    $database = mysql_connect('mysql3.000webhost.com', 'a5370290_team', 'aaaa1234') or die('Could not connect: ' . mysql_error());
    mysql_select_db('a5370290_skypeak') or die('Could not select database');
	
	// Strings must be escaped to prevent SQL injection attack. 
        $name = mysql_real_escape_string($_GET['name'], $database); 
       
        $hash = $_GET['hash']; 
 
        $secretKey="mySecretKey"; 

        $real_hash = md5($name . $secretKey); 

        if($real_hash == $hash) { 
 
		$query = "select `score` from city where `name` = '$name'";    		
 
		$result = mysql_query($query) or die('Query failed: ' . mysql_error());
		
		
   		
		$row = mysql_fetch_array($result);
		echo $row['score'];
			
		
	}
?>
 