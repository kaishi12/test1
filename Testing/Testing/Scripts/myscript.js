
$(document).ready(function(){

	$('.menu_xs_sm').click(function () {
    	$('#categories').css("display", "block");
	});

	$('.mobile_menu i').click(function () {
		$(this).parent().parent().find("ul").slideUp(300);
	    $(this).parent().parent().find("i").removeClass("fa-minus-circle").addClass("fa-plus-circle");

		if($(this).parent().find("ul").first().is(':visible')){
	    	$(this).parent().find("ul").first().slideUp(300);
	    	$(this).removeClass("fa-minus-circle").addClass("fa-plus-circle");
	    }else{
			$(this).parent().find("ul").first().slideDown(300);
			$(this).removeClass("fa-plus-circle").addClass("fa-minus-circle");
	    }
	});

	$(".closes").click(function(){

		$('#categories').css("display", "none");
	});


	$('.toptoptop').click(function () {    
	    $('body,html').animate({
	        scrollTop: 0
	    }, 800);
	    return false;
	});

	$(".dropdown_language").click(function(){
		if($(this).parent().find(".dropdown_menu").css("display") == "block"){
			$(this).parent().find(".dropdown_menu").slideUp(500);
		}
		else{
			$(this).parent().find(".dropdown_menu").slideDown(500);
		}
	});

	$(".manga_slide_container").owlCarousel({
		itemsCustom : [
			[0, 1],
			[350, 2],
			[550, 3],
			[768, 4],
			[991, 5]
		], 
		autoPlay: 5000,
	}); 

	$('.next_prev_sphighlight .fa-angle-left').click(function () {
		$(".manga_slide_container").trigger('owl.prev');
		return false;
	});
	$('.next_prev_sphighlight .fa-angle-right').click(function () {
		$(".manga_slide_container").trigger('owl.next');
		return false;
	});

	$(".zoom_img").change(function(){
		var size = $(this).val();
		switch(size) {
		    case "1":
		        $(".list_img img").css("width", "100%");
		        break;
		    case "2":
		        $(".list_img img").css("width", "80%");
		        break;
		    case "3":
		        $(".list_img img").css("width", "60%");
		        break;
		    case "4":
		        $(".list_img img").css("width", "40%");
		        break;
		    default:
		        $(".list_img img").css("width", "80%");
		}
	});

	// $(".remove i").click(function(){
	// 	$(this).append().append().append().append().append().find(".content_grid_item").css("display", "none");
	// })
});
