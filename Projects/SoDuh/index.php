<!DOCTYPE html>
	<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
	<title>Videowelder Hub</title>
	<link rel="icon"type="image/png"href="/files/vw_logo.png">
	<style type="text/css" media="screen">
* {
	margin: 0px 0px 0px 0px;
	padding: 0px 0px 0px 0px;
	cursor:url("/files/mouse.png"), auto;
	-webkit-touch-callout: none;
   -webkit-user-select: none;
   -webkit-user-drag: none;
   -khtml-user-select: none;
   -moz-user-select: none;
   -ms-user-select: none;
	user-select: none;
	user-drag:none;
}

html {
	padding: 3px 3px 3px 3px;
	background-color: #152754;
	margin-left: 75px;
	font-family: Verdana, sans-serif;
	font-size: 11pt;
	text-align: center;
}

@font-face {
    font-family: Subfont;
    src: url(/files/pixel.ttf);
}

@font-face {
    font-family: Mainfont;
    src: url(/files/cmd.ttf);
}

div.main_text {
	padding: 4px 8px 4px 8px;
	color: #FFFFFF;
	font-size: 100%;
	font-weight: 100;
	font-family: Mainfont;
	font-size: 20pt;
	text-align: left;
}

div.sub_text {
	padding: 4px 8px 4px 8px;
	margin: 20px 0px 20px 0px;
	color: #FFFFFF;
	font-size: 100%;
	font-weight: 100;
	font-family: Subfont;
	font-size: 12pt;
	text-align: center;
}

div.main_page {
	position: relative;
	display: block;

	width: 800px;
	height: auto;

	margin-left: auto;
	margin-right: auto;
	margin-bottom: 50px;

	border-width: 3px;
	border-color: #212738;
	border-style: dotted;

	background-color: #2e3a5a;

	text-align: center;
}

div.page_header {
	height: 99px;
	width: 100%;

	background-color: #FFFFFF;
}

div.page_header span {
	margin: 15px 0px 0px 50px;

	font-size: 180%;
	font-weight: bold;
}

div.page_header img {
	margin: 3px 0px 0px 40px;

	border: 0px 0px 0px;
}

div.table_of_contents {
	clear: left;

	min-width: 200px;

	margin: 3px 3px 3px 3px;

	background-color: #FFFFFF;

	text-align: left;
}

div.table_of_contents_item {
	clear: left;

	width: 100%;

	margin: 4px 0px 0px 0px;

	background-color: #FFFFFF;

	color: #000000;
	text-align: left;
}

div.table_of_contents_item a {
	margin: 6px 0px 0px 6px;
}

div.content_section {
	margin: 3px 3px 3px 3px;

	background-color: #FFFFFF;

	text-align: left;
}

div.content_section_text {
	padding: 4px 8px 4px 8px;

	color: #000000;
	font-size: 100%;
}

div.content_section_text pre {
	margin: 0px 0px 0px 0px;
	padding: 8px 8px 8px 8px;

	border-width: 1px;
	border-style: dotted;
	border-color: #000000;

	background-color: #F5F6F7;

	font-style: italic;
}

div.content_section_text p {
	margin-bottom: 6px;
}

div.content_section_text ul, div.content_section_text li {
	padding: 4px 8px 4px 16px;
}

.section_header {
	padding: 3px 6px 3px 6px;

	background-color: #CD214F;
	text-shadow: 5px 5px #2e3a5a;
	color: #FFFFFF;
	font-family: Mainfont;
	font-weight: bold;
	font-size: 333%;
	border-radius: 3px;
	text-align: center;
}

.section_header_red {
	background-color: #CD214F;
	color: #FFFFFF;
	font-family: Subfont;
	font-weight: bold;
	font-size: 112%;
	text-align: center;
	border-radius: 3px;
	padding: 0px 10px 0px 10px;
}

.section_header_grey {
	background-color: #F5F6F7;
}

div.table_of_contents_item a:hover {
	background-color: #000000;

	color: #FFFFFF;
}

div.main_text a:link,
div.main_text a:visited,
div.main_text a:active {
	text-decoration: none;
	background-color: #000000;
	color: #FFFFFF;
}

div.main_text :hover {
	text-decoration: none;
	background-color: #000000;
	color: #FFFFFF;
}

div.sub_text a:link,
div.sub_text a:visited,
div.sub_text a:active {
	text-decoration: none;
	font-style: normal;
	font-weight: bold;
	background-color: #000000;
	color: #FFFFFF;
}

