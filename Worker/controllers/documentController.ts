'use strict';

var express = require('express');
var router = express.Router();
var MongooseDocumentRepository = require('../models/repositories/mongooseDocumentRepository');
var DocumentModel = require('../models/documentModel');

module.exports = router;

router.get('/', indexAction);
router.get('/index', indexAction);
router.put('/', addDocumentAction);


function indexAction(req, res){
    var repo = new MongooseDocumentRepository();
    repo.getAll(function(err, documents) {
            if (err) {
                res.send(err);
            }

            res.json(documents);
        });
}

function addDocumentAction(req, res){
        var document = new DocumentModel(req.body.DocTypeId,
                                    req.body.DocNumber,
                                    req.body.PageCount,
                                    req.body.urlToImage,
                                    req.body.CreationDate);

        var repo = new MongooseDocumentRepository();

        repo.insert(null, function (err, doc) {
                                if (err) {
                                    // If it failed, return error
                                    res.send("There was a problem adding the information to the database.");
                                }
                                else {
                                    console.log("Your document successfully added!!");
                                    // And forward to success page
                                    res.redirect("/api/documents");
                                }
                            });
    }

