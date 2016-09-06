// modules =================================================

var express = require('express');

var bodyParser = require('body-parser');
var mongoose = require('mongoose');
var DbConfig = require('./config/db');
var Routes = require('./app_start/routes');

// configuration ===========================================
var app = express();
// configure the app to use bodyParser()
app.use(bodyParser.urlencoded({
    extended: true
}));
app.use(bodyParser.json());


var port = 8080;

mongoose.connect(DbConfig.url); 

// routes ==================================================
Routes.registerRoutes(app);

// start app ===============================================
app.listen(port);

// shoutout to the user                     
console.log('Magic happens on port ' + port);