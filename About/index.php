<!DOCTYPE html>
	<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
	<title>About</title>
	<link rel="icon"type="image/png"href="/videowelder.xyz/files/vw_logo.png">
	<style type="text/css" media="screen">

html {
	cursor:url("/videowelder.xyz/files/mouse.png"), auto;
	color: #152754;
	-webkit-touch-callout: none;
	-webkit-user-select: none;
	-webkit-user-drag: none;
	-khtml-user-select: none;
	-moz-user-select: none;
	-ms-user-select: none;
	user-select: none;
	user-drag:none;
	background-color: #000000;
	font-family: Subfont;
	font-size: 12pt;
	text-align: center;
	overflow-x: hidden;
}

@font-face {
	font-family: Subfont;
	src: url(/videowelder.xyz/files/pixel.ttf);
}

@font-face {
	font-family: Mainfont;
	src: url(/videowelder.xyz/files/cmd.ttf);
}

div.main_text {
	top: 0;
	padding: 4px 8px 4px 8px;
	color: #FFFFFF;
	font-size: 100%;
	font-weight: 100;
	font-family: Mainfont;
	font-size: 20pt;
	text-align: center;
	position: sticky;
	text-shadow: 0px 0px 5px #777777;
	opacity: 20%;
}

div.sec_main_text {
	margin: 100px 0px 0px 0px;
	color: #FFFFFF;
	font-family: Mainfont;
	font-size: 40pt;
	position: relative;
	width: 100%;
}

div.ter_main_text {
	color: #FFFFFF;
	font-family: Mainfont;
	font-size: 20pt;
	width: 100%;
	padding-top: 700px;
	margin-bottom: 300px;
	text-shadow: 0px 0px 30px #FFFFFF;
}

div.bg {
	top: 0px;
	left: 0px;
	z-index: -1;
	position: absolute;
	background-image: url("/videowelder.xyz/files/wall.jpg");
	background-size: contain;
	display: block;
	filter: blur(2000px);
	width: 100%;
	height: 100%;
}

div.sub_text {
	top: 45px;
	padding: 4px 8px 4px 8px;
	color: #FFFFFF;
	font-size: 100%;
	font-weight: 100;
	font-family: Subfont;
	font-size: 10pt;
	text-align: center;
	position: sticky;
}

div.sec_sub_text {
	margin-top: 80px;
	padding: 4px 8px 4px 8px;
	color: #FFFFFF;
	font-size: 100%;
	font-weight: 100;
	font-family: Subfont;
	font-size: 12pt;
	text-align: center;
	opacity: 0.75;
	text-shadow: 0px 0px 10px #FFFFFF;
}

div.sec_sub_text p{
	padding-top: 500px;
}

.button {
	background-color: #FFFFFF;
	color: #000000;
	border: 3px solid #FFFFFF;
	display: inline-block;
	border-radius: 500px;
	padding: 20px 20px 20px 20px;
	color: transparent;
}

.button:hover {
	background-image: url("/videowelder.xyz/files/vw_logo.png");
	background-size: 100%;
	background-color: transparent;
	border: 3px dotted #FFFFFF;
}

div.border {
	margin: 50px 300px 0px 300px;
	border-width: 0px 2px 2px 2px;
	padding-top: 15px;
	padding-bottom: 15px;
	border-top: 20px solid #e45c2d;
	border-radius: 3px;
	background-color: #FFFFFF;
	height: 100%;
}

img.emblem {
	width: 40%;
	height: 40%;
}

</style>
<div id="ecran" style='overflow:auto;width:100%;height:650px;'>
	<div class="bg"></div>
	<div class="sec_main_text">About</div>
	<div>
		<div class="border">
			<div>
				<img src="/videowelder.xyz/files/bio.png" alt="VideoWelder Emblem" class="emblem">
			</div>
		</div>
	</div>
		<div class="main_text">VideoWelder</div>
		<div class="sub_text">Victor Litzanov</div>
		<div class="sec_sub_text">
			<p>A man that has done all of his most notable projects out of sheer boredom;</p>
			<p>A man obsessing over the weirdness and stupidity of the cold war and the beauty of communist monuments;</p>
			<p>A man deeply nostalgic of the year 2015;</p>
			<p>A man afraid of sleeping; 
			<p>A man with terrible luck with technology;</p>
			<p>A man in love with electronic-ambient-jazz-fusion music (a very weird musical taste indeed).</p>
			<p>This is who VideoWelder is. A laidback man that built this site not only to showcase his work, but because he had nothing better to do and one day decided to learn HTML, CSS, JAVASCRIPT, SQL, and PHP.</p>
			<p>He's manually removed and reverse-engineered viruses, gone past poorly-built pay-walls, messed up Windows 10 into an unstable Windows ME, made music, a computer from garbage, semi-pro photographer, participated in 4 open-source projects (with varying success), designed books...
		</div>
			<div class="ter_main_text">'Cause Why Not?
				<p>
					<a onclick="history.go(-1)" class="button"></a>
				</p>
			</div>
		</div>
	<script type='text/javascript'>
function ScrollDiv(){
if (document.getElementById('ecran').scrollTop > 400) {
   if(document.getElementById('ecran').scrollTop<(document.getElementById('ecran').scrollHeight-document.getElementById('ecran').offsetHeight+100)){-1
         document.getElementById('ecran').scrollTop=document.getElementById('ecran').scrollTop+1
         }
	}
}

setInterval(ScrollDiv,20)
</script>
