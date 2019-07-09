$( document ).ready(function() {
/////////////////////////////////////////////////////////////////////
// Change opacity on scroll
/////////////////////////////////////////////////////////////////////
$(function(){
    var fadeBegin = 100,
    fadeFinish = 750,
    fadingElement = $('header');

$(window).on('scroll', function(){
    var offset = $(document).scrollTop(), opacity = 0;
    if( offset <= fadeBegin ){
        opacity = 1;
    } else if( offset <= fadeFinish ){
        opacity = 1 - offset / fadeFinish;

    }
    fadingElement.stop().animate({opacity: opacity}, 200);
});
});
	
/////////////////////////////////////////////////////////////////////
// Date Picker
/////////////////////////////////////////////////////////////////////
//$(function () {
//  $("#datepicker").datepicker({
//        autoclose: true,
//        todayHighlight: true
//  }).datepicker('update', new Date());;
//});

/////////////////////////////////////////////////////////////////////
// Menu position on scroll
/////////////////////////////////////////////////////////////////////
$(window).scroll(function() {
    var scroll = $(window).scrollTop();

    if (scroll >= 100) {
        $(".navbar-default").addClass("navbar-fixed-top");
    } else {
        $(".navbar-default").removeClass("navbar-fixed-top");
    }
});

/////////////////////////////////////////////////////////////////////
// Animation on scroll
/////////////////////////////////////////////////////////////////////
var $animation_elements = $('.animated');
var $window = $(window);

//var animationType = $animation_elements.attr("data-animation");

function check_if_in_view() {
  var window_height = $window.height();
  var window_top_position = $window.scrollTop();
  var window_bottom_position = (window_top_position + window_height);

  $.each($animation_elements, function() {
    var $element = $(this);
    var element_height = $element.outerHeight();
    var element_top_position = $element.offset().top;
    var element_bottom_position = (element_top_position + element_height);
	var animationType = $(this).attr("data-animation");

    //check to see if this current container is within viewport
    if ((element_bottom_position >= window_top_position) &&
        (element_top_position <= window_bottom_position)) {
      $element.addClass(animationType);
    } else {
      $element.removeClass(animationType);
    }
  });
}

$window.on('scroll resize', check_if_in_view);
$window.trigger('scroll');

/////////////////////////////////////////////////////////////////////
// Scroll to top
/////////////////////////////////////////////////////////////////////
$(window).scroll(function() {
	if ($(this).scrollTop() > 100) {
		$('.scroll-top').fadeIn();
	} else {
		$('.scroll-top').fadeOut();
	}
});

	$('a[href="#totop"]').click(function() {
		$('html, body').animate({ scrollTop: 0 }, 'slow');
		return false;
});

/////////////////////////////////////////////////////////////////////
// Counter
/////////////////////////////////////////////////////////////////////
$(function() {
$('.stats-box').each(function(i) {
			$(this).appear(function() {
				var stats = $(this).find('h3').text();
				$(this).find('h3').countTo({from: 0, to: stats, speed: 2400, refreshInterval: 30});
			});
		});
});

/////////////////////////////////////////////////////////////////////
// Contact
/////////////////////////////////////////////////////////////////////
// Function for check if email valid
function isValidEmailAddress(emailAddress) {
    var pattern = /^([a-z\d!#$%&'*+\-\/=?^_`{|}~\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]+(\.[a-z\d!#$%&'*+\-\/=?^_`{|}~\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]+)*|"((([ \t]*\r\n)?[ \t]+)?([\x01-\x08\x0b\x0c\x0e-\x1f\x7f\x21\x23-\x5b\x5d-\x7e\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]|\\[\x01-\x09\x0b\x0c\x0d-\x7f\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))*(([ \t]*\r\n)?[ \t]+)?")@(([a-z\d\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]|[a-z\d\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF][a-z\d\-._~\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]*[a-z\d\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])\.)+([a-z\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]|[a-z\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF][a-z\d\-._~\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]*[a-z\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])\.?$/i;
    return pattern.test(emailAddress);
}
 
// Contact Form
$("#contactFormBtn").on('click', function(event){
    // cancels the form submission
    event.preventDefault();
    $('.error').hide();
    submitForm();
});

function submitForm(){
    // Initiate Variables With Form Content
    var name = $("#name").val();
    var email = $("#email").val();
    var message = $("#message").val();

    function isEmpty(str) {
        return (!str || 0 === str.length);
    }

    function validate() {
        var status;

        if(isEmpty(email) || !isValidEmailAddress(email)) {
            $('#email').after('<span class="error">Wrong input.</span>');
            status = false;
        }

        if(isEmpty(name)) {
            $('#name').after('<span class="error">Wrong input.</span>');
            status = false;
        }

        if(isEmpty(message)) {
            $('#message').after('<span class="error">Wrong input.</span>');
            status = false;
        }

        if(status === false) {
            return false;
        } else {
            return true;
        }
    }

    if(validate()) {
        $.ajax({
            type: "POST",
            url: "mail.php",
            data: "name=" + name + "&email=" + email + "&message=" + message,
            success : function(text){
                if (text == "success"){
                    formSuccess();
                } else {
                    formError();
                }
            }
        });
    }
}

// If Successed
var name = $('#name');
function formSuccess(){
    name.before('<p class="message-sent">Message sent successfully!</p>');
    $('.message-sent').delay(5000).fadeOut('slow');
}

// If Failed
function formError(){
    name.before('<p class="message-not-sent">Message not sent!</p>');
    $('.message-not-sent').delay(5000).fadeOut('slow');
}

// Show mail on click
var showMail = $('.show-mail');
var myMail = $('.my-mail');

showMail.on('click', function(e) {
    e.preventDefault();
    myMail.slideToggle();
});


/////////////////////////////////////////////////////////////////////
// Slider
/////////////////////////////////////////////////////////////////////
(function( $ ) {

    //Function to animate slider captions
	function doAnimations( elems ) {
		//Cache the animationend event in a variable
		var animEndEv = 'webkitAnimationEnd animationend';

		elems.each(function () {
			var $this = $(this),
				$animationType = $this.data('animation');
			$this.addClass($animationType).one(animEndEv, function () {
				$this.removeClass($animationType);
			});
		});
	}

	//Variables on page load
	var $myCarousel = $('#carousel-example-generic'),
		$firstAnimatingElems = $myCarousel.find('.item:first').find("[data-animation ^= 'animated']");

	//Initialize carousel
	$myCarousel.carousel();

	//Animate captions in first slide on page load
	doAnimations($firstAnimatingElems);

	//Pause carousel
	$myCarousel.carousel('pause');


	//Other slides to be animated on carousel slide event
	$myCarousel.on('slide.bs.carousel', function (e) {
		var $animatingElems = $(e.relatedTarget).find("[data-animation ^= 'animated']");
		doAnimations($animatingElems);
	});
    $('#carousel-example-generic').carousel({
        interval:3000,
        pause: "false"
    });

})(jQuery);
}); // Document ready
