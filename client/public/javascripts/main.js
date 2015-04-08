$(document).ready(function() {

    $(".circle").click(function() {
        var classname = $(this).attr('class').split(' ')[1];
        var circleNum = classname.split('-')[1];
        console.log(circleNum);
        circleNumToMidi(circleNum);
    });

    function circleNumToMidi(circleNum) {
        var midiNote = 0;
        if (circleNum == 1) {
            midiNote = 56;
        } else if (circleNum == 2) {
            midiNote = 46;
        } else if (circleNum == 3) {
            midiNote = 49;
        } else if (circleNum == 4) {
            midiNote = 40;
        } else if (circleNum == 5) {
            midiNote = 35;
        } else if (circleNum == 6) {
            midiNote = 48;
        } else {
            return;
        }
        $.post("/max/single_midi", {theText: midiNote});
    }

    $(document).keypress(function(event){
        var keycode = (event.keyCode ? event.keyCode : event.which);
        console.log("KEYCODE: " + keycode);

        if (keycode == 97) {
            circleNumToMidi(1);
        } else if (keycode == 114) {
            circleNumToMidi(2);
        } else if (keycode == 112) {
            circleNumToMidi(3);
        } else if (keycode == 100) {
            circleNumToMidi(4);
        } else if (keycode == 98 || keycode == 118 || keycode == 99) {
            circleNumToMidi(5);
        } else if (keycode == 106) {
            circleNumToMidi(6);
        }
    });

});