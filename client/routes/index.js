var express = require('express');
var router = express.Router();

/* GET home page. */
router.get('/', function(req, res) {
    console.log("Uh");
    res.render('index', {
        title: 'Max Live',
    });
});

module.exports = router;
