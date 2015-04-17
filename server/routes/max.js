var express = require('express');
var router = express.Router();

var osc = require('node-osc');
var singleMidiClient = new osc.Client('127.0.0.1', 8085);
var midiClient = new osc.Client('127.0.0.1', 8086);
var channelClient = new osc.Client('127.0.0.1', 8087);

router.post('/channel', function(req, res) {

    channelClient.send(req.body.channel);
    res.sendStatus(200);
});

router.post('/single_midi', function(req, res) {
    console.log("Posting " + req.body.theText)
    singleMidiClient.send(req.body.theText);
    res.sendStatus(200);
});

router.post('/midi', function(req, res) {
    console.log(JSON.stringify(req.body));
    var noteParams = req.body.midi_value + " " + req.body.velocity + " " + req.body.duration;
    midiClient.send(noteParams);
    res.send({status: 200, params: noteParams});
});

module.exports = router;
