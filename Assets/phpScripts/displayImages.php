<?php
    // Send variables for the MySQL database class.
    $database = mysql_connect('mysql3.000webhost.com', 'a5370290_team', 'aaaa1234') or die('Could not connect: ' . mysql_error());
    mysql_select_db('a5370290_skypeak') or die('Could not select database');
 
    $query = "select `achievement` from users_achievements where `user` = 'Me'";
    $result = mysql_query($query) or die('Query failed: ' . mysql_error());
 
    $row = mysql_fetch_array($result);

    echo $row['achievement'];
?>