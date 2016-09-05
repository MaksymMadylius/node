var mongoose = require('mongoose');

var Schema = mongoose.Schema;

var documentSchema = new Schema({  
  DocTypeId: Number,
  DocNumber: String,
  PageCount: Number,
  urlToImage: String,
  CreationDate: Date
});

module.exports = mongoose.model('Document', documentSchema);