var express = require('express');
var router = express.Router();

/* GET home page. */
router.get('/', function(req, res) {
    console.log("Uh");
    res.render('index', {
        title: 'Max Live',
    });
});

router.get('/crossdomain.xml', function(req, res) {
    res.header('Content-Type','text/xml').send('<?xml version="1.0" ?><cross-domain-policy><allow-access-from domain="*" /></cross-domain-policy>');
});

module.exports = router;
