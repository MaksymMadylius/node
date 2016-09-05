var express = require('express');
var router = express.Router();
var Document = require('../models/document');

module.exports = router;

router.get('/', indexAction);
router.get('/index', indexAction);

function indexAction(req, res){
    Document.find(function(err, documents) {
            if (err) {
                res.send(err);
            }

            res.json(documents);
        });
}

function addDocumentAction(req, res){
    // Get our form values. These rely on the "name" attributes
        var DocTypeId = req.body.DocTypeId
        var DocNumber = req.body.DocNumber
        var PageCount = req.body.PageCount
        var urlToImage = req.body.urlToImage
        var CreationDate = req.body.CreationDate

        // Submit to the DB
        Document.collection.insertOne({
            'DocTypeId': DocTypeId,
            'DocNumber': DocNumber,
            'PageCount': PageCount,
            'urlToImage': urlToImage,
            'CreationDate': CreationDate
        }, function (err, doc) {
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

