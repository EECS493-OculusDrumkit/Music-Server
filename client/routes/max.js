var express = require('express');
var router = express.Router();

var osc = require('node-osc');
var midiClient = new osc.Client('127.0.0.1', 8086);

router.post('/tempo', function(req, res) {

    tempoClient.send(req.body.theText);
    res.sendStatus(200);
});

router.post('/other', function(req, res) {

    otherClient.send(req.body.theText);
    res.sendStatus(200);
});

router.post('/vocoder', function(req, res) {

    vocoderClient.send(req.session.name + ":" + req.body.theText);
    res.sendStatus(200);
});

router.post('/midi', function(req, res) {
    console.log("Posting " + req.body.theText)
    midiClient.send(req.body.theText);
    res.sendStatus(200);
});

module.exports = router;
