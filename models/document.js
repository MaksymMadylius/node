'use strict';

class Document{
  constructor(docTypeId, docNumber, pageCount, urlToImage, creationDate){
    this.docTypeId = docTypeId;
    this.docNumber = docNumber;
    this.pageCount = pageCount;
    this.urlToImage = urlToImage;
    this.creationDate = creationDate;
  }

  get docTypeId(){
    return this.docTypeId;
  }

  get docNumber(){
    return this.docNumber;
  }

  get pageCount(){
    return this.pageCount;
  }

  get urlToImage(){
    return this.urlToImage;
  }

  get creationDate(){
    return this.creationDate;
  }
}

module.exports = Document;