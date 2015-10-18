<?php 
        $db = mysql_connect('mysql3.000webhost.com', 'a5370290_team', 'aaaa1234') or die('Could not connect: ' . mysql_error()); 
        mysql_select_db('a5370290_skypeak') or die('Could not select database');
 
        // Strings must be escaped to prevent SQL injection attack. 
        $name = mysql_real_escape_string($_GET['name'], $db); 

        $score = mysql_real_escape_string($_GET['score'], $db); 
        $hash = $_GET['hash']; 
 
        $secretKey="mySecretKey"; # Change this value to match the value stored in the client javascript below 

        $real_hash = md5($name . $score . $secretKey); 

        if($real_hash == $hash) { 

        		//$query = "UPDATE test SET score='$score' WHERE name='$name'";
		
		$query = "select score from city where name='$name'";
		$exec_query = mysql_query($query) or die('Query failed: ' . mysql_error());
		$row = mysql_fetch_array($exec_query);
		if ((int)$row['score'] < $score){
        		$query = "replace into city values('$name', '$score');";
 		}

            // Send variables for the MySQL database class. 
            //$query = "insert into test values('$name', '$score')";
            //$query = "UPDATE test SET score='$score' WHERE name='$name'";
            //$query = "insert into test (name, score) values('$name', '$score') on duplicate key update name=values('$name') score=values('$score')";
            $result = mysql_query($query) or die('Query failed: ' . mysql_error()); 
        } 

?>