div.sub_text a:hover {
	text-decoration: none;
	background-color: #FFFFFF;
	color: #000000;
	box-shadow: 5px 5px;
	font-size: 110%;
}
div.sub_text div{
	padding-top: 3px;
	padding-bottom: 3px;
}
.button {
	 text-decoration: none;
	 font-family: Subfont;
	 background-color: #FFFFFF;
    color: #000000;
    width: auto;
    text-align: center;
    border-radius: 2px;
    border: 5px solid #FFFFFF;
    font-size: 16px;
}

.button:hover {
	text-decoration: none;
    background-color: #000000;
    border: 5px solid #000000;
    color: #FFFFFF;
}

div.navbar {
	width: 75px;
	position: fixed;
	top: 0;
	left: 0;
	font-family: Subfont;
	text-align: center;
	border-width: 3px;
	border-color: #212738;
	border-right-style: dotted;
	background-color: #2e3a5a;
	color: #FFFFFF;
	height: 100%;
	padding-top: 20px;
}

div.navbar a:link,
div.navbar a:visited,
div.navbar a:active {
	text-decoration: none;
	font-style: normal;
	font-weight: bold;
	color: #FFFFFF;
}

div.navbar div {
	font-style: normal;
	font-weight: bold;
	color: #FFFFFF;
	text-align: left;
	padding-left: 5px;
}

div.navbar div:hover {
	text-decoration: none;
	color: #000000;
	background-color: #FFFFFF;
	border-right-style: dotted;
	border-right-width: 3px;
	margin-right: -3px;
}

div.navbar a:hover {
	color: #000000;
	background-color: #FFFFFF;
}

div.navbar p {
	color: #FFFFFF;
	background-color: #152754;
	border-top: 1px double #2e3a5a;
	border-bottom: 1px double #2e3a5a;
	border-left: 1px double #2e3a5a;
	font-weight: bold;
	margin-right: -3px;
}

img.close {
	position: absolute;
	margin-top: 15px;
	left: 10px;
}
img.close:hover{
	background-image: url("/files/back-hover.png");
}

.nav {
width: 105px;
left: 0;
font-family: Subfont;
color: white;
position: fixed;
margin-left: 78px;
background-color: #212738;
margin-top: -18px;
}

.nav p:hover {
background-color: #FFFFFF;
color: #000000;
}

.nav a:link,
.nav a:visited,
.nav a:active {
	text-decoration: none;
	font-style: normal;
	font-weight: bold;
	color: #FFFFFF;
}

	</style>
</head>
<body onpageshow="Hide()">
<div class="navbar">
<a href="/" class="section_header_red">Home</a>
<span>~</span>
<a href="/Crowtel">
	<div>Crowtel</div>
</a>
<a href="/DATA">
	<div>DATA</div>
</a>
<p onmouseover="Show()" onmouseout="Hide()">Projects
	<nav class="nav" id="subpages" onmouseover="Show()" onmouseout="Hide()">
		<a href="/Projects/TM">
			<p>ToneMatricks</p>
		</a>		
		<a href="/Projects/ToneGen">
			<p>ToneGen</p>
		</a>
		<a href="/Projects/JMinesweeper">
			<p>Minesweeper</p>
		</a>
		<a href="/Projects/SoDuh">
			<p>SoDuh</p>
		</a>
		<a href="/Projects/Asteroids">
			<p>Asteroids</p>
		</a>
	</nav>
</p>
<a href="/About">
	<div>About</div>
</a>
</div>
	<div class="main_page">
		<div class="section_header">
		<a href="/Projects">
			<img class="close" src="/files/back.png">
			</a>
		SoDuh
		</div>
		<div class="section_header_red">
		Platforms: JVM
		</div>
		<div class="sub_text">
		<img src="/files/sd_logo.ico" alt="SoDuh Emblem">
		<div class="sub_text">
		A version of the universal fizz-buzz test compiled in Java. Name based on a pun of soda.
		</div>
		<a href="/Projects/SoDuh/SoDuh.jar">Download</a>
		<a href="/Projects/SoDuh/Play.php">Play</a>
		</div>
		<div class="section_header_red" title="Fin">Fin</div>
		</div>
	</div>
</body>
</html>
<script type='text/javascript'>
function Show(){
		document.getElementById('subpages').style.visibility = 'visible';
}
function Hide(){
	if(document.getElementById('subpages').style.visibility = 'visible')
		document.getElementById('subpages').style.visibility = 'hidden';
}
</script>
