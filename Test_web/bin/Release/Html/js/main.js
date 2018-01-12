jQuery(document).ready(function($){
	//open interest point description
	// $('.cd-single-point').children('a').on('click', function(){
	// 	var selectedPoint = $(this).parent('li');
	// 	if( selectedPoint.hasClass('is-open') ) {
	// 		selectedPoint.removeClass('is-open').addClass('visited');
	// 	} else {
	// 		selectedPoint.addClass('is-open').siblings('.cd-single-point.is-open').removeClass('is-open').addClass('visited');
	// 	}
	// });
	// //close interest point description
	// $('.cd-close-info').on('click', function(event){
	// 	event.preventDefault();
	// 	$(this).parents('.cd-single-point').eq(0).removeClass('is-open').addClass('visited');
	// });
	$('.cd-single-point').children('a').hover(function(){
		var selected = $(this).parent('li');
		if( selected.hasClass('is-open') ) {
			selected.removeClass('is-open');
		} else {
			selected.addClass('is-open').siblings('.cd-single-point.is-open');
		}
	}, function(){
		var selected = $(this).parent('li');
		if( selected.hasClass('is-open') ) {
			selected.removeClass('is-open');
		} else {
			selected.addClass('is-open').siblings('.cd-single-point.is-open');
		}
	});
	$('p.office').replaceWith("<hr><h3>Standar</h3><p>Temp:&nbsp;<span>15&#8451;&nbsp;-&nbsp;29&#8451;</span></p><p>Humid:&nbsp;<span>40&#37;&nbsp;-&nbsp;70&#37;</span></p>");
	$('p.print').replaceWith("<hr><h3>Standar</h3><p>Temp:&nbsp;<span>22&#8451;&nbsp;-&nbsp;28&#8451;</span></p><p>Humid:&nbsp;<span>40&#37;&nbsp;-&nbsp;60&#37;</span></p>");

	// $('#btn-on').click(function(event) {
	// 	event.preventDefault();
	// 	$('.cd-single-point').addClass('open-point');
	// });
	// $('#btn-off').click(function(event) {
	// 	event.preventDefault();
	// 	$('.cd-single-point').removeClass('open-point');
	// });
	var myVar = setInterval(function(){ readTextFile('data.txt') }, 3000);
});
var tem;
function readTextFile(file)
{
	var rawFile = new XMLHttpRequest();
	rawFile.open("GET", file, false);
	rawFile.onreadystatechange = function ()
	{
		if(rawFile.readyState === 4)
		{
			if(rawFile.status === 200 || rawFile.status == 0)
			{
				var allText = rawFile.responseText;
				var lines = allText.split('\n');
				for (var i = 0; i < lines.length; i++) {
					lines[i] = lines[i].trim();
				}

				tem = lines[1].split(',');
				var mc = {
					standar: tem[0],
					temp : tem[1],
					humid: tem[2],
					connect: tem[3]
				}

				tem = lines[3].split(',');
				var pc = {
					standar: tem[0],
					temp : tem[1],
					humid: tem[2],
					connect: tem[3]
				}

				tem = lines[5].split(',');
				var pd1_smt = {
					standar: tem[0],
					temp : tem[1],
					humid: tem[2],
					connect: tem[3]
				}

				tem = lines[7].split(',');
				var mc2 = {
					standar: tem[0],
					temp : tem[1],
					humid: tem[2],
					connect: tem[3]
				}

				tem = lines[9].split(',');
				var pc2 = {
					standar: tem[0],
					temp : tem[1],
					humid: tem[2],
					connect: tem[3]
				}

				tem = lines[11].split(',');
				var pd2_smt = {
					standar: tem[0],
					temp : tem[1],
					humid: tem[2],
					connect: tem[3]
				}

				tem = lines[13].split(',');
				var pd2_pu_1 = {
					standar: tem[0],
					temp : tem[1],
					humid: tem[2],
					connect: tem[3]
				}

				tem = lines[15].split(',');
				var pd2_pu_2 = {
					standar: tem[0],
					temp : tem[1],
					humid: tem[2],
					connect: tem[3]
				}
				tem = lines[17].split(',');
				var pd1_fat_1 = {
					standar: tem[0],
					temp : tem[1],
					humid: tem[2],
					connect: tem[3]
				}

				tem = lines[19].split(',');
				var pd1_fat_2 = {
					standar: tem[0],
					temp : tem[1],
					humid: tem[2],
					connect: tem[3]
				}


				tem = lines[21].split(',');
				var pd1_spot = {
					standar: tem[0],
					temp : tem[1],
					humid: tem[2],
					connect: tem[3]
				}

				tem = lines[23].split(',');
				var pd1_print_1 = {
					standar: tem[0],
					temp : tem[1],
					humid: tem[2],
					connect: tem[3]
				}
				tem = lines[25].split(',');
				var pd1_print_2 = {
					standar: tem[0],
					temp : tem[1],
					humid: tem[2],
					connect: tem[3]
				}

				tem = lines[27].split(',');
				var pd1_print_3 = {
					standar: tem[0],
					temp : tem[1],
					humid: tem[2],
					connect: tem[3]
				}

				tem = lines[29].split(',');
				var pc12 = {
					standar: tem[0],
					temp : tem[1],
					humid: tem[2],
					connect: tem[3]
				}
				tem = lines[31].split(',');
				var fuji = {
					standar: tem[0],
					temp : tem[1],
					humid: tem[2],
					connect: tem[3]
				}
				tem = lines[33].split(',');
				var se1 = {
					standar: tem[0],
					temp : tem[1],
					humid: tem[2],
					connect: tem[3]
				}
				tem = lines[35].split(',');
				var se2 = {
					standar: tem[0],
					temp : tem[1],
					humid: tem[2],
					connect: tem[3]
				}

				tem = lines[37].split(',');
				var se3 = {
					standar: tem[0],
					temp : tem[1],
					humid: tem[2],
					connect: tem[3]
				}

				tem = lines[39].split(',');
				var se4 = {
					standar: tem[0],
					temp : tem[1],
					humid: tem[2],
					connect: tem[3]
				}

				tem = lines[41].split(',');
				var se5 = {
					standar: tem[0],
					temp : tem[1],
					humid: tem[2],
					connect: tem[3]
				}

				tem = lines[43].split(',');
				var se6 = {
					standar: tem[0],
					temp : tem[1],
					humid: tem[2],
					connect: tem[3]
				}

				if (mc.connect === "True") {
					$('li:nth-child(14)').addClass('warning-connection');
					$('li:nth-child(14) a').addClass('cd-img-replace-alarm').removeClass('cd-img-replace');
					$('#mc-temp').text('connection warning!');
					$('#mc-humid').html('');
				}
				else if (mc.standar === "True") {
					$('li:nth-child(14)').removeClass('warning-connection');
					$('li:nth-child(14)').addClass('open-point');
					$('li:nth-child(14) a').removeClass('cd-img-replace-alarm').addClass('cd-img-replace');
					// $('#mc-temp').html('');
					// $('#mc-humid').html('');
					$('#mc-temp').html(mc.temp + '&#8451;');
					$('#mc-humid').html(mc.humid + '&#37;');
				}
				else{
					$('li:nth-child(14) a').addClass('cd-img-replace-alarm').removeClass('cd-img-replace');
					$('#mc-temp').html(mc.temp + '&#8451;');
					$('#mc-humid').html(mc.humid + '&#37;');
					$('li:nth-child(14)').removeClass('open-point');
					$('li:nth-child(14)').removeClass('warning-connection');
				}

				if (pc.connect === "True") {
					$('li:nth-child(13)').addClass('warning-connection');
					$('li:nth-child(13) a').addClass('cd-img-replace-alarm').removeClass('cd-img-replace');
					$('#pc-temp').text('connection warning!');
					$('#pc-humid').html('');
				}
				else if (pc.standar === "True") {
					$('li:nth-child(13)').removeClass('warning-connection');
					$('li:nth-child(13)').addClass('open-point');
					$('li:nth-child(13) a').removeClass('cd-img-replace-alarm').addClass('cd-img-replace');
					// $('#pc-temp').html('');
					// $('#pc-humid').html('');
					$('#pc-temp').html(pc.temp + '&#8451;');
					$('#pc-humid').html(pc.humid + '&#37;');
				}
				else{
					$('li:nth-child(13) a').addClass('cd-img-replace-alarm').removeClass('cd-img-replace');
					$('li:nth-child(13)').removeClass('open-point');
					$('li:nth-child(13)').removeClass('warning-connection');
					$('#pc-temp').html(pc.temp + '&#8451;');
					$('#pc-humid').html(pc.humid + '&#37;');
				}

				if (pd1_smt.connect === "True") {
					$('li:nth-child(5)').addClass('warning-connection');
					$('li:nth-child(5) a').addClass('cd-img-replace-alarm').removeClass('cd-img-replace');
					$('#pd1-smt-temp').text('connection warning!');
					$('#pd1-smt-humid').html('');
				}
				else if (pd1_smt.standar === "True") {
					$('li:nth-child(5)').removeClass('warning-connection');
					$('li:nth-child(5)').addClass('open-point');
					$('li:nth-child(5) a').removeClass('cd-img-replace-alarm').addClass('cd-img-replace');
					// $('#pd1-smt-temp').html('');
					// $('#pd1-smt-humid').html('');
					$('#pd1-smt-temp').html(pd1_smt.temp + '&#8451;');
					$('#pd1-smt-humid').html(pd1_smt.humid + '&#37;');
				}
				else{
					$('li:nth-child(5) a').addClass('cd-img-replace-alarm').removeClass('cd-img-replace');
					$('li:nth-child(5)').removeClass('open-point');
					$('li:nth-child(5)').removeClass('warning-connection');
					$('#pd1-smt-temp').html(pd1_smt.temp + '&#8451;');
					$('#pd1-smt-humid').html(pd1_smt.humid + '&#37;');
				}

				if (mc2.connect === "True") {
					$('li:nth-child(2)').addClass('warning-connection');
					$('li:nth-child(2) a').addClass('cd-img-replace-alarm').removeClass('cd-img-replace');
					$('#mc2-temp').text('connection warning!');
					$('#mc2-humid').html('');
				}
				else if (mc2.standar === "True") {
					$('li:nth-child(2)').removeClass('warning-connection');
					$('li:nth-child(2)').addClass('open-point');
					$('li:nth-child(2) a').removeClass('cd-img-replace-alarm').addClass('cd-img-replace');
					// $('#mc2-temp').html('');
					// $('#mc2-humid').html('');
					$('#mc2-temp').html(mc2.temp + '&#8451;');
					$('#mc2-humid').html(mc2.humid + '&#37;');
				}
				else{
					$('li:nth-child(2) a').addClass('cd-img-replace-alarm').removeClass('cd-img-replace');
					$('li:nth-child(2)').removeClass('open-point');
					$('li:nth-child(2)').removeClass('warning-connection');
					$('#mc2-temp').html(mc2.temp + '&#8451;');
					$('#mc2-humid').html(mc2.humid + '&#37;');
				}

				if (pc2.connect === "True") {
					$('li:nth-child(6)').addClass('warning-connection');
					$('li:nth-child(6) a').addClass('cd-img-replace-alarm').removeClass('cd-img-replace');
					$('#pc2-temp').text('connection warning!');
					$('#pc2-humid').html('');
				}
				else if (pc2.standar === "True") {
					$('li:nth-child(6)').removeClass('warning-connection');
					$('li:nth-child(6)').addClass('open-point');
					$('li:nth-child(6) a').removeClass('cd-img-replace-alarm').addClass('cd-img-replace');
					// $('#pc2-temp').html('');
					// $('#pc2-humid').html('');
					$('#pc2-temp').html(pc2.temp + '&#8451;');
					$('#pc2-humid').html(pc2.humid + '&#37;');
				}
				else{
					$('li:nth-child(6) a').addClass('cd-img-replace-alarm').removeClass('cd-img-replace');
					$('li:nth-child(6)').removeClass('open-point');
					$('li:nth-child(6)').removeClass('warning-connection');
					$('#pc2-temp').html(pc2.temp + '&#8451;');
					$('#pc2-humid').html(pc2.humid + '&#37;');
				}

				if (pd2_smt.connect === "True") {
					$('li:nth-child(10)').addClass('warning-connection');
					$('li:nth-child(10) a').addClass('cd-img-replace-alarm').removeClass('cd-img-replace');
					$('#pd2-smt-temp').text('connection warning!');
					$('#pd2-smt-humid').html('');
				}
				else if (pd2_smt.standar === "True") {
					$('li:nth-child(10)').removeClass('warning-connection');
					$('li:nth-child(10)').addClass('open-point');
					$('li:nth-child(10) a').removeClass('cd-img-replace-alarm').addClass('cd-img-replace');
					// $('#pd2-smt-temp').html('');
					// $('#pd2-smt-humid').html('');
					$('#pd2-smt-temp').html(pd2_smt.temp + '&#8451;');
					$('#pd2-smt-humid').html(pd2_smt.humid + '&#37;');
				}
				else{
					$('li:nth-child(10) a').addClass('cd-img-replace-alarm').removeClass('cd-img-replace');
					$('li:nth-child(10)').removeClass('open-point');
					$('li:nth-child(10)').removeClass('warning-connection');
					$('#pd2-smt-temp').html(pd2_smt.temp + '&#8451;');
					$('#pd2-smt-humid').html(pd2_smt.humid + '&#37;');
				}

				if (pd2_pu_1.connect === "True") {
					$('li:nth-child(11)').addClass('warning-connection');
					$('li:nth-child(11) a').addClass('cd-img-replace-alarm').removeClass('cd-img-replace');
					$('#pd2-pu-1-temp').text('connection warning!');
					$('#pd2-pu-1-humid').html('');
				}
				else if (pd2_pu_1.standar === "True") {
					$('li:nth-child(11)').removeClass('warning-connection');
					$('li:nth-child(11)').addClass('open-point');
					$('li:nth-child(11) a').removeClass('cd-img-replace-alarm').addClass('cd-img-replace');
					// $('#pd2-pu-1-temp').html('');
					// $('#pd2-pu-1-humid').html('');
					$('#pd2-pu-1-temp').html(pd2_pu_1.temp + '&#8451;');
					$('#pd2-pu-1-humid').html(pd2_pu_1.humid + '&#37;');
				}
				else{
					$('li:nth-child(11) a').addClass('cd-img-replace-alarm').removeClass('cd-img-replace');
					$('li:nth-child(11)').removeClass('open-point');
					$('li:nth-child(11)').removeClass('warning-connection');
					$('#pd2-pu-1-temp').html(pd2_pu_1.temp + '&#8451;');
					$('#pd2-pu-1-humid').html(pd2_pu_1.humid + '&#37;');
				}

				if (pd2_pu_2.connect === "True") {
					$('li:nth-child(12)').addClass('warning-connection');
					$('li:nth-child(12) a').addClass('cd-img-replace-alarm').removeClass('cd-img-replace');
					$('#pd2-pu-2-temp').text('connection warning!');
					$('#pd2-pu-2-humid').html('');
				}
				else if (pd2_pu_2.standar === "True") {
					$('li:nth-child(12)').removeClass('warning-connection');
					$('li:nth-child(12)').addClass('open-point');
					$('li:nth-child(12) a').removeClass('cd-img-replace-alarm').addClass('cd-img-replace');
					// $('#pd2-pu-2-temp').html('');
					// $('#pd2-pu-2-humid').html('');
					$('#pd2-pu-2-temp').html(pd2_pu_2.temp + '&#8451;');
					$('#pd2-pu-2-humid').html(pd2_pu_2.humid + '&#37;');
				}
				else{
					$('li:nth-child(12) a').addClass('cd-img-replace-alarm').removeClass('cd-img-replace');
					$('li:nth-child(12)').removeClass('open-point');
					$('li:nth-child(12)').removeClass('warning-connection');
					$('#pd2-pu-2-temp').html(pd2_pu_2.temp + '&#8451;');
					$('#pd2-pu-2-humid').html(pd2_pu_2.humid + '&#37;');
				}

				if (pd1_fat_1.connect === "True") {
					$('li:nth-child(1)').addClass('warning-connection');
					$('li:nth-child(1) a').addClass('cd-img-replace-alarm').removeClass('cd-img-replace');
					$('#pd1-fat-1-temp').text('connection warning!');
					$('#pd1-fat-1-humid').html('');
				}
				else if (pd1_fat_1.standar === "True") {
					$('li:nth-child(1)').removeClass('warning-connection');
					$('li:nth-child(1)').addClass('open-point');
					$('li:nth-child(1) a').removeClass('cd-img-replace-alarm').addClass('cd-img-replace');
					// $('#pd1-fat-1-temp').html('');
					// $('#pd1-fat-1-humid').html('');
					$('#pd1-fat-1-temp').html(pd1_fat_1.temp + '&#8451;');
					$('#pd1-fat-1-humid').html(pd1_fat_1.humid + '&#37;');
				}
				else{
					$('li:nth-child(1) a').addClass('cd-img-replace-alarm').removeClass('cd-img-replace');
					$('li:nth-child(1)').removeClass('open-point');
					$('li:nth-child(1)').removeClass('warning-connection');
					$('#pd1-fat-1-temp').html(pd1_fat_1.temp + '&#8451;');
					$('#pd1-fat-1-humid').html(pd1_fat_1.humid + '&#37;');
				}

				if (pd1_fat_2.connect === "True") {
					$('li:nth-child(3)').addClass('warning-connection');
					$('li:nth-child(3) a').addClass('cd-img-replace-alarm').removeClass('cd-img-replace');
					$('#pd1-fat-2-temp').text('connection warning!');
					$('#pd1-fat-2-humid').html('');
				}
				else if (pd1_fat_2.standar === "True") {
					$('li:nth-child(3)').removeClass('warning-connection');
					$('li:nth-child(3)').addClass('open-point');
					$('li:nth-child(3) a').removeClass('cd-img-replace-alarm').addClass('cd-img-replace');
					// $('#pd1-fat-2-temp').html('');
					// $('#pd1-fat-2-humid').html('');
					$('#pd1-fat-2-temp').html(pd1_fat_2.temp + '&#8451;');
					$('#pd1-fat-2-humid').html(pd1_fat_2.humid + '&#37;');
				}
				else{
					$('li:nth-child(3) a').addClass('cd-img-replace-alarm').removeClass('cd-img-replace');
					$('li:nth-child(3)').removeClass('open-point');
					$('li:nth-child(3)').removeClass('warning-connection');
					$('#pd1-fat-2-temp').html(pd1_fat_2.temp + '&#8451;');
					$('#pd1-fat-2-humid').html(pd1_fat_2.humid + '&#37;');
				}

				if (pd1_spot.connect === "True") {
					$('li:nth-child(4)').addClass('warning-connection');
					$('li:nth-child(4) a').addClass('cd-img-replace-alarm').removeClass('cd-img-replace');
					$('#pd1-spot-temp').text('connection warning!');
					$('#pd1-spot-humid').html('');
				}
				else if (pd1_spot.standar === "True") {
					$('li:nth-child(4)').removeClass('warning-connection');
					$('li:nth-child(4)').addClass('open-point');
					$('li:nth-child(4) a').removeClass('cd-img-replace-alarm').addClass('cd-img-replace');
					// $('#pd1-spot-temp').html('');
					// $('#pd1-spot-humid').html('');
					$('#pd1-spot-temp').html(pd1_spot.temp + '&#8451;');
					$('#pd1-spot-humid').html(pd1_spot.humid + '&#37;');
				}
				else{
					$('li:nth-child(4) a').addClass('cd-img-replace-alarm').removeClass('cd-img-replace');
					$('li:nth-child(4)').removeClass('open-point');
					$('li:nth-child(4)').removeClass('warning-connection');
					$('#pd1-spot-temp').html(pd1_spot.temp + '&#8451;');
					$('#pd1-spot-humid').html(pd1_spot.humid + '&#37;');
				}

				if (pd1_print_1.connect === "True") {
					$('li:nth-child(7)').addClass('warning-connection');
					$('li:nth-child(7) a').addClass('cd-img-replace-alarm').removeClass('cd-img-replace');
					$('#pd1-print1-temp').text('connection warning!');
					$('#pd1-print1-humid').html('');
				}
				else if (pd1_print_1.standar === "True") {
					$('li:nth-child(7)').removeClass('warning-connection');
					$('li:nth-child(7)').addClass('open-point');
					$('li:nth-child(7) a').removeClass('cd-img-replace-alarm').addClass('cd-img-replace');
					// $('#pd1-print1-temp').html('');
					// $('#pd1-print1-humid').html('');
					$('#pd1-print1-temp').html(pd1_print_1.temp + '&#8451;');
					$('#pd1-print1-humid').html(pd1_print_1.humid + '&#37;');
				}
				else{
					$('li:nth-child(7) a').addClass('cd-img-replace-alarm').removeClass('cd-img-replace');
					$('li:nth-child(7)').removeClass('open-point');
					$('li:nth-child(7)').removeClass('warning-connection');
					$('#pd1-print1-temp').html(pd1_print_1.temp + '&#8451;');
					$('#pd1-print1-humid').html(pd1_print_1.humid + '&#37;');
				}

				if (pd1_print_2.connect === "True") {
					$('li:nth-child(8)').addClass('warning-connection');
					$('li:nth-child(8) a').addClass('cd-img-replace-alarm').removeClass('cd-img-replace');
					$('#pd1-print2-temp').text('connection warning!');
					$('#pd1-print2-humid').html('');
				}
				else if (pd1_print_2.standar === "True") {
					$('li:nth-child(8)').removeClass('warning-connection');
					$('li:nth-child(8)').addClass('open-point');
					$('li:nth-child(8) a').removeClass('cd-img-replace-alarm').addClass('cd-img-replace');
					// $('#pd1-print2-temp').html('');
					// $('#pd1-print2-humid').html('');
					$('#pd1-print2-temp').html(pd1_print_2.temp + '&#8451;');
					$('#pd1-print2-humid').html(pd1_print_2.humid + '&#37;');
				}
				else{
					$('li:nth-child(8) a').addClass('cd-img-replace-alarm').removeClass('cd-img-replace');
					$('li:nth-child(8)').removeClass('open-point');
					$('li:nth-child(8)').removeClass('warning-connection');
					$('#pd1-print2-temp').html(pd1_print_2.temp + '&#8451;');
					$('#pd1-print2-humid').html(pd1_print_2.humid + '&#37;');
				}

				if (pd1_print_3.connect === "True") {
					$('li:nth-child(9)').addClass('warning-connection');
					$('li:nth-child(9) a').addClass('cd-img-replace-alarm').removeClass('cd-img-replace');
					$('#pd1-print3-temp').text('connection warning!');
					$('#pd1-print3-humid').html('');
				}
				else if (pd1_print_3.standar === "True") {
					$('li:nth-child(9)').removeClass('warning-connection');
					$('li:nth-child(9)').addClass('open-point');
					$('li:nth-child(9) a').removeClass('cd-img-replace-alarm').addClass('cd-img-replace');
					// $('#pd1-print3-temp').html('');
					// $('#pd1-print3-humid').html('');
					$('#pd1-print3-temp').html(pd1_print_3.temp + '&#8451;');
					$('#pd1-print3-humid').html(pd1_print_3.humid + '&#37;');
				}
				else{
					$('li:nth-child(9) a').addClass('cd-img-replace-alarm').removeClass('cd-img-replace');
					$('li:nth-child(9)').removeClass('open-point');
					$('li:nth-child(9)').removeClass('warning-connection');
					$('#pd1-print3-temp').html(pd1_print_3.temp + '&#8451;');
					$('#pd1-print3-humid').html(pd1_print_3.humid + '&#37;');
				}

				if (pc12.connect === "True") {
					$('li:nth-child(15)').addClass('warning-connection');
					$('li:nth-child(15) a').addClass('cd-img-replace-alarm').removeClass('cd-img-replace');
					$('#pc12-temp').text('connection warning!');
					$('#pc12-humid').html('');
				}
				else if (pc12.standar === "True") {
					$('li:nth-child(15)').removeClass('warning-connection');
					$('li:nth-child(15)').addClass('open-point');
					$('li:nth-child(15) a').removeClass('cd-img-replace-alarm').addClass('cd-img-replace');
					// $('#pd1-print3-temp').html('');
					// $('#pd1-print3-humid').html('');
					$('#pc12-temp').html(pc12.temp + '&#8451;');
					$('#pc12-humid').html(pc12.humid + '&#37;');
				}
				else{
					$('li:nth-child(15) a').addClass('cd-img-replace-alarm').removeClass('cd-img-replace');
					$('li:nth-child(15)').removeClass('open-point');
					$('li:nth-child(15)').removeClass('warning-connection');
					$('#pc12-temp').html(pc12.temp + '&#8451;');
					$('#pc12-humid').html(pc12.humid + '&#37;');
				}

				if (fuji.connect === "True") {
					$('li:nth-child(16)').addClass('warning-connection');
					$('li:nth-child(16) a').addClass('cd-img-replace-alarm').removeClass('cd-img-replace');
					$('#fuji-temp').text('connection warning!');
					$('#fuji-humid').html('');
				}
				else if (fuji.standar === "True") {
					$('li:nth-child(16)').removeClass('warning-connection');
					$('li:nth-child(16)').addClass('open-point');
					$('li:nth-child(16) a').removeClass('cd-img-replace-alarm').addClass('cd-img-replace');
					// $('#pd1-print3-temp').html('');
					// $('#pd1-print3-humid').html('');
					$('#fuji-temp').html(fuji.temp + '&#8451;');
					$('#fuji-humid').html(fuji.humid + '&#37;');
				}
				else{
					$('li:nth-child(16) a').addClass('cd-img-replace-alarm').removeClass('cd-img-replace');
					$('li:nth-child(16)').removeClass('open-point');
					$('li:nth-child(16)').removeClass('warning-connection');
					$('#fuji-temp').html(fuji.temp + '&#8451;');
					$('#fuji-humid').html(fuji.humid + '&#37;');
				}
				if (se1.connect === "True") {
					$('li:nth-child(17)').addClass('warning-connection');
					$('li:nth-child(17) a').addClass('cd-img-replace-alarm').removeClass('cd-img-replace');
					$('#se1-temp').text('connection warning!');
					$('#se1-humid').html('');
				}
				else if (se1.standar === "True") {
					$('li:nth-child(17)').removeClass('warning-connection');
					$('li:nth-child(17)').addClass('open-point');
					$('li:nth-child(17) a').removeClass('cd-img-replace-alarm').addClass('cd-img-replace');
					// $('#pd1-print3-temp').html('');
					// $('#pd1-print3-humid').html('');
					$('#se1-temp').html(se1.temp + '&#8451;');
					$('#se1-humid').html(se1.humid + '&#37;');
				}
				else{
					$('li:nth-child(17) a').addClass('cd-img-replace-alarm').removeClass('cd-img-replace');
					$('li:nth-child(17)').removeClass('open-point');
					$('li:nth-child(17)').removeClass('warning-connection');
					$('#se1-temp').html(se1.temp + '&#8451;');
					$('#se1-humid').html(se1.humid + '&#37;');
				}

				if (se2.connect === "True") {
					$('li:nth-child(18)').addClass('warning-connection');
					$('li:nth-child(18) a').addClass('cd-img-replace-alarm').removeClass('cd-img-replace');
					$('#se2-temp').text('connection warning!');
					$('#se2-humid').html('');
				}
				else if (se2.standar === "True") {
					$('li:nth-child(18)').removeClass('warning-connection');
					$('li:nth-child(18)').addClass('open-point');
					$('li:nth-child(18) a').removeClass('cd-img-replace-alarm').addClass('cd-img-replace');
					// $('#pd1-print3-temp').html('');
					// $('#pd1-print3-humid').html('');
					$('#se2-temp').html(se2.temp + '&#8451;');
					$('#se2-humid').html(se2.humid + '&#37;');
				}
				else{
					$('li:nth-child(18) a').addClass('cd-img-replace-alarm').removeClass('cd-img-replace');
					$('li:nth-child(18)').removeClass('open-point');
					$('li:nth-child(18)').removeClass('warning-connection');
					$('#se2-temp').html(se2.temp + '&#8451;');
					$('#se2-humid').html(se2.humid + '&#37;');
				}

				if (se3.connect === "True") {
					$('li:nth-child(19)').addClass('warning-connection');
					$('li:nth-child(19) a').addClass('cd-img-replace-alarm').removeClass('cd-img-replace');
					$('#se3-temp').text('connection warning!');
					$('#se3-humid').html('');
				}
				else if (se3.standar === "True") {
					$('li:nth-child(19)').removeClass('warning-connection');
					$('li:nth-child(19)').addClass('open-point');
					$('li:nth-child(19) a').removeClass('cd-img-replace-alarm').addClass('cd-img-replace');
					// $('#pd1-print3-temp').html('');
					// $('#pd1-print3-humid').html('');
					$('#se3-temp').html(se3.temp + '&#8451;');
					$('#se3-humid').html(se3.humid + '&#37;');
				}
				else{
					$('li:nth-child(19) a').addClass('cd-img-replace-alarm').removeClass('cd-img-replace');
					$('li:nth-child(19)').removeClass('open-point');
					$('li:nth-child(19)').removeClass('warning-connection');
					$('#se3-temp').html(se3.temp + '&#8451;');
					$('#se3-humid').html(se3.humid + '&#37;');
				}

				if (se4.connect === "True") {
					$('li:nth-child(20)').addClass('warning-connection');
					$('li:nth-child(20) a').addClass('cd-img-replace-alarm').removeClass('cd-img-replace');
					$('#se4-temp').text('connection warning!');
					$('#se4-humid').html('');
				}
				else if (se4.standar === "True") {
					$('li:nth-child(20)').removeClass('warning-connection');
					$('li:nth-child(20)').addClass('open-point');
					$('li:nth-child(20) a').removeClass('cd-img-replace-alarm').addClass('cd-img-replace');
					// $('#pd1-print3-temp').html('');
					// $('#pd1-print3-humid').html('');
					$('#se4-temp').html(se4.temp + '&#8451;');
					$('#se4-humid').html(se4.humid + '&#37;');
				}
				else{
					$('li:nth-child(20) a').addClass('cd-img-replace-alarm').removeClass('cd-img-replace');
					$('li:nth-child(20)').removeClass('open-point');
					$('li:nth-child(20)').removeClass('warning-connection');
					$('#se4-temp').html(se4.temp + '&#8451;');
					$('#se4-humid').html(se4.humid + '&#37;');
				}

				if (se5.connect === "True") {
					$('li:nth-child(21)').addClass('warning-connection');
					$('li:nth-child(21) a').addClass('cd-img-replace-alarm').removeClass('cd-img-replace');
					$('#se5-temp').text('connection warning!');
					$('#se5-humid').html('');
				}
				else if (se5.standar === "True") {
					$('li:nth-child(21)').removeClass('warning-connection');
					$('li:nth-child(21)').addClass('open-point');
					$('li:nth-child(21) a').removeClass('cd-img-replace-alarm').addClass('cd-img-replace');
					// $('#pd1-print3-temp').html('');
					// $('#pd1-print3-humid').html('');
					$('#se5-temp').html(se5.temp + '&#8451;');
					$('#se5-humid').html(se5.humid + '&#37;');
				}
				else{
					$('li:nth-child(21) a').addClass('cd-img-replace-alarm').removeClass('cd-img-replace');
					$('li:nth-child(21)').removeClass('open-point');
					$('li:nth-child(21)').removeClass('warning-connection');
					$('#se5-temp').html(se5.temp + '&#8451;');
					$('#se5-humid').html(se5.humid + '&#37;');
				}

				if (se6.connect === "True") {
					$('li:nth-child(22)').addClass('warning-connection');
					$('li:nth-child(22) a').addClass('cd-img-replace-alarm').removeClass('cd-img-replace');
					$('#se6-temp').text('connection warning!');
					$('#se6-humid').html('');
				}
				else if (se6.standar === "True") {
					$('li:nth-child(22)').removeClass('warning-connection');
					$('li:nth-child(22)').addClass('open-point');
					$('li:nth-child(22) a').removeClass('cd-img-replace-alarm').addClass('cd-img-replace');
					// $('#pd1-print3-temp').html('');
					// $('#pd1-print3-humid').html('');
					$('#se6-temp').html(se6.temp + '&#8451;');
					$('#se6-humid').html(se6.humid + '&#37;');
				}
				else{
					$('li:nth-child(22) a').addClass('cd-img-replace-alarm').removeClass('cd-img-replace');
					$('li:nth-child(22)').removeClass('open-point');
					$('li:nth-child(22)').removeClass('warning-connection');
					$('#se6-temp').html(se6.temp + '&#8451;');
					$('#se6-humid').html(se6.humid + '&#37;');
				}
			}
		}
	}
	rawFile.send(null);
}