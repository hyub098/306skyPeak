<?php 
        $db = mysql_connect('mysql3.000webhost.com', 'a5370290_team', 'aaaa1234') or die('Could not connect: ' . mysql_error()); 
        mysql_select_db('a5370290_skypeak') or die('Could not select database');
 
        // Strings must be escaped to prevent SQL injection attack. 
        $user = mysql_real_escape_string($_GET['user'], $db); 

        $achievement = mysql_real_escape_string($_GET['achievement'], $db); 
        $hash = $_GET['hash']; 
 
        $secretKey="mySecretKey";

		echo $secretKey;
		
        $real_hash = md5($user . $achievement . $secretKey); 

        if($real_hash == $hash) { 

			$query = "replace into users_achievements values('$user', '$achievement');";
            
            $result = mysql_query($query) or die('Query failed: ' . mysql_error()); 
        } 

?>