<?php
phpinfo();
	$passw = htmlspecialchars($_POST['passw']);
	$users = file("users.log");
	print_r(get_password());
	if ($passw == get_password())
	{
		if (!in_array($passw, $users)){
			print_r("nope");	
		} else {
			print_r("yep");
		//file_put_contents("users.log", $password . "\r\n", $flags = FILE_APPEND, $context = null);
		}
	}
	function get_password() {
	$req1 = date("zdNG",$timestamp = time());
	$req2 = get_browser(null,true);
	$req3 = get_client_ip();
	$password = ($req1 . "-" . $req2[parent] . "-" . $req2[platform] . "-" . $req3);
	return $password;
	}
	function get_client_ip() {
    $ipaddress = '';
    if (getenv('HTTP_CLIENT_IP'))
        $ipaddress = getenv('HTTP_CLIENT_IP');
    else if(getenv('HTTP_X_FORWARDED_FOR'))
        $ipaddress = getenv('HTTP_X_FORWARDED_FOR');
    else if(getenv('HTTP_X_FORWARDED'))
        $ipaddress = getenv('HTTP_X_FORWARDED');
    else if(getenv('HTTP_FORWARDED_FOR'))
        $ipaddress = getenv('HTTP_FORWARDED_FOR');
    else if(getenv('HTTP_FORWARDED'))
       $ipaddress = getenv('HTTP_FORWARDED');
    else if(getenv('REMOTE_ADDR'))
        $ipaddress = getenv('REMOTE_ADDR');
    else
        $ipaddress = 'UNKNOWN';
    return $ipaddress;
}
?>