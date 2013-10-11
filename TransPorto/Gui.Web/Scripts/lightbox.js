$(document).ready(function() {
    $('.teste').click(function() {
        $('.divtransparente').css('display', 'block').animate({ opacity: 0.7 }).show('slow');
        $('.divconteudo').css('display', 'block').slow('slow');
    });

    $('.divtransparente').click(function() {
        $(this).css('display', 'none').hide('slow');
        $('.divconteudo').css('display','none').hide('slow');
    });
});