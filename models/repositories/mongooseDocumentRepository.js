'use strict';

var Document = require('../../models/document');
var mongoose = require('mongoose');
var Schema = mongoose.Schema;

var documentSchema = new Schema({  
  docTypeId: Number,
  docNumber: String,
  pageCount: Number,
  urlToImage: String,
  creationDate: Date
});

var documentModel = mongoose.model('Document', documentSchema);

class MongooseDocumentRepository{
    getAll(callback) {
        documentModel.find(function(err, documents) {
            if (err) {
                callback(err);
            }
            else{
            callback(null, documents);
            }
        });
    }

    insert(document, callback) {
        documentModel.collection.insertOne(document, function (err, insertedDocument) {
            if (err) {
                callback(err);
            }
            else {
                callback(null, insertedDocument);
            }
        });
    }
}

module.exports = MongooseDocumentRepository;