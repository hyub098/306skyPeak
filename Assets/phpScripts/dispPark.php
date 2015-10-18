<?php
    // Send variables for the MySQL database class.
    $database = mysql_connect('mysql3.000webhost.com', 'a5370290_team', 'aaaa1234') or die('Could not connect: ' . mysql_error());
    mysql_select_db('a5370290_skypeak') or die('Could not select database');
 
    $query = "SELECT * FROM `park` ORDER by `score` DESC LIMIT 5";

    $result = mysql_query($query) or die('Query failed: ' . mysql_error());
 
    $num_results = mysql_num_rows($result);  
 
    for($i = 0; $i < $num_results; $i++)
    {
         $row = mysql_fetch_array($result);
         echo $row['name'];
         echo ",";
         echo $row['score'];
         echo ",";
    }
?>