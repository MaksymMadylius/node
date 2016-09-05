var documentController = require('../controllers/documentController.js');

module.exports = function(app) {    
    app.use('/document', documentController);
};