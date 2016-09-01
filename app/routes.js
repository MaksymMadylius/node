var Document = require('./models/document');

module.exports = function(app) {    
    app.get('/api/documents', function(req, res) {        
        Document.find(function(err, documents) {
            if (err) {
                res.send(err);
            }

            res.json(documents);
        });
    });
};