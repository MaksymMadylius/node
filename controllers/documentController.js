'use strict';

var express = require('express');
var router = express.Router();
var Document = require('../models/document');
var DocumentRepository = require('../models/repositories/mongooseDocumentRepository.js');

module.exports = router;

router.get('/', indexAction);
router.get('/index', indexAction);
router.put('/', addDocumentAction);


function indexAction(req, res){
    var repo = new DocumentRepository();
    repo.getAll(function(err, documents) {
            if (err) {
                res.send(err);
            }

            res.json(documents);
        });
}

function addDocumentAction(req, res){
    // Get our form values. These rely on the "name" attributes
        var document = new Document(req.body.DocTypeId,
                                    req.body.DocNumber,
                                    req.body.PageCount,
                                    req.body.urlToImage,
                                    req.body.CreationDate);

        var repo = new DocumentRepository();

        repo.insert(document, function (err, doc) {
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

