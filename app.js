// modules =================================================
var express        = require('express');
var app            = express();
var bodyParser     = require('body-parser');
var methodOverride = require('method-override');
var mongoose       = require('mongoose');

// configuration ===========================================
// configure the app to use bodyParser()
app.use(bodyParser.urlencoded({
    extended: true
}));
app.use(bodyParser.json());

var db = require('./config/db');


var port = 8080;

mongoose.connect(db.url); 

// routes ==================================================
require('./app/routes')(app);

// start app ===============================================
app.listen(port);

// shoutout to the user                     
console.log('Magic happens on port ' + port);

// expose app           
exports = module.exports = app;