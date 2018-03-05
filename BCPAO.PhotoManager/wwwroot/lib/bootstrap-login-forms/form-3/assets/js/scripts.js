
jQuery(document).ready(function() {
	
	/*
	    Navigation (toggle "navbar-no-bg" class)
	*/
	$('.l-form-3').waypoint(function() {
		$('nav').toggleClass('navbar-no-bg');
	});
	
    /*
        Background slideshow
    */
    $('.l-form-3-container').backstretch("assets/img/backgrounds/1.jpg");
    
    /*
        Wow
    */
    new WOW().init();
    
    /*
	    Form validation
	*/
	$('.l-form-3-box input[type="text"], .l-form-3-box input[type="password"], .l-form-3-box textarea').on('focus', function() {
		$(this).removeClass('input-error');
	});
	
	$('.l-form-3-box form').on('submit', function(e) {
		
		$(this).find('input[type="text"], input[type="password"], textarea').each(function(){
			if( $(this).val() == "" ) {
				e.preventDefault();
				$(this).addClass('input-error');
			}
			else {
				$(this).removeClass('input-error');
			}
		});
		
	});
	
});
